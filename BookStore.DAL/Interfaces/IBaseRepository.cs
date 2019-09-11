using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        T GetById(object id);
        Task Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
