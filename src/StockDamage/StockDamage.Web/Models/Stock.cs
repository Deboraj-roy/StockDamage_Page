using System.ComponentModel.DataAnnotations;
namespace StockDamage.Web.Models
{
    public class Stock
    {
        [Key]
        public long AutoSlNo { get; set; }
        public long GodownAutoSlNo { get; set; }
        public long SubItemAutoSlNo { get; set; }
        public decimal Quantity { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}
