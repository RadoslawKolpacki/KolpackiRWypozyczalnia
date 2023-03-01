using System.ComponentModel.DataAnnotations;

namespace KolpackiRWypozyczalnia.Models
{
    public class Film
    {
        [Required(ErrorMessage ="Wpisz tytuł")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        [StringLength(500)]
        public string Desc { get; set; }
        public decimal Price { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
