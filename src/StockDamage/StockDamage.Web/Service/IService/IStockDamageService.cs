using StockDamage.Web.Models.DTO;

namespace StockDamage.Web.Service.IService
{
    public interface IStockDamageService
    {
        Task<List<WarehouseDto>> GetWarehousesAsync(CancellationToken cancellationToken = default);
        Task<List<ItemDto>> GetItemsAsync(CancellationToken cancellationToken = default);
        Task<ItemDto?> GetItemDetailsAsync(long itemId, CancellationToken cancellationToken = default);
        Task<StockDto> GetStockAsync(long warehouseId, long itemId, CancellationToken cancellationToken = default);
        Task<List<CurrencyDto>> GetCurrenciesAsync(CancellationToken cancellationToken = default);
        Task<List<EmployeeDto>> GetEmployeesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Saves all stock damage lines as a single voucher using stored procedure SP_StockDamage_Save.
        /// Returns generated voucher number.
        /// </summary>
        Task<long> SaveStockDamageAsync(StockDamageSaveRequest request, CancellationToken cancellationToken = default);

    }
}
