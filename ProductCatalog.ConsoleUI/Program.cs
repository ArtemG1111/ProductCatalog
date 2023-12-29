using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.ConsoleUI.Controllers;
using ProductCatalog.BusinessLogic.Interfaces;
using ProductCatalog.BusinessLogic.Services;
using ProductCatalog.DataAccess.Repositories;
using ProductCatalog.DataAccess.Interfaces;
using ProductCatalog.DataAccess.Data;

namespace ProductCatalog.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = GetConfiguration();
            var serviceProvider = GetServiceProvider(config);
            var productController = serviceProvider.GetService<ProductController>();
            var categoryController = serviceProvider.GetService<CategoryController>();
            Product product = new();
            Category category = new();
            int menu = 0;
            do
            {
                Console.WriteLine("1 - Продукты | 2 - Категории");
                Int32.TryParse(Console.ReadLine(), out menu);
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("***Продукты***");
                        int pMenu;
                        Console.WriteLine("1 - Список всех продуктов | 2 - Добавить продукт | 3 - Изменить продукт " +
                            "| 4 - Удалить продукт");
                        Int32.TryParse(Console.ReadLine(), out pMenu);
                        Console.Clear();
                        if (pMenu == 1)
                        {
                            Console.WriteLine("Все продукты: ");
                            Console.WriteLine("-----------------------------");
                            foreach (var p in productController.GetProducts())
                            {
                                Console.WriteLine("*********************");
                                Console.WriteLine($"Название: {p.Name}");
                                Console.WriteLine($"Цена: {p.Price} грн");
                                Console.WriteLine($"Описание: {p.Description}");
                                Console.WriteLine("Категории продукта: ");
                                foreach (var c in p.Categories.OrderBy(n=>n.Name))
                                {
                                    Console.WriteLine(c.Name);
                                }
                                Console.WriteLine("*********************");
                            }
                            Console.WriteLine("Нажмите Enter что бы вернутся назад");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (pMenu == 2)
                        {
                            int selectCategoryId;
                            Console.WriteLine("Все категории: ");
                            var categories = categoryController.GetAllCategories();
                            foreach (var c in categories)
                            {
                                Console.WriteLine($"{c.Id} - {c.Name}");
                            }
                            Console.WriteLine("Выберете категорию к которой хотите присвоить продукт: ");
                            Int32.TryParse(Console.ReadLine(), out selectCategoryId);
                            var selectedCategory = categories.First(s=>s.Id == selectCategoryId);
                            product.Categories = new List<Category>() { selectedCategory };
                            Console.Clear();
                            Console.Write("Название продукта: ");
                            product.Name = Console.ReadLine();
                            Console.Write("Цена: ");
                            product.Price = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Описание: ");
                            product.Description = Console.ReadLine();
                            productController.AddProduct(product);
                            Console.WriteLine("Нажмите Enter что бы выйти");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case 2:
                        Console.WriteLine("***Категории***");
                        int cMenu;
                        Console.WriteLine("1 - Посмотреть все категории | 2 - Создать категорию");
                        Int32.TryParse(Console.ReadLine(), out cMenu);
                        Console.Clear();
                        if (cMenu == 1)
                        {
                            Console.WriteLine("Все доступные категории: ");
                            Console.WriteLine("-----------------------------");
                            var categories = categoryController.GetAllCategories();                           
                            foreach (var c in categories)
                            {
                                Console.WriteLine(c.Name);
                            }
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Нажмите Enter что бы вернутся назад");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (cMenu == 2)
                        {
                            Console.Write("Название категории: ");
                            category.Name = Console.ReadLine();
                            categoryController.AddCategory(category);
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Нажмите Enter что бы вернутся назад");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                }
            }
            while (menu != 0);

        }
        static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            return builder.Build();
        }
        static IServiceProvider GetServiceProvider(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DeffaultConnection");
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IProductService, ProductService>()
                .AddTransient<CategoryController>()
                .AddTransient<ProductController>()
                .AddDbContext<ProductContext>(options => options.UseSqlite(connectionString));
            services.AddScoped<ProductContext>();
            return services.BuildServiceProvider();
        }

    }
}
    
