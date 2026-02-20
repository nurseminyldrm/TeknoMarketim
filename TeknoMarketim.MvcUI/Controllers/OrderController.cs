using Microsoft.AspNetCore.Mvc;

namespace TeknoMarketim.MvcUI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
