using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Common.ViewModels.BooksController.Get;
using BookStore.Common.ViewModels.BooksController.Post;
using BookStore.Common.ViewModels.BooksController.Put;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    //[Authorize]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: /api/books
        [HttpGet]
        public AllBookViewModel GetAllBook()
        {
            AllBookViewModel bookItems = _bookService.GetAllBook();
            return bookItems;
        }

        //GET :api/books/{id}
        [HttpGet("{id}")]
        public BookByIdViewModel GetBookById(int id)
        {
            return _bookService.GetBookById(id);
        }

        //POST : api/books
        [HttpPost]
        public void CreateBook(CreateBookViewModel book)
        {
            //CreateBookViewModel book = null;
            _bookService.CreateBook(book);
        }

        //PUT : api/books
        [HttpPut]
        public void UpdateBook([FromBody]UpdateBookViewModel book)
        {
            _bookService.UpdateBook(book);
        }

        //DELETE : api/books/deletebook/{id}
        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
        }

        //GET : api/books/alltables
        [HttpGet("/alltables")]
        public CategoriesBooksAuthorsDTO GetAllTables()
        {
            return _bookService.GetAllTables();
        }
    }
}
