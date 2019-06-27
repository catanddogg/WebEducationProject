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
    public class DapperBookRepository : IBookRepository
    {
        private string _connectionString;
        public DapperBookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateBook(Book book)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                SqlMapperExtensions.Insert(db, book);
            }
        }

        public void DeleteBook(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Book book = SqlMapperExtensions.Get<Book>(db, id);
                if (book != null)
                {
                    SqlMapperExtensions.Delete(db, book);
                }
            }
        }

        public IEnumerable<Book> GetAllBook()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                IEnumerable<Book> books = SqlMapperExtensions.GetAll<Book>(db);
                return books;
            }
        }

        public CategoriesBooksAvtors GetAllTables()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                IEnumerable<Book> books = SqlMapperExtensions.GetAll<Book>(db);
                IEnumerable<Avtor> avtors = SqlMapperExtensions.GetAll<Avtor>(db);
                IEnumerable<Category> categories = SqlMapperExtensions.GetAll<Category>(db);

                CategoriesBooksAvtors categoriesBooksAvtors = new CategoriesBooksAvtors();
                categoriesBooksAvtors.Books.AddRange(books);
                categoriesBooksAvtors.Avtors.AddRange(avtors);
                categoriesBooksAvtors.Categories.AddRange(categories);

                return categoriesBooksAvtors;
            }
        }

        public Book GetBookById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Book books = SqlMapperExtensions.Get<Book>(db, id);
                return books;
            }
        }

        public void UpdateBook(Book book)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                SqlMapperExtensions.Update<Book>(db, book);
            }
        }    
    }
}
