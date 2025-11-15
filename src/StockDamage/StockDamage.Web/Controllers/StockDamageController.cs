using Microsoft.AspNetCore.Mvc;
using StockDamage.Web.Service.IService;

namespace StockDamage.Web.Controllers
{
    public class StockDamageController : Controller
    {
        private readonly IStockDamageService _stockDamageService;
        public StockDamageController(IStockDamageService stockDamageService)
        {
            _stockDamageService = stockDamageService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
