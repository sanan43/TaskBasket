using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yummysayt.DAL;
using yummysayt.Models;

namespace yummysayt.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly AppDbContext _Context;
        public MenuViewComponent(AppDbContext context)
        {
            _Context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Product> Menu = await _Context.Products.ToListAsync();

            return View(Menu);
        }
    }
}
