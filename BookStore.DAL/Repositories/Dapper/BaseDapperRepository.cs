using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.Dapper
{
    public class BaseDapperRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly IDbConnection _connectionString;
        public BaseDapperRepository(IDbConnection connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Create(T entity)
        {
            await SqlMapperExtensions.InsertAsync(_connectionString, entity);
        }

        public void Delete(int id)
        {
            T entity = SqlMapperExtensions.Get<T>(_connectionString, id);
            if(entity != null)
            {
                SqlMapperExtensions.Delete(_connectionString, entity);
            }
        }

        public async Task<List<T>> GetAll()
        {
            List<T> entities = SqlMapperExtensions.GetAll<T>(_connectionString).ToList();

            return entities;
        }

        public T GetById(object id)
        {
            T entities = SqlMapperExtensions.Get<T>(_connectionString, id);
            return entities;
        }

        public void Update(T entity)
        {
            SqlMapperExtensions.Update<T>(_connectionString, entity);
        }
    }
}
