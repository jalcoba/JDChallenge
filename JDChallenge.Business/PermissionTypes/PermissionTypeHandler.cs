using AutoMapper;
using JDChallenge.Business.PermissionTypes.Commands;
using JDChallenge.Business.PermissionTypes.Querys;
using JDChallenge.Domain.Entities;
using JDChallenge.Services.Interfaces;
using MediatR;

namespace JDChallenge.Business.PermissionTypes;

public class PermissionTypeHandler :
    IRequestHandler<GetPermissionTypes, IEnumerable<PermissionType>>,
    IRequestHandler<CreatePermissionType, PermissionType>, 
    IRequestHandler<UpdatePermissionType, PermissionType>

{
    private readonly IMapper _mapper;
    private readonly IPermissionTypeService _service;

    public PermissionTypeHandler(IMapper mapper, IPermissionTypeService service)
    {
        _mapper = mapper;
        _service = service;
    }

    public async Task<IEnumerable<PermissionType>> Handle(GetPermissionTypes request, CancellationToken cancellationToken)
    {
        return await _service.Get();
    }

    public async Task<PermissionType> Handle(CreatePermissionType request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<PermissionType>(request);
        return await _service.Add(data);
    }

    public async Task<PermissionType> Handle(UpdatePermissionType request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<PermissionType>(request);
        return await _service.Update(data);
    }
}

