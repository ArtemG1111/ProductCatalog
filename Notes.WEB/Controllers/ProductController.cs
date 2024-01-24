
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.BusinessLogic.Interfaces;
using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.ConsoleUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public void AddProduct(Product product)
        {
            _productService.AddProduct(product);
        }
        [HttpGet]
        public List<Product> GetProducts()
        {
            return _productService.GetProducts();
        }
        [HttpPut]
        public void UpdateProduct(Product product)
        {
            _productService.UpdateProduct(product);
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
