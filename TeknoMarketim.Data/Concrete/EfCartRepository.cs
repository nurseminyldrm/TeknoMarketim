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

public class EfCartRepository(AppDbContext _context) : EfGenericRepositoryBase<Cart, AppDbContext>(_context), ICartRepository
{
   private readonly AppDbContext _context = _context;

    public void ClearCart(string cartId)
    {
        
            var cmd = @"delete from CartItem where Id=@p0";
            _context.Database.ExecuteSqlRaw(cmd,cartId);  
        
    }

    public void DeleteFromCart(int cartId, int productId)
    {
       
            var cmd = @"delete from CartItem where Id=@p0 and ProductId=@p2";
            _context.Database.ExecuteSqlRaw(cmd,cartId,productId);
        
    }

    public Cart GetByUserId(string userId)
    {
        
            return _context.Carts.Include(i => i.CartItems).ThenInclude(i => i.Product).FirstOrDefault(i => i.UserId == userId);
        
    }
}
