using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDemoAPI.Model.Personnel
{
    [Table("Personnel.Employee")]
    public class Employee
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeID { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
