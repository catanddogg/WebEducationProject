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
            AllAuthorViewModel result = await _authorService.GetAllAuthors();

            return result;
        }

        [AllowAnonymous]
        [HttpGet("GetAuthorById/{id}")]
        public AuthorByIdViewModel GetAuthorById(int id)
        {
            AuthorByIdViewModel authorByIdViewModel = _authorService.GetAuthorById(id);

            return authorByIdViewModel;
        }

        [HttpPost("CreateAuthor")]
        public void CreateAuthor(CreateAuthorViewModel createAuthorViewModel)
        {
            _authorService.CreateAuthor(createAuthorViewModel);
        }

        [HttpPut("UpdateAuthor")]
        public void UpdateAuthor(UpdateAuthorViewModel updateAuthorViewModel)
        {
            _authorService.UpdateAuthor(updateAuthorViewModel);
        }

        [HttpDelete("DeleteAuthor/{id}")]
        public void DeleteAuthor(int id)
        {
            _authorService.DeleteAuthor(id);
        }

        [HttpGet("GetAuthorsBooks/{author}")]
        public async Task<AuthorBooksViewModel> GetAuthorsBooks(string author)
        {
            AuthorBooksViewModel bookItem = await _authorService.GetAuthorBooks(author);

            return bookItem;
        }

        [HttpGet("GetPublishersBooks/{publisher}")]
        public async Task<PublishersBooksViewModel> GetPublishersBooks(string publisher)
        {
            PublishersBooksViewModel bookItem = await _authorService.GetPublisherBooks(publisher);

            return bookItem;
        }
    }
}