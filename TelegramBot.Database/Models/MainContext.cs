using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Database.Models
{
    public class MainContext : DbContext
    {
        public MainContext() : base("DBConnection") { }

        public DbSet<CatImages> Cats { get; set; }
        public DbSet<Message> Messanges { get; set; }
        public DbSet<Wallpapers> Wallpapers { get; set; }
    }
}
