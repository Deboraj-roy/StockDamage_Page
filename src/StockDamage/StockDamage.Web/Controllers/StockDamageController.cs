using Microsoft.AspNetCore.Mvc;

namespace StockDamage.Web.Controllers
{
    public class StockDamageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
