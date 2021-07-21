using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClairvoyantSQL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClairvoyantSQL.ViewModels
{
    public class AddContactViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "First name must be between 3 and 12 characters long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Last name must be between 3 and 12 characters long")]
        public string LastName { get; set; }

        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId  { get; set; }

        public List<SelectListItem> Categories { get; set; }
        


        public AddContactViewModel(List<ContactCategory> categories)
        {
            Categories = new List<SelectListItem>();
            

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }
        }

            

        public AddContactViewModel()
        {

        }
        

        //public Event EventType { get; set; }




    }
}
