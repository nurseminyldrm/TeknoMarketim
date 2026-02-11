using Microsoft.AspNetCore.Mvc;
using TeknoMarketim.Business.Abstract;
using TeknoMarketim.MvcUI.Models.ProductModel;

namespace TeknoMarketim.MvcUI.ViewComponents
{
    public class HomeTodayViewComponent:ViewComponent
    {
        private IProductService _productService;

        public HomeTodayViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            return View(new ProductListModel
            {
                Products = _productService.GetAll().Where(x => x.ShowOnPageAsDailyHighLight == true).Take(6).ToList()

            });
        }
    }
}
