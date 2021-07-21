using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClairvoyantSQL.Data;
using ClairvoyantSQL.Models;
using ClairvoyantSQL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClairvoyantSQL.Controllers
{
    public class ContactsController : Controller
    {

        private ContactDbContext context;

        public ContactsController(ContactDbContext dbContext)
        {
            context = dbContext;
        }
        

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {

            List<Contact> contacts = context.Contacts
                .Include(c => c.Category)
                .ToList();

            return View(contacts);
            
        }
            

        [HttpGet]
        public IActionResult Add()
        {

            List<ContactCategory> categories = context.Categories.ToList();
            AddContactViewModel addContactViewModel = new AddContactViewModel(categories);

            return View(addContactViewModel);
        }

            

        [HttpPost]
        public IActionResult Add(AddContactViewModel addContactViewModel)
        {
            if (ModelState.IsValid)
            {

                ContactCategory category = context.Categories.Find(addContactViewModel.CategoryId);

                Contact newContact = new Contact
                {
                    FirstName = addContactViewModel.FirstName,
                    LastName = addContactViewModel.LastName,
                    Phone = addContactViewModel.Phone,
                    Email = addContactViewModel.Email,
                    Category = category
                };

               


                context.Contacts.Add(newContact);
                context.SaveChanges();

                return Redirect("/Contacts");

            }

            return View(addContactViewModel);
        }

        //method currently not in use
        //public IActionResult Delete()
        //{
        //    ViewBag.contacts = context.Contacts.ToList();

        //    return View();
        //}


        [Route("Contacts/Edit/{contactId}")]
        public IActionResult Edit(int contactId)
        {
            var contactToChange = context.Contacts.Find(contactId);
            List<ContactCategory> categories = context.Categories.ToList();
           

            AddContactViewModel addContactViewModel = new AddContactViewModel(categories)
            {
                FirstName = contactToChange.FirstName,
                LastName = contactToChange.LastName,
                Phone = contactToChange.Phone,
                Email = contactToChange.Email,
                
                
            };

                
            ViewBag.contactToEdit = context.Contacts.Find(contactId);

            return View(addContactViewModel);
        }


            
        [HttpPost]
        public IActionResult Edit(int contactId, [Bind("contactId,FirstName,LastName,Phone,Email,CategoryId")] AddContactViewModel addContactViewModel)
        {
            var updated = context.Contacts.Find(contactId);
            ContactCategory category = context.Categories.Find(addContactViewModel.CategoryId);

            if (ModelState.IsValid)
            {
                updated.FirstName = addContactViewModel.FirstName;
                updated.LastName = addContactViewModel.LastName;
                updated.Phone = addContactViewModel.Phone;
                updated.Email = addContactViewModel.Email;
                updated.Category = category;

                context.Update(updated);
                context.SaveChanges();
            }

            
            return Redirect("/Contacts");
        }


        [HttpGet]
        [Route("/Contacts/Delete/")]
        public IActionResult Delete(int contactId)
        {
            Contact theContact = context.Contacts.Find(contactId);
            context.Contacts.Remove(theContact);
            context.SaveChanges();

            return Redirect("/Contacts");

        }


    }
}

     

