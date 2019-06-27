using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class AvtorRepository : IAvtorRepository
    {
        private BooksContext _booksContext;
        public AvtorRepository(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        public void CreateAvtor(Avtor avtor)
        {
            _booksContext.Add(avtor);
            _booksContext.SaveChanges();
        }

        public void DeleteAvtor(int id)
        {
            Avtor avtor = _booksContext.Find<Avtor>(id);
            if(avtor != null)
            {
                _booksContext.Remove(avtor);
                _booksContext.SaveChanges();
            }
        }

        public IEnumerable<Avtor> GetAllAvtor()
        {
            DbSet<Avtor> avtors = _booksContext.Set<Avtor>();
            return avtors;
        }

        public IEnumerable<Avtor> GetAvtorBooks(string avtor)
        {
            List<Avtor> bookItem = _booksContext.Avtors.Where(x => x.NameAvtor == avtor).ToList();
            return bookItem;
        }

        public Avtor GetAvtorById(int id)
        {
            Avtor avtor = _booksContext.Find<Avtor>(id);
            return avtor;
        }

        public IEnumerable<Avtor> GetPublisherBooks(string publisher)
        {
            List<Avtor> bookItem = _booksContext.Avtors.Where(x => x.Publisher == publisher).ToList();
            return bookItem;
        }

        public void UpdateAvtor(Avtor avtor)
        {
            _booksContext.Entry(avtor).State = EntityState.Modified;
            _booksContext.SaveChanges();
        }
    }
}
