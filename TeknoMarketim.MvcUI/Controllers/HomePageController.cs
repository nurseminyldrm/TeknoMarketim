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

        public PartialViewResult Slider()
        {
            return PartialView();
        }

        public PartialViewResult HomeCategory()
        {
            return PartialView();
        }

        public IActionResult ProductList(string category, int page = 1)
        {
            const int pageSize = 9;
            return View(new ProductListModel
            {
                PageInfo = new PageInfo
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemPerPage = pageSize,
                    CurrentCategory = category
                },
                Products = _productService.GetProductsByCategory(category, page, pageSize)
            });
        }

    }
}
