using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;

namespace SelfWebSite.Services
{
    public class EmailService : IEmailSender
    {

        public EmailServiceOptions Options { get; } //set only via Secret Manager
        public EmailService(IOptions<EmailServiceOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SmtpKey, Options.SmtpUser, subject, message, email);
        }

        public async Task Execute(string smtpKey, string smtpUser, string subject, string message, string email)
        {
            var emailMessage = new MimeMessage();
            //Debug.WriteLine("WWWWWWWWWWWWWWWWWWWWWWWW   " + email + "  WWWWWWWWWWWWWWWWWWWWWWWW   " + message + "  WWWWWWWWWWWWWWWWWWWWWWWW   ");
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", $"{smtpUser}"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync($"{smtpUser}", $"{smtpKey}");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

        //public async Task SendEmailAsync2(string email, string subject, string message)
        //{
        //    var emailMessage = new MimeMessage();
        //   Debug.WriteLine("WWWWWWWWWWWWWWWWWWWWWWWW   " + email + "  WWWWWWWWWWWWWWWWWWWWWWWW   " + message + "  WWWWWWWWWWWWWWWWWWWWWWWW   ");
        //    emailMessage.From.Add(new MailboxAddress("Администрация сайта", "Alexeya299@gmail.com"));
        //    emailMessage.To.Add(new MailboxAddress("", email));
        //    emailMessage.Subject = subject;
        //    emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        //    {
        //        Text = message
        //    };
        //   
        //    using (var client = new SmtpClient())
        //    {
        //        await client.ConnectAsync("smtp.gmail.com", 587, false);
        //        await client.AuthenticateAsync("Alexeya299@gmail.com", "gzrlmfrgchddrgsr");
        //        await client.SendAsync(emailMessage);
        //   
        //        await client.DisconnectAsync(true);
        //    }
        //}
    }
}
