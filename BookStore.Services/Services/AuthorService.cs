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
            _mapper = mapper;
            _authorRepository = authorRepository;
        }
        #endregion Constructors

        #region Public Methods
        public void CreateAuthor(CreateAuthorViewModel createAuthorViewModel)
        {
            Author author = _mapper.Map<Author>(createAuthorViewModel);

            _authorRepository.Create(author);
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.Delete(id);
        }

        public AuthorByIdViewModel GetAuthorById(int id)
        {
            Author author = _authorRepository.GetById(id);

            AuthorByIdViewModel authorByIdView = _mapper.Map<AuthorByIdViewModel>(author);

            return authorByIdView;
        }

        public async Task<AllAuthorViewModel> GetAllAuthors()
        {
            var result = new AllAuthorViewModel();

            List<Author> authors = await _authorRepository.GetAll();

            List<AllAuthorViewModelItem> authorViewModelItem  = _mapper.Map<List<AllAuthorViewModelItem>>(authors);

            result.Authors = authorViewModelItem;

            return result;
        }

        public async Task<AuthorBooksViewModel> GetAuthorBooks(string author)
        {
            var result = new AuthorBooksViewModel();

            List<Author> authors = await _authorRepository.GetAuthorBooks(author);

            List<AuthorBooksViewModelItem> authorBooksViewModel = _mapper.Map<List<AuthorBooksViewModelItem>>(authors);

            result.AuthorBooks = authorBooksViewModel;

            return result;
        }

        public async Task<PublishersBooksViewModel> GetPublisherBooks(string publisher)
        {
            var result = new PublishersBooksViewModel();

            List<Author> authors = await _authorRepository.GetPublisherBooks(publisher);

            List<PublishersBooksViewModelItem> publishersBooksViewModel = _mapper.Map<List<PublishersBooksViewModelItem>>(authors);

            result.Publishers = publishersBooksViewModel;

            return result;
        }

        public void UpdateAuthor(UpdateAuthorViewModel updateAuthorViewModel)
        {
            Author author = _mapper.Map<Author>(updateAuthorViewModel);

            _authorRepository.Update(author);
        }
        #endregion Public Methods
    }
}
