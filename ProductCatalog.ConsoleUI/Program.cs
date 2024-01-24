//using Microsoft.Extensions.Configuration;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using ProductCatalog.DataAccess.Data.Models;
//using ProductCatalog.ConsoleUI.Controllers;
//using ProductCatalog.BusinessLogic.Interfaces;
//using ProductCatalog.BusinessLogic.Services;
//using ProductCatalog.DataAccess.Repositories;
//using ProductCatalog.DataAccess.Interfaces;
//using ProductCatalog.DataAccess.Data;

//namespace ProductCatalog.ConsoleUI
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            var config = GetConfiguration();
//            var serviceProvider = GetServiceProvider(config);
//            var productController = serviceProvider.GetService<ProductController>();
//            var categoryController = serviceProvider.GetService<CategoryController>();
//            Product product = new();
//            Category category = new();
//            int menu = 0;
//            do
//            {
//                Console.WriteLine("1 - Продукты | 2 - Категории | 0 - Выйти");
//                Int32.TryParse(Console.ReadLine(), out menu);
//                Console.Clear();
//                switch (menu)
//                {
//                    case 1:
//                        Console.WriteLine("***Продукты***");
//                        int pMenu;
//                        Console.WriteLine("1 - Список всех продуктов | 2 - Добавить продукт | 3 - Изменить продукт " +
//                            "| 4 - Удалить продукт или категорию | 5 - Посмотреть продкуты категории");
//                        Int32.TryParse(Console.ReadLine(), out pMenu);
//                        Console.Clear();
//                        if (pMenu == 1)
//                        {
//                            Console.WriteLine("Все продукты: ");
//                            Console.WriteLine("-----------------------------");
//                            foreach (var p in productController.GetProducts())
//                            {                               
//                                Console.WriteLine($"Название: {p.Name}");
//                                Console.WriteLine($"Цена: {p.Price} грн");
//                                Console.WriteLine($"Описание: {p.Description}");
//                                Console.WriteLine("Категории продукта: ");
//                                foreach (var c in p.Categories.OrderBy(n=>n.Name))
//                                {
//                                    Console.WriteLine(c.Name);
//                                }
//                                Console.WriteLine("*********************");
//                            }
//                            Console.WriteLine("Нажмите Enter что бы вернутся назад");
//                            Console.ReadLine();
//                            Console.Clear();
//                        }
//                        else if (pMenu == 2)
//                        {
//                            int selectCategoryId;
//                            Console.WriteLine("Все категории: ");
//                            var categories = categoryController.GetAllCategories();
//                            foreach (var c in categories)
//                            {
//                                Console.WriteLine($"{c.Id} - {c.Name}");
//                            }
//                            Console.WriteLine("Выберете категорию к которой хотите присвоить продукт: ");
//                            Int32.TryParse(Console.ReadLine(), out selectCategoryId);
//                            var selectedCategory = categories.First(s=>s.Id == selectCategoryId);
//                            product.Categories = new List<Category>() { selectedCategory };
//                            Console.Clear();
//                            Console.Write("Название продукта: ");
//                            product.Name = Console.ReadLine();
//                            Console.Write("Цена: ");
//                            product.Price = Convert.ToDecimal(Console.ReadLine());
//                            Console.Write("Описание: ");
//                            product.Description = Console.ReadLine();
//                            productController.AddProduct(product);
//                            Console.WriteLine("Нажмите Enter что бы выйти");
//                            Console.ReadLine();
//                            Console.Clear();
//                        }
//                        else if (pMenu == 3)
//                        {
//                            int selectProductId;
//                            Console.WriteLine("***Продукты***");
//                            foreach (var p in productController.GetProducts())
//                            {
                                                             
