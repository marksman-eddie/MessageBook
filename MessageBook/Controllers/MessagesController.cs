using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MessageBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using MessageBook.Database;
using MessageBook.Database.DatabaseModel;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MessageBook.Controllers
{
    //Database Database = new MessageBook.Database();


    [Route("[controller]")]
    [ApiController]
    public class MessagesController : Controller
    {


        [HttpGet("getAllMessages")]
        public List<MessageModel> GetAllMessages()
        {
            var options = new DbContextOptionsBuilder<ContextDB>()
        .UseSqlite(DB.ConnectionString)
        .Options;
            ContextDB dbc = new ContextDB(options);
            var messages = dbc.MESSAGES.ToList<Messages>();
            List<MessageModel> model = new List<MessageModel>();
            //ListMessagesModel modelObject = new ListMessagesModel();
            //modelObject.listMessages = new List<MessageModel>();
            foreach (Messages msg in messages)
            {
                MessageModel OutMessage = new MessageModel();
                OutMessage.Id = msg.ID;
                OutMessage.Text = msg.TEXT_MESSAGE;
                OutMessage.Date = msg.DATE_MESSAGE;
                model.Add(OutMessage);
            }


            return model;
        }

        [HttpPost("addNewMessage")]
        public MessageModel AddNewMessage(MessageModel msg_model)
        {
            /*MessageModel model = new MessageModel
            {
                Id = 1,
                Text = mode,
                Date = DateTime.Now
            };*/

            var options = new DbContextOptionsBuilder<ContextDB>()
        .UseSqlite(DB.ConnectionString)
        .Options;
            var date = DateTime.Now;
            using (ContextDB dbc = new ContextDB(options))
            {

                Messages messages = new Messages
                {
                    DATE_MESSAGE = date,
                    TEXT_MESSAGE = msg_model.Text
                };
                dbc.MESSAGES.Add(messages);
                dbc.SaveChanges();


            }




            return msg_model;
        }

        [HttpDelete]
        public void RemoveMessage(int id)
        {
            var options = new DbContextOptionsBuilder<ContextDB>()
        .UseSqlite(DB.ConnectionString)
        .Options;
            using (ContextDB dbc = new ContextDB(options))
            {
                Messages message = dbc
                     .MESSAGES
                     .Where(o => o.ID == id)
                     .FirstOrDefault();
                dbc.MESSAGES.Remove(message);
                dbc.SaveChanges();
            }



        }
    }
}
