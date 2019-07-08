using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: /api/books
        [Authorize]
        [HttpGet]
        public IEnumerable<Book> GetAllBook()
        {
            IEnumerable<Book> bookItems = _bookService.GetAllBook();
            return bookItems;
        }

        //GET :api/books/{id}
        [Authorize]
        [HttpGet("{id}")]
        public Book GetBookById(int id)
        {
            return _bookService.GetBookById(id);
        }

        //POST : api/books
        [Authorize]
        [HttpPost]
        public void CreateBook([FromBody]Book book)
        {
            _bookService.CreateBook(book);
        }

        //PUT : api/books
        [Authorize]
        [HttpPut]
        public void UpdateBook([FromBody]Book book)
        {
            _bookService.UpdateBook(book);
        }

        //DELETE : api/books/deletebook/{id}
        [Authorize]
        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
        }

        //GET : api/books/alltables
        [Authorize]
        [HttpGet("{alltables}")]
        public CategoriesBooksAvtors GetAllTables()
        {
            return _bookService.GetAllTables();
        }
    }
}
