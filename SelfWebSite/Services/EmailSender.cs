﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SelfWebSite.Services
{
    /// <summary>
    /// Класс для отсылки сообщений через службу SenderGreed
    /// </summary>
    public class EmailSender //: IEmailSender
    {
       // public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
       // {
       //     Options = optionsAccessor.Value;
       // }
       //
       // public AuthMessageSenderOptions Options { get; } //set only via Secret Manager
       //
       // public Task SendEmailAsync(string email, string subject, string message)
       // {
       //     return Execute(Options.SendGridKey, subject, message, email);
       // }
       //
       // public Task Execute(string apiKey, string subject, string message, string email)
       // {
       //     //Debug.WriteLine("WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW  " + Options.SendGridUser + "WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW" + Options.SendGridKey);
       //
       //     var client = new SendGridClient(apiKey);
       //     var msg = new SendGridMessage()
       //     {
       //         From = new EmailAddress("alexeya29@yandex.ru", Options.SendGridUser),
       //         Subject = subject,
       //         PlainTextContent = message,
       //         HtmlContent = message
       //     };
       //     msg.AddTo(new EmailAddress(email));
       //
       //     // Disable click tracking.
       //     // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
       //     msg.SetClickTracking(false, false);
       //
       //     return client.SendEmailAsync(msg);
       // }
    }
}
