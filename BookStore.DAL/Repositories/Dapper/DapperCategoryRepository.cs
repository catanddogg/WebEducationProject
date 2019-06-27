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
    public class DapperCategoryRepository : ICategoryRepository
    {
        private string _connectionString;
        public DapperCategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateCategory(Category category)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                SqlMapperExtensions.Insert(db, category);
            }
        }

        public void DeleteCategory(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Category category = SqlMapperExtensions.Get<Category>(db, id);
                if(category != null)
                {
                    SqlMapperExtensions.Delete(db, category);
                }
            }
        }

        public IEnumerable<Category> GetAllCategory()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                IEnumerable<Category> categories = SqlMapperExtensions.GetAll<Category>(db);
                return categories;
            }
        }

        public IEnumerable<Category> GetAutorAndCategoryBook(string avtor, int category)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                List<Category> bookList = new List<Category>();
                CategoryType categoryType = (CategoryType)category;
                bookList.AddRange(SqlMapperExtensions.GetAll<Category>(db).Where(x => x.CategoryType == categoryType).ToList());
                return bookList;
            }
        }

        public Category GetCategoryById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Category category = SqlMapperExtensions.Get<Category>(db, id);
                return category;
            }
        }

        public IEnumerable<Category> GetCategoryBooks(int category)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                CategoryType categoryType = (CategoryType)category;
                IEnumerable<Category> res = SqlMapperExtensions.GetAll<Category>(db).Where(x => x.CategoryType == categoryType);
                return res;
            }
        }

        public void UpdateCategory(Category category)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                SqlMapperExtensions.Update<Category>(db, category);
            }
        }
    }
}
