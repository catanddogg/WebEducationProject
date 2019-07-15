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
    public class BookRepository : BaseRepository<BooksContext, Book>, IBookRepository
    {
        private BooksContext _booksContext;

        public BookRepository(BooksContext booksContext)
            : base (booksContext)
        {
            _booksContext = booksContext;
        }

        public CategoriesBooksAvtors GetAllTables()
        {
            DbSet<Book> books = _booksContext.Set<Book>();
            DbSet<Author> authors = _booksContext.Set<Author>();
            DbSet<Category> categories = _booksContext.Set<Category>();
            DbSet<Comment> comments = _booksContext.Set<Comment>();
            
            CategoriesBooksAvtors categoriesBooksAvtors = new CategoriesBooksAvtors();
            categoriesBooksAvtors.Books.AddRange(books);
            categoriesBooksAvtors.Avtors.AddRange(authors);
            categoriesBooksAvtors.Categories.AddRange(categories);
            categoriesBooksAvtors.Comments.AddRange(comments);

            return categoriesBooksAvtors;
        }
    }
}
