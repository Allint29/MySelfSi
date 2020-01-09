using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SelfWebSite.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Age { get; set; } // добавляем свойство Age
        //навигация к таблице Person связь 1-1
        public Person Person { get; set; }

        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //{
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    return userIdentity;
        //}
    }
}
