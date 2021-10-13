using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DataAccess.Domains
{
    public class DbContextSeeder
    {
        public static async Task SeedAsync(RabbitMqDbContext context, ILogger<DbContextSeeder> logger)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(GeInitialUsers());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(RabbitMqDbContext).Name);
            }
        }

        private static IEnumerable<User> GeInitialUsers()
        {
            return new List<User>
            {
                new User
                {
                    Username = "user1",
                    Password = "123"
                },
                new User
                {
                    Username = "mmzb",
                    Password = "12345"
                },
                new User
                {
                    Username = "user3",
                    Password = "125063"
                }
            };
        }
    }
}