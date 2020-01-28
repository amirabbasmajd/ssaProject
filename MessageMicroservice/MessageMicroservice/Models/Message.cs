using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Models
{
    public class Message
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public static long lastid = 0;
        public long SenderId { get; set; }
        public long RecieverId { get; set; }
        public long ChatId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastModifiedTime { get; set; }

        public Message(string content,long sender,long receiver,long chatid)
        {
            Id = lastid++;
            Content = content;
            CreationTime = DateTime.Now;
            LastModifiedTime = DateTime.Now;
            SenderId = sender;
            RecieverId = receiver;
            ChatId = chatid;
        }
    }
}
