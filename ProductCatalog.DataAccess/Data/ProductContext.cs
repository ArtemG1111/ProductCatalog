﻿

using Microsoft.EntityFrameworkCore;
using ProductCatalog.DataAccess.Data.Models;
using System.Reflection;

namespace ProductCatalog.DataAccess.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) 
        {
            
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
