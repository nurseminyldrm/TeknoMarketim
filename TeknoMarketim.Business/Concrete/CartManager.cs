

using TeknoMarketim.Business.Abstract;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Business.Concrete;

public class CartManager : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IWishListRepository _wishListRepository;

    public CartManager(ICartRepository cartRepository, IWishListRepository wishListRepository)
    {
        _cartRepository = cartRepository;
        _wishListRepository = wishListRepository;
    }

    public void AddToCart(string userId, int productId, int quantity)
    {
        var cart=GetCartByUserId(userId);
        if (cart != null)
        {
            var index = cart.CartItems.FindIndex(i => i.ProductId == productId);
            if (index < 0)
            {
                cart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    CartId = cart.Id
                });
            }
            else
            {
                cart.CartItems[index].Quantity += quantity;
            }
                _cartRepository.Update(cart);   
        }


    }
    

    public void AddToWishlist(string userId, int productId)
    {
        var cart = GetCartByUserWishlistId(userId);
        if(cart != null)
        {
            var index = cart.WishLists.FindIndex(i => i.ProductId == productId);
            if(index < 0)
            {
                cart.WishLists.Add(new WishList
                {
                    ProductId = productId,
                    CartId = cart.Id
                });
            }
            else
            {

            }
            _cartRepository.Update(cart);
        }
    }

    public void ClearCart(string cartId)
    {
        _cartRepository.ClearCart(cartId);
    }

    public void DeleteFromCart(string userId, int productId)
    {
        var cart = GetCartByUserId(userId);
        if (cart!=null)
        {
            var cartId = cart.Id;
            _cartRepository.DeleteFromCart(cartId, productId);
        }
    }

    public void DeleteFromWishlist(string userId, int productId)
    {
        var cart = GetCartByUserWishlistId(userId);
        if (cart !=null)
        {
            var cartId=cart.Id;
            _wishListRepository.DeleteFromWishList(cartId, productId);
        }
    }

    public Cart GetCartByUserId(string userId)
    {
        return _cartRepository.GetByUserId(userId);
    }
    /////////////////////////////////////
    public Cart GetCartByUserWishlistId(string userId)
    {
        return _cartRepository.GetByUserId(userId);
    }

    public void InitializeCart(string userId)
    {
        _cartRepository.Add(new Cart
        {
            UserId = userId
        });
    }
}
