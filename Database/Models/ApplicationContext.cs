using Database.Models.Messages;
using Database.Models.Chats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    class ApplicationContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }

        //public ApplicationContext()
        //{
        //    Database.EnsureCreated();
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Message>()
        //        .HasOne<User>(s => s.User)
        //        .WithMany(g => g.Messages)
        //        .HasForeignKey(s => s.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder builder) 
        {
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TelegramBot;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
