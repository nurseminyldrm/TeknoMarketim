using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Data.Context;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Concrete;

public class EfCartRepository : EfGenericRepositoryBase<Cart, AppDbContext>, ICartRepository
{
    public void ClearCart(string cartId)
    {
        using (var context = new AppDbContext())
        {
            var cmd = @"delete from CartItem where Id=@p0";
            context.Database.ExecuteSqlRaw(cmd);  
        }
    }

    public void DeleteFromCart(int cartId, int productId)
    {
        using (var context = new AppDbContext())
        {
            var cmd = @"delete from CartItem where Id=@p0 and ProductId=@p2";
            context.Database.ExecuteSqlRaw(cmd,cartId,productId);
        }
    }

    public Cart GetByUserId(string userId)
    {
        using (var context = new AppDbContext())
        {
            return context.Carts.Include(i => i.CartItems).ThenInclude(i => i.Product).FirstOrDefault(i => i.UserId == userId);
        }
    }
}
