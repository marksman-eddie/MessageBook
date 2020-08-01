using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MessageBook.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MessageBook.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessagesController : Controller
    {
        [HttpGet("getAllMessages")]
        public List<MessageModel> GetAllMessages()
        {
            List<MessageModel> model = new List<MessageModel>
            {
                new MessageModel{
                    Id=1,
                    Text = "Text",
                    Date=DateTime.Now
                },
                new MessageModel
                {
                    Id=1,
                    Text = "Text",
                    Date=DateTime.Now
                }
            };

            return model;
        }

        [HttpPost("addNewMessage")]        
        public MessageModel AddNewMessage (MessageModel msg_model)
        {
            /*MessageModel model = new MessageModel
            {
                Id = 1,
                Text = mode,
                Date = DateTime.Now
            };*/

            return msg_model; 
        }

        [HttpDelete]
        public void RemoveMessage (int id)
        {
            

        }



    }
}
