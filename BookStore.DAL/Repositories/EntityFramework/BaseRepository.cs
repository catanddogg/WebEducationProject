using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class BaseRepository<C, T> : IBaseRepository<T> where T : class 
        where C : BooksContext
    {
        private C _entities;
        private DbSet<T> _dbSet;

        public BaseRepository(C bookContext)
        {
            _entities = bookContext;
            _dbSet = _entities.Set<T>();
        }

        public async Task Create(T entity)
        {
            _dbSet.Add(entity);
            _entities.SaveChanges();
        }

        public void Delete(int id)
        {
            T dbItem = _dbSet.Find(id);
            if(dbItem != null)
            {
                _dbSet.Remove(dbItem);
                _entities.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.Set<T>();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            _entities.SaveChanges();
        }
    }
}
