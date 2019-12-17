using BookStore.DAL.Interfaces;
using BookStore.DAL.Models.Entitys;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.Dapper
{
    public class DapperNotificationRepository : BaseDapperRepository<Notification>, INotificationRepository
    {
        public DapperNotificationRepository(IDbConnection connectionString)
            : base(connectionString)
        {
        }

        public async Task<int> GetNotificationCountByUserIdAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Notification>> GetNotificationsByUserIdAsync(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
