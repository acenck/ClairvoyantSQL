using System;
using System.Collections.Generic;
using ClairvoyantSQL.Models;

namespace ClairvoyantSQL.Data
{
    public class ContactData
    {
        //Storage variable for contacts
        static private Dictionary<int, Contact> Contacts = new Dictionary<int, Contact>();

        //Get All
        public static IEnumerable<Contact> GetAll()
        {
            return Contacts.Values;
        }

        //Add

        public static void Add(Contact newContact)
        {
            Contacts.Add(newContact.Id, newContact);
        }

        //Remove
        public static void Remove(int id)
        {
            Contacts.Remove(id);
        }

        // GetById
        public static Contact GetById(int id)
        {
            return Contacts[id];
        }
    }
}
