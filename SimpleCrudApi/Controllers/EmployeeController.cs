using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SimpleCrudApi.Data;
using SimpleCrudApi.Models;

namespace SimpleCrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _db;

        public EmployeeController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            return await _db.Employees.FromSqlRaw("EXEC spGetAllEmployees").ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var param = new SqlParameter("@Id", id);
            var employee = await _db.Employees.FromSqlRaw("EXEC spGetEmployeeById @Id", param).FirstOrDefaultAsync();
            if (employee == null) return NotFound();
            return employee;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Employee emp)
        {
            await _db.Database.ExecuteSqlRawAsync("EXEC spAddEmployee @Name, @Position, @Salary",
                new SqlParameter("@Name", emp.Name),
                new SqlParameter("@Position", emp.Position),
                new SqlParameter("@Salary", emp.Salary));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Employee emp)
        {
            await _db.Database.ExecuteSqlRawAsync("EXEC spUpdateEmployee @Id, @Name, @Position, @Salary",
                new SqlParameter("@Id", id),
                new SqlParameter("@Name", emp.Name),
                new SqlParameter("@Position", emp.Position),
                new SqlParameter("@Salary", emp.Salary));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _db.Database.ExecuteSqlRawAsync("EXEC spDeleteEmployee @Id",
                new SqlParameter("@Id", id));
            return NoContent();
        }
    }
}