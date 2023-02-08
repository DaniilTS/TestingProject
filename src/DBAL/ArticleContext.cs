using DBAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DBAL
{
    public class ArticleContext: DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
