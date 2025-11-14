using System.ComponentModel.DataAnnotations;
namespace StockDamage.Web.Models
{
    public class Currency
    {
        [Key]
        public long CurrencyId { get; set; }
        public string CurrencyName { get; set; } = null!;
        public decimal ConversionRate { get; set; }
    }
}
