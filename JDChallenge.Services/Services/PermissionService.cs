using JDChallenge.DataAccess.Interfaces;
using JDChallenge.Domain.Entities;
using JDChallenge.Services.Interfaces;
using JDChallenge.Services.Services.KafkaMessages;

namespace JDChallenge.Services.Services;

public class PermissionService : IPermissionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IElasticsearchService _elasticsearchService;
    private readonly IKafkaProducer _kafka;

    public PermissionService(IUnitOfWork unitOfWork, IElasticsearchService elasticsearchService, IKafkaProducer kafka)
    {
        _unitOfWork = unitOfWork;
        _elasticsearchService = elasticsearchService;
        _kafka = kafka;
    }

    public async Task<IEnumerable<Permission>> Get()
    {
        var data = await _unitOfWork.PermissionRepository.GetAll();
        await _kafka.Publish(new OperationMessage(OperationType.get));
        return data;
    }

    public async Task<Permission?> Get(long id)
    {
        var data = await _unitOfWork.PermissionRepository.Get(x => x.Id == id);
        await _kafka.Publish(new OperationMessage(OperationType.get));
        return data;
    }

    public async Task<Permission> Add(Permission request)
    {
        var data = await _unitOfWork.PermissionRepository.Add(request);
        await _unitOfWork.Save();
        await _elasticsearchService.IndexDocument(data, data.Id.ToString());
        await _kafka.Publish(new OperationMessage(OperationType.request));
        return data;
    }

    public async Task<Permission> Update(Permission request)
    {
        var data = _unitOfWork.PermissionRepository.Update(request);
        await _unitOfWork.Save();
        await _elasticsearchService.IndexDocument(data, data.Id.ToString());
        await _kafka.Publish(new OperationMessage(OperationType.modify));
        return data;
    }
}
