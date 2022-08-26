using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingMessenger.Models.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Participants> Participants { get; set; }

    }
}
