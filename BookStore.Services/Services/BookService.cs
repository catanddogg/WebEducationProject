using AutoMapper;
using BookStore.Common.ViewModels.BooksController.Get;
using BookStore.Common.ViewModels.BooksController.Post;
using BookStore.Common.ViewModels.BooksController.Put;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void CreateBook(CreateBookViewModel createBookViewModel)
        {
            Book book = Mapper.Map<CreateBookViewModel, Book>(createBookViewModel);
            _bookRepository.Create(book);
        }

        public BookByIdViewModel GetBookById(int id)
        {
            Book book = _bookRepository.GetById(id);
            BookByIdViewModel bookByIdViewModel = Mapper.Map<Book, BookByIdViewModel>(book);
            return bookByIdViewModel;
        }

        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }

        public AllBookViewModel GetAllBook()
        {
            IEnumerable<Book> bookItems = _bookRepository.GetAll();
            AllBookViewModel allBookViewModel = Mapper.Map<IEnumerable<Book>, AllBookViewModel>(bookItems);
            return allBookViewModel;
        }

        public void UpdateBook(UpdateBookViewModel updateBookViewModel)
        {
            Book book = Mapper.Map<UpdateBookViewModel, Book>(updateBookViewModel);
            _bookRepository.Update(book);
        }

        public CategoriesBooksAuthors GetAllTables()
        {
            return _bookRepository.GetAllTables();
        }
    }
}
