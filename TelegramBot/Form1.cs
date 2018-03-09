// My First Telegram Bot with GUI

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelegramBot
{
    public partial class Form1 : Form
    {
        BackgroundWorker bw;

        public Form1()
        {
            InitializeComponent();

            this.bw = new BackgroundWorker();
            this.bw.DoWork += this.bw_DoWorkAsync;
        }

        public async void bw_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            string log = "";
            var worker = sender as BackgroundWorker;
            var key = e.Argument as String;
            
            // Если ключ не подходит - бросаем исключение 
            try
            {
                var Bot = new Telegram.Bot.TelegramBotClient(key); // Инициализируем
                await Bot.SetWebhookAsync(""); // Убираем старую привязку к WebHook
                Random rnd = new Random();

                Bot.OnUpdate += async (object su, Telegram.Bot.Args.UpdateEventArgs updates) =>
                {
                    if (updates.Update.CallbackQuery != null || updates.Update.InlineQuery != null) return;
                    var update = updates.Update;
                    var message = update.Message;
                    if (message == null) return;

                    rtbInput.Invoke((MethodInvoker)delegate
                    {
                        rtbInput.Text += "MSG ID: " + message.MessageId.ToString()
                        + " | MSG Text: " + message.Text.ToString()
                        + " | CHAT ID: " + message.From.Id.ToString() + "\n";
                    });

                    if (message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage)
                    {
                        // Позже, возможно, оптимизирую! :)
                        if (message.Text.Contains("ello") || message.Text.Contains("Привет") || message.Text.Contains("привет")
                            || message.Text.Contains("ку") || message.Text.Contains("Ку") || message.Text.Contains("Здарова") || message.Text.Contains("здарова"))
                        {
                            int i = rnd.Next(0, Words.hello.Length);
                            await Bot.SendTextMessageAsync(message.Chat.Id, Words.hello[i], replyToMessageId: message.MessageId);
                        }

                        else if (message.Text == "/start")
                        {
                            // KeyboardButtons
                            var markup = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup(new[]
                            {
                                    new Telegram.Bot.Types.KeyboardButton("Привет"),
                                    new Telegram.Bot.Types.KeyboardButton("Ку"),
                                    new Telegram.Bot.Types.KeyboardButton("Hello"),
                            });
                            markup.OneTimeKeyboard = true;
                            await Bot.SendTextMessageAsync(message.Chat.Id, "Поздоровайтесь! :)", replyMarkup: markup); // Описание действия 
                        }

                        else if(message.Text.Contains("идор") || message.Text.Contains("урак") || message.Text.Contains("чмо") || message.Text.Contains("хуй"))
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, "Я робот, я не могу им быть!", replyToMessageId: message.MessageId);
                        }

                        else if(message.Text.Contains("зовут"))
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, "Я хлебушек!");
                        }

                        else if (message.Text.Contains("дела"))
                        {
                            int i = rnd.Next(0, Words.mood.Length);
                            await Bot.SendTextMessageAsync(message.Chat.Id, Words.mood[i], replyToMessageId: message.MessageId);
                        }

                        else if (message.Text == "/sendcat")
                        {

                            int i = rnd.Next(0, Words.cats.Length);

                            Telegram.Bot.Types.FileToSend fl;
                            Uri cat = new Uri(Words.cats[i]);
                            fl.Url = cat;
                            await Bot.SendPhotoAsync(message.Chat.Id, fl, "Мяу!");
                        }
                        else if(message.Text == "/smile")
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, ":smirk:");
                        }
                        else
                        {
                            //int i = rnd.Next(0, Words.other.Length);
                            await Bot.SendTextMessageAsync(message.Chat.Id, message.Text, replyToMessageId: message.MessageId);
                            rtbUndefined.Invoke((MethodInvoker)delegate
                            {
                                rtbUndefined.Text += message.Text.ToString() + "\n";
                            });
                        }
                    }
                };
                Bot.StartReceiving(); // Запуск приема обновлений 
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex) 
            {
                rtbInput.Invoke((MethodInvoker)delegate
                {
                    rtbInput.Text += ex.Message.ToString();
                });
            }
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;

            if (text != "" && this.bw.IsBusy != true)
            {
                rtbInput.Text += "Бот запущен!\n";
                this.bw.RunWorkerAsync(text);
            }
        }
    }
}
