

using ProductCatalog.BusinessLogic.Interfaces;
using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.ConsoleUI.Controllers
{
    public class CategoryController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public void AddCategory(Category category)
        {
            _categoryService.AddCategory(category);
        }
        public void GetCategoryById(int id)
        {
            _categoryService.GetCategoryById(id);
        }
        public List<Category> GetAllCategories()
        {
            return _categoryService.GetAllCategories();
        }
        public void UpdateCategoty(Category category)
        {
            _categoryService.UpdateCategory(category);
        }
        public void DeleteCategory(Category category)
        {
            _categoryService.DeleteCategory(category);
        }
    }
}
