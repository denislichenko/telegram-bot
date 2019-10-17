using Database.Models;
using Database.Models.Chats;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Controllers
{
    public static class ChatController
    {
        public static async Task CreateChat(Chat model)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var exChat = await context.Chats.FindAsync(model.Id);
                if(exChat == null)
                {
                    await context.Chats.AddAsync(model);
                    await context.SaveChangesAsync(); 
                }
            } 
        }

        public static async Task UpdateChat(Chat model)
        {
            using(ApplicationContext context = new ApplicationContext())
            {
                var chat = await context.Chats.FindAsync(model.Id);
                if (chat == null) return;
                chat.Status = model.Status;
                chat.Step = model.Step;
                await context.SaveChangesAsync();
            }
        }
    }
}
