using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeknoMarketim.Business.Abstract;
using TeknoMarketim.MvcUI.Identity;

namespace TeknoMarketim.MvcUI.Controllers
{
    public class StaticController : Controller
    {
        private IOrderService _orderService;
        private IOrderItemService _orderItemService;
        private IProductService _productService;
        private ICategoryService _categoryService;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public StaticController(IOrderService orderService, IOrderItemService orderItemService, IProductService productService, ICategoryService categoryService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _productService = productService;
            _categoryService = categoryService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}