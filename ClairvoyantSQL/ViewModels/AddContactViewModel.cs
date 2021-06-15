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

        public ContactType Type { get; set; }

        public List<SelectListItem> ContactTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(ContactType.Personal.ToString(), ((int)ContactType.Personal).ToString()),
            new SelectListItem(ContactType.Business.ToString(), ((int)ContactType.Business).ToString()),
            new SelectListItem(ContactType.Undecided.ToString(), ((int)ContactType.Undecided).ToString())
        };




    }
}
