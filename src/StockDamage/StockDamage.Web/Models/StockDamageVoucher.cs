using System.ComponentModel.DataAnnotations;
namespace StockDamage.Web.Models
{
    public class StockDamageVoucher
    {
        [Key]
        public long VoucherNo { get; set; }
        public DateTime VoucherDate { get; set; }
        public string DrACHead { get; set; } = null!;
        public long? EmployeeID { get; set; }
        public string? Comments { get; set; }
    }
}
