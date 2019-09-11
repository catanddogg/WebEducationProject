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
    public class DapperAuthorRepository : BaseDapperRepository<Author>, IAuthorRepository
    {
        public DapperAuthorRepository(IDbConnection connectionString)
            : base (connectionString)
        {
        }

        public async Task<List<Author>> GetAuthorBooks(string author)
        {
            List<Author> result = await SqlMapperExtensions
                .GetAll<Author>(_connectionString)
                .AsQueryable()
                .ToListAsync();

            return result;
        }

        public async Task<List<Author>> GetPublisherBooks(string publisher)
        {
            List<Author> result = await SqlMapperExtensions
                .GetAll<Author>(_connectionString)
                .Where(x => x.Publisher == publisher)
                .AsQueryable()
                .ToListAsync();

            return result;
        }
    }
}
