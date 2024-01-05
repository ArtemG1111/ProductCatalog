

using ProductCatalog.BusinessLogic.Interfaces;
using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.ConsoleUI.Controllers
{
    public class ProductController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public void AddProduct(Product product)
        {
            _productService.AddProduct(product);
        }
        public List<Product> GetProducts()
        {
            return _productService.GetProducts();
        }
        public void UpdateProduct(Product product)
        {
            _productService.UpdateProduct(product);
        }
        public void DeleteProduct(Product product)
        {
            _productService.DeleteProduct(product);
        }
        public Product GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }
        public List<Product> GetProductByCategoryId(int id)
        {
            return _productService.GetProductByCategoryId(id);
        }
    }
}
