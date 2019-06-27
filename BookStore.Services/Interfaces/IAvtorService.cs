using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Interfaces
{
    public interface IAvtorService
    {
        IEnumerable<Avtor> GetAllAvtors();
        Avtor GetAvtorById(int id);
        void CreateAvtor(Avtor avtor);
        void UpdateAvtor(Avtor avtor);
        void DeleteAvtor(int id);

        IEnumerable<Avtor> GetAvtorBooks(string avtor);
        IEnumerable<Avtor> GetPublisherBooks(string publisher);
    }
}
