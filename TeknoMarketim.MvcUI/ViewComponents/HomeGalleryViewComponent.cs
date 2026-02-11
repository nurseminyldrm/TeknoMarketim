using Microsoft.AspNetCore.Mvc;
using TeknoMarketim.Business.Abstract;
using TeknoMarketim.MvcUI.Models.ProductModel;

namespace TeknoMarketim.MvcUI.ViewComponents
{
    public class HomeGalleryViewComponent:ViewComponent
    {
        private readonly IProductService _productService;

        public HomeGalleryViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            return View(new ProductListModel
            {
                Products = _productService.GetAll().Where(x => x.ShowOnPageAsPopular == true).Take(8).ToList()

            });
        }
    }
}
