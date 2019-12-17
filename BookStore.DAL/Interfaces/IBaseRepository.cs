using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task InsertAsync(T entity);
        Task InsertRangeAsync(List<T> list);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<int> GetCountAsync();
    }
}
