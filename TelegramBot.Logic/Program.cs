using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Logic
{
    class Program
    {
        public static Telegram.Bot.TelegramBotClient Bot;

        static void Main(string[] args)
        {
            Bot = new Telegram.Bot.TelegramBotClient("557031482:AAH--c8jZKgREyK9rZ0RgUI2ccw8-wIS2ow");
            Bot.OnMessage += OnMessageReceived;
            Bot.OnMessageEdited += OnMessageReceived;
            Bot.OnCallbackQuery += OnCallBackQueryReceived;
            Bot.OnInlineQuery += OnInlineQueryReceived;
            Bot.OnInlineResultChosen += OnInlineResultChosenReveived;
            Bot.OnReceiveError += OnReceiveError;

            Bot.StartReceiving(Array.Empty<UpdateType>());
            SuccessMessage("Bot started!");
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
                callbackQuery.Id,
                $"Received {callbackQuery.Data}"); 
        }

        private static void OnMessageReceived(object sender, MessageEventArgs e)
        {
            throw new NotImplementedException();
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
