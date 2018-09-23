using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Logic
{
    public static class BotConsole
    {
        public static void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" > ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"| {message}");
        }

        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" x ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"| {message}");
        }
    }
}
