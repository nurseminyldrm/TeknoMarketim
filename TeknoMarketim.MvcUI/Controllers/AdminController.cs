using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeknoMarketim.Business.Abstract;
using TeknoMarketim.MvcUI.Identity;
using TeknoMarketim.MvcUI.Models.ProductModel;

namespace TeknoMarketim.MvcUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;

        private UserManager<ApplicationUser> _userManager;
        private UserManager<ApplicationUser> _signInManager;
        private ICampaignService _campaignService;

        public AdminController(IProductService productService, UserManager<ApplicationUser> userManager, UserManager<ApplicationUser> signInManager, ICampaignService campaignService)
        {
            _productService = productService;
            _userManager = userManager;
            _signInManager = signInManager;
            _campaignService = campaignService;
        }

        public IActionResult DashBoard()
        {
            var values = _productService.GetAll().Count().ToString();
            ViewBag.v1 = values;
            var values2 = _productService.GetAll().Select(x => x.Brand).Distinct().Count().ToString();
            ViewBag.v2 = values2;
            var values3 = _productService.GetAll().Count(x => x.StockQuantity < 60).ToString();
            ViewBag.v3 = values3;
            var values4 = _userManager.Users.Count().ToString();
            ViewBag.v4 = values4;
            return View();

        }

        public IActionResult HomeMonth()
        {
            return View(new ProductListModel
            {
                Products = _productService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult UpdateMonth(int id)
        {
            var entity = _productService.GetById(id);
            
            return View(new ProductModel
            {
                Id = entity.Id,
                Name = entity.Name,
                HomeMonth = entity.ShowOnPageAsMonthlyHighLight
            });
        }
        [HttpPost]
        public IActionResult UpdateMonth(ProductModel model)
        {
            var entity = _productService.GetById(model.Id);
            if(entity == null)
            {
                return NotFound();
            }
            entity.ShowOnPageAsMonthlyHighLight = model.HomeMonth;
            _productService.Update(entity, null);
            return RedirectToAction("HomeMonth");
        }


        public IActionResult HomeToday()
        {
            return View(new ProductListModel
            {
                Products = _productService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult UpdateToday(int id)
        {
            var entity = _productService.GetById(id);

            return View(new ProductModel
            {
                Id = entity.Id,
                Name = entity.Name,
                //HomeToday = entity.Today
            });
        }
        [HttpPost]
        public IActionResult UpdateToday(ProductModel model)
        {
            var entity = _productService.GetById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }
            //HomeToday = entity.Today
            _productService.Update(entity, null);
            return RedirectToAction("HomeToday");
        }


        public IActionResult HomePopular()
        {
            return View(new ProductListModel
            {
                Products = _productService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult UpdatePopular(int id)
        {
            var entity = _productService.GetById(id);

            return View(new ProductModel
            {
                Id = entity.Id,
                Name = entity.Name,
                HomePopular = entity.ShowOnPageAsPopular
            });
        }
        [HttpPost]
        public IActionResult UpdatePopular(ProductModel model)
        {
            var entity = _productService.GetById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }
            model.HomePopular = entity.ShowOnPageAsPopular;
            _productService.Update(entity, null);
            return RedirectToAction("HomePopular");
        }
    }
}

