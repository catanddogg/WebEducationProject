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
    public class DapperAvtorRepository : BaseDapperRepository<Avtor>, IAvtorRepository
    {
        private IDbConnection _connectionString;
        public DapperAvtorRepository(IDbConnection connectionString)
            : base (connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Avtor> GetAvtorBooks(string avtor)
        {
            IEnumerable<Avtor> books = SqlMapperExtensions.GetAll<Avtor>(_connectionString).Where(x => x.NameAvtor == avtor);
            return books;
        }

        public IEnumerable<Avtor> GetPublisherBooks(string publisher)
        {
            IEnumerable<Avtor> res = SqlMapperExtensions.GetAll<Avtor>(_connectionString).Where(x => x.Publisher == publisher);
            return res;
        }
    }
}
