

using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Data.Context;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Concrete;

public class EfCampaignRepository : EfGenericRepositoryBase<Campaign, AppDbContext>, ICampaignRepository
{
    public EfCampaignRepository(AppDbContext _context) : base(_context)
    {
    }
}
