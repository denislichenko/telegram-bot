using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    public static class Extensions
    {
        public static bool IsOneOf<T>(this T self, params T[] elems)
        {
            return elems.Contains(self); 
        }
    }
}
