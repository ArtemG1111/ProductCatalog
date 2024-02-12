
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.BusinessLogic.Interfaces;
using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.WEB.ViewModels;

namespace ProductCatalog.ConsoleUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IValidator<CategoryViewModel> _validator;
        public CategoryController(ICategoryService categoryService, IMapper mapper, 
            IValidator<CategoryViewModel> validator)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpPost]
        public void AddCategory(CategoryViewModel category)
        {
            ValidationResult result = _validator.Validate(category);
            if(!result.IsValid)
            {
                var errors = result.Errors.Select(e => new { Property = e.PropertyName, ErrorMessage = e.ErrorMessage });
                BadRequest(new { Errors = errors });
            }

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
            ValidationResult result = _validator.Validate(category);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => new { Property = e.PropertyName, ErrorMessage = e.ErrorMessage });
                BadRequest(new { Errors = errors });
            }

            _categoryService.UpdateCategory(_mapper.Map<Category>(category));
        }
        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}
