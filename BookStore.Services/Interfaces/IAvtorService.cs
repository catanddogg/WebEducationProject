using BookStore.Common.ViewModels.AvtorsController.Get;
using BookStore.Common.ViewModels.AvtorsController.Post;
using BookStore.Common.ViewModels.AvtorsController.Put;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Interfaces
{
    public interface IAvtorService
    {
        AllAvtorViewModel GetAllAvtors();
        AvtorByIdViewModel GetAvtorById(int id);
        void CreateAvtor(CreateAvtorViewModel createAvtorViewModel);
        void UpdateAvtor(UpdateAvtorViewModel updateAvtorViewModel);
        void DeleteAvtor(int id);

        AvtorBooksViewModel GetAvtorBooks(string avtor);
        PublishersBooksViewModel GetPublisherBooks(string publisher);
    }
}
