using AutoMapper;
using BookStore.Common.ViewModels.BaseViewModel;
using BookStore.Common.ViewModels.BooksController.Get;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class BookService : IBookService
    {
        #region Properties & Variables
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        #endregion Properties & Variables

        #region Constructors
        public BookService(IBookRepository bookRepository,
                          IMapper mapper)
        {
            _bookRepository = bookRepository;

            _mapper = mapper;
        }
        #endregion Constructors

        #region Public Methods
        public async Task<BaseRequestViewModel> CreateBookAsync(BookViewModel model)
        {
            var result = new BaseRequestViewModel();

            Book book = _mapper.Map<BookViewModel, Book>(model);

            await _bookRepository.InsertAsync(book);

            result.Message = "Book updated successfully";
            result.Success = true;

            return result;
        }

        public async Task<BookViewModel> GetBookByIdAsync(int id)
        {
            Book book = await _bookRepository.GetBookByIdAsync(id);

            BookViewModel bookByIdViewModel = _mapper.Map<Book, BookViewModel>(book);

            return bookByIdViewModel;
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<AllBookViewModel> GetAllBookAsync(string filter)
        {
            var result = new AllBookViewModel();

            List<Book> bookItems = await _bookRepository.GetBooksWIthAuthorAndCategoriesAsync(filter);

            result.Books = _mapper.Map<List<AllBookViewModelItem>>(bookItems);

            return result;
        }

        public async Task<BaseRequestViewModel> UpdateBookAsync(BookViewModel model)
        {
            var result = new BaseRequestViewModel();

            Book book = _mapper.Map<BookViewModel, Book>(model);

            await _bookRepository.UpdateAsync(book);
            
            result.Message = "Book updated successfully";
            result.Success = true;

            return result;
        }
        #endregion Public Methods
    }
}
