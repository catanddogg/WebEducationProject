using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class AuthorRepository : BaseRepository<BooksContext, Author>, IAuthorRepository
    {
        private BooksContext _booksContext;

        public AuthorRepository(BooksContext booksContext)
           : base(booksContext)
        {
            _booksContext = booksContext;
        }

        public IEnumerable<Author> GetAuthorBooks(string author)
        {
            List<Author> bookItem = _booksContext.Avtors.Where(x => x.NameAuthor == author).ToList();
            return bookItem;
        }

        public IEnumerable<Author> GetPublisherBooks(string publisher)
        {
            List<Author> bookItem = _booksContext.Avtors.Where(x => x.Publisher == publisher).ToList();
            return bookItem;
        }
    }
}
