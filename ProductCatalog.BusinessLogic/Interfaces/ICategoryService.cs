

using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.BusinessLogic.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        Category GetCategoryById(int id);
        List<Category> GetAllCategories();
        void DeleteCategory(int id);
        void UpdateCategory(Category category);
    }
}
