using Microsoft.AspNetCore.Mvc;
using TeknoMarketim.Business.Abstract;
using TeknoMarketim.MvcUI.Models.ProductModel;

namespace TeknoMarketim.MvcUI.ViewComponents
{
    public class HomeOfferViewComponent:ViewComponent
    {
        private IProductService _productService;

        public HomeOfferViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            return View(new ProductListModel
            {
                Products = _productService.GetAll().Where(x => x.ShowOnPageAsPopular == true).Take(6).ToList()

            });
        }
    }
}
