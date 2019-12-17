using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Dapper;
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
    public class DapperAuthorRepository : BaseDapperRepository<Author>, IAuthorRepository
    {
        public DapperAuthorRepository(IDbConnection connectionString)
            : base (connectionString)
        {
        }

        public async Task<List<Author>> GetAuthorBooksAsync(string author)
        {
            IEnumerable<Author> query = await _connectionString.QueryAsync<Author>("SELECT * FROM Book.dbo.Avtors");
                //.GetAll<Author>
                //.AsQueryable()
                //.ToListAsync();

            return query.ToList();
        }

        public async Task<List<Author>> GetPublisherBooksAsync(string publisher)
        {
            IEnumerable<Author> query = await _connectionString.QueryAsync<Author>("SELECT * FROM Book.dbo.Avtors");
                //.GetAll<Author>(_connectionString)
                //.Where(x => x.Publisher == publisher)
                //.AsQueryable()
                //.ToListAsync();

            return query.ToList();
        }
    }
}
