using BookStore.Common.ViewModels.AuthorsController.Get;
using BookStore.Common.ViewModels.AuthorsController.Post;
using BookStore.Common.ViewModels.AuthorsController.Put;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AllAuthorViewModel> GetAllAuthors();
        AuthorByIdViewModel GetAuthorById(int id);
        void CreateAuthor(CreateAuthorViewModel createAuthorViewModel);
        void UpdateAuthor(UpdateAuthorViewModel updateAuthorViewModel);
        void DeleteAuthor(int id);

        Task<AuthorBooksViewModel> GetAuthorBooks(string author);
        Task<PublishersBooksViewModel> GetPublisherBooks(string publisher);
    }
}
