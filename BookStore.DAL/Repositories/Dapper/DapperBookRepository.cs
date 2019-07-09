using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using System.Linq;
using BookStore.DAL.Enums;

namespace BookStore.DAL.Repositories.Dapper
{
    public class DapperBookRepository : BaseDapperRepository<Book>, IBookRepository
    {
        private IDbConnection _connectionString;
        public DapperBookRepository(IDbConnection connectionString)
            : base(connectionString)
        {
            _connectionString = connectionString;
        }

        //public void CreateBook(Book book)
        //{
        //    SqlMapperExtensions.Insert(_connectionString, book);
        //}

        //public void DeleteBook(int id)
        //{
        //    Book book = SqlMapperExtensions.Get<Book>(_connectionString, id);
        //    if (book != null)
        //    {
        //        SqlMapperExtensions.Delete(_connectionString, book);
        //    }
        //}

        //public IEnumerable<Book> GetAllBook()
        //{
        //    IEnumerable<Book> books = SqlMapperExtensions.GetAll<Book>(_connectionString);
        //    return books;
        //}

        public CategoriesBooksAvtors GetAllTables()
        {
            IEnumerable<Book> books = SqlMapperExtensions.GetAll<Book>(_connectionString);
            IEnumerable<Avtor> avtors = SqlMapperExtensions.GetAll<Avtor>(_connectionString);
            IEnumerable<Category> categories = SqlMapperExtensions.GetAll<Category>(_connectionString);
            IEnumerable<Comment> comments = SqlMapperExtensions.GetAll<Comment>(_connectionString);

            CategoriesBooksAvtors categoriesBooksAvtors = new CategoriesBooksAvtors();
            categoriesBooksAvtors.Books.AddRange(books);
            categoriesBooksAvtors.Avtors.AddRange(avtors);
            categoriesBooksAvtors.Categories.AddRange(categories);
            categoriesBooksAvtors.Comments.AddRange(comments);

            return categoriesBooksAvtors;
        }

        //public Book GetBookById(int id)
        //{
        //    Book books = SqlMapperExtensions.Get<Book>(_connectionString, id);
        //    return books;
        //}

        //public void UpdateBook(Book book)
        //{
        //    SqlMapperExtensions.Update<Book>(_connectionString, book);
        //} 
    }
}
