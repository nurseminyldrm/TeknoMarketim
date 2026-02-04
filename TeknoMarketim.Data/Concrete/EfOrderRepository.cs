using Microsoft.EntityFrameworkCore;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Data.Context;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Concrete;

public class EfOrderRepository : EfGenericRepositoryBase<Order, AppDbContext>, IOrderRepository
{
    public List<Order> GetOrders(string userId)
    {
        using (var context = new AppDbContext())
        {
            var orders = context.Orders.Include(i=>i.OrderItems).ThenInclude(i=>i.Product).AsQueryable();
            if (!string.IsNullOrEmpty(userId))
            {
                orders =orders.Where(i=>i.UserId == userId);
            }
            return orders.ToList();
        }
    }
}
