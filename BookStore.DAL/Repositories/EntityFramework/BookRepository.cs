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
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {

        public BookRepository(BooksContext booksContext)
            : base(booksContext)
        {
        }
         
        public async Task<List<Book>> GetBooksWIthAuthorAndCategories()
        {
            List<Book> result = await _dbSet
                .Include(item => item.Author)
                .Include(item => item.Category)
                .ToListAsync();

            return result;
        }
    }
}
