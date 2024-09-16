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

        [HttpGet("{id:long}")]
        //oute("{id:long}")]
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

        [HttpPost]
        public IActionResult Add([FromBody] Employee employee)
        {
            try
            {
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = employee.EmployeeID },employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        [HttpPut("{id:long}")]
        //[Route("{id:long}")]
        public IActionResult Update([FromRoute] long id,[FromBody] Employee employee)
        {
            try
            {
                if (employee is null)
                {
                    return NotFound();
                }
                dbContext.Entry(employee).State = EntityState.Modified;
                dbContext.SaveChanges();
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
