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

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetByIdWithCategories((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new ProductModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Brand = entity.Brand,
                Price = entity.Price,
                DiscountedPrice = entity.DiscountedPrice,
                StockQuantity = entity.StockQuantity,
                ImageUrl = entity.ImageUrl,
                SelectedCategories = entity.ProductCategories.Select(i => i.Category).ToList()
            };
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductModel model, IFormFile file, int[] categoryIds)
        {
            if (ModelState.IsValid)
            {
                var entity = _productService.GetById(model.Id);
                if(entity == null)
                {
                    return NotFound();
                }

                entity.Name = model.Name;
                entity.Brand = model.Brand;
                entity.Price = model.Price;
                entity.DiscountedPrice = model.DiscountedPrice;
                entity.StockQuantity = model.StockQuantity;
                entity.Description = model.Description;
                if (file!=null)
                {
                    entity.ImageUrl = file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                _productService.Update(entity, categoryIds);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }
    }
}
