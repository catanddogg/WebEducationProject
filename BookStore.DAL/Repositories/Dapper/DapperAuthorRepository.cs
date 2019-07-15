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
    public class DapperAuthorRepository : BaseDapperRepository<Author>, IAuthorRepository
    {
        private IDbConnection _connectionString;
        public DapperAuthorRepository(IDbConnection connectionString)
            : base (connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Author> GetAuthorBooks(string author)
        {
            IEnumerable<Author> books = SqlMapperExtensions.GetAll<Author>(_connectionString).Where(x => x.NameAuthor == author);
            return books;
        }

        public IEnumerable<Author> GetPublisherBooks(string publisher)
        {
            IEnumerable<Author> res = SqlMapperExtensions.GetAll<Author>(_connectionString).Where(x => x.Publisher == publisher);
            return res;
        }
    }
}
