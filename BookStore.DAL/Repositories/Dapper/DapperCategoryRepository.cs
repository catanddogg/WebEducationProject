using BookStore.DAL.Enums;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Dapper.Contrib.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.Dapper
{
    public class DapperCategoryRepository : BaseDapperRepository<Category>, ICategoryRepository
    {
        public DapperCategoryRepository(IDbConnection connectionString)
            : base(connectionString)
        {
        }

        public async Task<List<Category>> GetAutorAndCategoryBook(string avtor, int category)
        {
            CategoryType categoryType = (CategoryType)category;

            List<Category> result = await SqlMapperExtensions
                                        .GetAll<Category>(_connectionString)
                                        .Where(item => item.FirstCategoryType == categoryType 
                                        || item.SecondCategoryType == categoryType
                                        || item.TrirdCategoryType == categoryType)
                                        .AsQueryable().ToListAsync();

            return result;
        }

        public async Task<List<Category>> GetCategoryBooks(int category)
        {
            CategoryType categoryType = (CategoryType)category;

            List<Category> result = await SqlMapperExtensions
                .GetAll<Category>(_connectionString)
                .Where(item => item.FirstCategoryType == categoryType
                || item.SecondCategoryType == categoryType
                || item.TrirdCategoryType == categoryType)
                .AsQueryable()
                .ToListAsync();

            return result;
        }
    }
}
