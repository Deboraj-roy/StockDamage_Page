using System.ComponentModel.DataAnnotations;

namespace StockDamage.Web.Models
{
    public class Godown
    {
        [Key]
        public long AutoSlNo { get; set; }
        public string GodownNo { get; set; } = null!;
        public string GodownName { get; set; } = null!;
        public DateTime? EntryDate { get; set; }
    }
}
