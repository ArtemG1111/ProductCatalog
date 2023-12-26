

using ProductCatalog.DataAccess.Data;
using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.DataAccess.Interfaces;

namespace ProductCatalog.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            _context.Add(product);
        }
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        public void UpdateProduct(Product product)
        {
            _context.Attach(product);
        }
        public void DeleteProduct(Product product)
        {
            _context.Remove(product);
        }
    }
}
