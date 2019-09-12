using System.Threading.Tasks;
using BookStore.Common.ViewModels.BooksController.Get;
using BookStore.Common.ViewModels.BooksController.Post;
using BookStore.Common.ViewModels.BooksController.Put;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
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

        [HttpGet("GetAllBook")]
        public async Task<AllBookViewModel> GetAllBook()
        {
            AllBookViewModel bookItems  = await _bookService.GetAllBook();

            return bookItems;
        }

        [HttpGet("GetBookById/{id}")]
        public BookByIdViewModel GetBookById(int id)
        {
            BookByIdViewModel result = _bookService.GetBookById(id);

            return result;
        }

        [HttpPost("CreateBook")]
        public void CreateBook(CreateBookViewModel book)
        {
            _bookService.CreateBook(book);
        }

        [HttpPut("UpdateBook")]
        public void UpdateBook([FromBody]UpdateBookViewModel book)
        {
            _bookService.UpdateBook(book);
        }

        [HttpDelete("DeleteBook/{id}")]
        public void DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
        }
    }
}
