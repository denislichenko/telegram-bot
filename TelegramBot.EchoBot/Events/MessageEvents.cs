using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using TelegramBot.Database.Controllers;
using TelegramBot.Database.Models.Chats;
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

            var chat = ChatController.GetChat(message.Chat.Id, message.From.Id);
            if(chat == null || (chat.Status == 0 && chat.Step == 0))
            {
                switch (message.Text.Split(' ').First())
                {
                    case "/start":
                        await ChatController.CreateChat(new Chat
                        {
                            ChatId = message.Chat.Id,
                            UserId = message.From.Id,
                            UserName = message.From.Username
                        });
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Started!", replyToMessageId: message.MessageId);
                        break;
                    case "/createmessage":
                        await ChatController.UpdateChat(new Chat
                        {
                            ChatId = message.Chat.Id,
                            UserId = message.From.Id,
                            Status = 1,
                            Step = 1
                        });
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Send input message", replyToMessageId: message.MessageId);
                        break;
                }
            }
            //else
            //{
            //    if(chat.Status == 1 && chat.Step == 1)
            //    {
            //        await ChatController.UpdateChat(new Chat
            //        {
            //            ChatId = message.Chat.Id,
            //            UserId = message.From.Id,
            //            Status = 1,
            //            Step = 2
            //        });
            //        await botClient.SendTextMessageAsync(message.Chat.Id, "Send output message", replyToMessageId: message.MessageId); 
            //    }
            //    if (chat.Status == 1 && chat.Step == 2)
            //    {
            //        await ChatController.UpdateChat(new Chat
            //        {
            //            ChatId = message.Chat.Id,
            //            UserId = message.From.Id,
            //            Status = 0,
            //            Step = 0
            //        });
            //        await botClient.SendTextMessageAsync(message.Chat.Id, "Done! Message saved!", replyToMessageId: message.MessageId);
            //    }
            //}
            
        }
    }
}
