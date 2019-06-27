using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBook();
        Book GetBookById(int id);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);

        CategoriesBooksAvtors GetAllTables();
    }
}
