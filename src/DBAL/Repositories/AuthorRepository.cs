using DBAL.Models;
using DBAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace DBAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ArticleContext _articleContext;
        private readonly IDistributedCache _cache;
        public AuthorRepository(ArticleContext articleContext, IDistributedCache cache)
        {
            _articleContext = articleContext;
            _cache = cache;
        }

        public async Task<Author> CreateObject(Author author)
        {
            var result = await _articleContext.Authors.AddAsync(author);
            await _articleContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<Author>> GetObjects()
        {
            List<Author>? authors;
            string recordKey = $"Users_{DateTime.Now:yyyyMMdd_hhmm}";

            authors = await _cache.GetRecordAsync<List<Author>>(recordKey); // Get data from cache

            if (authors is null) // Data not available in the Cache
            {
                authors = await _articleContext.Authors.ToListAsync();// Read data from database
                await _cache.SetRecordAsync(recordKey, authors); // Set cache
            }

            return await _articleContext.Authors.ToListAsync();
        }
    }
}
