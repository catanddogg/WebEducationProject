using System.Threading.Tasks;
using BookStore.Common.ViewModels.AuthorsController.Get;
using BookStore.Common.ViewModels.AuthorsController.Post;
using BookStore.Common.ViewModels.AuthorsController.Put;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AddTestCors")]
    [Authorize]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAllAuthors")]
        public async Task<AllAuthorViewModel> GetAllAuthors()
        {
            AllAuthorViewModel result = await _authorService.GetAllAuthorsAsync();

            return result;
        }

        [AllowAnonymous]
        [HttpGet("GetAuthorById/{id}")]
        public async Task<AuthorByIdViewModel> GetAuthorById(int id)
        {
            AuthorByIdViewModel authorByIdViewModel = await _authorService.GetAuthorByIdAsync(id);

            return authorByIdViewModel;
        }

        [HttpPost("CreateAuthor")]
        public async Task CreateAuthor(CreateAuthorViewModel createAuthorViewModel)
        {
            await _authorService.CreateAuthorAsync(createAuthorViewModel);
        }

        [HttpPut("UpdateAuthor")]
        public async Task UpdateAuthor(UpdateAuthorViewModel updateAuthorViewModel)
        {
            await _authorService.UpdateAuthorAsync(updateAuthorViewModel);
        }

        [HttpDelete("DeleteAuthor/{id}")]
        public async Task DeleteAuthor(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
        }

        [HttpGet("GetAuthorsBooks/{author}")]
        public async Task<AuthorBooksViewModel> GetAuthorsBooks(string author)
        {
            AuthorBooksViewModel bookItem = await _authorService.GetAuthorBooksAsync(author);

            return bookItem;
        }

        //[HttpGet("GetPublishersBooks/{publisher}")]
        //public async Task<PublishersBooksViewModel> GetPublishersBooks(string publisher)
        //{
        //    PublishersBooksViewModel bookItem = await _authorService.GetPublisherBooksAsync(publisher);

        //    return bookItem;
        //}
    }
}