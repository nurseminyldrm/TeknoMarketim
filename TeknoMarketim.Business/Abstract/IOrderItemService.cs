

using TeknoMarketim.Entities;

namespace TeknoMarketim.Business.Abstract;

public interface IOrderItemService
{
    List<OrderItem> GetAll();
}
