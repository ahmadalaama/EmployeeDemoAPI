using EmployeeDemoAPI.Data;
using EmployeeDemoAPI.Model.Personnel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            try
            {
                var employees = dbContext.Employees.ToList();

                return Ok(employees);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        [HttpGet]
        [Route("{id:long}")]
        public IActionResult GetById([FromRoute] long id)
        {
            try
            {
                var employee = dbContext.Employees.Find(id);
                if (employee is null)
                {
                    return NotFound();
                }

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
