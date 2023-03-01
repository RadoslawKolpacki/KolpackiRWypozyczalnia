using System.Collections.Generic;

namespace KolpackiRWypozyczalnia.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Desc { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}
