using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Bot = TelegramBot.EchoBot.Models.Bot; 

namespace TelegramBot.EchoBot.Events
{
    public static class MessageEvents
    {
        public async static void OnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            var botClient = Bot.GetBotClientAsync(); 
            if (message == null || message.Type != MessageType.Text) return; 

            switch(message.Text.Split(' ').First())
            {
                case "/start":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Started!", replyToMessageId: message.MessageId); 
                    break;
            }
        }
    }
}
