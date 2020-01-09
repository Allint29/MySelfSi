using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SelfWebSite.Data;
using SelfWebSite.Models;

namespace SelfWebSite.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Person> People { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            People = _context.Persons.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var product = await _context.Persons.FindAsync(id);

            if (product != null)
            {
                _context.Persons.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
