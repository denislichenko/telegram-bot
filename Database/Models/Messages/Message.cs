using TelegramBot.Database.Models.Chats;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot.Database.Models.Messages
{
    public class Message
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = false;
        public string IncomeMessage { get; set; }
        public string ReplyMessage { get; set; }
        public DateTime Date { get; set; } = DateTime.Now; 

        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
