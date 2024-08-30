using EmployeeDemoAPI.Model.Personnel;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDemoAPI.Data;

public class EmployeeDbContext:DbContext
{
    public EmployeeDbContext(DbContextOptions contextOptions):base(contextOptions)
    {
            
    }

    public DbSet<Employee> Employees { get; set; }
}