using AutoMapper;
using BookStore.Common.ViewModels.CategoriesController.Get;
using BookStore.Common.ViewModels.CategoriesController.Post;
using BookStore.Common.ViewModels.CategoriesController.Put;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class CategoryService : ICategoryService
    {
        #region Properties & Variables
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        #endregion  Properties & Variables

        #region Constructors
        public CategoryService(ICategoryRepository categoryRepository,
                               IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        #endregion Constructors

        #region Public Methods
        public async Task CreateCategoryAsync(CreateCategoryViewModel createCategoryViewModel)
        {
            Category category = _mapper.Map<Category>(createCategoryViewModel);

            await _categoryRepository.InsertAsync(category);
        }

        public async Task<CategoryByIdViewModel> GetCategoryByIdAsync(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);

            CategoryByIdViewModel categoryByIdViewModel = _mapper.Map<CategoryByIdViewModel>(category);

            return categoryByIdViewModel;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<AllCategoryViewModel> GetAllCategoryAsync()
        {
            var result = new AllCategoryViewModel();

            List<Category> categories = await _categoryRepository.GetAllAsync();

            result.Categories = _mapper.Map<List<AllCategoryViewModelItem>>(categories);

            return result;
        }

        public async Task<AuthorAndCategoryViewModel> GetAutorAndCategoryBookAsync(string avtor, int category)
        {
            var result = new AuthorAndCategoryViewModel();

            List<Category> categories = await _categoryRepository.GetAutorAndCategoryBookAsync(avtor, category);

            result.Categories = _mapper.Map<List<AuthorAndCategoryViewModelItem>>(categories);

            return result;
        }

        public async Task<CategoryBooksViewModel> GetCategoryBooksAsync(int category)
        {
            var result = new CategoryBooksViewModel();

            List<Category> categories = await _categoryRepository.GetCategoryBooksAsync(category);

            result.Categories = _mapper.Map<List<CategoryBooksViewModelItem>>(categories);

            return result;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryViewModel updateCategoryViewModel)
        {
            Category category = _mapper.Map<Category>(updateCategoryViewModel);

            await _categoryRepository.UpdateAsync(category);
        }
        #endregion Public Methods
    }
}
