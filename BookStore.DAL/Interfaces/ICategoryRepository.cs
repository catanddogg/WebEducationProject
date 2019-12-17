﻿using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<List<Category>> GetCategoryBooksAsync(int category);
        Task<List<Category>> GetAutorAndCategoryBookAsync(string avtor, int category);
    }
}
