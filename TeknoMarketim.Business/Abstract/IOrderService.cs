

using TeknoMarketim.Entities;

namespace TeknoMarketim.Business.Abstract;

public interface IOrderService
{
    List<Order> GetOrder(string userId);
    List<Order> GetAll();
    Order GetById(int id);
    void Add(Order order);
    void Update(Order order);
}
