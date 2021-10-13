using DataAccess.Domains;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Producer.Extensions;

namespace Producer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
             .Build()
             .MigrateDatabase<RabbitMqDbContext>((context, services) =>
                 {
                     var logger = services.GetService<ILogger<DbContextSeeder>>();
                     DbContextSeeder
                         .SeedAsync(context, logger)
                         .Wait();
                 })
             .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}