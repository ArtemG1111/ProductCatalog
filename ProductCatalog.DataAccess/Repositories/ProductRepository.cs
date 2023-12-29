

using Microsoft.EntityFrameworkCore;
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
            _context.SaveChanges();
        }
        public List<Product> GetProducts()
        {
            return _context.Products.Include(c=>c.Categories).ToList();
        }
        public void UpdateProduct(Product product)
        {
            _context.Attach(product);
            _context.SaveChanges();
        }
        public void DeleteProduct(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }
        public Product GetProductById(int id)
        {
            return _context.Products.Include(c=>c.Categories).FirstOrDefault(i=>i.Id == id);
        }
    }
}
