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

namespace BookStore.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            Category category = Mapper.Map<CreateCategoryViewModel, Category>(createCategoryViewModel);
            _categoryRepository.Create(category);
        }

        public CategoryByIdViewModel GetCategoryById(int id)
        {
            Category category = _categoryRepository.GetById(id);
            CategoryByIdViewModel categoryByIdViewModel = Mapper.Map<Category, CategoryByIdViewModel>(category);
            return categoryByIdViewModel;
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        }

        public AllCategoryViewModel GetAllCategory()
        {
            IEnumerable<Category> categories = _categoryRepository.GetAll();
            AllCategoryViewModel allCategoryViewModel = Mapper.Map<IEnumerable<Category>, AllCategoryViewModel>(categories);
            return allCategoryViewModel;
        }

        public AutorAndCategoryViewModel GetAutorAndCategoryBook(string avtor, int category)
        {
            IEnumerable<Category> categories = _categoryRepository.GetAutorAndCategoryBook(avtor, category);
            AutorAndCategoryViewModel autorAndCategoryViewModel = Mapper.Map<IEnumerable<Category>, AutorAndCategoryViewModel>(categories);
            return autorAndCategoryViewModel;
        }

        public CategoryBooksViewModel GetCategoryBooks(int category)
        {
            IEnumerable<Category> categories = _categoryRepository.GetCategoryBooks(category);
            CategoryBooksViewModel categoryBooksViewModel = Mapper.Map<IEnumerable<Category>, CategoryBooksViewModel>(categories);
            return categoryBooksViewModel;
        }

        public void UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel)
        {
            Category category = Mapper.Map<UpdateCategoryViewModel, Category>(updateCategoryViewModel);
            _categoryRepository.Update(category);
        }
    }
}
