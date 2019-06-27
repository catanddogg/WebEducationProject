using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBook();
        Book GetBookById(int id);
        void CreateBook(Book book);
        void DeleteBook(int id);
        void UpdateBook(Book book);

        CategoriesBooksAvtors GetAllTables();
    }
}
