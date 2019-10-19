using System;

namespace TelegramBot.EchoBot
{
    class Program
    {
        static void Main(string[] args)
        {
            EchoBot.Models.Bot.GetBotClientAsync(); 
            Console.ReadLine();
        }
    }
}
