using System;
namespace MessageBook.Database.DatabaseModel
{
    public class Messages
    {
        public int ID { get; set; }
        public string TEXT_MESSAGE { get; set; }
        public DateTime DATE_MESSAGE { get; set; }
        //public int USER_ID { get; set; }
        
    }
}
