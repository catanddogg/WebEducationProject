using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private BooksContext _booksContext;

        public AuthorRepository(BooksContext booksContext)
           : base(booksContext)
        {
            _booksContext = booksContext;
        }

        public async Task<List<Author>> GetAuthorBooksAsync(string author)
        {
            List<Author> bookItem = await _dbSet.ToListAsync();

            return bookItem;
        }

        //public async Task<List<Author>> GetPublisherBooksAsync(string publisher)
        //{
        //    List<Author> bookItem = await _dbSet.Where(x => x.Publisher == publisher).ToListAsync();

        //    return bookItem;
        //}
    }
}
