using AutoMapper;
using BookStore.Common.ViewModels.CategoriesController.Get;
using BookStore.Common.ViewModels.CategoriesController.Post;
using BookStore.Common.ViewModels.CategoriesController.Put;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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
        public void CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            Category category = _mapper.Map<Category>(createCategoryViewModel);

            _categoryRepository.Create(category);
        }

        public CategoryByIdViewModel GetCategoryById(int id)
        {
            Category category = _categoryRepository.GetById(id);

            CategoryByIdViewModel categoryByIdViewModel = _mapper.Map<CategoryByIdViewModel>(category);

            return categoryByIdViewModel;
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        }

        public async Task<AllCategoryViewModel> GetAllCategory()
        {
            var result = new AllCategoryViewModel();

            List<Category> categories = await _categoryRepository.GetAll();

            List<AllCategoryViewModelItem> allCategoryViewModel = _mapper.Map<List<AllCategoryViewModelItem>>(categories);

            result.Categories = allCategoryViewModel;

            return result;
        }

        public async Task<AuthorAndCategoryViewModel> GetAutorAndCategoryBook(string avtor, int category)
        {
            var result = new AuthorAndCategoryViewModel();

            List<Category> categories = await _categoryRepository.GetAutorAndCategoryBook(avtor, category);

            List<AuthorAndCategoryViewModelItem>  categoryViewModelItems = _mapper.Map<List<AuthorAndCategoryViewModelItem>>(categories);

            result.Categories = categoryViewModelItems;

            return result;
        }

        public async Task<CategoryBooksViewModel> GetCategoryBooks(int category)
        {
            var result = new CategoryBooksViewModel();

            List<Category> categories = await _categoryRepository.GetCategoryBooks(category);

            List<CategoryBooksViewModelItem> categoryBooksViewModel = _mapper.Map<List<CategoryBooksViewModelItem>>(categories);

            result.Categories = categoryBooksViewModel;

            return result;
        }

        public void UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel)
        {
            Category category = _mapper.Map<Category>(updateCategoryViewModel);

            _categoryRepository.Update(category);
        }
        #endregion Public Methods
    }
}
