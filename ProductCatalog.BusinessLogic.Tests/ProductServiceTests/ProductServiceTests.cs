
using Moq;
using Moq.EntityFrameworkCore;
using ProductCatalog.BusinessLogic.Services;
using ProductCatalog.DataAccess.Data;
using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.DataAccess.Interfaces;
using ProductCatalog.DataAccess.Repositories;

namespace ProductCatalog.BusinessLogic.Tests.ServiceTests
{
    public class ProductServiceTests
    {
        [Fact]
        public void GetAllProductsTest()
        {
            //Arrange
            List<Product> products = new List<Product>()
            {
                new Product {Name = "test", Price = 1},
                new Product {Name = "test1", Price = 2},
            };
            var mock = new Mock<IProductRepository>();
            mock.Setup(s=>s.GetProducts()).Returns(products);

            var service = new ProductService(mock.Object);

            //Act
            var result = service.GetProducts();

            //Assert
            Assert.Equal(products, result);
        }
        [Fact]
        public void GetProductByIdTest()
        {
            //Arrange
            Product product = new();
            var mock = new Mock<IProductRepository>();
            mock.Setup(s=>s.GetProductById(1)).Returns(product);
            var service = new ProductService(mock.Object);

            //Act
            var result = service.GetProductById(1);

            //Assert
            Assert.Equal(product, result);
        }
        [Fact]
        public void GetProductByCategoryId()
        {
            //Arrange
            List<Product> products = new List<Product>();
            var mock = new Mock<IProductRepository>();
            mock.Setup(s => s.GetProductByCategoryId(1)).Returns(products);
            var service = new ProductService(mock.Object);

            //Act
            var result = service.GetProductByCategoryId(1);

            //Assert
            Assert.Equal(products, result);
        }
        [Fact]
        public void DeleteProductTest()
        {
            //Arrange
            List<Product> products = new List<Product>()
            {
                new Product(),
                new Product()
            };
            Product product = new();

            var mock = new Mock<ProductContext>();
            mock.Setup(s => s.Products).ReturnsDbSet(products);
            mock.Setup(s => s.Remove(products[0])).Callback(() => products.Remove(products[0]));

            var repo = new ProductRepository(mock.Object);

            //Act
            repo.DeleteProduct(products[0]);

            //Assert
            Assert.Equal(1, products.Count);
        }
        [Fact]
        public void AddProductTest()
        {
            //Arrange
            Category category = new();
            List<Product> products = new List<Product>()
            {
                new Product(),
                new Product()
            };
            List<Category> categories = new List<Category>()
            {
                new Category()
            };
            Product product = new Product()
            {
                Categories = new()
                {
                    category
                }
            };

            var mock = new Mock<ProductContext>();
            mock.Setup(s => s.Products).ReturnsDbSet(products);
            mock.Setup(s => s.Categories).ReturnsDbSet(categories);
            mock.Setup(s => s.Categories.Find(1)).Returns(category);
            mock.Setup(s=>s.Products.Add(product)).Callback(() => products.Add(product));

            var repo = new ProductRepository(mock.Object);

            //Act
            repo.AddProduct(product);

            //Assert
            Assert.Equal(3, products.Count);
            Assert.Equal(product.Categories.First(), category);
            
        }
    }
}
