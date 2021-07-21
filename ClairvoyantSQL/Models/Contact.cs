using System;
using System.Collections.Generic;
using System.Linq;
using ClairvoyantSQL.Data;

namespace ClairvoyantSQL.Models
{
    public class Contact
    {

        private ContactDbContext context;

        public Contact(ContactDbContext dbContext)
        {
            context = dbContext;
        }


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ContactCategory Category { get; set; }
        public int CategoryId { get; set; }

        public List<Event> events { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        
        



        public Contact(string firstname, string lastname, string phone, string email)
        {
            FirstName = firstname;
            LastName = lastname;
            Phone = phone;
            Email = email;
            events = context.Events
                .Where(x => x.ContactId == Id)
                .ToList();
                   
            
        }

        public Contact()
        {
            
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
