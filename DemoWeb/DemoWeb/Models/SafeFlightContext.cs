using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoWeb.Models
{
    public class SafeFlightContext : DbContext
    {
        public SafeFlightContext(): base()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SafeFlightContext, DemoWeb.Migrations.Configuration>("SafeFlightContextDB"));
        }


        public DbSet<Flight> Flights { get; set; }
        public DbSet<WatchListEntry> WatchList { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
    }
}