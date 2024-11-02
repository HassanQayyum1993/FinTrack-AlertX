using FinTrack.AlertX.Models;
using MongoDB.Driver;

namespace FinTrack.AlertX.Repositories
{
    public class NotificationRepository
    {
        private readonly IMongoCollection<Notification> _notifications;

        public NotificationRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("FinTrackDB");
            _notifications = database.GetCollection<Notification>("Notifications");
        }

        public async Task SaveNotification(Notification notification)
        {
            await _notifications.InsertOneAsync(notification);
        }

        public async Task<List<Notification>> GetUserNotifications(int userId)
        {
            return await _notifications.Find(n => n.UserId == userId).ToListAsync();
        }
    }

}
