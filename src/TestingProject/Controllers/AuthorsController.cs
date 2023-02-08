using DBAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TestingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorsController(IAuthorRepository authorRepository) 
        { 
            _authorRepository= authorRepository;
        }

        [HttpPost("articles")]
        public async Task<IActionResult> CreateArticle(string firstName, string lastName)
        {
            var res = await _authorRepository.CreateObject(new() 
            { 
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName
            });

            return Ok(res);
        }

        [HttpGet("articles")]
        public async Task<IActionResult> GetArticles() 
        {
            return Ok(await _authorRepository.GetObjects());
        }
    }
}
