using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KolpackiRWypozyczalnia.Models
{
    public class Film
    {
        /// <summary>
        /// 1 sposób
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 2 sposób
        /// </summary>
        //public int FilmId { get; set; }

        /// <summary>
        /// 3 sposób
        /// </summary>
        //[Key]
        //public int IdFilm { get; set; }
        [Required(ErrorMessage = "Wpisz tytul")]
        public string Title { get; set; }

        public string Director { get; set; }

        [StringLength(500)]
        public string Desc { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishDate { get; set; }

        public string PosterName { get; set; }

        //[ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
