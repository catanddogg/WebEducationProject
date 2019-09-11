using BookStore.Common.ViewModels.CategoriesController.Get;
using BookStore.Common.ViewModels.CategoriesController.Post;
using BookStore.Common.ViewModels.CategoriesController.Put;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<AllCategoryViewModel> GetAllCategory();
        CategoryByIdViewModel GetCategoryById(int id);
        void CreateCategory(CreateCategoryViewModel createCategoryViewModel);
        void UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel);
        void DeleteCategory(int id);

        Task<CategoryBooksViewModel> GetCategoryBooks(int category);
        Task<AuthorAndCategoryViewModel> GetAutorAndCategoryBook(string avtor, int category);
    }
}
