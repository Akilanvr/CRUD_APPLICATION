using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SimpleCrudApi.Data;
using SimpleCrudApi.Models;

namespace SimpleCrudApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _db;
        public EmployeeService(AppDbContext db) => _db = db;

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _db.Employees.FromSqlRaw("EXEC spGetAllEmployees").ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            var p = new SqlParameter("@Id", id);
            return await _db.Employees
                .FromSqlRaw("EXEC spGetEmployeeById @Id", p)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Employee emp)
        {
            await _db.Database.ExecuteSqlRawAsync(
                "EXEC spAddEmployee @Name, @Position, @Salary",
                new SqlParameter("@Name", emp.Name ?? string.Empty),
                new SqlParameter("@Position", emp.Position ?? string.Empty),
                new SqlParameter("@Salary", emp.Salary));
        }

        public async Task UpdateAsync(int id, Employee emp)
        {
            await _db.Database.ExecuteSqlRawAsync(
                "EXEC spUpdateEmployee @Id, @Name, @Position, @Salary",
                new SqlParameter("@Id", id),
                new SqlParameter("@Name", emp.Name ?? string.Empty),
                new SqlParameter("@Position", emp.Position ?? string.Empty),
                new SqlParameter("@Salary", emp.Salary));
        }

        public async Task DeleteAsync(int id)
        {
            await _db.Database.ExecuteSqlRawAsync(
                "EXEC spDeleteEmployee @Id",
                new SqlParameter("@Id", id));
        }
    }
}
