using System;
using ClairvoyantSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace ClairvoyantSQL.Data
{
    public class ContactDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactCategory> Categories { get; set; }
        public DbSet<Event> Events { get; set; }

        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options)
        {
            
        }
    }
}
