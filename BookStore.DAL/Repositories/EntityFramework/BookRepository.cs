using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BookStore.DAL.Enums;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class BookRepository : IBookRepository
    {
        private BooksContext _booksContext;

        public BookRepository(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        public void CreateBook(Book book)
        {
            _booksContext.Add(book);
            _booksContext.SaveChanges();
        }
        public IEnumerable<Book> GetAllBook()
        {
            DbSet<Book> books = _booksContext.Set<Book>();
            return books;
        }

        public void DeleteBook(int id)
        {
            Book book = _booksContext.Find<Book>(id);
            if(book != null)
            {
                _booksContext.Remove(book);
                _booksContext.SaveChanges();
            }
        }

        public Book GetBookById(int id)
        {
            Book bookItem = _booksContext.Find<Book>(id);
            return bookItem;
        }

        public void UpdateBook(Book book)
        {
            _booksContext.Entry(book).State = EntityState.Modified;
            _booksContext.SaveChanges();
        }

        public CategoriesBooksAvtors GetAllTables()
        {
            DbSet<Book> books = _booksContext.Set<Book>();
            DbSet<Avtor> avtors = _booksContext.Set<Avtor>();
            DbSet<Category> categories = _booksContext.Set<Category>();
            DbSet<Comment> comments = _booksContext.Set<Comment>();

            CategoriesBooksAvtors categoriesBooksAvtors = new CategoriesBooksAvtors();
            categoriesBooksAvtors.Books.AddRange(books);
            categoriesBooksAvtors.Avtors.AddRange(avtors);
            categoriesBooksAvtors.Categories.AddRange(categories);
            categoriesBooksAvtors.Comments.AddRange(comments);

            return categoriesBooksAvtors;
        }
    }
}
