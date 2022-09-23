using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Models;
using System.Collections.Generic;
using Workshop05.Services;

namespace Workshop05.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        IHubContext<SignalRHub> hub;

        private static List<Message> messages = new List<Message>();

        public MessageController(IHubContext<SignalRHub> hub)
        {
            this.hub = hub;
        }

        [HttpPost]
        public void Create([FromBody] Message value)
        {
            messages.Add(value);
            this.hub.Clients.All.SendAsync("MessageCreated", value);
        }

        [HttpGet]
        public IEnumerable<Message> ReadAll()
        {
            return messages;
        }
    }
}
