
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductViewModel> _validator;
        public ProductController(IProductService productService, IMapper mapper, 
            IValidator<ProductViewModel> validator)
        {
            _productService = productService;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpPost]
        public void AddProduct(ProductViewModel product)
        {
            ValidationResult result = _validator.Validate(product);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => new { Property = e.PropertyName, ErrorMessage = e.ErrorMessage });
                BadRequest(new { Errors = errors });
            }

            _productService.AddProduct(_mapper.Map<Product>(product));
        }
        [HttpGet]
        public List<ProductViewModel> GetProducts()
        {
            return _mapper.Map<List<ProductViewModel>>(_productService.GetProducts());
        }
        [HttpPut]
        public void UpdateProduct(ProductViewModel product)
        {
            ValidationResult result = _validator.Validate(product);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => new { Property = e.PropertyName, ErrorMessage = e.ErrorMessage });
                BadRequest(new { Errors = errors });
            }

            _productService.UpdateProduct(_mapper.Map<Product>(product));
        }
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
        }
        [HttpGet("GetProductById/{id}")]
        public ProductViewModel GetProductById(int id)
        {
            return _mapper.Map<ProductViewModel>(_productService.GetProductById(id));
        }
        [HttpGet("GetProductByCategoryId/{id}")]
        public List<ProductViewModel> GetProductByCategoryId(int id)
        {
            return _mapper.Map<List<ProductViewModel>>(_productService.GetProductByCategoryId(id));
        }
    }
}
