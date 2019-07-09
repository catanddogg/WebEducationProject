using BookStore.DAL.Enums;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class CategoryRepository : BaseRepository<BooksContext, Category>, ICategoryRepository
    {
        private BooksContext _booksContext;
        public CategoryRepository(BooksContext booksContext)
            : base(booksContext)
        {
            _booksContext = booksContext;
        }

        //public void CreateCategory(Category category)
        //{
        //    _booksContext.Add(category);
        //    _booksContext.SaveChanges();
        //}

        //public void DeleteCategory(int id)
        //{
        //    Category category = _booksContext.Find<Category>(id);
        //    if(category != null)
        //    {
        //        _booksContext.Remove(category);
        //        _booksContext.SaveChanges();
        //    }
        //}

        //public IEnumerable<Category> GetAllCategory()
        //{
        //    DbSet<Category> categories = _booksContext.Set<Category>();
        //    return categories;
        //}

        public IEnumerable<Category> GetAutorAndCategoryBook(string avtor, int category)
        {
            List<Category> bookList = new List<Category>();
            CategoryType categoryType = (CategoryType)category;
            bookList.AddRange(_booksContext.Categories.Where(x => x.CategoryType == categoryType).ToList());
            return bookList;
        }

        //public Category GetCategoryById(int id)
        //{
        //    Category category = _booksContext.Find<Category>(id);
        //    return category;
        //}

        public IEnumerable<Category> GetCategoryBooks(int category)
        {
            CategoryType categoryType = (CategoryType)category;
            List<Category> bookItem = _booksContext.Categories.Where(x => x.CategoryType == categoryType).ToList();
            return bookItem;
        }

        //public void UpdateCategory(Category category)
        //{
        //    _booksContext.Entry(category).State = EntityState.Modified;
        //    _booksContext.SaveChanges();
        //}
    }
}
