

using TeknoMarketim.Entities;

namespace TeknoMarketim.Business.Abstract;

public interface IWishListService
{
    void DeleteFromWishList(int cartId, int productId);
    WishList GetByUserId(string userId);
    WishList GetByUserWishListId(string userId);

}
