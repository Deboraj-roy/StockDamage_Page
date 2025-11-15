using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockDamage.Web.Models.DTO;
using StockDamage.Web.Service.IService;
using System.Threading.Tasks;
using System.Web;

namespace StockDamage.Web.Controllers
{
    public class StockDamageController : Controller
    {
        private readonly IStockDamageService _stockDamageService;
        public StockDamageController(IStockDamageService stockDamageService)
        {
            _stockDamageService = stockDamageService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.ddlGodowns = new SelectList( await _stockDamageService.GetGodownsAsync(s => s.AutoSlNo > 0), "AutoSlNo", "GodownName");
            ViewBag.ddlEmployees = new SelectList( await _stockDamageService.GetEmployeesAsync(s => s.EmployeeID > 0), "EmployeeID", "EmployeeName");
            ViewBag.ddlCurrency = new SelectList( await _stockDamageService.GetCurrenciesAsync(s => s.CurrencyId > 0), "CurrencyId", "CurrencyName");
            ViewBag.ddlGodowns = new SelectList( await _stockDamageService.GetGodownsAsync(s => s.AutoSlNo > 0), "AutoSlNo", "GodownName");
            ViewBag.ddlSubItemNames = new SelectList( await _stockDamageService.GetSubItemCodeAsync(s => s.AutoSlNo > 0), "AutoSlNo", "SubItemName");

            return View();
        }
         
        public async Task<IActionResult> GetItemDetails(long itemId)
        {
            var item = (await _stockDamageService.GetSubItemCodeAsync(s => s.AutoSlNo == itemId)).FirstOrDefault();
            if (item == null) return Json(new { SubItemCode = "", Unit = 0, stockId = 0, stockqty = 0 });

            var stock = (await _stockDamageService.GetStockAsync(s => s.SubItemAutoSlNo == itemId)).FirstOrDefault();
            return Json(new { SubItemCode = item.SubItemCodeValue, Unit = item.Unit , stockId = stock.AutoSlNo, stockqty = stock.Quantity });
        }
         
        public async Task<IActionResult> GetStock(long warehouseId, long itemId)
        {
            var s = await _stockDamageService.GetStockAsync(st => st.GodownAutoSlNo == warehouseId && st.SubItemAutoSlNo == itemId);
            var s2 = s.FirstOrDefault();
            if (s2 == null) return Json(new { Quantity = 0m });
            return Json(s2);
        }
        public async Task<IActionResult> GetCurrencyDetails(long cId)
        {
            var item = (await _stockDamageService.GetCurrenciesAsync(s => s.CurrencyId == cId)).FirstOrDefault();
            if (item == null) return Json(new { CurrencyName = "", CurrencyId = 0, ConversionRate = 0 });

            return Json(new { CurrencyName = item.CurrencyName, CurrencyId = item.CurrencyId, ConversionRate = item.ConversionRate });
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] StockDamageSaveRequest request)
        {
            try
            {
                //var voucher = await _stockDamageService.SaveStockDamageAsync2(request);
                var voucher = await _stockDamageService.SaveStockDamageAsync(request);
                return Ok(new { success = true, voucherNo = voucher });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        public async Task<IActionResult> GetDamageStock()
        {
            var list = await _stockDamageService.GetStockDamageAsync();
            return View(list);
        }


    }
}
