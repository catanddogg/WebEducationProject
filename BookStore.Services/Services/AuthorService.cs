using AutoMapper;
using BookStore.Common.ViewModels.AuthorsController.Get;
using BookStore.Common.ViewModels.AuthorsController.Post;
using BookStore.Common.ViewModels.AuthorsController.Put;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Services
{
    public class AuthorService : IAuthorService
    {
        public readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void CreateAuthor(CreateAuthorViewModel createAuthorViewModel)
        {
            Author author = Mapper.Map<CreateAuthorViewModel, Author>(createAuthorViewModel);
            _authorRepository.Create(author);
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.Delete(id);
        }

        public AuthorByIdViewModel GetAuthorById(int id)
        {
            Author author = _authorRepository.GetById(id);
            AuthorByIdViewModel authorByIdView = Mapper.Map<Author, AuthorByIdViewModel>(author);
            return authorByIdView;
        }

        public AllAuthorViewModel GetAllAuthors()
        {
            IEnumerable<Author> authors = _authorRepository.GetAll();
            AllAuthorViewModel allAuthorViewModel = Mapper.Map<IEnumerable<Author>, AllAuthorViewModel>(authors);
            return allAuthorViewModel;
        }

        public AuthorBooksViewModel GetAuthorBooks(string author)
        {
            IEnumerable<Author> authors = _authorRepository.GetAuthorBooks(author);
            AuthorBooksViewModel authorBooksViewModel = Mapper.Map<IEnumerable<Author>, AuthorBooksViewModel>(authors);
            return authorBooksViewModel;
        }

        public PublishersBooksViewModel GetPublisherBooks(string publisher)
        {
            IEnumerable<Author> authors = _authorRepository.GetPublisherBooks(publisher);
            PublishersBooksViewModel publishersBooksViewModel = Mapper.Map<IEnumerable<Author>, PublishersBooksViewModel>(authors);
            return publishersBooksViewModel;
        }

        public void UpdateAuthor(UpdateAuthorViewModel updateAuthorViewModel)
        {
            Author author = Mapper.Map<UpdateAuthorViewModel, Author>(updateAuthorViewModel);
            _authorRepository.Update(author);
        }
    }
}
