using System;
namespace ClairvoyantSQL.Models
{
    public class Contact
    {

        public int Id { get; }

        static private int nextId = 1;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ContactType Type { get; set; }


        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        //public Event EventType { get; set; }



        public Contact()
        {
            Id = nextId;
            nextId++;
        }

        public Contact(string firstname, string lastname, string phone, string email)
        {
            FirstName = firstname;
            LastName = lastname;
            Phone = phone;
            Email = email;
            

            Id = nextId;
            nextId++;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        public override bool Equals(object obj)
        {
            return obj is Contact @contact &&
                Id == @contact.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        //public Contact(string firstname, string lastname, string phone, string email, Event eventtype)
        //{
        //    FirstName = firstname;
        //    LastName = lastname;
        //    Phone = phone;
        //    Email = email;

        //}



    }
}
