using SimpleCrudApi.Models;

namespace SimpleCrudApi.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task CreateAsync(Employee emp);
        Task UpdateAsync(int id, Employee emp);
        Task DeleteAsync(int id);
    }
}
