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

        public void CreateBook(Book book)
        {
            _bookRepository.CreateBook(book);
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }

        public IEnumerable<Book> GetAllBook()
        {
            IEnumerable<Book> bookItems = _bookRepository.GetAllBook();
            return bookItems;
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.UpdateBook(book);
        }

        public CategoriesBooksAvtors GetAllTables()
        {
            return _bookRepository.GetAllTables();
        }
    }
}
