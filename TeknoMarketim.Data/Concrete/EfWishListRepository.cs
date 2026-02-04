

using Microsoft.EntityFrameworkCore;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Data.Context;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Concrete;

public class EfWishListRepository : EfGenericRepositoryBase<WishList, AppDbContext>, IWishListRepository
{
    public void DeleteFromWishList(int cartId, int productId)
    {
        using(var context = new AppDbContext())
        {

            var cmd = @"delete from Wishlist where CartId=@p0 and ProductId=@p2";
            context.Database.ExecuteSqlRaw(cmd,cartId,productId);
        }
    }

    public WishList GetByUserId(string userId)
    {
        using (var context = new AppDbContext())
        {
            var cmd = @"Select Top 1 * from Wishlist w Inner Join Carts 
                c on w.CartId = c.Id where c.UserId={0}";
            return context.WishLists.FromSqlRaw(cmd, userId).Include(w=>w.Product).FirstOrDefault();
        }
    }

    public WishList GetByUserWhishlistId(string userId)
    {
        using (var context = new AppDbContext())
        {
            var cmd = @"Select Top 1 * from Wishlist w Inner Join Carts 
                c on w.CartId = c.Id where c.UserId={0}";
            return context.WishLists.FromSqlRaw(cmd, userId).Include(w => w.Product).FirstOrDefault();
        }
    }
}


public class EfWishListAsyncRepository : EfGenericRepositoryBase<WishList, AppDbContext>, IAsyncWishListRepository
{
    public async Task DeleteFromWishListAsync(int cartId, int productId)
    {
        using (var context = new AppDbContext())
        {
            var item = await context.WishLists.FirstOrDefaultAsync(w => w.CartId == cartId && w.ProductId == productId);
            if(item != null)
            {
                context.WishLists.Remove(item);
                await context.SaveChangesAsync();
            }
        }
    }

    public async Task<WishList> GetByUserIdAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<WishList?> GetByUserWhishlistIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}
