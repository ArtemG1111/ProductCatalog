

using ProductCatalog.BusinessLogic.Interfaces;
using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.DataAccess.Interfaces;

namespace ProductCatalog.BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void AddCategory(Category category)
        {
            _categoryRepository.AddCategory(category);
        }
        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }
        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }
        public void UpdateCategory(Category category)
        {
            _categoryRepository.UpdateCategory(category);
        }
        public void DeleteCategory(Category category)
        {
            _categoryRepository.DeleteCategory(category);
        }
    }
}
