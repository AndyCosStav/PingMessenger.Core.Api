using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingMessenger.Models.Models
{
    public class PingUser
    {
        public Guid PingUserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

    }
}
