using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Common.ViewModels.AuthorsController.Get;
using BookStore.Common.ViewModels.AuthorsController.Post;
using BookStore.Common.ViewModels.AuthorsController.Put;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        //GET : /api/authors
        [HttpGet]
        public AllAuthorViewModel GetAllAuthors()
        {
            return _authorService.GetAllAuthors();
        }

        //GET : api/authors/{id}
        [AllowAnonymous]
        [HttpGet("{id}")]
        public AuthorByIdViewModel GetAuthorById(int id)
        {
            AuthorByIdViewModel authorByIdViewModel = _authorService.GetAuthorById(id);
            return authorByIdViewModel;
        }

        // POST : api/authors
        [HttpPost]
        public void CreateAuthor(CreateAuthorViewModel createAuthorViewModel)
        {
            _authorService.CreateAuthor(createAuthorViewModel);
        }

        //PUT : api/authors
        [HttpPut]
        public void UpdateAuthor(UpdateAuthorViewModel updateAuthorViewModel)
        {
            _authorService.UpdateAuthor(updateAuthorViewModel);
        }

        //Delete : api/authors
        [HttpDelete]
        public void DeleteAuthor(int id)
        {
            _authorService.DeleteAuthor(id);
        }

        // GET /api/authors/author/{author}
        [HttpGet("avtor/{avtor}")]
        public AuthorBooksViewModel GetAuthorBooks(string author)
        {
            AuthorBooksViewModel bookItem = _authorService.GetAuthorBooks(author);
            return bookItem;
        }

        // GET /api/authors/publisher/{publisher}
        [HttpGet("publisher/{publisher}")]
        public PublishersBooksViewModel GetPublishersBooks(string publisher)
        {
            PublishersBooksViewModel bookItem = _authorService.GetPublisherBooks(publisher);
            return bookItem;
        }
    }
}