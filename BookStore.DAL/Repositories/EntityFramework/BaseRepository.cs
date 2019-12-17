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

        public async Task InsertAsync(T entity)
        {
            _dbSet.Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task InsertRangeAsync(List<T> list)
        {
            if (list is null)
            {
                return;
            }

            _dbSet.AddRange(list);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T dbItem = _dbSet.Find(id);

            if(dbItem != null)
            {
                _dbSet.Remove(dbItem);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> result = await _context.Set<T>().ToListAsync();

            return result;
        }

        public async Task<T> GetByIdAsync(object id)
        {
            T result = await _dbSet.FindAsync(id);

            return result;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<int> GetCountAsync()
        {
            int result = await _dbSet.CountAsync();

            return result;
        }
    }
}
