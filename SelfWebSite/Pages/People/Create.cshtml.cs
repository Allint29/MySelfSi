using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SelfWebSite.Data;
using SelfWebSite.Models;

namespace SelfWebSite.Pages.People
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Person Person { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Persons.Add(Person);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
