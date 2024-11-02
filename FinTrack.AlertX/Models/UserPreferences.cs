namespace FinTrack.AlertX.Models
{
    public class UserPreferences
    {
        public int UserId { get; set; }
        public bool EmailEnabled { get; set; }
        public bool SmsEnabled { get; set; }
        public bool InAppEnabled { get; set; }
    }
}
