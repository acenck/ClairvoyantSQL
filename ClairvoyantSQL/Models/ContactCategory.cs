using System;
using System.Collections.Generic;

namespace ClairvoyantSQL.Models
{
    public class ContactCategory
    {
       
        public string Name { get; set; }

        public int Id { get; set; }

        public List<Contact> contacts { get; set; }

        public ContactCategory(string name)
        {
            Name = name;
        }

        public ContactCategory()
        {
            
        }
    
    }
}
