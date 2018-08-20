using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using TelegramBot.Models;

namespace TelegramBot
{
    public enum ImageType
    {
        Cat,
        Wallpaper
    }

    public static class Commands
    {
        public static MessageContext context = new MessageContext();
        private static Random rnd = new Random(); 

        public static List<string> DownloadImages(ImageType type)
        {
            List<string> imageArr = new List<string>();

            switch(type)
            {
                case ImageType.Cat:
                    using (CatImagesContext context = new CatImagesContext())
                    {
                        var images = context.Images;
                        foreach (CatImages image in images)
                        {
                            if (image.ImageUrl != null)
                                imageArr.Add(image.ImageUrl);
                        }
                    }
                    break;
                case ImageType.Wallpaper:
                    using (WallpapersContext context = new WallpapersContext())
                    {
                        var images = context.Images;

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

        public static async void CreateMessage(string income, string reply)
        {
            using (MessageContext context = new MessageContext())
            {
                MessageModel model = new MessageModel
                {
                    IncomeMessage = income,
                    ReplyMessage = reply
                };

                context.Messanges.Add(model);
                await context.SaveChangesAsync(); 
            }
        }
    }
}
