using System.Threading.Tasks;
using BookStore.Common.ViewModels.BaseViewModel;
using BookStore.Common.ViewModels.BooksController.Get;
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
            AllBookViewModel bookItems  = await _bookService.GetAllBookAsync(filter);

            return bookItems;
        }

        [HttpGet("GetBookById")]
        public async Task<BookViewModel> GetBookById(int bookId)
        {
            BookViewModel result = await _bookService.GetBookByIdAsync(bookId);

            return result;
        }

        [HttpPost("CreateBook")]
        public async Task<BaseRequestViewModel> CreateBook([FromBody]BookViewModel book)
        {
            BaseRequestViewModel result =  await _bookService.CreateBookAsync(book);

            return result;
        }
    
        [HttpPost("UpdateBook")]
        public async Task<BaseRequestViewModel> UpdateBook([FromBody]BookViewModel book)
        {
            BaseRequestViewModel result = await _bookService.UpdateBookAsync(book);

            return result;
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
        }
    }
}
