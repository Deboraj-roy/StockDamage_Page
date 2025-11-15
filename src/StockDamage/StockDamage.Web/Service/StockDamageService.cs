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
                result = await _context.Godowns
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
                result = await _context.SubItemCodes
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
                result = await _context.Stocks
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
                result = await _context.Currencies
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
                result = await _context.Employees
                                       .AsNoTracking()
                                       .Where(whereCondition).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

        public async Task<List<StockDamageLine>> GetStockDamageLineAsync(Expression<Func<StockDamageLine, bool>> whereCondition)
        {
            var result = new List<StockDamageLine>();
            try
            {
                result = await _context.StockDamageLines
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
                result = await _context.StockDamageVouchers
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
