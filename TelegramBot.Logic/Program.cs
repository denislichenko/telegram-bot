using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Telegram.Bot.Args;
using System.Linq;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using TelegramBot.Database;
using TelegramBot.Database.Models;

namespace TelegramBot.Logic
{
    class Program
    {
        public static MainContext context = new MainContext();
        public static BackgroundWorker bw;
        public static Telegram.Bot.TelegramBotClient Bot;
        public static string[] blackList = { "0" };

        static void Main(string[] args)
        {
            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWorkAsync;
            bw.RunWorkerAsync("661233574:AAFLUWfYhQ9fbV4Oi5U2MrtwNz2OwyVZfbg");
            SuccessMessage("Bot has been started!");
            Console.ReadKey();
        }

        public static async void bw_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            var key = e.Argument as String;
            Bot = new Telegram.Bot.TelegramBotClient("661233574:AAFLUWfYhQ9fbV4Oi5U2MrtwNz2OwyVZfbg");
            Bot.OnMessage += OnMessageReceived;
            Bot.OnMessageEdited += OnMessageReceived;
            Bot.OnCallbackQuery += OnCallBackQueryReceived;
            Bot.OnInlineQuery += OnInlineQueryReceived;
            Bot.OnInlineResultChosen += OnInlineResultChosenReveived;
            Bot.OnReceiveError += OnReceiveError;

            Bot.StartReceiving(Array.Empty<UpdateType>());
        }

        private static void OnReceiveError(object sender, ReceiveErrorEventArgs e)
        {
            ErrorMessage(string.Format("Received error: {0} - {1}",
                e.ApiRequestException.ErrorCode,
                e.ApiRequestException.Message));
        }

        private static void OnInlineResultChosenReveived(object sender, ChosenInlineResultEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnInlineQueryReceived(object sender, InlineQueryEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static async void OnCallBackQueryReceived(object sender, CallbackQueryEventArgs e)
        {
            var callbackQuery = e.CallbackQuery;
            await Bot.AnswerCallbackQueryAsync(
                callbackQuery.Id,
                $"Received {callbackQuery.Data}");
            await Bot.SendTextMessageAsync(
                callbackQuery.Message.Chat.Id,
                $"Received {callbackQuery.Data}");
        }

        private static async void OnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            Random rnd = new Random();
            int i;
            Telegram.Bot.Types.FileToSend fileSend;

            SuccessMessage(string.Format("MSG ID - {0} | Text - {1} | ChatId - {2}",
                message.MessageId, message.Text.ToString(), message.Chat.Id));

            try
            {
                switch (message.Text.ToLower())
                {
                    case "/start":
                        await Bot.SendTextMessageAsync(message.Chat.Id, "Start", replyToMessageId: message.MessageId);
                        break;

                    case "/sendcat":
                        fileSend.Url = null;
                        await Bot.SendPhotoAsync(message.Chat.Id, fileSend, "Meow!");
                        break;
                    case "/wallpaper":
                        fileSend.Url = null;

                        await Bot.SendPhotoAsync(message.Chat.Id, fileSend, "Ты сказал « обои »? Ставь на рабочий стол! :)");
                        break;
                    default:

                        if (message.Text.Contains(">"))
                        {
                            foreach (string userId in blackList)
                            {
                                if (message.Chat.Id.ToString() == userId)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, $"You were deprived of this royal opportunity! :((", replyToMessageId: message.MessageId);
                                    break;
                                }

                                string incomeMessage = message.Text.Substring(0, message.Text.IndexOf(">")).Trim().ToLower();
                                string replyMessage = message.Text.Substring(message.Text.IndexOf(">") + 1).Trim();

                                SuccessMessage(string.Format($"\nCreated new message: {incomeMessage} | {replyMessage}\n" +
                                                             $"User Id: {message.Chat.Id}\n"));

                                DatabaseCommands.CreateMessage(incomeMessage, replyMessage);

                                await Bot.SendTextMessageAsync(message.Chat.Id, $"Add message: {incomeMessage} | {replyMessage}", replyToMessageId: message.MessageId);
                                break;
                            }

                        }

                        var messanges = DatabaseCommands.GetMessages();
                        var answer = messanges.Where(x => message.Text.ToLower().Contains(x.IncomeMessage.ToLower())).ToList();

                        if (answer.Count != 0)
                        {
                            if (answer.Count > 1)
                            {
                                i = rnd.Next(0, answer.Count);
                                await Bot.SendTextMessageAsync(message.Chat.Id, answer[i].ReplyMessage, replyToMessageId: message.MessageId);
                                break;
                            }

                            await Bot.SendTextMessageAsync(message.Chat.Id, answer[0].ReplyMessage, replyToMessageId: message.MessageId);
                            break;
                        }
                        else
                            await Bot.SendTextMessageAsync(message.Chat.Id, "Unknown command", replyToMessageId: message.MessageId);

                        break;


                }
            }
            catch(Exception ex)
            {
                ErrorMessage(ex.Message);
            }

        }

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
