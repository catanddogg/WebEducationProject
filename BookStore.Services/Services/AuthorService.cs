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
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class AuthorService : IAuthorService
    {
        #region Properties & Variables
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        #endregion Properties & Variables

        #region Constructors
        public AuthorService(IAuthorRepository authorRepository,
                             IMapper mapper)
        {
            _authorRepository = authorRepository;

            _mapper = mapper;
        }
        #endregion Constructors

        #region Public Methods
        public async Task CreateAuthorAsync(CreateAuthorViewModel createAuthorViewModel)
        {
            Author author = _mapper.Map<Author>(createAuthorViewModel);

            await _authorRepository.InsertAsync(author);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            await _authorRepository.DeleteAsync(id);
        }

        public async Task<AuthorByIdViewModel> GetAuthorByIdAsync(int id)
        {
            Author author = await _authorRepository.GetByIdAsync(id);

            AuthorByIdViewModel authorByIdView = _mapper.Map<AuthorByIdViewModel>(author);

            return authorByIdView;
        }

        public async Task<AllAuthorViewModel> GetAllAuthorsAsync()
        {
            var result = new AllAuthorViewModel();

            List<Author> authors = await _authorRepository.GetAllAsync();

            result.Authors = _mapper.Map<List<AllAuthorViewModelItem>>(authors);

            return result;
        }

        public async Task<AuthorBooksViewModel> GetAuthorBooksAsync(string author)
        {
            var result = new AuthorBooksViewModel();

            List<Author> authors = await _authorRepository.GetAuthorBooksAsync(author);

            result.AuthorBooks = _mapper.Map<List<AuthorBooksViewModelItem>>(authors);

            return result;
        }

        public async Task<PublishersBooksViewModel> GetPublisherBooksAsync(string publisher)
        {
            var result = new PublishersBooksViewModel();

            List<Author> authors = await _authorRepository.GetPublisherBooksAsync(publisher);

            result.Publishers = _mapper.Map<List<PublishersBooksViewModelItem>>(authors);

            return result;
        }

        public async Task UpdateAuthorAsync(UpdateAuthorViewModel updateAuthorViewModel)
        {
            Author author = _mapper.Map<Author>(updateAuthorViewModel);

            await _authorRepository.UpdateAsync(author);
        }
        #endregion Public Methods
    }
}
