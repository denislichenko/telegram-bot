using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Database.Models.Users
{
    public class BlackList
    {
        public int Id { get; set; }
        public long ChatId { get; set; }
        public int MuteLevel { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public int AdminId { get; set; }
        public string AdminName { get; set; }
    }
}
