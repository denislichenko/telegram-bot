using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string IncomeMessage { get; set; }
        public string ReplyMessage { get; set; }
    }

    public class MessageContext : DbContext
    {
        public MessageContext() : base("DBConnection") { }
        public DbSet<MessageModel> Messanges { get; set; }
    }
}
