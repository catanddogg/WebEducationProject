using BookStore.Common.ViewModels.AuthorsController.Get;
using BookStore.Common.ViewModels.AuthorsController.Post;
using BookStore.Common.ViewModels.AuthorsController.Put;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Interfaces
{
    public interface IAuthorService
    {
        AllAuthorViewModel GetAllAuthors();
        AuthorByIdViewModel GetAuthorById(int id);
        void CreateAuthor(CreateAuthorViewModel createAuthorViewModel);
        void UpdateAuthor(UpdateAuthorViewModel updateAuthorViewModel);
        void DeleteAuthor(int id);

        AuthorBooksViewModel GetAuthorBooks();
        PublishersBooksViewModel GetPublisherBooks(string publisher);
    }
}
