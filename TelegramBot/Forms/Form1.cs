// My First Telegram Bot with GUI

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using TelegramBot.Models;
using MetroFramework.Forms;
using TelegramBot.Forms;
using Telegram.Bot.Args;
using System.Linq;
using Telegram.Bot.Types.Enums;

namespace TelegramBot
{
    public partial class MainForm : MetroForm
    {
        BackgroundWorker bw;
        public static Telegram.Bot.TelegramBotClient Bot;
        public List<string> CatImages = Commands.DownloadImages(ImageType.Cat);
        public List<string> WallpaperImages = Commands.DownloadImages(ImageType.Wallpaper);
        public MessageContext messageContext = new MessageContext();
        public string[] blackList = { "0" }; 
        public MainForm()
        {
            InitializeComponent();

            this.bw = new BackgroundWorker();
            this.bw.DoWork += this.bw_DoWorkAsync;
        }

        public async void bw_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            var key = e.Argument as String;
            Bot = new Telegram.Bot.TelegramBotClient("557031482:AAH--c8jZKgREyK9rZ0RgUI2ccw8-wIS2ow");
            Bot.OnMessage += OnMessageReceived;
            Bot.OnMessageEdited += OnMessageReceived;
            Bot.OnCallbackQuery += OnCallBackQueryReceived;
            Bot.OnInlineQuery += OnInlineQueryReceived;
            Bot.OnInlineResultChosen += OnInlineResultChosenReveived;
            Bot.OnReceiveError += OnReceiveError;
                 
            Bot.StartReceiving(Array.Empty<UpdateType>());
        }

        private void OnReceiveError(object sender, ReceiveErrorEventArgs e)
        {
            rtbInput.Text += string.Format("Received error: {0} - {1}",
                e.ApiRequestException.ErrorCode,
                e.ApiRequestException.Message);
        }

        private void OnInlineResultChosenReveived(object sender, ChosenInlineResultEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnInlineQueryReceived(object sender, InlineQueryEventArgs e)
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

        private async void OnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            Random rnd = new Random();
            int i;
            Telegram.Bot.Types.FileToSend fileSend;

            if (message == null || message.Type != Telegram.Bot.Types.Enums.MessageType.TextMessage) return;

            rtbInput.Invoke((MethodInvoker)delegate
            {
                rtbInput.Text += $"MSG ID: {message.MessageId} | MSG Text: {message.Text.ToString()} | CHAT ID: {message.From.Id.ToString()} \n";
            });

            try
            {
                switch (message.Text.ToLower())
                {
                    case "/start":
                        i = rnd.Next(0, Words.start.Length);
                        await Bot.SendTextMessageAsync(message.Chat.Id, Words.start[i], replyToMessageId: message.MessageId);
                        break;
                    case "/sendcat":
                        i = rnd.Next(0, CatImages.Count);
                        Uri cat = new Uri(CatImages[i]);
                        fileSend.Url = cat;
                        await Bot.SendPhotoAsync(message.Chat.Id, fileSend, "Meow!");
                        break;
                    case "/wallpaper":
                        // Отправляем пользователю рандомное изображение 
                        i = rnd.Next(0, WallpaperImages.Count);

                        Uri wallpaper = new Uri(WallpaperImages[i]);
                        fileSend.Url = wallpaper;

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

                                rtbInput.Invoke((MethodInvoker)delegate
                                {
                                    rtbInput.Text += $"\nCreated new message: {incomeMessage} | {replyMessage}\n" +
                                                     $"User Id: {message.Chat.Id}\n";
                                });

                                Commands.CreateMessage(incomeMessage, replyMessage);

                                await Bot.SendTextMessageAsync(message.Chat.Id, $"Add message: {incomeMessage} | {replyMessage}", replyToMessageId: message.MessageId);
                                break;
                            }

                        }

                        var messanges = messageContext.Messanges;
                        var answer = messanges.Where(x => x.IncomeMessage == message.Text.ToLower()).ToList();

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
            catch { }
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var key = "557031482: AAH--c8jZKgREyK9rZ0RgUI2ccw8 - wIS2ow"; // Токен бота

            if (key != "" && this.bw.IsBusy != true)
            {
                rtbInput.Text += "Бот запущен!\n";
                this.bw.RunWorkerAsync("557031482: AAH--c8jZKgREyK9rZ0RgUI2ccw8 - wIS2ow");
            }
        }

        private void btnForm2_Click(object sender, EventArgs e)
        {
            DataBaseForm form = new DataBaseForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageForm form = new MessageForm();
            form.Show();
        }
    }
}
