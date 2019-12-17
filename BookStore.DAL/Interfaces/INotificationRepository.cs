using BookStore.DAL.Models.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        Task<List<Notification>> GetNotificationsByUserIdAsync(string userId);
        Task<int> GetNotificationCountByUserIdAsync(int userId);
    }
}
