using Database.Models.Messages;
using Database.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    class ApplicationContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated(); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) 
        {
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TelegramBot;Trusted_Connection=True;");
        }
    }
}
