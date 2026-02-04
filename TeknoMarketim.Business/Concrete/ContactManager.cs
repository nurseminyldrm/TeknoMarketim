

using TeknoMarketim.Business.Abstract;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void Add(Contact contact)
        {
            _contactRepository.Add(contact);
        }

        public void Delete(Contact contact)
        {
            _contactRepository.Delete(contact);
        }

        public List<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }

        public Contact GetById(int id)
        {
            return _contactRepository.GetById(id);
        }

        public void Update(Contact contact)
        {
            _contactRepository.Update(contact);
        }
    }
}
