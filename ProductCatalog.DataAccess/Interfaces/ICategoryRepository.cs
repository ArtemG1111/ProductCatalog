

using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.DataAccess.Interfaces
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        Category GetCategoryById(int id);
        List<Category> GetAllCategories();
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);
    }
}
