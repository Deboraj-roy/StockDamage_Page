using System.ComponentModel.DataAnnotations;
namespace StockDamage.Web.Models
{
    public class SubItemCode
    {
        [Key]
        public long AutoSlNo { get; set; }
        public string SubItemCodeValue { get; set; } = null!; // DB column SubItemCode
        public string SubItemName { get; set; } = null!;
        public string Unit { get; set; } = null!;
        public decimal? Weight { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}
