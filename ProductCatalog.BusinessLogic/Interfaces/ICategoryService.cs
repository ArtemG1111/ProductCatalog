

using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.BusinessLogic.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        Category GetCategoryById(int id);
        List<Category> GetAllCategories();
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);
    }
}
