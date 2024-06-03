using AutoMapper;
using JDChallenge.Business.Permissions.Commands;
using JDChallenge.Business.Permissions.Querys;
using JDChallenge.Domain.Entities;
using JDChallenge.Services.Interfaces;
using MediatR;

namespace JDChallenge.Business.Permissions;

public class PermissionHandler :
    IRequestHandler<GetPermissions, IEnumerable<Permission>>,
    IRequestHandler<CreatePermission, Permission>, 
    IRequestHandler<UpdatePermission, Permission>

{
    private readonly IMapper _mapper;
    private readonly IPermissionService _service;

    public PermissionHandler(IMapper mapper, IPermissionService service)
    {
        _mapper = mapper;
        _service = service;
    }

    public async Task<IEnumerable<Permission>> Handle(GetPermissions request, CancellationToken cancellationToken)
    {
        return await _service.Get();
    }

    public async Task<Permission> Handle(CreatePermission request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Permission>(request);
        return await _service.Add(data);
    }

    public async Task<Permission> Handle(UpdatePermission request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Permission>(request);
        return await _service.Update(data);
    }
}

