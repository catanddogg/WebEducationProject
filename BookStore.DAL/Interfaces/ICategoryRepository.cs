using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        IEnumerable<Category> GetCategoryBooks(int category);
        IEnumerable<Category> GetAutorAndCategoryBook(string avtor, int category);
    }
}
