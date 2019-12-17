using BookStore.Common.ViewModels.NotificationController;
using BookStore.Common.ViewModels.NotificationController.Responses;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AddTestCors")]
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("NotificationsByUserId")]
        public async Task<NotificationsByUserIdRequestView> NotificationsByUserId(string userId)
        {
            NotificationsByUserIdRequestView result = await _notificationService.NotificationByUserIdAsync(userId);

            return result;
        }

        [HttpGet("NotificationCountByUserId")]
        public async Task<NotificationCountByUserIdResponseView> NotificationCountByUserId(int userId)
        {
            NotificationCountByUserIdResponseView result = await _notificationService.GetNotificationCountByUserIdAsync(userId);

            return result;
        }

        [HttpPost("CreateNotification")]
        public async Task<CreateNotificationResponseView> CreateNotification(CreateNotificationRequestView notificationView)
        {
            CreateNotificationResponseView result = await _notificationService.CreateNotificationAsync(notificationView);

            return result;
        }
    }
}
