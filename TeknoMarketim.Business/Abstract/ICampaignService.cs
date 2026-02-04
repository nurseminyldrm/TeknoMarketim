

using TeknoMarketim.Entities;

namespace TeknoMarketim.Business.Abstract
{
    public interface ICampaignService
    {
        Campaign GetById(int id);
        List<Campaign> GetAll();
        void Add(Campaign campaign);
        void Update(Campaign campaign);
        void Delete(Campaign campaign);

    }
}
