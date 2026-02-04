

using TeknoMarketim.Business.Abstract;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Business.Concrete;

public class OrderItemManager : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;

    public OrderItemManager(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }

    public List<OrderItem> GetAll()
    {
        return _orderItemRepository.GetAll();
    }
}
