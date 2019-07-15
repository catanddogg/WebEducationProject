using AutoMapper;
using BookStore.Common.ViewModels.AvtorsController.Get;
using BookStore.Common.ViewModels.AvtorsController.Post;
using BookStore.Common.ViewModels.AvtorsController.Put;
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

        public void CreateAvtor(CreateAvtorViewModel createAvtorViewModel)
        {
            Avtor avtor = Mapper.Map<CreateAvtorViewModel, Avtor>(createAvtorViewModel);
            _avtorRepository.Create(avtor);
        }

        public void DeleteAvtor(int id)
        {
            _avtorRepository.Delete(id);
        }

        public AvtorByIdViewModel GetAvtorById(int id)
        {
            Avtor avtor = _avtorRepository.GetById(id);
            AvtorByIdViewModel avtorByIdView = Mapper.Map<Avtor ,AvtorByIdViewModel>(avtor);
            return avtorByIdView;
        }

        public AllAvtorViewModel GetAllAvtors()
        {
            IEnumerable<Avtor> avtors = _avtorRepository.GetAll();
            AllAvtorViewModel allAvtorViewModel = Mapper.Map<IEnumerable<Avtor>, AllAvtorViewModel>(avtors);
            return allAvtorViewModel;
        }

        public AvtorBooksViewModel GetAvtorBooks(string avtor)
        {
            IEnumerable<Avtor> avtors = _avtorRepository.GetAvtorBooks(avtor);
            AvtorBooksViewModel avtorBooksViewModel = Mapper.Map<IEnumerable<Avtor>, AvtorBooksViewModel>(avtors);
            return avtorBooksViewModel;
        }

        public PublishersBooksViewModel GetPublisherBooks(string publisher)
        {
            IEnumerable<Avtor> avtors = _avtorRepository.GetPublisherBooks(publisher);
            PublishersBooksViewModel publishersBooksViewModel = Mapper.Map<IEnumerable<Avtor>, PublishersBooksViewModel>(avtors);
            return publishersBooksViewModel;
        }

        public void UpdateAvtor(UpdateAvtorViewModel updateAvtorViewModel)
        {
            Avtor avtor = Mapper.Map<UpdateAvtorViewModel, Avtor>(updateAvtorViewModel);
            _avtorRepository.Update(avtor);
        }
    }
}
