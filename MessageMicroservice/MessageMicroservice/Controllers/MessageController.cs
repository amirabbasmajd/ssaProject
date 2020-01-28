using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MessageService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace MessageService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private static readonly List<Message>  Messages = new List<Message>
        {
            new Message("hi",1,2,0), new Message("hello",2,1,0), new Message("bye",1,2,0)
        };

        //private readonly ILogger<MessageController> _logger;

        //public MessageController(ILogger<MessageController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        public ActionResult<IEnumerable<Message>> GetAll()
        {
            return Messages;
        }


        [HttpGet("{id}")]
        public ActionResult<Message> GetById(int id)
        {
            return Messages.Find(msg => msg.Id == id);
        }

        [HttpPost]
        public ActionResult<Message> NewMessage(String content,long sender,long receiver,long chatid)
        {
            var nmsg = new Message(content,sender,receiver,chatid);
            Messages.Add(nmsg);
            var resourceUrl = Path.Combine(Request.Path.ToString(), Uri.EscapeUriString(nmsg.Content));
            return Created(resourceUrl, nmsg);

        }
    }
}
