using Microsoft.AspNetCore.Mvc;
using SimpleCrudApi.Models;
using SimpleCrudApi.Services;

namespace SimpleCrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _svc;
        public EmployeeController(IEmployeeService svc) => _svc = svc;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            var list = await _svc.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var emp = await _svc.GetByIdAsync(id);
            if (emp == null) return NotFound(new { message = $"Employee {id} not found" });
            return Ok(emp);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Employee emp)
        {
            if (emp == null) return BadRequest();
            await _svc.CreateAsync(emp);
            return Ok(new { message = "Created" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Employee emp)
        {
            if (emp == null) return BadRequest();
            await _svc.UpdateAsync(id, emp);
            return Ok(new { message = "Updated" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _svc.DeleteAsync(id);
            return Ok(new { message = "Deleted" });
        }
    }
}
