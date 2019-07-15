using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BookStore.DAL.Enums;
using System.Data.SqlClient;
using System.Data;

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

        public CategoriesBooksAuthorsDTO GetAllTables()
        {
            CategoriesBooksAuthorsDTO categoriesBooksAvtors = new CategoriesBooksAuthorsDTO();
            categoriesBooksAvtors.Books = _booksContext.Books.ToList();
            categoriesBooksAvtors.Authors = _booksContext.Avtors.ToList();
            categoriesBooksAvtors.Categories = _booksContext.Categories.ToList();
            categoriesBooksAvtors.Comments = _booksContext.Comments.ToList();

            return categoriesBooksAvtors;
        }
    }
}
