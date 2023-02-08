using System.Diagnostics;

namespace TestingProject.Extensions
{
    public static class RedisExtension
    {
        public static void AddRedisCache(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration["CacheSettings:RedisConnectionString"];
            Debug.WriteLine(connectionString);
            Console.WriteLine(connectionString);
            builder.Services.AddStackExchangeRedisCache(opt => {
                opt.Configuration = connectionString;
                opt.InstanceName = "ArticleContextCache";
            });
        }
    }
}