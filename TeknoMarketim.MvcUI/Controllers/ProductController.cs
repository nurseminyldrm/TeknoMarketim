using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TeknoMarketim.Business.Abstract;
using TeknoMarketim.Entities;
using TeknoMarketim.MvcUI.Models.ProductModel;

namespace TeknoMarketim.MvcUI.Controllers
{
    public class ProductController : Controller
    {
        private ICategoryService _categoryService;
        private IProductService _productService;

        public ProductController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll().Where(x => x.isActive == true).ToList()
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductModel model, IFormFile ImageFile)
        {
            ModelState.Remove("ImageUrl");
            if (ModelState.IsValid)
            {
                var entity = new Product()
                {
                    Name = model.Name,
                    Brand = model.Brand,
                    Price = model.Price,
                    DiscountedPrice = model.DiscountedPrice,
                    Description = model.Description,
                    StockQuantity = model.StockQuantity,
                    isActive = model.Status = true
                };
                if (ImageFile != null)
                {
                    entity.ImageUrl = ImageFile.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", ImageFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }
                }
                if (_productService.Add(entity))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}
