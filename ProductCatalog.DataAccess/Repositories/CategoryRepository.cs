

using ProductCatalog.DataAccess.Data;
using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.DataAccess.Interfaces;

namespace ProductCatalog.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductContext _categoryContext;
        public CategoryRepository(ProductContext categoryContext)
        {
            _categoryContext = categoryContext;
        }
        public void AddCategory(Category category)
        {
            _categoryContext.Categories.Add(category);
            _categoryContext.SaveChanges();
        }
        public Category GetCategoryById(int id)
        {
            return _categoryContext.Categories.FirstOrDefault(i=>i.Id == id);
        }
        public List<Category> GetAllCategories()
        {
            return _categoryContext.Categories.ToList();
        }
        public void UpdateCategory(Category category)
        {
            _categoryContext.Categories.Attach(category);
            _categoryContext.SaveChanges();
        }
        public void DeleteCategory(Category category)
        {
            _categoryContext.Categories.Remove(category);
            _categoryContext.SaveChanges();
        }
    }
}
