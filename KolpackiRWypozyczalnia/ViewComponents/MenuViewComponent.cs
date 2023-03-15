
using KolpackiRWypozyczalnia.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace KolpackiRWypozyczalnia.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        FilmContext db;
    public MenuViewComponent(FilmContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_Menu", db.Categories.ToList()));
        }
    }
}
