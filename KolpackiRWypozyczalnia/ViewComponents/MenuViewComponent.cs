using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolpackiRWypozyczalnia.DAL;

namespace KolpackiRWypozyczalnia.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        FilmsContext db;

        public MenuViewComponent(FilmsContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_Menu", db.Categories.ToList()));
        }
    }
}
