using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Database.Models.Messanges;
using TelegramBot.Database.Models.Users;

namespace TelegramBot.Database.Models
{
    public class MainContext : DbContext
    {
        public MainContext() : base("DBConnection") { }

        public DbSet<CatImages> Cats { get; set; }
        public DbSet<Message> Messanges { get; set; }
        public DbSet<Wallpapers> Wallpapers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BlackList> BlackList { get; set; }
        public DbSet<IncomeMessage> IncomeMessages { get; set; }
    }
}
