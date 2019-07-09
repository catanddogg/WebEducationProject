using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class AvtorRepository : BaseRepository<BooksContext, Avtor>, IAvtorRepository
    {
        private BooksContext _booksContext;

        public AvtorRepository(BooksContext booksContext)
           : base(booksContext)
        {
            _booksContext = booksContext;
        }

        public IEnumerable<Avtor> GetAvtorBooks(string avtor)
        {
            List<Avtor> bookItem = _booksContext.Avtors.Where(x => x.NameAvtor == avtor).ToList();
            return bookItem;
        }

        public IEnumerable<Avtor> GetPublisherBooks(string publisher)
        {
            List<Avtor> bookItem = _booksContext.Avtors.Where(x => x.Publisher == publisher).ToList();
            return bookItem;
        }
    }
}
