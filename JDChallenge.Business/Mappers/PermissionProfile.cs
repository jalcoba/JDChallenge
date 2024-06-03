using AutoMapper;
using JDChallenge.Business.Permissions.Commands;
using JDChallenge.Domain.Entities;

namespace JDChallenge.Business.Mappers;

public class PermissionProfile : Profile
{
    public PermissionProfile()
    {
        CreateMap<CreatePermission, Permission>();
        CreateMap<UpdatePermission, Permission>();
    }
}
