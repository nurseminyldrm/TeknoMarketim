

using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Data.Context;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Concrete;

public class EfContactRepository:EfGenericRepositoryBase<Contact,AppDbContext>,IContactRepository
{

}
