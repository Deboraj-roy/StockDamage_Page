using StockDamage.Web.Service.IService;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using StockDamage.Web.Models.DTO;

namespace StockDamage.Web.Service
{
    public class StockDamageService : IStockDamageService
    {
        public Task<List<WarehouseDto>> GetWarehousesAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ItemDto>> GetItemsAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<ItemDto?> GetItemDetailsAsync(long itemId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<StockDto> GetStockAsync(long warehouseId, long itemId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<CurrencyDto>> GetCurrenciesAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<EmployeeDto>> GetEmployeesAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<long> SaveStockDamageAsync(StockDamageSaveRequest request, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
