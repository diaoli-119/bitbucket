using System;
using System.ComponentModel.DataAnnotations;

namespace SubmitForm.Models
{
    public class Form
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public Form(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}

