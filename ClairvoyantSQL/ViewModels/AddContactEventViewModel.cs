using System;
using System.ComponentModel.DataAnnotations;

namespace ClairvoyantSQL.ViewModels
{
    public class AddContactEventViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Define name of event.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Define date of event.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Define message for recipient.")]
        public string Message { get; set; }


        public int ContactId { get; set; }

        



    }
}
