using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using TelegramBot.Database;
using TelegramBot.Database.Models;
using TelegramBot.Database.Models.Users;

namespace TelegramBot.Logic
{
    public static class BotUtilities
    {
        static MainContext db; 
        public static void CreateMessage(Telegram.Bot.Types.Message message)
        {
            if (!GetCommands.GetBlackList().Select(x => x.ChatId).Contains(message.Chat.Id))
            {
                string income = message.Text.Substring(0, message.Text.IndexOf(">")).Trim().ToLower();
                string outgoing = message.Text.Substring(message.Text.IndexOf(">") + 1).Trim();
                CreateCommands.CreateMessage(income, outgoing, message.Chat.Id, message.Chat.Username);

                BotConsole.SuccessMessage($"@{message.Chat.Username}: Created new message: {income} | {outgoing}");

                SendMessage(message, $"You have created a message.\n" +
                                     $"Incoming message: <code>{income}</code>\n" +
                                     $"Outgoing message: <code>{outgoing}</code>");
            }
            else
                SendMessage(message, "You are not allowed to use this function");
        }

        public static Uri ReturnRandomUrl(List<string> list)
        {
            if (list.Count == 0) return new Uri("https://cdn.pixabay.com/photo/2018/03/27/17/25/cat-3266671_1280.jpg"); 
        
            Random rnd = new Random();
            int i = rnd.Next(0, list.Count);
            Uri result = new Uri(list[i]);
            return result; 
        }

        public static string GetStatistic(string username)
        {
            string result = string.Empty;
            db = new MainContext();

            result = $"Income messages: <code>{db.IncomeMessages.Count()}</code>\n" +
                     $"Created messages: <code>{db.Messanges.Count()}</code>\n" +
                     $"Messages from you: <code>{db.IncomeMessages.Where(x => x.Username == username).Count()}</code>\n" +
                     $"Cats images: <code>{db.Cats.Count()}</code>\n" +
                     $"Wallpapers: <code>{db.Wallpapers.Count()}</code>\n" +
                     $"Users in black list: <code>{db.BlackList.Count()}</code>\n";

            return result; 
        }

        public static async void SendMessage(Telegram.Bot.Types.Message message, string messageText, bool status = true)
        {
            await BotConfiguration.Bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: messageText,
                parseMode: ParseMode.Html,
                replyToMessageId: message.MessageId
                );
            CreateCommands.CreateIncomeMessage(
                chatId: message.Chat.Id,
                messageText: message.Text.ToString(),
                messageStatus: status,
                username: message.Chat.Username); 
        }
    }
}
