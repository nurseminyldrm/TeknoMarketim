

using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Data.Context;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Concrete;

public class EfCustomerCardRepository : EfGenericRepositoryBase<CustomerCard, AppDbContext>, ICustomerCardRepository
{
    public EfCustomerCardRepository(AppDbContext _context) : base(_context)
    {
    }
}
