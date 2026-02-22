using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeknoMarketim.Business.Abstract;

namespace TeknoMarketim.MvcUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //index create update delete => category sizde
        /* public IActionResult Index()
        {
            return View(new CategoryListModel
            {


            });
        } */
    }
}
