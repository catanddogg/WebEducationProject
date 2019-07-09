using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.Dapper
{
    public class BaseDapperRepository<T> : IBaseRepository<T> where T : class
    {
        private IDbConnection _connection;
        public BaseDapperRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task Create(T entity)
        {
            await SqlMapperExtensions.InsertAsync(_connection, entity);
        }

        public void Delete(int id)
        {
            T entity = SqlMapperExtensions.Get<T>(_connection, id);
            if(entity != null)
            {
                SqlMapperExtensions.Delete(_connection, entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> entities = SqlMapperExtensions.GetAll<T>(_connection);
            return entities;
        }

        public T GetById(object id)
        {
            T entities = SqlMapperExtensions.Get<T>(_connection, id);
            return entities;
        }

        public void Update(T entity)
        {
            SqlMapperExtensions.Update<T>(_connection, entity);
        }
    }
}
