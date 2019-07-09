using BookStore.DAL.Enums;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BookStore.DAL.Repositories.Dapper
{
    public class DapperCategoryRepository : BaseDapperRepository<Category>, ICategoryRepository
    {
        private IDbConnection _connectionString;
        public DapperCategoryRepository(IDbConnection connectionString)
            : base(connectionString)
        {
            _connectionString = connectionString;
        }

        //public void CreateCategory(Category category)
        //{
        //    SqlMapperExtensions.Insert(_connectionString, category);
        //}

        //public void DeleteCategory(int id)
        //{
        //    Category category = SqlMapperExtensions.Get<Category>(_connectionString, id);
        //    if (category != null)
        //    {
        //        SqlMapperExtensions.Delete(_connectionString, category);
        //    }
        //}

        //public IEnumerable<Category> GetAllCategory()
        //{
        //    IEnumerable<Category> categories = SqlMapperExtensions.GetAll<Category>(_connectionString);
        //    return categories;
        //}

        public IEnumerable<Category> GetAutorAndCategoryBook(string avtor, int category)
        {
            List<Category> bookList = new List<Category>();
            CategoryType categoryType = (CategoryType)category;
            bookList.AddRange(SqlMapperExtensions.GetAll<Category>(_connectionString).Where(x => x.CategoryType == categoryType).ToList());
            return bookList;
        }

        //public Category GetCategoryById(int id)
        //{
        //    Category category = SqlMapperExtensions.Get<Category>(_connectionString, id);
        //    return category;
        //}

        public IEnumerable<Category> GetCategoryBooks(int category)
        {
                CategoryType categoryType = (CategoryType)category;
                IEnumerable<Category> res = SqlMapperExtensions.GetAll<Category>(_connectionString).Where(x => x.CategoryType == categoryType);
                return res;
        }

        //public void UpdateCategory(Category category)
        //{
        //    SqlMapperExtensions.Update<Category>(_connectionString, category);
        //}
    }
}