//                                Console.WriteLine($"ID: {p.Id}, Название: {p.Name}, Цена: {p.Price}\nОписание: {p.Description}");
//                                Console.WriteLine("###############");
//                            }
//                            Console.WriteLine("Напишете ID продукта который хотите изменить: ");
//                            Int32.TryParse(Console.ReadLine(), out selectProductId);
//                            var selectedProduct = productController.GetProductById(selectProductId);
//                            Console.Clear();
//                            int changeMenu;
//                            Console.WriteLine("1 - Обновить категорию | 2 - Добавить категорию | 3 - Изменить информацию о продукте");
//                            Int32.TryParse(Console.ReadLine(), out changeMenu);
//                            Console.Clear();
//                            if (changeMenu == 1)
//                            {
//                                int changeCategoryId;
//                                var products = productController.GetProducts();
//                                foreach (var p in products)
//                                {                                   
//                                    Console.WriteLine($"Название: {p.Name}");
//                                    Console.WriteLine("Категории: ");
//                                    foreach (var c in p.Categories.OrderBy(n => n.Name))
//                                    {
//                                        Console.WriteLine($"{c.Id} - {c.Name}");
//                                    }
//                                    Console.WriteLine("################");
//                                }
//                                Console.WriteLine("Введите ID категории которую хотите изменить: ");
//                                Int32.TryParse(Console.ReadLine(), out changeCategoryId);
//                                var selectedCategory = categoryController.GetCategoryById(changeCategoryId);
//                                Console.Clear();
//                                Console.Write("Новое название категории: ");
//                                selectedCategory.Name = Console.ReadLine();
//                                categoryController.UpdateCategoty(selectedCategory);
//                                Console.WriteLine("Нажмите Enter что бы выйти");
//                                Console.ReadLine();
//                                Console.Clear();
//                            }
//                            else if (changeMenu == 2)
//                            {
//                                int setCategory;
//                                var categories = categoryController.GetAllCategories();
//                                foreach (var c in categories)
//                                {
//                                    Console.WriteLine($"{c.Id} - {c.Name}");
//                                }
//                                Console.WriteLine("Выберите ID категории которую хотите добавить: ");
//                                Int32.TryParse(Console.ReadLine(), out setCategory);
//                                var selectedSetCategory = categoryController.GetCategoryById(setCategory);
//                                Console.Clear();
//                                if (!selectedProduct.Categories.Any(i => i.Id == setCategory))
//                                {
//                                    selectedProduct.Categories.Add(selectedSetCategory);
//                                    productController.UpdateProduct(selectedProduct);
//                                    Console.WriteLine("Категория добавлена!");
//                                }
//                                else
//                                    Console.WriteLine("Такая категория уже есть!");
//                                Console.WriteLine("Нажмите Enter что бы выйти");
//                                Console.ReadLine();
//                                Console.Clear();
//                            }
//                            else if (changeMenu == 3)
//                            {
//                                int changeProductMenu = 0;
//                                do
//                                {
//                                    Console.WriteLine("1 - Изменить название | 2 - Изменить цену | 3 - Изменить описание | 0 - Закончить изменение");
//                                    Int32.TryParse(Console.ReadLine(), out changeProductMenu);
//                                    if (changeProductMenu == 1)
//                                    {
//                                        Console.Write("Введите новое название продукта: ");
//                                        selectedProduct.Name = Console.ReadLine();
//                                        productController.UpdateProduct(selectedProduct);
//                                        Console.WriteLine("Название изменено! Нажмите Enter что бы вернутся назад");
//                                        Console.ReadLine();
//                                        Console.Clear();
//                                    }
//                                    if (changeProductMenu == 2)
//                                    {
//                                        Console.Write("Введите новую цену: ");
//                                        selectedProduct.Price = Convert.ToDecimal(Console.ReadLine());
//                                        productController.UpdateProduct(selectedProduct);
//                                        Console.WriteLine("Цена изменена! Нажмите Enter что бы вернутся назад");
//                                        Console.ReadLine();
//                                        Console.Clear();
//                                    }
//                                    if (changeProductMenu == 3)
//                                    {
//                                        Console.WriteLine("Введите новое описание");
//                                        selectedProduct.Description = Console.ReadLine();
//                                        productController.UpdateProduct(selectedProduct);
//                                        Console.WriteLine("Описание изменено! Нажмите Enter что бы вернутся назад");
//                                        Console.ReadLine();
//                                        Console.Clear();
//                                    }
//                                }
//                                while(changeProductMenu != 0);
//                                Console.Clear();
//                            }
//                        }
//                        else if (pMenu == 4)
//                        {
//                            int delete;
//                            int selectProductId;                            
//                            Console.WriteLine("***УДАЛЕНИЕ***");
//                            Console.WriteLine("1 - Удалить продукт | 2 - Удалить категорию продукта");
//                            Int32.TryParse(Console.ReadLine(), out delete);
//                            Console.Clear();
//                            if (delete == 1)
//                            {                               
//                                Console.WriteLine("***Продукты***");
//                                foreach (var p in productController.GetProducts())
//                                {
//                                    Console.WriteLine($"{p.Id}: {p.Name} - {p.Price}");
//                                    Console.WriteLine("---------------------");
//                                }
//                                Console.Write("Введите ID продукта который хотите удалить: ");
//                                Int32.TryParse(Console.ReadLine(), out selectProductId);
//                                var selectedProduct = productController.GetProductById(selectProductId);
//                                productController.DeleteProduct(selectedProduct);
//                                Console.WriteLine("Продукт удалён! Нажмите Enter что бы вернутся назад");
//                                Console.ReadLine();
//                                Console.Clear();
//                            }
//                            if (delete == 2)
//                            {
//                                int selectCategoryId;                               
//                                Console.WriteLine("***Продукты***");
//                                foreach (var p in productController.GetProducts())
//                                {
//                                    Console.WriteLine($"{p.Id} - {p.Name}");                                   
//                                }
//                                Console.Write("Выберите ID продукта категорию которого хотите поменять: ");
//                                Int32.TryParse(Console.ReadLine(), out selectProductId);
//                                var selectedProduct = productController.GetProductById(selectProductId);
//                                Console.Clear();
//                                if (selectedProduct.Categories.Count >= 1)
//                                {
//                                    foreach (var c in selectedProduct.Categories.OrderBy(n => n.Name))
//                                    {
//                                        Console.WriteLine($"{c.Id} - {c.Name}");                                        
//                                    }
//                                    Console.Write("Выберите ID категории которую хотите удалить: ");
//                                    Int32.TryParse(Console.ReadLine(), out selectCategoryId);
//                                    var selectedCategory = categoryController.GetCategoryById(selectCategoryId);
//                                    Console.Clear();
//                                    if (selectedCategory != null)
//                                    {
//                                        categoryController.DeleteCategory(selectedCategory);
//                                        Console.WriteLine("Категория удалена! Нажмите Enter что бы вернутся назад");                                    
//                                    }
//                                    else
//                                        Console.WriteLine("Не верный ID! Нажмите Enter что бы венутся");
//                                    Console.ReadLine();
//                                    Console.Clear();
//                                }
//                                else
//                                    Console.WriteLine("Ошибка! Категорий нет");                             
//                                Console.Clear();                            
//                            }
//                        }
//                        else if (pMenu == 5)
//                        {
//                            Console.WriteLine("Все категории: ");
//                            var categories = categoryController.GetAllCategories();
//                            foreach (var c in categories)
//                            {
//                                Console.WriteLine($"{c.Id} - {c.Name}");
//                            }
//                            Console.Write("Выберите Id категории: ");
//                            Int32.TryParse(Console.ReadLine(), out pMenu);
//                            Console.Clear();                    
//                            var productsByCategory = productController.GetProductByCategoryId(pMenu);
//                            if (productsByCategory.Count > 0)
//                            {                               
//                                foreach (var p in productsByCategory)
//                                {
//                                    Console.WriteLine(p.Name);
//                                }
//                            }
//                            else if (productsByCategory.Count == 0)
//                            {
//                                Console.WriteLine("Не найдено продуктов с данной категорией");
//                            }
//                            Console.WriteLine("Нажмите Enter что бы вернутся назад");
//                            Console.ReadLine();
//                            Console.Clear();
//                        } 
//                        break;
//                    case 2:
//                        Console.WriteLine("***Категории***");
//                        int cMenu;
//                        Console.WriteLine("1 - Посмотреть все категории | 2 - Создать категорию");
//                        Int32.TryParse(Console.ReadLine(), out cMenu);                       
//                        Console.Clear();
//                        if (cMenu == 1)
//                        {
//                            Console.WriteLine("Все доступные категории: ");
//                            Console.WriteLine("-----------------------------");
//                            var categories = categoryController.GetAllCategories();
//                            foreach (var c in categories)
//                            {
//                                Console.WriteLine($"Категория: {c.Name}");
//                                if (c.ParentCategory != null)
//                                {
//                                    Console.WriteLine($"Родительская категория: {c.ParentCategory.Name}");
//                                }
//                                if (c.ChildCategories != null)
//                                {
                                    
