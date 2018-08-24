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
            DatabaseCommands.CreateMessage("test", "test1");
            MainContext context = new MainContext();
            Console.WriteLine(context.Messanges.Count());
            Console.ReadLine(); 
        }
    }
}
