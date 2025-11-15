using Microsoft.EntityFrameworkCore;
using StockDamage.Web.Data;
using StockDamage.Web.Models;
using StockDamage.Web.Models.DTO;
using StockDamage.Web.Service.IService;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace StockDamage.Web.Service
{
    public class StockDamageService : IStockDamageService
    {
        private readonly AppDbContext _context;
        public StockDamageService(AppDbContext db)
        {
            this._context = db;
        }



        public async Task<List<Godown>> GetGodownsAsync(Expression<Func<Godown, bool>> whereCondition)
        {
            var result = new List<Godown>();
            try
            {
                result = await _context.Godown
                                       .AsNoTracking()
                                       .Where(whereCondition).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

        public async Task<List<SubItemCode>> GetSubItemCodeAsync(Expression<Func<SubItemCode, bool>> whereCondition)
        {
            var result = new List<SubItemCode>();
            try
            {
                result = await _context.SubItemCode
                                       .AsNoTracking()
                                       .Where(whereCondition).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

        public async Task<List<Stock>> GetStockAsync(Expression<Func<Stock, bool>> whereCondition)
        {
            var result = new List<Stock>();
            try
            {
                result = await _context.Stock
                                       .AsNoTracking()
                                       .Where(whereCondition).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

        public async Task<List<Currency>> GetCurrenciesAsync(Expression<Func<Currency, bool>> whereCondition)
        {
            var result = new List<Currency>();
            try
            {
                result = await _context.Currencie
                                       .AsNoTracking()
                                       .Where(whereCondition).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

        public async Task<List<Employee>> GetEmployeesAsync(Expression<Func<Employee, bool>> whereCondition)
        {
            var result = new List<Employee>();
            try
            {
                result = await _context.Employee
                                       .AsNoTracking()
                                       .Where(whereCondition).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

        public async Task<List<StockDamage.Web.Models.StockDamage>> GetStockDamageLineAsync(Expression<Func<StockDamage.Web.Models.StockDamage, bool>> whereCondition)
        {
            var result = new List<StockDamage.Web.Models.StockDamage>();
            try
            {
                result = await _context.StockDamage
                                       .AsNoTracking()
                                       .Where(whereCondition).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }
        public async Task<List<StockDamageVoucher>> GetStockDamageVoucherAsync(Expression<Func<StockDamageVoucher, bool>> whereCondition)
        {
            var result = new List<StockDamageVoucher>();
            try
            {
                result = await _context.StockDamageVoucher
                                       .AsNoTracking()
                                       .Where(whereCondition).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

        public Task<long> SaveStockDamageAsync(StockDamageSaveRequest request, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