//                                    foreach (var p in c.ChildCategories)
//                                    {
//                                        Console.WriteLine($"Подкатегория: {p.Name}");
//                                    }
//                                }
                                
//                            }
//                            Console.WriteLine("-----------------------------");
//                            Console.WriteLine("Нажмите Enter что бы вернутся назад");
//                            Console.ReadLine();
//                            Console.Clear();
//                        }
//                        else if (cMenu == 2)
//                        {
//                            int createCategoryMenu;
//                            category = new();
//                            Console.WriteLine("1 - Добавить категорию | 2 - Добавить подкатегорию");
//                            Int32.TryParse(Console.ReadLine(), out createCategoryMenu);
//                            Console.Clear();
//                            if (createCategoryMenu == 1)
//                            {
//                                Console.Write("Название категории: ");
//                                category.Name = Console.ReadLine();
//                                categoryController.AddCategory(category);
//                                Console.WriteLine("-----------------------------");
//                                Console.WriteLine("Нажмите Enter что бы вернутся назад");
//                                Console.ReadLine();
//                                Console.Clear();                             
//                            }
//                            if (createCategoryMenu == 2)
//                            {                                
//                                var categories = categoryController.GetAllCategories();
//                                foreach (var c in categories)
//                                {
//                                    Console.WriteLine($"{c.Id} - {c.Name}");
//                                }
//                                Console.WriteLine("----------------");
//                                Console.WriteLine("Выберите ID категории: ");
//                                Int32.TryParse(Console.ReadLine(), out createCategoryMenu);                    
//                                Console.Clear();
//                                Console.WriteLine("Введите название подкатегории: ");
//                                category.Name = Console.ReadLine();
//                                category.ParentCategoryId = createCategoryMenu;
//                                categoryController.AddCategory(category);
//                                Console.WriteLine("Подкатегория добавлена! Нажмите Enter что бы вернутся");
//                                Console.ReadLine();
//                                Console.Clear();
//                            }
                            
//                        }                     
//                        break;
//                }
//            }
//            while (menu != 0);

//        }
//        static IConfiguration GetConfiguration()
//        {
//            var builder = new ConfigurationBuilder();
//            builder.SetBasePath(Directory.GetCurrentDirectory());
//            builder.AddJsonFile("appsettings.json");
//            return builder.Build();
//        }
//        static IServiceProvider GetServiceProvider(IConfiguration config)
//        {
//            var connectionString = config.GetConnectionString("DeffaultConnection");
//            IServiceCollection services = new ServiceCollection();
//            services.AddTransient<ICategoryRepository, CategoryRepository>()
//                .AddTransient<ICategoryService, CategoryService>()
//                .AddTransient<IProductRepository, ProductRepository>()
//                .AddTransient<IProductService, ProductService>()
//                .AddTransient<CategoryController>()
//                .AddTransient<ProductController>()
//                .AddDbContext<ProductContext>(options => options.UseSqlite(connectionString));
//            services.AddScoped<ProductContext>();
//            return services.BuildServiceProvider();
//        }

//    }
//}
    
