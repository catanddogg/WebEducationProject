using System.Threading.Tasks;
using BookStore.Common.ViewModels.BaseViewModel;
using BookStore.Common.ViewModels.BooksController.Get;
using BookStore.Common.ViewModels.BooksController.Post;
using BookStore.Common.ViewModels.BooksController.Put;
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
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBook")]
        public async Task<AllBookViewModel> GetAllBook(string filter)
        {
            AllBookViewModel bookItems  = await _bookService.GetAllBook(filter);

            return bookItems;
        }

        [HttpGet("GetBookById")]
        public async Task<BookViewModel> GetBookById(int bookId)
        {
            BookViewModel result = await _bookService.GetBookById(bookId);

            return result;
        }

        [HttpPost("CreateBook")]
        public BaseRequestViewModel CreateBook([FromBody]BookViewModel book)
        {
            BaseRequestViewModel result =  _bookService.CreateBook(book);

            return result;
        }
    
        [HttpPost("UpdateBook")]
        public BaseRequestViewModel UpdateBook([FromBody]BookViewModel book)
        {
            BaseRequestViewModel result = _bookService.UpdateBook(book);

            return result;
        }

        [HttpDelete("DeleteBook/{id}")]
        public void DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
        }
    }
}
