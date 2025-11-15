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

        [HttpGet]
        public async Task<IActionResult> GetItemDetails(long itemId)
        {
            var item = (await _stockDamageService.GetSubItemCodeAsync(s => s.AutoSlNo == itemId)).FirstOrDefault();
            if (item == null) return Json(null);
            return Json(new { SubItemCode = item.SubItemCodeValue, Unit = item.Unit });
        }

        [HttpGet]
        public async Task<IActionResult> GetStock(long warehouseId, long itemId)
        {
            var s = await _stockDamageService.GetStockAsync(st => st.GodownAutoSlNo == warehouseId && st.SubItemAutoSlNo == itemId);
            var s2 = s.FirstOrDefault();
            if (s2 == null) return Json(new { Quantity = 0m });
            return Json(s2);
        }

        //[HttpPost]
        //public async Task<IActionResult> Save([FromBody] StockDamageSaveRequest req)
        //{
        //    // basic validation
        //    if (req == null || req.Lines == null || !req.Lines.Any()) return Json(new { success = false, message = "No lines provided" });

        //    // generate voucher if not provided
        //    if (string.IsNullOrWhiteSpace(req.VoucherNo))
        //    {
        //        req.VoucherNo = "SD-" + DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        //    }
        //    req.TotalAmountBDT = req.Lines.Sum(x => x.AmountBDT);

        //    var result = await _stockDamageService.SaveStockDamageAsync(req);
        //    if (result.Success) return Json(new { success = true, voucherNo = result.VoucherNo, id = result.Id });
        //    return Json(new { success = false, message = result.Message ?? "Save failed" });
        //}
    }
}
