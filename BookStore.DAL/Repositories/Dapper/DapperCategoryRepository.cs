using BookStore.DAL.Enums;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Dapper.Contrib.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<List<Category>> GetAutorAndCategoryBookAsync(string avtor, int category)
        {
            List<Category> result = await SqlMapperExtensions
                                        .GetAll<Category>(_connectionString)
                                        .AsQueryable().ToListAsync();

            return result;
        }

        public async Task<List<Category>> GetCategoryBooksAsync(int category)
        {
            List<Category> result = await SqlMapperExtensions
                .GetAll<Category>(_connectionString)
                .AsQueryable()
                .ToListAsync();

            return result;
        }
    }
}
