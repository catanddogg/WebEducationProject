using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        IEnumerable<Author> GetAuthorBooks();
        IEnumerable<Author> GetPublisherBooks(string publisher);
    }
}
