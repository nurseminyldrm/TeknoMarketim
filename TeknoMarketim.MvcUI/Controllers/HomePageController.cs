using Microsoft.AspNetCore.Mvc;
using TeknoMarketim.Business.Abstract;
using TeknoMarketim.Entities;
using TeknoMarketim.MvcUI.Models.ProductModel;

namespace TeknoMarketim.MvcUI.Controllers
{
    public class HomePageController : Controller
    {
        private IProductService _productService;

        public HomePageController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(new ProductListModel
            {
                Products = _productService.GetAll()
            });
        }


    }
}
