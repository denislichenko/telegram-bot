using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Database.Models.Messanges
{
    public class IncomeMessage
    {
        public int Id { get; set; }
        public long ChatId { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public bool Answer { get; set; }
        public DateTime Date { get; set; }
    }
}
