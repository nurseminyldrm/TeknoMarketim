using Microsoft.AspNetCore.Mvc;

namespace TeknoMarketim.MvcUI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
