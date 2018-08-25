using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Database.Models;

namespace TelegramBot.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var messages = DatabaseCommands.GetMessages();
            Console.WriteLine(messages.Count());
            Console.ReadLine(); 
        }
    }
}
