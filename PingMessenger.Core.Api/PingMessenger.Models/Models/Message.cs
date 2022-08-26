using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingMessenger.Models.Models
{
    public class Message
    {
        public int Id { get; set; }
        public Guid Sender_Id { get; set; }
        public string Content { get; set; }
        public DateTime TimeSend { get; set; }

        public int Conversation_Id { get; set; }
        public Conversation Conversation { get; set; }

    }
}
