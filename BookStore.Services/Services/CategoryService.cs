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

        public void CreateCategory(Category category)
        {
            _categoryRepository.CreateCategory(category);
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _categoryRepository.GetAllCategory();
        }

        public IEnumerable<Category> GetAutorAndCategoryBook(string avtor, int category)
        {
            return _categoryRepository.GetAutorAndCategoryBook(avtor, category);
        }

        public IEnumerable<Category> GetCategoryBooks(int category)
        {
            return _categoryRepository.GetCategoryBooks(category);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.UpdateCategory(category);
        }
    }
}
