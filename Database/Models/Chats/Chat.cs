using Database.Models.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models.Chats
{
    public class Chat
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public long ChatId { get; set; }
        public string UserName { get; set; }

        public short Status { get; set; } = 0;
        public short Step { get; set; } = 0;

        public ICollection<Message> Messages { get; set; }
    }
}
