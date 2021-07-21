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
    public class ContactCategoryController : Controller
    {

        private ContactDbContext context;

        public ContactCategoryController(ContactDbContext dbContext)
        {
            context = dbContext;
        }


        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddContactCategoryViewModel addContactCategoryViewModel = new AddContactCategoryViewModel();
            return View(addContactCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Create(AddContactCategoryViewModel addContactCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                ContactCategory newCategory = new ContactCategory
                {
                    Name = addContactCategoryViewModel.Name
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Create");
            }

            return View("Create", addContactCategoryViewModel);
        }
    }
}
