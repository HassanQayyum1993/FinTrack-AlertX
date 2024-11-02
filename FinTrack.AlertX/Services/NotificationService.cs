using FinTrack.AlertX.Models;
using FinTrack.AlertX.Repositories;

namespace FinTrack.AlertX.Services
{
    public class NotificationService
    {
        private readonly UserPreferencesRepository _userPreferencesRepo;
        private readonly NotificationRepository _notificationRepo;
        private readonly MessageQueueService _mqService;

        public NotificationService(UserPreferencesRepository userPreferencesRepo, NotificationRepository notificationRepo, MessageQueueService mqService)
        {
            _userPreferencesRepo = userPreferencesRepo;
            _notificationRepo = notificationRepo;
            _mqService = mqService;
        }

        public async Task DispatchNotification(int userId, string message)
        {
            var preferences = await _userPreferencesRepo.GetUserPreferences(userId);

            if (preferences == null) return;

            if (preferences.EmailEnabled)
                await _mqService.SendEmailNotification(userId, message);

            if (preferences.SmsEnabled)
                await _mqService.SendSmsNotification(userId, message);

            if (preferences.InAppEnabled)
                await _notificationRepo.SaveNotification(new Notification
                {
                    UserId = userId,
                    Message = message,
                    Timestamp = DateTime.UtcNow,
                    IsRead = false
                });
        }

        public async Task<List<Notification>> GetUserNotifications(int userId)
        {
            return await _notificationRepo.GetUserNotifications(userId);
        }
    }


}
