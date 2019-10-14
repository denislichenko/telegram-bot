using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models.Users
{
    class User
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public long ChatId { get; set; }
        public string UserName { get; set; }
    }
}
