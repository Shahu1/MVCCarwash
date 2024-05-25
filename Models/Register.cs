//craete a register model
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApp.Models
{
    public class Register
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }

        // [Required]
        // public string ConfirmPassword { get; set; }
    }
}
