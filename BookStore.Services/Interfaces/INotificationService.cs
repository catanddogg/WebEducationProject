using BookStore.Common.ViewModels.NotificationController;
using BookStore.Common.ViewModels.NotificationController.Responses;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface INotificationService
    {
        Task<NotificationsByUserIdRequestView> NotificationByUserIdAsync(string userId);
        Task<CreateNotificationResponseView> CreateNotificationAsync(CreateNotificationRequestView notificationView);
        Task<NotificationCountByUserIdResponseView> GetNotificationCountByUserIdAsync(int userId);
    }
}
