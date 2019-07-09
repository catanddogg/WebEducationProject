using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Interfaces
{
    public interface IAvtorRepository : IBaseRepository<Avtor>
    {
        IEnumerable<Avtor> GetAvtorBooks(string avtor);
        IEnumerable<Avtor> GetPublisherBooks(string publisher);
    }
}
