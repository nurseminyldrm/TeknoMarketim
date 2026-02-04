
using TeknoMarketim.Business.Abstract;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Business.Concrete;

public class CampaignManager : ICampaignService
{

    private readonly ICampaignRepository _campaignRepository;

    public CampaignManager(ICampaignRepository campaignRepository)
    {
        _campaignRepository = campaignRepository;
    }

    public void Add(Campaign campaign)
    {
        _campaignRepository.Add(campaign);
    }

    public void Delete(Campaign campaign)
    {
        _campaignRepository.Delete(campaign);
    }

    public List<Campaign> GetAll()
    {
        return _campaignRepository.GetAll();
    }

    public Campaign GetById(int id)
    {
        return _campaignRepository.GetById(id);

    }

    public void Update(Campaign campaign)
    {
        _campaignRepository.Update(campaign);
    }
}
