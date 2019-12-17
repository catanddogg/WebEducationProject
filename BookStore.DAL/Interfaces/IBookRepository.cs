using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<List<Book>> GetBooksWIthAuthorAndCategoriesAsync(string filter);
        Task<Book> GetBookByIdAsync(int bookId);
    }
}
