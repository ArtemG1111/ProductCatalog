﻿

using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        List<Product> GetProducts();
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProductById(int id);
        List<Product> GetProductByCategoryId(int id);
    }
}
