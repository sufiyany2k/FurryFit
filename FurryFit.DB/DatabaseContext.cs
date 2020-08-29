using System;
using FurryFit.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace FurryFit.DB
{
    public class DatabaseContext: DbContext
    {
        private readonly string _databasePath;

        public DbSet<User> Users { get; set; }
        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
