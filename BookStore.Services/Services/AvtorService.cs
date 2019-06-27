using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Services
{
    public class AvtorService : IAvtorService
    {
        public readonly IAvtorRepository _avtorRepository;

        public AvtorService(IAvtorRepository avtorRepository)
        {
            _avtorRepository = avtorRepository;
        }

        public void CreateAvtor(Avtor avtor)
        {
            _avtorRepository.CreateAvtor(avtor);
        }

        public void DeleteAvtor(int id)
        {
            _avtorRepository.DeleteAvtor(id);
        }

        public Avtor GetAvtorById(int id)
        {
            return _avtorRepository.GetAvtorById(id);
        }

        public IEnumerable<Avtor> GetAllAvtors()
        {
            return _avtorRepository.GetAllAvtor();
        }

        public IEnumerable<Avtor> GetAvtorBooks(string avtor)
        {
            return _avtorRepository.GetAvtorBooks(avtor);
        }

        public IEnumerable<Avtor> GetPublisherBooks(string publisher)
        {
            return _avtorRepository.GetPublisherBooks(publisher);
        }

        public void UpdateAvtor(Avtor avtor)
        {
            _avtorRepository.UpdateAvtor(avtor);
        }
    }
}
