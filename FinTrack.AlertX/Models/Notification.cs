namespace FinTrack.AlertX.Models
{
    public class Notification
    {
        public string Id { get; set; } // MongoDB uses string ObjectIds
        public int UserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
