using DBAL.Models;

namespace DBAL.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetObjects();
        Task<Author> CreateObject(Author author);
    }
}
