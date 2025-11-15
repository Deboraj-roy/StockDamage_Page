using Microsoft.EntityFrameworkCore;
using StockDamage.Web.Models;
using StockDamage.Web.Models.DTO;
using System.Linq.Expressions;

namespace StockDamage.Web.Service.IService
{
    public interface IStockDamageService
    {
        Task<List<Godown>> GetGodownsAsync(Expression<Func<Godown, bool>> whereCondition);
        Task<List<SubItemCode>> GetSubItemCodeAsync(Expression<Func<SubItemCode, bool>> whereCondition);
        Task<List<Stock>> GetStockAsync(Expression<Func<Stock, bool>> whereCondition);
        Task<List<Currency>> GetCurrenciesAsync(Expression<Func<Currency, bool>> whereCondition);
        Task<List<Employee>> GetEmployeesAsync(Expression<Func<Employee, bool>> whereCondition);
        Task<List<StockDamageLine>> GetStockDamageLineAsync(Expression<Func<StockDamageLine, bool>> whereCondition);
        Task<List<StockDamageVoucher>> GetStockDamageVoucherAsync(Expression<Func<StockDamageVoucher, bool>> whereCondition);
         
        /// <summary>
        /// Saves all stock damage lines as a single voucher using stored procedure SP_StockDamage_Save.
        /// Returns generated voucher number.
        /// </summary>
        Task<long> SaveStockDamageAsync(StockDamageSaveRequest request, CancellationToken cancellationToken = default);

    }
}
