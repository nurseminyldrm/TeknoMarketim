

using TeknoMarketim.Business.Abstract;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Business.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryManager(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public bool Validate(Category entity)
    {
        var IsValid = true;
        if (string.IsNullOrEmpty(entity.Name))
        {
            ErrorMessage = "The category Name cannot be blank!";
            IsValid = false;
        }
        return IsValid;
    }

    public string ErrorMessage { get ; set ; }

    public void Add(Category category)
    {
        if (Validate(category))
        {
            _categoryRepository.Add(category);
        }
    }

    public void Delete(Category category)
    {
        _categoryRepository?.Delete(category);
    }

    public List<Category> GetAll()
    {
        return _categoryRepository.GetAll();
    }

    public Category GetById(int id)
    {
        return _categoryRepository.GetById(id);
    }

    public Category GetByWithProduct(int id)
    {
        return _categoryRepository.GetByIdWithProducts(id);
    }

    public void Update(Category category)
    {
        _categoryRepository.Update(category);
    }

    
}
