using DBAL.Repositories.Interfaces;
using DBAL.Repositories;

namespace TestingProject.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
        }
    }
}
