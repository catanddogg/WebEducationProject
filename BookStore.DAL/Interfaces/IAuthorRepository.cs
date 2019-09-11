using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<List<Author>> GetAuthorBooks(string author);
        Task<List<Author>> GetPublisherBooks(string publisher);
    }
}
