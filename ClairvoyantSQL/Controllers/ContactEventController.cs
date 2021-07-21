using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClairvoyantSQL.Data;
using ClairvoyantSQL.Models;
using ClairvoyantSQL.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClairvoyantSQL.Controllers
{
    public class ContactEventController : Controller
    {

        private ContactDbContext context;

        public ContactEventController(ContactDbContext dbContext)
        {
            context = dbContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            AddContactEventViewModel addContactEventViewModel = new AddContactEventViewModel();
            return View(addContactEventViewModel);
        }

        public IActionResult Create(AddContactEventViewModel addContactEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newContactEvent = new Event
                {
                    Name = addContactEventViewModel.Name,
                    Message = addContactEventViewModel.Message,
                    Date = addContactEventViewModel.Date
                };

                context.Events.Add(newContactEvent);
                context.SaveChanges();

                return Redirect("/Create");
            }

            return View("Add", addContactEventViewModel);

        }
    }
}
