using Microsoft.EntityFrameworkCore;
using ProductCatalog.BusinessLogic.Interfaces;
using ProductCatalog.BusinessLogic.Services;
using ProductCatalog.ConsoleUI.Controllers;
using ProductCatalog.DataAccess.Data;
using ProductCatalog.DataAccess.Interfaces;
using ProductCatalog.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DeffaultConnection");
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IProductService, ProductService>()
                .AddTransient<CategoryController>()
                .AddTransient<ProductController>()
                .AddDbContext<ProductContext>(options => options.UseSqlite(connectionString));
builder.Services.AddScoped<ProductContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseRouting();
app.MapControllers();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();