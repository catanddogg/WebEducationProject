using BookStore.Common.ViewModels.CategoriesController.Get;
using BookStore.Common.ViewModels.CategoriesController.Post;
using BookStore.Common.ViewModels.CategoriesController.Put;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Interfaces
{
    public interface ICategoryService
    {
        AllCategoryViewModel GetAllCategory();
        CategoryByIdViewModel GetCategoryById(int id);
        void CreateCategory(CreateCategoryViewModel createCategoryViewModel);
        void UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel);
        void DeleteCategory(int id);

        CategoryBooksViewModel GetCategoryBooks(int category);
        AutorAndCategoryViewModel GetAutorAndCategoryBook(string avtor, int category);
    }
}
