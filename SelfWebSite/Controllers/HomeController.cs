using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SelfWebSite.Data;
using SelfWebSite.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SelfWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;
        UserManager<IdentityUser> _userManager;
        RoleManager<IdentityRole> _roleManager;

        public HomeController(ILogger<HomeController> logger, 
            ApplicationDbContext context, 
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _logger = logger;
            //контекст БД
            _context = context;
            //менеджер управления пользователми
            _userManager = userManager;
            //менеджер управления ролями 
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            //  Execute().Wait();
            //Используя контекст БД
            //var users = _context.Users.ToList(); //_context.Users.ToList();
            //используя юзерменеджер 
            var users = await _userManager.Users.ToListAsync();

            return View( users);
            //return View();
        }

        public async Task<IActionResult> GetRoles()
        {
            //создаю роль при помощи менеджера ролей
            await _roleManager.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });

            //создаю роль при помощи контекста
            // _context.Add(new IdentityRole("simpleUser"));
            // await _context.SaveChangesAsync();
            return View(await _context.Roles.ToListAsync());
        }
    

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //отсылка писем через SenderGreed
       // static async Task Execute()
       // {
       //     var apiKey = "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";//Environment.GetEnvironmentVariable("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");
       //     var client = new SendGridClient(apiKey);
       //     var from = new EmailAddress("alexeya29@yandex.ru", "Allint29");
       //     var subject = "Sending with SendGrid is Fun";
       //     var to = new EmailAddress("alexeya29@yandex.ru", "Allint29");
       //     var plainTextContent = "and easy to do anywhere, even with C#";
       //     var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
       //     var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
       //     Debug.Write("I Am hear!!!!!!!!!!!!!!!!!!!!!");
       //     var response = await client.SendEmailAsync(msg);
       // }
    }


}
