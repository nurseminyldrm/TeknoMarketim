using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using TeknoMarketim.Business.Abstract;
using TeknoMarketim.MvcUI.Identity;
using TeknoMarketim.MvcUI.Models;

namespace TeknoMarketim.MvcUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICustomerAddressService _customerAddressService;
        private readonly ICustomerCardService _customerCardService;

        public CartController(ICartService cartService, IOrderService orderService, 
            UserManager<ApplicationUser> userManager, ICustomerAddressService customerAddressService, 
            ICustomerCardService customerCardService)
        {
            _cartService = cartService;
            _orderService = orderService;
            _userManager = userManager;
            _customerAddressService = customerAddressService;
            _customerCardService = customerCardService;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            if(userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var cart = _cartService.GetCartByUserId(userId);

            if(cart == null)
            {
                cart = _cartService.InitializeCart(userId);
            }

            return View(new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel
                {
                    CartItemId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price = (decimal)i.Product.Price,
                    DiscountedPrice = (decimal)i.Product.DiscountedPrice,
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity
                }).ToList()??new List<CartItemModel>()
            });
        }

        public IActionResult Wishlist()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            return View(new CartModel()
            {
                CartId = cart.Id,
                WishLists = cart.WishLists.Select(i => new WishListModel
                {
                    WishlistId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price = (decimal)i.Product.Price,
                    DiscountedPrice = (decimal)i.Product.DiscountedPrice,
                    ImageUrl = i.Product.ImageUrl
                }).ToList()
            });
        }


        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            _cartService.AddToCart(_userManager.GetUserId(User), productId, quantity);
            return RedirectToAction("Index");   
        }

        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            _cartService.DeleteFromCart(_userManager.GetUserId(User), productId);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult CheckOut()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            var orderModel = new OrderModel();
            orderModel.CartModel = new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel
                {
                    CartItemId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price = (decimal)i.Product.Price,
                    DiscountedPrice = (decimal)i.Product.DiscountedPrice,
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity
                }).ToList() ?? new List<CartItemModel>()
            };
            return View(orderModel);
        }

        [HttpPost]
        public IActionResult CheckOut(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var cart = _cartService.GetCartByUserId(userId);
                model.CartModel = new CartModel()
                {
                    CartId = cart.Id,
                    CartItems = cart.CartItems.Select(i => new CartItemModel
                    {
                        CartItemId = i.Id,
                        ProductId = i.ProductId,
                        Name = i.Product.Name,
                        Price = (decimal)i.Product.Price,
                        DiscountedPrice = (decimal)i.Product.DiscountedPrice,
                        ImageUrl = i.Product.ImageUrl,
                        Quantity = i.Quantity
                    }).ToList() ?? new List<CartItemModel>()
                };

                ////////////////////////////////////
                //var payment = PaymentProcess();




                
            }

            return RedirectToAction("İndex", "Home");
        }
    }
}
