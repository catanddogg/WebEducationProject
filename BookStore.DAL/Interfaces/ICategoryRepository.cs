using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        //IEnumerable<Category> GetAllCategory();
        //Category GetCategoryById(int id);
        //void CreateCategory(Category category);
        //void UpdateCategory(Category category);
        //void DeleteCategory(int id);

        IEnumerable<Category> GetCategoryBooks(int category);
        IEnumerable<Category> GetAutorAndCategoryBook(string avtor, int category);
    }
}
