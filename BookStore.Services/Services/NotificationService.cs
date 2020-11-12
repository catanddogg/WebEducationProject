using AutoMapper;
using BookStore.Common.ViewModels.NotificationController;
using BookStore.Common.ViewModels.NotificationController.Responses;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.DAL.Models.Entitys;
using BookStore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public NotificationService(
            INotificationRepository notificationRepository,
            IPersonRepository personRepository,
            IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _personRepository = personRepository;

            _mapper = mapper;
        }

        public async Task<NotificationsByUserIdRequestView> NotificationByUserIdAsync(string userId)
        {
            var result = new NotificationsByUserIdRequestView();

            List<Notification> notifications = await _notificationRepository.GetNotificationsByUserIdAsync(userId);

            result.Notifications = _mapper.Map<List<NotificationsByUserIdViewItem>>(notifications);

            return result;
        }

        public async Task<CreateNotificationResponseView> CreateNotificationAsync(CreateNotificationRequestView notificationView)
        {
            var result = new CreateNotificationResponseView();
            var notifications = new List<Notification>();

            Notification notification = _mapper.Map<Notification>(notificationView);

            List<User> users = await _personRepository.GetAllAsync();

            foreach(User user in users)
            {
                var notificationToSave = new Notification();

                notificationToSave.ImagePath = notification.ImagePath;
                notificationToSave.Message = notification.Message;
                notificationToSave.Title = notification.Title;
                notificationToSave.UserId = user.Id;

                notifications.Add(notificationToSave);
            }

            await _notificationRepository.InsertRangeAsync(notifications);

            result.Success = true;
            result.Message = "Successfully!";

            return result;
        }

        public async Task<NotificationCountByUserIdResponseView> GetNotificationCountByUserIdAsync(int userId)
        {
            var result = new NotificationCountByUserIdResponseView();

            int notificationCount = await _notificationRepository.GetNotificationCountByUserIdAsync(userId);

            result.Count = notificationCount;

            return result;
        }
    }
}
