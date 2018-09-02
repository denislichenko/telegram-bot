using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Database.Models.Users
{
    public class Admin
    {
        public int Id { get; set; }
        public long ChatId { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
