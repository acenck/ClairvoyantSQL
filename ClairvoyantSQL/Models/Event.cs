using System;
namespace ClairvoyantSQL.Models
{
    public class Event
    {

        public int Id {get; set;} 

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Message { get; set; }

        public int Countdown
        {
            get => (Date - DateTime.Today).Days;
            private set { }
        }


        public virtual Contact AssignedContact { get; set; }
        public int ContactId { get; set; }



        public Event(string name, DateTime date, string message)
        {
            Name = name;
            Date = date;
            Message = message;
        }

        public Event()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }


    }
}





