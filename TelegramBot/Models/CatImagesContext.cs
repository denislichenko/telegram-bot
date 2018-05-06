using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Models
{
    public class CatImagesContext : DbContext
    {
        public CatImagesContext() : base("DBConnection") { }
        public DbSet<CatImages> Images { get; set; }
    }
}
