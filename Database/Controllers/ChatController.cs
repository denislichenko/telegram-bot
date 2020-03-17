using TelegramBot.Database.Models;
using TelegramBot.Database.Models.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Database.Controllers
{
    public static class ChatController
    {
        public static Chat GetChat(long chatId, int userId)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.Chats.Where(x => x.ChatId == chatId && x.UserId == userId).FirstOrDefault(); 
            }
        }
        public static async Task CreateChat(long chatId, int userId, string userName)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var exChat = context.Chats.Where(x => x.ChatId == chatId && x.UserId == userId).FirstOrDefault();
                if(exChat == null)
                {
                    await context.Chats.AddAsync(new Chat { ChatId = chatId, UserId = userId, UserName = userName });
                    await context.SaveChangesAsync(); 
                }
            } 
        }

        public static async Task UpdateChat(Chat model)
        {
            using(ApplicationContext context = new ApplicationContext())
            {
                var chat = context.Chats.Where(x => x.ChatId == model.ChatId && x.UserId == model.UserId).FirstOrDefault();
                if (chat == null) await CreateChat(model.ChatId, model.UserId, model.UserName);
                chat.Status = model.Status;
                chat.Step = model.Step;
                await context.SaveChangesAsync();
            }
        }

        public static async Task SetStep(short status, short step, Chat chat)
        {
            await UpdateChat(new Chat
            {
                ChatId = chat.ChatId,
                UserId = chat.UserId,
                Status = status,
                Step = step
            });
        }
    }
}
