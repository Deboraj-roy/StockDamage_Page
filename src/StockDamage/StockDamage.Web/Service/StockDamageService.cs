using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StockDamage.Web.Data;
using StockDamage.Web.Models;
using StockDamage.Web.Models.DTO;
using StockDamage.Web.Service.IService;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Security.Cryptography;
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
                result = await _context.Currency
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
        //public async Task<List<StockDamageVoucher>> GetStockDamageVoucherAsync(Expression<Func<StockDamageVoucher, bool>> whereCondition)
        //{
        //    var result = new List<StockDamageVoucher>();
        //    try
        //    {
        //        result = await _context.StockDamageVoucher
        //                               .AsNoTracking()
        //                               .Where(whereCondition).ToListAsync();
        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        return result;
        //    }
        //}


        private string GenerateVoucher()
        {
            return "SD-" + DateTime.UtcNow.ToString("yyyyMMdd-HHmmss");
        }


        public async Task<string> SaveStockDamageAsync2(StockDamageSaveRequest request)
        {
            using var trx = await _context.Database.BeginTransactionAsync();

            try
            {
                var voucherNo = GenerateVoucher();

                // Save lines
                foreach (var l in request.Lines)
                {
                    var line = new StockDamage.Web.Models.StockDamage
                    {
                        EntryDate = request.Date,
                        EmployeeID = request.EmployeeID,
                        Comments = request.Comments,
                        VoucherNo = voucherNo,


                        CreateDate = DateTime.UtcNow,
                        //StockDamageId = header.AutoSlNo,
                        GodownAutoSlNo = l.GodownAutoSlNo,
                        SubItemAutoSlNo = l.SubItemAutoSlNo,
                        BatchNo = l.BatchNo,
                        CurrencyId = l.Currency,
                        Quantity = l.Quantity,
                        Rate = l.Rate,
                        AmountIn = l.AmountIn,
                        ExchangeRate = l.ExchangeRate,
                        AmountBDT = l.AmountBDT
                    };

                    _context.StockDamage.Add(line);
                }

                await _context.SaveChangesAsync();

                await trx.CommitAsync();

                return voucherNo; // OR return voucherNo if you prefer
            }
            catch
            {
                await trx.RollbackAsync();
                throw;
            }
        }
        
        public async Task<string> SaveStockDamageAsync(StockDamageSaveRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Lines == null || !request.Lines.Any()) throw new ArgumentException("No lines to save", nameof(request));

            var conn = _context.Database.GetDbConnection();
            await using (conn)
            {
                await conn.OpenAsync();

                using var transaction = await conn.BeginTransactionAsync();

                try
                {
                    var voucherNo = GenerateVoucher();
                    foreach (var line in request.Lines)
                    {
                        // Prepare parameters
                        //var pVoucherNo = new SqlParameter("@VoucherNo", voucherNo) { Direction = System.Data.ParameterDirection.InputOutput, Value = voucherNo };
                        var cmd = conn.CreateCommand();
                        cmd.Transaction = transaction;
                        cmd.CommandText = "dbo.SP_StockDamage_Save";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        //cmd.Parameters.Add(pVoucherNo);
                        cmd.Parameters.Add(new SqlParameter("@VoucherNo", voucherNo));
                        cmd.Parameters.Add(new SqlParameter("@EntryDate", request.Date));
                        cmd.Parameters.Add(new SqlParameter("@GodownAutoSlNo", line.GodownAutoSlNo));
                        cmd.Parameters.Add(new SqlParameter("@SubItemAutoSlNo", line.SubItemAutoSlNo));
                        cmd.Parameters.Add(new SqlParameter("@BatchNo", line.BatchNo ?? "NA"));
                        cmd.Parameters.Add(new SqlParameter("@Currency", line.Currency));
                        cmd.Parameters.Add(new SqlParameter("@Quantity", line.Quantity));
                        cmd.Parameters.Add(new SqlParameter("@Rate", line.Rate));
                        cmd.Parameters.Add(new SqlParameter("@AmountIn", line.AmountIn));
                        cmd.Parameters.Add(new SqlParameter("@ExchangeRate", line.ExchangeRate));
                        cmd.Parameters.Add(new SqlParameter("@AmountBDT", line.AmountBDT));
                        cmd.Parameters.Add(new SqlParameter("@DrACHead", "Stock Damage"));
                        cmd.Parameters.Add(new SqlParameter("@EmployeeID", (object?)request.EmployeeID ?? DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Comments", (object?)request.Comments ?? DBNull.Value));

                        // Execute stored procedure
                        await cmd.ExecuteNonQueryAsync();

                        // read output voucher number
                        //voucherNo = Convert.ToInt32(pVoucherNo.Value);
                    }

                    await transaction.CommitAsync();
                    return voucherNo;
                }
                catch
                {
                    try { await transaction.RollbackAsync(); } catch { }
                    throw;
                }
            }
        }

        public async Task<List<StockDamageViewDto>> GetStockDamageAsync()
        { 
            var conn = _context.Database.GetDbConnection();
            var result = new List<StockDamageViewDto>();
            try
            {
                result = await _context.Database
                                        .SqlQuery<StockDamageViewDto>($"EXEC SP_GetStockDamage")
                                        .ToListAsync();

                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }


    }
}
