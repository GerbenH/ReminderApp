using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ReminderAPIApplication.Models
{
    public class ReminderModelDbContext : DbContext
    {
        public ReminderModelDbContext()
        {
        }

        public DbSet<ReminderModel> ReminderModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ReminderModel>().HasKey(m => m.Key);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Use a PostgreSQL database
            var sqlConnectionString = "User ID=gerbenheinen;Password=gerbenheinen;Host=localhost;Port=5432;Database=reminderapp;Pooling=true;";

            optionsBuilder.UseNpgsql(sqlConnectionString);

        }
    }
}