using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using TelegramBot.Database.Controllers;
using TelegramBot.Database.Models.Chats;
using Bot = TelegramBot.EchoBot.Models.Bot;

namespace TelegramBot.EchoBot.Events
{
    public static class MessageEvents
    {
        private static TelegramBotClient botClient = Bot.GetBotClientAsync();
        public async static void OnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.Text) return;

            var chat = ChatController.GetChat(message.Chat.Id, message.From.Id);

            switch (message.Text.Split(' ').First())
            {
                case "/start":
                    await ChatController.CreateChat(message.Chat.Id, message.From.Id, message.From.Username);
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Started!", replyToMessageId: message.MessageId);
                    break;
                case "/createmessage":
                    await ChatController.SetStep(1, 1, chat); 
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Send input message", replyToMessageId: message.MessageId);
                    break;
                default:
                    switch (chat.Status)
                    {
                        case 1:
                            CreateMessageDialog(chat, message.Text);
                            break;
                        default:
                            var answer = await MessageController.GetAnswer(message.Text);
                            await botClient.SendTextMessageAsync(message.Chat.Id, answer);
                            break; 
                    }
                    break;
            }

        }

        public async static void CreateMessageDialog(Chat chat, string messageText)
        {
            switch (chat.Step)
            {
                case 1:
                    await MessageController.CreateMessage(messageText, string.Empty, chat.Id);
                    await ChatController.SetStep(1, 2, chat); 
                    await botClient.SendTextMessageAsync(chat.ChatId, "Send output message");
                    break;
                case 2:
                    await MessageController.UpdateMessage(messageText, chat.Id); 
                    await ChatController.SetStep(0, 0, chat); 
                    await botClient.SendTextMessageAsync(chat.ChatId, "Done! Message saved!");
                    break;
            }
        }
    }
}
