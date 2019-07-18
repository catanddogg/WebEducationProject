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

namespace BookStore.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
        }

        public void CreateBook(CreateBookViewModel createBookViewModel)
        {
            Book book = Mapper.Map<CreateBookViewModel, Book>(createBookViewModel);
            //Book book = new Book() { Name = "TestBook2", Path = "test2" };
            //_bookRepository.Create(book);

            //Author author = new Author() { NameAuthor = "TestAuthor2", Publisher = "TestPublisher2", Book = book, BookId = book.Id };
            //_authorRepository.Create(author);

            //Category category = new Category() { CategoryType = CategoryType.Drama, Book = book, BookId = book.Id };
            //_categoryRepository.Create(category);
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

        public CategoriesBooksAuthorsDTO GetAllTables()
        {
            return _bookRepository.GetAllTables();
        }
    }
}
