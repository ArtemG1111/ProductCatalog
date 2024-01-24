
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.BusinessLogic.Interfaces;
using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.ConsoleUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public void AddCategory(Category category)
        {
            _categoryService.AddCategory(category);
        }
        [HttpGet("{id}")]
        public Category GetCategoryById(int id)
        {
            return _categoryService.GetCategoryById(id);
        }
        [HttpGet]
        public List<Category> GetAllCategories()
        {
            return _categoryService.GetAllCategories();
        }
        [HttpPut]
        public void UpdateCategoty(Category category)
        {
            _categoryService.UpdateCategory(category);
        }
        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}
