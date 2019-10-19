using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;
using TelegramBot.Database.Models;

namespace TelegramBot.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var usersCount = context.Chats.ToList().Count;
                var messagesCount = context.Messages.ToList().Count();
                Console.WriteLine($"Users: {usersCount}\nMessages: {messagesCount}");
            }
        }
    }
}
