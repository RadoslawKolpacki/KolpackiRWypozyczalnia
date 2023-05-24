using System.ComponentModel.DataAnnotations;

namespace KolpackiRWypozyczalnia.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Musisz wprowadzić login")]
        public string Login { get; set; }

        [Required(ErrorMessage = " Musisz wprowadzić hasło")]
        public string Password { get; set; }    
    }
}
