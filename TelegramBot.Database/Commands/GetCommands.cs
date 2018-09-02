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
        //static MainContext context = new MainContext();
        private static Random rnd = new Random();

        #region Images
        public static List<string> GetImages(ImageType type)
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
        #endregion

        #region Messages
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

        public static List<IncomeMessage> GetIncomeMessages()
        {
            List<IncomeMessage> incomeMessages = new List<IncomeMessage>();
            using (MainContext context = new MainContext())
            {
                foreach(var msg in context.IncomeMessages)
                {
                    incomeMessages.Add(msg); 
                }
            }

            return incomeMessages; 
        }
#endregion

        #region Users
        public static List<Admin> GetAdmins()
        {
            List<Admin> admins = new List<Admin>();
            using (MainContext context = new MainContext())
            {
                foreach(var admin in context.Admins)
                {
                    admins.Add(admin);
                }
            }

            return admins;
        }

        public static List<BlackList> GetBlackList()
        {
            List<BlackList> blackList = new List<BlackList>();
            using (MainContext context = new MainContext())
            {
                foreach(var user in context.BlackList)
                {
                    blackList.Add(user);
                }
                return blackList;
            }

            
        }
        #endregion
    }
}
