using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeknoMarketim.Business.Abstract;
using TeknoMarketim.Entities;
using TeknoMarketim.MvcUI.Identity;
using TeknoMarketim.MvcUI.Models;

namespace TeknoMarketim.MvcUI.Controllers
{
    public class AdminLoginController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AdminLoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult AdminLogin(string returnUrl = null)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl,

            });
        }
        [HttpPost]
        public async Task<IActionResult> AdminLogin(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user =await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "No user has been created with this e-mail address before");

            }
            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "please confirm your account by email");

                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "~/Admin/DashBoard");
            }
            ModelState.AddModelError("", "your password and e-mail address is incorrect");

            return View(model);
            
        }



    } 
}
