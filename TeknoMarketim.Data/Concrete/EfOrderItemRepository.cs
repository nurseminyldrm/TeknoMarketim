

using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Data.Context;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Concrete;

public class EfOrderItemRepository : EfGenericRepositoryBase<OrderItem, AppDbContext>, IOrderItemRepository
{
    public EfOrderItemRepository(AppDbContext _context) : base(_context)
    {
    }
}
