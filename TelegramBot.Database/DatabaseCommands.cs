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

        //public static List<string> DownloadImages(ImageType type)
        //{
        //    List<string> imageArr = new List<string>();

        //    switch (type)
        //    {
        //        case ImageType.Cat:
        //            var cats = context.Cats;
        //            foreach (CatImages image in cats)
        //            {
        //                if (image.ImageUrl != null)
        //                    imageArr.Add(image.ImageUrl);
        //            }
        //            break;
        //        case ImageType.Wallpaper:
        //            var wallpapers = context.Wallpapers;

        //            foreach (Wallpapers image in wallpapers)
        //            {
        //                if (image.ImageUrl != null)
        //                    imageArr.Add(image.ImageUrl);
        //            }
        //            break;
        //    }

        //    return imageArr;
        //}

        public static async void CreateMessage(string income, string reply)
        {
            using (MainContext context = new MainContext())
            {
                Message model = new Message
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
