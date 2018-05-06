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
using TelegramBot.Models;

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
                        try
                        {
                            rtbInput.Text += "MSG ID: " + message.MessageId.ToString()
                            + " | MSG Text: " + message.Text.ToString()
                            + " | CHAT ID: " + message.From.Id.ToString() + "\n";
                        }
                        catch { }
                    });

                    if (message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage)
                    {
                        var msg = message.Text.ToLower();
                        // Позже, возможно, оптимизирую! :)

                        if (msg.Length <= 100)
                        {
                            if (msg.Contains("привет") || msg.Contains("ку") || msg.Contains("здарова"))
                            {
                                int i = rnd.Next(0, Words.hello.Length);
                                await Bot.SendTextMessageAsync(message.Chat.Id, Words.hello[i], replyToMessageId: message.MessageId);
                            }

                            else if (message.Text == "/start")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Привет! :)", replyToMessageId: message.MessageId); // Описание действия 
                            }

                            else if (msg.Contains("пидор") || msg.Contains("дурак") || msg.Contains("чмо") || msg.Contains("хуй"))
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Я робот, я не могу им быть!", replyToMessageId: message.MessageId);
                            }

                            else if (msg.Contains("бля"))
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Сам ты бля!", replyToMessageId: message.MessageId);
                            }

                            else if (msg.Contains("зовут"))
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Я хлебушек!");
                            }

                            else if (msg.Contains("дела"))
                            {
                                int i = rnd.Next(0, Words.mood.Length);
                                await Bot.SendTextMessageAsync(message.Chat.Id, Words.mood[i], replyToMessageId: message.MessageId);
                            }

                            else if (msg.Contains("олбанский") || msg.Contains("олбанском"))
                            {
                                int i = rnd.Next(0, Words.olbanskyi.Length);
                                await Bot.SendTextMessageAsync(message.Chat.Id, Words.olbanskyi[i], replyToMessageId: message.MessageId);
                            }

                            else if (message.Text == "/sendcat")
                            {
                                List<string> imageArr = new List<string>();

                                using (CatImagesContext context = new CatImagesContext())
                                {
                                    var images = context.Images;
                                    foreach(CatImages image in images)
                                    {
                                        if(image.ImageUrl != null)
                                            imageArr.Add(image.ImageUrl);
                                    }

                                    int i = rnd.Next(0, imageArr.Count);

                                    Telegram.Bot.Types.FileToSend fileSend;
                                    Uri cat = new Uri(imageArr[i]);
                                    fileSend.Url = cat;

                                    await Bot.SendPhotoAsync(message.Chat.Id, fileSend, "Мяу!");
                                }
                                
                            }
                            
                            else if(message.Text == "/wallpaper" || msg.Contains("обои") || msg.Contains("рабочий стол"))
                            {
                                List<string> imageArr = new List<string>();

                                using (WallpapersContext context = new WallpapersContext())
                                {
                                    var images = context.Images;

                                    foreach(Wallpapers image in images)
                                    {
                                        if (image.ImageUrl != null)
                                            imageArr.Add(image.ImageUrl);
                                    }

                                    int i = rnd.Next(0, imageArr.Count);

                                    Telegram.Bot.Types.FileToSend fileSend;
                                    Uri wallpaper = new Uri(imageArr[i]);
                                    fileSend.Url = wallpaper;

                                    await Bot.SendPhotoAsync(message.Chat.Id, fileSend, "Ты сказал « обои »? Ставь на рабочий стол! :)");
                                }
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
                        else await Bot.SendTextMessageAsync(message.Chat.Id, "Многабукаф!!");
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
