﻿using BookStore.DAL.Enums;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BooksContext booksContext)
            : base(booksContext)
        {
        }

        public async Task<List<Category>> GetAutorAndCategoryBookAsync(string avtor, int category)
        {
            var categoryType = (CategoryType)category;

            List<Category> categoryList = await _dbSet
                .ToListAsync();

            return categoryList;
        }

        public async Task<List<Category>> GetCategoryBooksAsync(int category)
        {
            var categoryType = (CategoryType)category;

            List<Category> bookItem = await _dbSet
                .ToListAsync();

            return bookItem;
        }
    }
}
