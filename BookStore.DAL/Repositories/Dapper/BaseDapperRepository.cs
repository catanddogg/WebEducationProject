using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Dapper;
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
            await _connectionString.InsertAsync(entity);
        }

        public void Delete(int id)
        {
            T entity = _connectionString.Get<T>(id);
            if(entity != null)
            {
                _connectionString.Delete(entity);
            }
        }

        public async Task<List<T>> GetAll()
        {
            IEnumerable<T> result = await _connectionString.GetAllAsync<T>();

            return result.ToList();
        }

        public T GetById(object id)
        {
            T entities = _connectionString.Get<T>(id);

            return entities;
        }
        
        public void Update(T entity)
        {
            _connectionString.Update<T>(entity);
        }
    }
}
