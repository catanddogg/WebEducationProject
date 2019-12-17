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
        Task<AllAuthorViewModel> GetAllAuthorsAsync();
        Task<AuthorByIdViewModel> GetAuthorByIdAsync(int id);
        Task CreateAuthorAsync(CreateAuthorViewModel createAuthorViewModel);
        Task UpdateAuthorAsync(UpdateAuthorViewModel updateAuthorViewModel);
        Task DeleteAuthorAsync(int id);
        Task<AuthorBooksViewModel> GetAuthorBooksAsync(string author);
        Task<PublishersBooksViewModel> GetPublisherBooksAsync(string publisher);
    }
}
