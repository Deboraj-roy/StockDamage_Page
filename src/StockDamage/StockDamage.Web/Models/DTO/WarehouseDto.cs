namespace StockDamage.Web.Models.DTO
{
    public class WarehouseDto
    {
        public long AutoSlNo { get; set; }
        public string GodownName { get; set; } = null!;
    }

    public class ItemDto
    {
        public long AutoSlNo { get; set; }
        public string SubItemName { get; set; } = null!;
        public string SubItemCode { get; set; } = null!;
        public string Unit { get; set; } = null!;
    }

    public class CurrencyDto
    {
        public string CurrencyName { get; set; } = null!;
        public decimal ConversionRate { get; set; }
    }

    public class EmployeeDto
    {
        public long EmployeeID { get; set; }
        public string EmployeeName { get; set; } = null!;
    }

    public class StockDto
    {
        public decimal Quantity { get; set; }
    }

    public class StockDamageLineDto
    {
        public long GodownAutoSlNo { get; set; }
        public long SubItemAutoSlNo { get; set; }
        public string BatchNo { get; set; } = "NA";
        public long Currency { get; set; } 
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal AmountIn { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal AmountBDT { get; set; }

        public long AutoSlNo { get; set; }
        public long StockDamageId { get; set; }
    }

    public class StockDamageSaveRequest
    {
        public DateTime Date { get; set; }
        public long? EmployeeID { get; set; }
        public string? Comments { get; set; }
        public List<StockDamageLineDto> Lines { get; set; } = new();

        public long AutoSlNo { get; set; }   
        public string VoucherNo { get; set; } = ""; 

    }

    public class StockDamage
    {
        public long AutoSlNo { get; set; }
        public DateTime Date { get; set; }
        public long? EmployeeID { get; set; }
        public string? Comments { get; set; }
        public string VoucherNo { get; set; } = "";
        public ICollection<StockDamageLine> Lines { get; set; } = new List<StockDamageLine>();
    }

    public class StockDamageLine
    {
        public long AutoSlNo { get; set; }
        public long StockDamageId { get; set; }
        public long GodownAutoSlNo { get; set; }
        public long SubItemAutoSlNo { get; set; }
        public string BatchNo { get; set; }
        public string Currency { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal AmountIn { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal AmountBDT { get; set; }
    }


    public class StockDamageViewDto
    {
        public long AutoSlNo { get; set; }
        public string VoucherNo { get; set; } = string.Empty;
        public DateTime EntryDate { get; set; }

        public long GodownAutoSlNo { get; set; }
        public string GodownName { get; set; } = string.Empty;

        public long SubItemAutoSlNo { get; set; }
        public string SubItemName { get; set; } = string.Empty;
        public string SubItemCodeValue { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;

        public string BatchNo { get; set; } = "NA";

        public long? CurrencyId { get; set; }
        public string CurrencyName { get; set; } = string.Empty;

        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal AmountIn { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal AmountBDT { get; set; }

        public string DrACHead { get; set; } = string.Empty;
        public long? EmployeeID { get; set; }
        public string EmployeeName { get; set; } = string.Empty;

        public string? Comments { get; set; }
        public DateTime? CreateDate { get; set; }
    }



}
