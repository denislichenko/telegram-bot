using TelegramBot.Database.Models;
using TelegramBot.Database.Models.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace TelegramBot.Database.Controllers
{
    public static class MessageController
    {
        public static async Task CreateMessage(Message model)
        {
            using(ApplicationContext context = new ApplicationContext())
            {
                if (!string.IsNullOrEmpty(model.ReplyMessage)) model.IsActive = true; 
                await context.Messages.AddAsync(model);
                await context.SaveChangesAsync(); 
            }
        }

        public static async Task CreateMessage(string incomeMessage, string replyMessage, int chatId)
        {
            await CreateMessage(new Message { IncomeMessage = incomeMessage, ReplyMessage = replyMessage, ChatId = chatId }); 
        }

        public static async Task UpdateMessage(Message message)
        {
            using(ApplicationContext context = new ApplicationContext())
            {
                var msg = await context.Messages.Where(x => x.Id == message.Id).FirstOrDefaultAsync(); 
                if(msg != null)
                {
                    msg.IncomeMessage = message.IncomeMessage;
                    msg.ReplyMessage = message.ReplyMessage;
                    msg.ChatId = message.ChatId;
                    msg.IsActive = message.IsActive;
                    await context.SaveChangesAsync(); 
                }
            }
        }

        public static async Task UpdateMessage(string replyMessage, int chatId)
        {
            using(ApplicationContext context = new ApplicationContext())
            {
                var msg = (await context.Messages.Where(x => x.ChatId == chatId && x.IsActive == false).ToListAsync()).Last(); 
                if(msg != null)
                {
                    msg.ReplyMessage = replyMessage;
                    msg.IsActive = true;
                    await context.SaveChangesAsync(); 
                }
            }
        }


        public static async Task<string> GetAnswer(string text)
        {
            using(ApplicationContext context = new ApplicationContext())
            {
                var answers = await context.Messages.Where(x => x.IsActive &&
                                                                text.ToLower().Contains(x.IncomeMessage.ToLower())
                                                                ).Select(x => x.ReplyMessage).ToListAsync();

                if (answers.Count > 1)
                {
                    var rnd = new Random();
                    int i = rnd.Next(0, answers.Count - 1);
                    return answers[i];
                }
                else if (answers.Count == 1) return answers[0];
                else return "idk :("; 
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
