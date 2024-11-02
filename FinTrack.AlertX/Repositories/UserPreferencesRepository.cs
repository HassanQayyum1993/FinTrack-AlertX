using FinTrack.AlertX.Data;
using FinTrack.AlertX.Models;
using System;

namespace FinTrack.AlertX.Repositories
{
    public class UserPreferencesRepository
    {
        private readonly AppDbContext _context;

        public UserPreferencesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserPreferences> GetUserPreferences(int userId)
        {
            return await _context.UserPreferences.FindAsync(userId);
        }
    }

}
