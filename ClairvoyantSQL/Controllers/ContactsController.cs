using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClairvoyantSQL.Data;
using ClairvoyantSQL.Models;
using ClairvoyantSQL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClairvoyantSQL.Controllers
{
    public class ContactsController : Controller
    {

        

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {

            List<Contact> Contacts = new List<Contact>(ContactData.GetAll());

            return View(Contacts);
            
        }
            

        [HttpGet]
        public IActionResult Add()
        {
            AddContactViewModel addContactViewModel = new AddContactViewModel();

            return View(addContactViewModel);
        }

            

        [HttpPost]
        public IActionResult Add(AddContactViewModel addContactViewModel)
        {
            if (ModelState.IsValid)
            {


                Contact newContact = new Contact
                {
                    FirstName = addContactViewModel.FirstName,
                    LastName = addContactViewModel.LastName,
                    Phone = addContactViewModel.Phone,
                    Email = addContactViewModel.Email,
                    Type = addContactViewModel.Type

                };

                ContactData.Add(newContact);


                return Redirect("/Contacts");
            }

            return View(addContactViewModel);
        }

        public IActionResult Delete()
        {
            var Contacts = ContactData.GetAll();

            return View();
        }

        
        
        public IActionResult Edit(int contactId)
        {
            ViewBag.contactToEdit = ContactData.GetById(contactId);
            return View();
        }

        [HttpPost]
        [Route("/Contacts/Edit")]
        public IActionResult Edit(int contactId, string firstname, string lastname, string phone, string email)
        {
            var updated = ContactData.GetById(contactId);

            updated.FirstName = firstname;
            updated.LastName = lastname;
            updated.Phone = phone;
            updated.Email = email;
            
            return Redirect("/Contacts");
        }

        [HttpGet]
        [Route("/Contacts/Delete/")]
        public IActionResult Delete(int contactId)
        {
            ContactData.Remove(contactId);


            return Redirect("/Contacts");

        }


    }
}
