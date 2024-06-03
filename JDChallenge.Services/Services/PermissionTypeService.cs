using JDChallenge.DataAccess.Interfaces;
using JDChallenge.Domain.Entities;
using JDChallenge.Services.Interfaces;

namespace JDChallenge.Services.Services;

public class PermissionTypeService : IPermissionTypeService
{
    private readonly IUnitOfWork _unitOfWork;

    public PermissionTypeService(IUnitOfWork unitOfWork, IElasticsearchService elasticsearchService, IKafkaProducer kafka)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PermissionType>> Get()
    {
        var data = await _unitOfWork.PermissionTypeRepository.GetAll();
        return data;
    }

    public async Task<PermissionType?> Get(long id)
    {
        var data = await _unitOfWork.PermissionTypeRepository.Get(x => x.Id == id);
        return data;
    }

    public async Task<PermissionType> Add(PermissionType request)
    {
        var data = await _unitOfWork.PermissionTypeRepository.Add(request);
        await _unitOfWork.Save();
        return data;
    }

    public async Task<PermissionType> Update(PermissionType request)
    {
        var data = _unitOfWork.PermissionTypeRepository.Update(request);
        await _unitOfWork.Save();
        return data;
    }
}
