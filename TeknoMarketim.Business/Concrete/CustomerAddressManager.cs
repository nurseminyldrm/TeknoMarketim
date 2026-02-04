

using TeknoMarketim.Business.Abstract;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Business.Concrete;

public class CustomerAddressManager : ICustomerAddressService
{
    private ICustomerAddressRepository _customerAddressRepository;

    public CustomerAddressManager(ICustomerAddressRepository customerAddressRepository)
    {
        _customerAddressRepository = customerAddressRepository;
    }

    public void Add(CustomerAddress customerAddress)
    {
        _customerAddressRepository.Add(customerAddress);
    }

    public void Delete(CustomerAddress customerAddress)
    {
        _customerAddressRepository.Delete(customerAddress);
    }

    public List<CustomerAddress> GetAll()
    {
        return _customerAddressRepository.GetAll();
    }

    public CustomerAddress GetById(int id)
    {
        return _customerAddressRepository.GetById(id);
    }

    public void Update(CustomerAddress customerAddress)
    {
        _customerAddressRepository.Update(customerAddress);
    }
}
