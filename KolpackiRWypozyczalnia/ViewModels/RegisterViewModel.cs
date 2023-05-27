using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KolpackiRWypozyczalnia.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Musisz wprowadzić email")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Musisz powtórzyć hasło")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła muszą być jednakowe!")]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
