using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingMessenger.Models.Models
{
    public class Participants
    {
        public int Id { get; set; }
        public int Conversation_Id { get; set; }
        public Conversation Conversation { get; set; }

        public Guid PingUser_Id { get; set; }
        public PingUser PingUser { get; set; }
        


    }
}
