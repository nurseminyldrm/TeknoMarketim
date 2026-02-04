

using TeknoMarketim.Business.Abstract;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Business.Concrete;

public class OrderManager : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderManager(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void Add(Order order)
    {
        _orderRepository.Add(order);
    }

    public List<Order> GetAll()
    {
        return _orderRepository.GetAll();
    }

    public Order GetById(int id)
    {
        return _orderRepository.GetById(id);
    }

    public List<Order> GetOrder(string userId)
    {
        return _orderRepository.GetOrders(userId);
    }

    public void Update(Order order)
    {
        _orderRepository.Update(order);
    }
}
