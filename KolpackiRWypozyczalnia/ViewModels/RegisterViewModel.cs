using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace KolpackiRWypozyczalnia.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage= "Musisz wprowadzić e-mail")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format e-mail")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Musisz wprowadzić login")]

        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Musisz wprowadzić hasło")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Musisz potwierdzić hasło")]
        public string ConfirmPassword { get; set; } 

        public string FirstName { get; set; }

        public string LastName { get; set; }    


    }
}
