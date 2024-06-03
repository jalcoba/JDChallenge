using JDChallenge.Domain.Entities;

namespace JDChallenge.Services.Interfaces
{
    public interface IEmployeesService
    {
        public Task<IEnumerable<Employee>> Get();
        public Task<Employee?> Get(long id);
        public Task<Employee> Add(Employee request);
        public Task<Employee> Update(Employee request);
    }
}
