using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class 
    {
        protected readonly BooksContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(BooksContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Create(T entity)
        {
            _dbSet.Add(entity);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            T dbItem = _dbSet.Find(id);

            if(dbItem != null)
            {
                _dbSet.Remove(dbItem);

                _context.SaveChanges();
            }
        }

        public async Task<List<T>> GetAll()
        {
            List<T> result = await _context.Set<T>().ToListAsync();

            return result;
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
