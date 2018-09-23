using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Database.Models;

namespace TelegramBot.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");
            try
            {
                MainContext context = new MainContext();
                Console.WriteLine(context.Messanges.Count());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message); 
            }
            
            Console.ReadKey(); 
        }
    }
}
