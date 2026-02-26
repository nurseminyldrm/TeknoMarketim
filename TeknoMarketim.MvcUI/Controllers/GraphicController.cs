/* using Microsoft.AspNetCore.Mvc;
using TeknoMarketim.Business.Abstract;
using TeknoMarketim.MvcUI.Models.GraphicModel;

namespace TeknoMarketim.MvcUI.Controllers
{
    public class GraphicController : Controller
    {
        private readonly IProductService _productService;
        
        public GraphicController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            var data = GetProductList();
            return Json(data);
        }

         /*private List<PieChartModel> GetProductList()
        {
            var product = _productService.GetProductStockSummary();
            return product.Select(x=> new PieChartModel
            {
                product = x.ProductName,
                stock = x.StockQuantity,
            }).ToList();
        } 
        
        public IActionResult LineChart()
        {
            return View();
        }

        public IActionResult VisualizeLineChart()
        {
            var data = GetProductList();
            return Json(data);
        }


        //////////////////////////////////////////////////////////////////7
    }
}  */
