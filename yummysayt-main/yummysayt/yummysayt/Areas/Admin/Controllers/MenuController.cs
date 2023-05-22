using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yummysayt.DAL;
using yummysayt.Models;

namespace yummysayt.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<Product> menu = await _context.Products.ToListAsync();
            return View(menu);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product menu)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool isExists = await _context.Products.AnyAsync(c =>
            c.Name.ToLower().Trim() == menu.Name.ToLower().Trim());

            if (isExists)
            {
                ModelState.AddModelError("Name", "Category name already exists");
                return View();
            }
            await _context.Products.AddAsync(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int Id)
        {
            Product? menu = _context.Products.Find(Id);

            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        [HttpPost]
        public IActionResult Update(Product menu)
        {
            Product? editedMenu = _context.Products.Find(menu.Id);
            if (editedMenu == null)
            {
                return NotFound();
            }
            editedMenu.Name = menu.Name;
            _context.Products.Update(editedMenu);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            Product? menu = _context.Products.Find(Id);
            if (menu == null)
            {
                return NotFound();
            }
            _context.Products.Remove(menu);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
