
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace ProductCatalog.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = GetConfiguration();
            var serviceProvider = GetServiceProvider(config);

        }
        static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettiings.json");
            return builder.Build();
        }
        static IServiceProvider GetServiceProvider(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DeffaultConnection");
            IServiceCollection services = new ServiceCollection();
            return services.BuildServiceProvider();
        }

    }
}
    
