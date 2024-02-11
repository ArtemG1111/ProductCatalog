
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.BusinessLogic.Interfaces;
using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.WEB.ViewModels;

namespace ProductCatalog.ConsoleUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpPost]
        public void AddCategory(CategoryViewModel category)
        {
            _categoryService.AddCategory(_mapper.Map<Category>(category));
        }
        [HttpGet("{id}")]
        public Category GetCategoryById(int id)
        {
            return _categoryService.GetCategoryById(id);
        }
        [HttpGet]
        public List<CategoryViewModel> GetAllCategories()
        {
            return _mapper.Map<List<CategoryViewModel>>(_categoryService.GetAllCategories());
        }
        [HttpPut]
        public void UpdateCategoty(CategoryViewModel category)
        {
            _categoryService.UpdateCategory(_mapper.Map<Category>(category));
        }
        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}
