using System.ComponentModel.DataAnnotations;
namespace StockDamage.Web.Models
{
    public class StockDamage
    {
        [Key]
        public long AutoSlNo { get; set; }
        public long VoucherNo { get; set; }
        public DateTime EntryDate { get; set; }
        public long GodownAutoSlNo { get; set; }
        public long SubItemAutoSlNo { get; set; }
        public string BatchNo { get; set; } = "N/A";
        public string CurrencyName { get; set; } = null!;
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal AmountIn { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal AmountBDT { get; set; }
        public string DrACHead { get; set; } = "Stock Damage";
        public long? EmployeeID { get; set; }
        public string? Comments { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}
