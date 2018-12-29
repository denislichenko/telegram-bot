using System;
using System.Collections.Generic;
using Telegram.Bot.Args;
using System.Linq;
using Telegram.Bot.Types.Enums;
using TelegramBot.Database;
using TelegramBot.Database.Models;

namespace TelegramBot.Logic
{
    class Program
    {
        public static MainContext context = new MainContext();
        public static List<string> CatImages;
        public static List<string> WallpaperImages;
        public static List<Database.Models.Message> messages;

        static void Main(string[] args)
        {
            Start();
            Console.ReadKey();
        }

        public static void Start()
        {
            BotConsole.SuccessMessage("Loading...");
            CatImages = GetCommands.GetImages(ImageType.Cat);
            WallpaperImages = GetCommands.GetImages(ImageType.Wallpaper);

            BotConfiguration.Bot = new Telegram.Bot.TelegramBotClient("");
            BotConfiguration.Bot.OnMessage += OnMessageReceived;
            BotConfiguration.Bot.OnMessageEdited += OnMessageReceived;
            BotConfiguration.Bot.OnCallbackQuery += OnCallBackQueryReceived;
            BotConfiguration.Bot.OnReceiveError += OnReceiveError;

            BotConfiguration.Bot.StartReceiving(Array.Empty<UpdateType>());
            BotConfiguration.Status = true;

            BotConsole.SuccessMessage("Bot has been started!");
        }

        private static void OnReceiveError(object sender, ReceiveErrorEventArgs e)
        {
            BotConsole.ErrorMessage(string.Format("Received error: {0} - {1}",
                e.ApiRequestException.ErrorCode,
                e.ApiRequestException.Message));
        }

        private static async void OnCallBackQueryReceived(object sender, CallbackQueryEventArgs e)
        {
            var callbackQuery = e.CallbackQuery;
            await BotConfiguration.Bot.AnswerCallbackQueryAsync(
                callbackQuery.Id,
                $"Received {callbackQuery.Data}");
            await BotConfiguration.Bot.SendTextMessageAsync(
                callbackQuery.Message.Chat.Id,
                $"Received {callbackQuery.Data}");
        }

        private static async void OnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            Telegram.Bot.Types.FileToSend fileSend;
            Random rnd = new Random(); 

            BotConsole.SuccessMessage(string.Format("ID: {0} | TEXT: {1} | ChatID: {2}",
                message.MessageId, message.Text.ToString(), message.Chat.Id));

            try
            {
                switch (message.Text.ToLower())
                {
                    case "/start":
                        string welcomeMessage = string.Format("Првет! Я Супер Котяра! Я могу защитить тебя! (но мне лень)\n" +
                            "Я могу отправить тебе фотку своих бро - /sendcat ,\n" +
                            "А также выбрать тебе новые обои на рабочий стол - /wallpaper . \n" +
                            "НО ЭТО НЕ ФСЁ! Также я учу новые слова и ты должен мне помочь!\n" +
                            "Почему ты? Потому что мой хАзяин (@denislichenko) сказал, что ему леьн!\n" +
                            "А Я НЕ ХОЧУ БЫТЬ ТУПЫМ КОТОМ! ПОЭТОМУ ПОМОООГИ МНЕ!\n\n" +
                            "Что-бы добавить новую фразу введи: \n" +
                            "входящее_сообщение>исходящее_сообщение");
                        await BotConfiguration.Bot.SendTextMessageAsync(message.Chat.Id, welcomeMessage, replyToMessageId: message.MessageId);
                        break;

                    case "/sendcat":
                        fileSend.Url = BotUtilities.ReturnRandomUrl(CatImages);
                        await BotConfiguration.Bot.SendPhotoAsync(message.Chat.Id, fileSend, "Meow!");
                        break;
                    case "/wallpaper":
                        fileSend.Url = BotUtilities.ReturnRandomUrl(WallpaperImages); ;
                        await BotConfiguration.Bot.SendPhotoAsync(message.Chat.Id, fileSend, "Ты сказал « обои »? Ставь на рабочий стол! :)");
                        break;
                    default:
                        if (message.Text.Contains(">"))
                        {
                            BotUtilities.CreateMessage(message);    
                            break;
                        }

                        messages = GetCommands.GetMessages();
                        List<string> answer = messages.Where(x => message.Text.ToLower().Contains(x.IncomeMessage.ToLower()))
                                                      .Select(x => x.ReplyMessage).ToList();
                        if (answer.Count != 0)
                        {
                            if (answer.Count > 1)
                            {
                                int i = rnd.Next(0, answer.Count);
                                BotUtilities.SendMessage(message, answer[i]);
                                break;
                            }
                            BotUtilities.SendMessage(message, answer[0]);
                            break;
                        }
                        BotUtilities.SendMessage(message, "Unknown command! Send message format:\n" +
                            "{income message}>{outgoing message}, so that I can remember the answer!", status: false);
                        break;
                }
            }
            catch(Exception ex)
            {
                BotConsole.ErrorMessage(ex.Message);
            }

        }
    }
}
