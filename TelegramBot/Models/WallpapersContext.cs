using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Models
{
    class WallpapersContext : DbContext
    {
        public WallpapersContext() : base("DBConnection") { }
        public DbSet<Wallpapers> Images { get; set; }
    }
}
