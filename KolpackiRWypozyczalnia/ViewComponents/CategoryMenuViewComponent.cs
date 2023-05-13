using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolpackiRWypozyczalnia.DAL;

namespace KolpackiRWypozyczalnia.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        FilmsContext db;

        public CategoryMenuViewComponent(FilmsContext db)
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
