
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.BusinessLogic.Interfaces;
using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.WEB.ViewModels;

namespace ProductCatalog.ConsoleUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpPost]
        public void AddProduct(ProductViewModel product)
        {
            _productService.AddProduct(_mapper.Map<Product>(product));
        }
        [HttpGet]
        public List<Product> GetProducts()
        {
            return _productService.GetProducts();
        }
        [HttpPut]
        public void UpdateProduct(ProductViewModel product)
        {
            _productService.UpdateProduct(_mapper.Map<Product>(product));
        }
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
        }
        [HttpGet("GetProductById/{id}")]
        public Product GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }
        [HttpGet("GetProductByCategoryId/{id}")]
        public List<Product> GetProductByCategoryId(int id)
        {
            return _productService.GetProductByCategoryId(id);
        }
    }
}
