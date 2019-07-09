using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Interfaces
{
    public interface IAvtorRepository : IBaseRepository<Avtor>
    {
        //IEnumerable<Avtor> GetAllAvtor();
        //Avtor GetAvtorById(int id);
        //void CreateAvtor(Avtor avtor);
        //void UpdateAvtor(Avtor avtor);
        //void DeleteAvtor(int id);

        IEnumerable<Avtor> GetAvtorBooks(string avtor);
        IEnumerable<Avtor> GetPublisherBooks(string publisher);
    }
}
