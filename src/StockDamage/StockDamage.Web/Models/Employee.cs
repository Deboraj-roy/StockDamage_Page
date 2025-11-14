using System.ComponentModel.DataAnnotations;
namespace StockDamage.Web.Models
{
    public class Employee
    {
        [Key]
        public long EmployeeID { get; set; }
        public string EmployeeName { get; set; } = null!;
    }
}
