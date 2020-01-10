using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SelfWebSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
          //  Execute().Wait();

            CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        //static async Task Execute()
        //{
        //    Debug.WriteLine("WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW");
        //    var apiKey = "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";
        //    var client = new SendGridClient(apiKey);
        //    var from = new EmailAddress("alexeya29@yandex.ru", "Allint29");
        //    var subject = "Sending with SendGrid is Fun";
        //    var to = new EmailAddress("alexeya29@yandex.ru", "Allint29");
        //    var plainTextContent = "and easy to do anywhere, even with C#";
        //    var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //    var response = await client.SendEmailAsync(msg);
        //}



    }


}
