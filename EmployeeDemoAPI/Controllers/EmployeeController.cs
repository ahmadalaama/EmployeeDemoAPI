using EmployeeDemoAPI.Data;
using EmployeeDemoAPI.Model.Personnel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext dbContext;

        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            dbContext = employeeDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var employees = await dbContext.Employees.ToListAsync();

                return Ok(employees);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        [HttpGet("{id:long}")]
        //oute("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            try
            {
                var employee = await dbContext.Employees.FindAsync(id);

                return Ok(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Employee employee)
        {
            try
            {
                await dbContext.Employees.AddAsync(employee);
                await dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = employee.EmployeeID }, employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        [HttpPut("{id:long}")]
        //[Route("{id:long}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] Employee employee)
        {
            try
            {
                if (employee is null)
                {
                    return NotFound();
                }
                dbContext.Entry(employee).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return Ok(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
