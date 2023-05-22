using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yummysayt.DAL;
using yummysayt.Models;

namespace yummysayt.ViewComponents
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly AppDbContext _Context;
        public CategoryViewComponent(AppDbContext Context)
        {
            _Context = Context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> category = await _Context.Categories.ToListAsync();

            return View(category);
        }
    }
}
