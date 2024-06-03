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

    public async Task<Permission> Add(Permission request)
    {
        var inserted = await _unitOfWork.PermissionRepository.Add(request);
        await _unitOfWork.Save();
        var data = await _unitOfWork.PermissionRepository.Get(p => p.Id == inserted.Id);
        ArgumentNullException.ThrowIfNull(data);
        await _elasticsearchService.IndexDocument(data, data.Id.ToString());
        await _kafka.Publish(new OperationMessage(OperationType.request));
        return data;
    }

    public async Task<Permission> Update(Permission request)
    {
        var dataRequest = await _unitOfWork.PermissionRepository.Get(p => p.Id == request.Id);
        ArgumentNullException.ThrowIfNull(dataRequest);
        dataRequest.ValidFrom = request.ValidFrom;
        dataRequest.ValidUntil = request.ValidUntil;
        var data = _unitOfWork.PermissionRepository.Update(dataRequest);
        await _unitOfWork.Save();
        await _elasticsearchService.IndexDocument(data, data.Id.ToString());
        await _kafka.Publish(new OperationMessage(OperationType.modify));
        return data;
    }
}
