using FinTrack.AlertX.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinTrack.AlertX.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserPreferences> UserPreferences { get; set; }
    }

}
