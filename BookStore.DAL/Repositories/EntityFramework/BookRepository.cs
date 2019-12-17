using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BookStore.DAL.Enums;
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

        public async Task<List<Book>> GetBooksWIthAuthorAndCategoriesAsync(string filter)
        {

            IQueryable<Book> resultQueryable = _dbSet
          .Include(item => item.Author)
          .Include(item => item.Category).AsQueryable();

            if (filter != null)
            {
                resultQueryable = resultQueryable
                    .Where(item => item.Name.Contains(filter)
                   || item.Path.Contains(filter)
                   || item.Author.NameAuthor.Contains(filter)
                   || item.Author.Publisher.Contains(filter)
                   /*|| item.Category.FirstCategoryType.ToString().Contains(filter)*/);
            }

            List<Book> result = null;

            result = await resultQueryable.ToListAsync();

            return result;
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            Book result = await _dbSet
                .Include(item => item.Author)
                .Include(item => item.Category)
                .Where(item => item.Id == bookId)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
