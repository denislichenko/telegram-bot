using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Database.Models;

namespace TelegramBot.Database
{
    public static class CreateCommands
    {
        #region Images
        public static async void CreateCatImage(string url)
        {
            using (MainContext context = new MainContext())
            {
                context.Cats.Add(new CatImages { ImageUrl = url });
                await context.SaveChangesAsync(); 
            }
        }

        public static async void CreateWallpaper(string url)
        {
            using (MainContext context = new MainContext())
            {
                context.Wallpapers.Add(new Wallpapers { ImageUrl = url });
                await context.SaveChangesAsync(); 
            }
        }
        #endregion

        #region Messages
        public static async void CreateMessage(string income, string reply, long chatId, string username)
        {
            using (MainContext context = new MainContext())
            {
                context.Messanges.Add(new Message
                {
                    IncomeMessage = income,
                    ReplyMessage = reply,
                    CreationDate = DateTime.Now,
                    ChatId = chatId,
                    Username = username
                });
                await context.SaveChangesAsync();
            }
        }

        public static async void CreateIncomeMessage(long chatId, string messageText, bool messageStatus, string username)
        {
            using (MainContext context = new MainContext())
            {
                context.IncomeMessages.Add(new Models.Messanges.IncomeMessage
                {
                    ChatId = chatId,
                    Message = messageText,
                    Answer = messageStatus,
                    Date = DateTime.Now,
                    Username = username
                });
                await context.SaveChangesAsync();
            }
        }
        #endregion

        #region Users
        public static async void CreateAdmin(long chatId, int level, string name)
        {
            using (MainContext context = new MainContext())
            {
                context.Admins.Add(new Models.Users.Admin
                {
                    ChatId = chatId,
                    Level = level,
                    Name = name,
                    CreateDate = DateTime.Now
                });
                await context.SaveChangesAsync();
            }
        }

        public static async void AddToBlackList(long chatId, int muteLevel, string comment, int adminId, string adminName)
        {
            using (MainContext context = new MainContext())
            {
                context.BlackList.Add(new Models.Users.BlackList
                {
                    ChatId = chatId,
                    MuteLevel = muteLevel,
                    Comment = comment,
                    AdminId = adminId,
                    AdminName = adminName,
                    CreateDate = DateTime.Now
                });
                await context.SaveChangesAsync(); 
            }
        }
        #endregion
    }
}
