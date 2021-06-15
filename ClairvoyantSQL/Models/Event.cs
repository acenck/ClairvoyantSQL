using System;
namespace ClairvoyantSQL.Models
{
    public class Event
    {


        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Message { get; set; }





        public Event()
        {

        }

        public Event(string name, DateTime date, string message)
        {
            Name = name;
            Date = date;
            Message = message;
        }
    }
}
