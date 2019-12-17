using BookStore.DAL.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public async Task InsertAsync(T entity)
        {
            await _connectionString.InsertAsync(entity);
        }

        public async Task InsertRangeAsync(List<T> entities)
        {
            if (entities is null)
            {
                return;
            }
            await _connectionString.InsertAsync(entities);
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await _connectionString.GetAsync<T>(id);
            if(entity != null)
            {
                _connectionString.Delete(entity);
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            IEnumerable<T> result = await _connectionString.GetAllAsync<T>();

            return result.ToList();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            T entities = await _connectionString.GetAsync<T>(id);

            return entities;
        }
        
        public async Task UpdateAsync(T entity)
        {
            await _connectionString.UpdateAsync<T>(entity);
        }

        public async Task<int> GetCountAsync()
        {
            string sql = $"SELECT COUNT(Id) FROM {typeof(T).Name}s";

            int result = await _connectionString.QueryFirstOrDefaultAsync<int>(sql);

            return result;
        }
    }
}
