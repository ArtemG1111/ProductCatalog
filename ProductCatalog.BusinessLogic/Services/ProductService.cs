

using ProductCatalog.BusinessLogic.Interfaces;
using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.DataAccess.Interfaces;

namespace ProductCatalog.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
            
        }
        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }
        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }
        public void DeleteProduct(int id)
        {
            Product deleteProduct = _productRepository.GetProductById(id);
            _productRepository.DeleteProduct(deleteProduct);
        }
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }
        public List<Product> GetProductByCategoryId(int id)
        {
            return _productRepository.GetProductByCategoryId(id);
        }
    }
}
