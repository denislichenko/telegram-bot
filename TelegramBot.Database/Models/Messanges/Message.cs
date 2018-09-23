using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Database.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string IncomeMessage { get; set; }
        public string ReplyMessage { get; set; }
        public long ChatId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
