using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Database;
using TelegramBot.Database.Models.Users;

namespace TelegramBot.Logic
{
    public static class BotUtilities
    {
        public static void CreateMessage(Telegram.Bot.Types.Message message)
        {
            if (!GetCommands.GetBlackList().Select(x => x.ChatId).Contains(message.Chat.Id))
            {
                string income = message.Text.Substring(0, message.Text.IndexOf(">")).Trim().ToLower();
                string outgoing = message.Text.Substring(message.Text.IndexOf(">") + 1).Trim();
                CreateCommands.CreateMessage(income, outgoing, message.Chat.Id);

                BotConsole.SuccessMessage(string.Format($"Created new message: {income} | {outgoing}\n" +
                                             $"User Id: {message.Chat.Id}\n"));

                SendMessage(message, $"You have created a message.\n" +
                                     $"Incoming message: {income}\n" +
                                     $"Outgoing message: {outgoing}");
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

        public static async void SendMessage(Telegram.Bot.Types.Message message, string answerText)
        {
            await BotConfiguration.Bot.SendTextMessageAsync(message.Chat.Id, answerText, replyToMessageId: message.MessageId);
        }
    }
}
