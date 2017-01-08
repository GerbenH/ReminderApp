using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ReminderAPIApplication.Models
{
    public class ReminderModelDbContext : DbContext
    {
        public ReminderModelDbContext(DbContextOptions<ReminderModelDbContext> options) 
            : base(options)
        {
        }

        public DbSet<ReminderModel> ReminderModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ReminderModel>().HasKey(m => m.Key);

            base.OnModelCreating(builder);
        }
    }
}