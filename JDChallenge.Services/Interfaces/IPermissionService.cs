using JDChallenge.Domain.Entities;

namespace JDChallenge.Services.Interfaces
{
    public interface IPermissionService
    {
        public Task<IEnumerable<Permission>> Get();

        public Task<Permission?> Get(long id);

        public Task<Permission> Add(Permission request);

        public Task<Permission> Update(Permission request);
    }
}
