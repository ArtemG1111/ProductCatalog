using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.BusinessLogic.Interfaces
{
    public interface IProductService
    {
        void AddProduct(Product product);
        List<Product> GetProducts();
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProductById(int id);

    }
}
