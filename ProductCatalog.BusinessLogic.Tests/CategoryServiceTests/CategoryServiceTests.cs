

using Moq;
using Moq.EntityFrameworkCore;
using ProductCatalog.BusinessLogic.Services;
using ProductCatalog.DataAccess.Data;
using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.DataAccess.Interfaces;
using ProductCatalog.DataAccess.Repositories;

namespace ProductCatalog.BusinessLogic.Tests.CategoryServiceTests
{
    public class CategoryServiceTests
    {
        [Fact]
        public void GetAllCategoriesTest()
        {
            //Arrange
            List<Category> categories = new List<Category>()
            {
                new Category(),
                new Category()
            };
            var mock = new Mock<ICategoryRepository>();
            mock.Setup(s => s.GetAllCategories()).Returns(categories);

            var service = new CategoryService(mock.Object);

            //Act
            var result = service.GetAllCategories();

            //Assert
            Assert.Equal(categories, result);
        }
        [Fact]
        public void GetCategoryByIdTest()
        {
            //Arrange
            Category category = new();
            var mock = new Mock<ICategoryRepository>();
            mock.Setup(s => s.GetCategoryById(1)).Returns(category);

            var service = new CategoryService(mock.Object);

            //Act
            var result = service.GetCategoryById(1);

            //Assert
            Assert.Equal(category, result);
        }
        [Fact]
        public void AddCategoryTest()
        {
            //Arrange
            List<Category> categories = new List<Category>()
            {
                new Category(),
                new Category()
            };
            Category category = new();

            var mock = new Mock<ProductContext>();
            mock.Setup(s => s.Categories).ReturnsDbSet(categories);
            mock.Setup(s => s.Categories.Add(category)).Callback(() => categories.Add(category));

            var repo = new CategoryRepository(mock.Object);

            //Act
            repo.AddCategory(category);

            //Assert
            Assert.Equal(3, categories.Count);

        }
        [Fact]
        public void DeleteCategoryTest()
        {
            //Arrange
            List<Category> categories = new List<Category>()
            {
                new Category(),
                new Category()
            };
            var mock = new Mock<ProductContext>();
            mock.Setup(s => s.Categories).ReturnsDbSet(categories);
            mock.Setup(s => s.Categories.Remove(categories[0])).Callback(() => categories.Remove(categories[0]));

            var repo = new CategoryRepository(mock.Object);

            //Act
            repo.DeleteCategory(categories[0]);

            //Assert
            Assert.Equal(1, categories.Count);

        }
    }
}
