// My First Telegram Bot with GUI

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using TelegramBot.Models;
using MetroFramework.Forms; 

namespace TelegramBot
{
    public partial class MainForm : MetroForm
    {
        BackgroundWorker bw;

        public MainForm()
        {
            InitializeComponent();

            this.bw = new BackgroundWorker();
            this.bw.DoWork += this.bw_DoWorkAsync;
        }

        public async void bw_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var key = e.Argument as String;
       
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

                    #region Команды бота
                    if (message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage)
                    {
                        var msg = message.Text.ToLower(); // Переводим входящее сообщение в нижний регистр

                        /* 
                           Если длина сообщения меньше или равно 100, то соответствующее сообщение, 
                           иначе выводим сообщение о превышении длины. 
                        */

                        if (msg.Length <= 100)
                        {
                            if (message.Text == "/start")
                            {
                                // Выводим в ответ случайное приветствие
                                int i = rnd.Next(0, Words.start.Length);
                                await Bot.SendTextMessageAsync(message.Chat.Id, Words.start[i], replyToMessageId: message.MessageId); // Описание действия 
                            }

                            else if (msg.IsOneOf("дела"))
                            {
                                // Генерируем рандомное значение переменной i, затем выводим ответ пользователю
                                int i = rnd.Next(0, Words.mood.Length);
                                await Bot.SendTextMessageAsync(message.Chat.Id, Words.mood[i], replyToMessageId: message.MessageId);
                            }

                            else if (msg.IsOneOf("олбанский", "олбанском"))
                            {
                                // Генерируем рандомное значение переменной i, затем выводим ответ пользователю
                                int i = rnd.Next(0, Words.olbanskyi.Length);
                                await Bot.SendTextMessageAsync(message.Chat.Id, Words.olbanskyi[i], replyToMessageId: message.MessageId);
                            }

                            else if (msg.IsOneOf("/sendcat", "мяу"))
                            {
                                // В этот массив будем помещать URL адреса из базы данных
                                List<string> imageArr = new List<string>();

                                // Если коллекция пустая - скачиваем данные с базы данных
                                if (imageArr != null)
                                {
                                    using (CatImagesContext context = new CatImagesContext())
                                    {
                                        var images = context.Images;
                                        foreach (CatImages image in images)
                                        {
                                            if (image.ImageUrl != null)
                                                imageArr.Add(image.ImageUrl);
                                        }
                                    }
                                }

                                // Отправляем пользователю рандомное изображение 
                                int i = rnd.Next(0, imageArr.Count);

                                Telegram.Bot.Types.FileToSend fileSend;
                                Uri cat = new Uri(imageArr[i]);
                                fileSend.Url = cat;

                                await Bot.SendPhotoAsync(message.Chat.Id, fileSend, "Мяу!");

                            }
                            
                            else if (msg.IsOneOf("/wallpaper", "обои", "рабочий стол"))
                            {
                                // В этот массив будем помещать URL адреса из базы данных
                                List<string> imageArr = new List<string>();

                                // Если коллекция пустая - то скачиваем данные с базы данных
                                if (imageArr != null)
                                {
                                    using (WallpapersContext context = new WallpapersContext())
                                    {
                                        var images = context.Images;

                                        foreach (Wallpapers image in images)
                                        {
                                            if (image.ImageUrl != null)
                                                imageArr.Add(image.ImageUrl);
                                        }  
                                    }
                                }

                                // Отправляем пользователю рандомное изображение 
                                int i = rnd.Next(0, imageArr.Count);

                                Telegram.Bot.Types.FileToSend fileSend;
                                Uri wallpaper = new Uri(imageArr[i]);
                                fileSend.Url = wallpaper;

                                await Bot.SendPhotoAsync(message.Chat.Id, fileSend, "Ты сказал « обои »? Ставь на рабочий стол! :)");
                            }

                            else
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, message.Text, replyToMessageId: message.MessageId);

                                // Если не знаем ответа на входящую фразу - добавляем ее в rtbUndefined
                                rtbUndefined.Invoke((MethodInvoker)delegate
                                {
                                    rtbUndefined.Text += message.Text.ToString() + "\n";
                                });
                            }
                        }
                        else await Bot.SendTextMessageAsync(message.Chat.Id, "Многабукаф!!"); 
                    }
                    #endregion
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
            var key = textBox1.Text; // Токен бота

            if (key != "" && this.bw.IsBusy != true)
            {
                rtbInput.Text += "Бот запущен!\n";
                this.bw.RunWorkerAsync(key);
            }
        }

        private void btnForm2_Click(object sender, EventArgs e)
        {
            DataBaseForm form = new DataBaseForm();
            form.Show();
        }
    }
}
