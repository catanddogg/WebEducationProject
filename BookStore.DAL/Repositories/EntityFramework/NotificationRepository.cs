using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.DAL.Models.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(BooksContext booksContext)
            : base (booksContext)
        {

        }

        public async Task<List<Notification>> GetNotificationsByUserIdAsync(string userId)
        {
            List<Notification> result = await _dbSet
                .Where(item => item.PersonId == int.Parse(userId))
                .ToListAsync();

            return result;
        }

        public async Task<int> GetNotificationCountByUserIdAsync(int userId)
        {
            int result = await _dbSet
                .Where(item => item.PersonId == userId)
                .CountAsync();

            return result;
        }
    }
}
