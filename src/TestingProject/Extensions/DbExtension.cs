using DBAL;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace TestingProject.Extensions
{
    public static class DbExtension
    {
        public static void AddDbContext(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration["DbContextSettings:ConnectionString"];
            Debug.WriteLine(connectionString);
            Console.WriteLine(connectionString);
            builder.Services.AddDbContext<ArticleContext>(
                opts => opts.UseNpgsql(connectionString)
            );
        }

        public static async Task RunDbMigrationsAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dataContext = scope.ServiceProvider.GetRequiredService<ArticleContext>();
            await dataContext.Database.EnsureCreatedAsync();
        }
    }
}
