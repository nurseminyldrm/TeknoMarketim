using TeknoMarketim.Business.Abstract;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool Validate(Product entity)
        {
            var IsValid = true;
            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage = "The Product Name cannot be blank!";
                IsValid = false;
            }
            return IsValid;
        }

        public string ErrorMessage { get ; set ; }

        public bool Add(Product product)
        {
            if (Validate(product))
            {
                _productRepository.Add(product);
                return true;
            }
            return false;
        }

        public void Delete(Product product)
        {
            _productRepository?.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _productRepository.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _productRepository.GetProductsByCategory(category);
        }

        public Product GetProductDetails(int id)
        {
            return _productRepository.GetProductDetails(id);
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            return _productRepository.GetProductByCategory(category, page, pageSize);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public void Update(Product product, int[] categoryIds)
        {
            _productRepository.Update(product, categoryIds);
        }

        
    }
}
