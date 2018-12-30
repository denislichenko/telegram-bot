using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Database.Models;
using TelegramBot.Database.Models.Messanges;
using TelegramBot.Database.Models.Users;

namespace TelegramBot.Database
{
    public enum ImageType
    {
        Cat,
        Wallpaper
    }

    public static class GetCommands
    {
        private static MainContext context = new MainContext();
        private static Random rnd = new Random();

        #region Images
        public static List<string> GetImages(ImageType type)
        {
            switch (type)
            {
                case ImageType.Cat:
                    return context.Cats.Select(x => x.ImageUrl).ToList();
                case ImageType.Wallpaper:
                    return context.Wallpapers.Select(x => x.ImageUrl).ToList();
                default:
                    return new List<string>(); 
            }
        }
        #endregion

        #region Messages
        public static List<Message> GetMessages()
        {
            return context.Messanges.ToList(); 
        }

        public static List<IncomeMessage> GetIncomeMessages()
        {
            return context.IncomeMessages.ToList(); 
        }
#endregion

        #region Users
        public static List<Admin> GetAdmins()
        {
            return context.Admins.ToList();
        }

        public static List<BlackList> GetBlackList()
        {
            return context.BlackList.ToList(); 
        }
        #endregion
    }
}
