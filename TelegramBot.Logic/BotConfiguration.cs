using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Logic
{
    public static class BotConfiguration
    {
        public static Telegram.Bot.TelegramBotClient Bot;
        public static bool Status { get; set; } = false; 
        public static string BotToken { get; set; }
        public static string Socks5Host { get; set; }
        public static int Socks5Port { get; set; }
    }
}
