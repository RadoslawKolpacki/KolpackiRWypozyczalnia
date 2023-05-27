using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KolpackiRWypozyczalnia.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Musisz wprowadzić login")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Musisz wprowadzić hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
