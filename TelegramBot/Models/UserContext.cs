using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    class UserContext : DbContext
    {
        public UserContext() : base("DBConnection") {}
        public DbSet<User> Users { get; set; }
    }
}
