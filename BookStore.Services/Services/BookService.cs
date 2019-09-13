using AutoMapper;
using BookStore.Common.ViewModels.BooksController.Get;
using BookStore.Common.ViewModels.BooksController.Post;
using BookStore.Common.ViewModels.BooksController.Put;
using BookStore.DAL.Enums;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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
        public void CreateBook(CreateBookViewModel createBookViewModel)
        {
            Book book = _mapper.Map<CreateBookViewModel, Book>(createBookViewModel);

            _bookRepository.Create(book);
        }

        public BookByIdViewModel GetBookById(int id)
        {
            Book book = _bookRepository.GetById(id);

            BookByIdViewModel bookByIdViewModel = _mapper.Map<Book, BookByIdViewModel>(book);

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

        public void UpdateBook(UpdateBookViewModel updateBookViewModel)
        {
            Book book = _mapper.Map<UpdateBookViewModel, Book>(updateBookViewModel);

            _bookRepository.Update(book);
        }
        #endregion Public Methods
    }
}
