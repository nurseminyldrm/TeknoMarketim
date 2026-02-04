using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Abstract;

public interface IWishListRepository:IGenericRepository<WishList>
{
    WishList GetByUserId(string userId);
    void DeleteFromWishList(int cartId, int productId);
    WishList GetByUserWhishlistId(string userId);
}
public interface IAsyncWishListRepository : IGenericRepository<WishList>
{
    Task DeleteFromWishListAsync(int cartId, int productId);
    Task<WishList> GetByUserIdAsync(string userId);
    Task<WishList?> GetByUserWhishlistIdAsync(int userId);
}