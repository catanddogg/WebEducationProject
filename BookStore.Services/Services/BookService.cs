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
        public BaseRequestViewModel CreateBook(BookViewModel model)
        {
            var result = new BaseRequestViewModel();

            Book book = _mapper.Map<BookViewModel, Book>(model);

            _bookRepository.Create(book);

            result.Message = "Book updated successfully";
            result.Success = true;

            return result;
        }

        public async Task<BookViewModel> GetBookById(int id)
        {
            Book book = await _bookRepository.GetBookById(id);

            BookViewModel bookByIdViewModel = _mapper.Map<Book, BookViewModel>(book);

            return bookByIdViewModel;
        }

        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }

        public async Task<AllBookViewModel> GetAllBook(string filter)
        {
            var result = new AllBookViewModel();

            List<Book> bookItems = await _bookRepository.GetBooksWIthAuthorAndCategories(filter);

            List<AllBookViewModelItem> allBookViewModel = _mapper.Map<List<AllBookViewModelItem>>(bookItems);

            result.Books = allBookViewModel;

            return result;
        }

        public BaseRequestViewModel UpdateBook(BookViewModel model)
        {
            var result = new BaseRequestViewModel();

            Book book = _mapper.Map<BookViewModel, Book>(model);

            _bookRepository.Update(book);

            result.Message = "Book updated successfully";
            result.Success = true;

            return result;
        }
        #endregion Public Methods
    }
}
