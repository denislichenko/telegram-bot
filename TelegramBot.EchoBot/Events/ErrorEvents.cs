using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Args;

namespace TelegramBot.EchoBot.Events
{
    public static class ErrorEvents
    {
        public static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Console.WriteLine("Received error: {0} — {1}",
                receiveErrorEventArgs.ApiRequestException.ErrorCode,
                receiveErrorEventArgs.ApiRequestException.Message);
        }
    }
}
