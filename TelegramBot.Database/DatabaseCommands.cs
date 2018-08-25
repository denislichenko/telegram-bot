using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Database.Models;

namespace TelegramBot.Database
{
    public enum ImageType
    {
        Cat,
        Wallpaper
    }

    public static class DatabaseCommands
    {
        //static MainContext context = new MainContext();
        private static Random rnd = new Random();

        public static List<string> DownloadImages(ImageType type)
        {
            List<string> imageArr = new List<string>();

            switch (type)
            {
                case ImageType.Cat:
                    using (MainContext context = new MainContext())
                    {
                        var images = context.Cats;
                        foreach (CatImages image in images)
                        {
                            if (image.ImageUrl != null)
                                imageArr.Add(image.ImageUrl);
                        }
                    }
                    break;
                case ImageType.Wallpaper:
                    using (MainContext context = new MainContext())
                    {
                        var images = context.Wallpapers;

                        foreach (Wallpapers image in images)
                        {
                            if (image.ImageUrl != null)
                                imageArr.Add(image.ImageUrl);
                        }
                    }
                    break;
            }

            return imageArr;
        }

        public static List<Message> GetMessages()
        {
            List<Message> messages = new List<Message>(); 
            using (MainContext context = new MainContext())
            {
                var msgs = context.Messanges;
                foreach(var i in msgs)
                {
                    messages.Add(i);
                }

                return messages; 
            }
        }

        public static async void CreateMessage(string income, string reply)
        {
            using (MainContext context = new MainContext())
            {
                Message model = new Message
                {
                    IncomeMessage = income,
                    ReplyMessage = reply,
                    CreationDate = DateTime.Now,
                    ChatId = 0
                };

                context.Messanges.Add(model);
                await context.SaveChangesAsync();
            }    
        }
    }
}
