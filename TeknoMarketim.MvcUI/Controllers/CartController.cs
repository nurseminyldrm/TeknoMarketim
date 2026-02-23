using TeknoMarketim.MvcUI.Payments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using TeknoMarketim.Business.Abstract;
using TeknoMarketim.MvcUI.Identity;
using TeknoMarketim.MvcUI.Models;
using TeknoMarketim.MvcUI.Models.OrderModel;

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
                var userId = _userManager.GetUserId(User);
                var cart = _cartService.GetCartByUserId(userId);
                var model = new CartModel()
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
            var orderModel = new OrderModel()
            {
                CartModel = model
            };

            return View(orderModel);
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(OrderModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var cart = _cartService.GetCartByUserId(userId);
            var cartModel = new CartModel()
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

            var orderModel = new OrderModel
            {
                Id= model.Id,
                CartModel = cartModel,
                FirstName =model.FirstName,
                LastName =model.LastName,
                Address = model.Address,
                City = model.City,
                Phone = model.Phone,
                Email = model.Email??user.Email
            };

            var iyzicoService = new IyzicoService();
            var checkoutFormHtml = await iyzicoService.InitializeCheckOutForm(cartModel, 
                user.Email, "https://localhost:7045/cart/paymentcallback");
            ViewBag.CheckoutFormHtml = checkoutFormHtml;
            return View("Checkout",orderModel);
        }
    }
}
