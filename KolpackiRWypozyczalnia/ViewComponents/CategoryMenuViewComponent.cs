using KolpackiRWypozyczalnia.Controllers;
using KolpackiRWypozyczalnia.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KolpackiRWypozyczalnia.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        FilmContext db;

        public CategoryMenuViewComponent(FilmContext db)
        {
            this.db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(string categoryName)
        {
            var category = db.Categories.Include("Films").Where(c => c.Name.ToUpper() == categoryName.ToUpper()).Single();
            var films = category.Films.ToList();
            return await Task.FromResult((IViewComponentResult)View("_CategoryMenu", films));
        }

    }
}
