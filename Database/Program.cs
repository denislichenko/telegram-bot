using Database.Models;
using System;
using System.Linq;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            using(ApplicationContext context = new ApplicationContext())
            {
                var usersCount = context.Users.ToList().Count;
                var messagesCount = context.Messages.ToList().Count();
                Console.WriteLine($"Users: {usersCount}\nMessages: {messagesCount}");
            }
        }
    }
}
