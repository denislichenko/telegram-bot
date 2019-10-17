using Database.Models;
using Database.Models.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Controllers
{
    public static class MessageController
    {
        public static async Task CreateMessage(Message model)
        {
            using(ApplicationContext context = new ApplicationContext())
            {
                await context.Messages.AddAsync(model);
                await context.SaveChangesAsync(); 
            }
        }

        public static async Task<List<Message>> GetMessages()
        {
            using(ApplicationContext context = new ApplicationContext())
            {
                return await context.Messages.ToListAsync();
            }
        }
    }
}
