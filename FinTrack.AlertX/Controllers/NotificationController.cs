using FinTrack.AlertX.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.AlertX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendNotification(int userId, string message)
        {
            await _notificationService.DispatchNotification(userId, message);
            return Ok("Notification sent.");
        }

        [HttpGet("notifications")]
        public async Task<IActionResult> GetNotifications(int userId)
        {
            var notifications = await _notificationService.GetUserNotifications(userId);
            return Ok(notifications);
        }
    }

}
