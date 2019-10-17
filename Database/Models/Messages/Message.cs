using Database.Models.Chats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models.Messages
{
    public class Message
    {
        public int Id { get; set; }
        public string IncomeMessage { get; set; }
        public string ReplyMessage { get; set; }
        public DateTime Date { get; set; }

        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
