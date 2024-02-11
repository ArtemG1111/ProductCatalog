

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
            var findCategory = _context.Categories.Find(product.Categories.First().Id);
            if (findCategory != null)
            {
                product.Categories[0] = findCategory;
            }
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public List<Product> GetProducts()
        {
            return _context.Products.Include(c=>c.Categories).ToList();
        }
        public void UpdateProduct(Product product)
        {
            Product? existingProduct = _context.Products
        .Include(p => p.Categories) // подключаем таблицу категорий, чтобы ef следил за изменениями связей с этой таблицей
        .First(p => p.Id == product.Id);

            if (existingProduct == null)
            {
                throw new Exception($"Product with id ({product.Id}) not found.");
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;

            var categoryIds = product.Categories.Select(pc => pc.Id); // выбираем Idшники категорий которые будут у обновленного продукта

            existingProduct.Categories = _context.Categories
                .Where(c => categoryIds.Any(pc => c.Id == pc)) // вытаскиваем из базы категории Id которых содержится в списке идшников
                .ToList();

            _context.SaveChanges(); // значения меняются благодаря трекингу
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
        public List<Product> GetProductByCategoryId(int id)
        {
            return _context.Products.Include(c => c.Categories).Where(i => i.Categories.Any(s => s.Id == id ||
            s.ParentCategoryId == id)).ToList();

        }
    }
}
