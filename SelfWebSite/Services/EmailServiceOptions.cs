using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfWebSite.Services
{
    /// <summary>
    /// Вспомогательный класс для отсылки сообщений через службу SenderGreed
    /// </summary>
    public class EmailServiceOptions
    {
        public string SmtpUser { get; set; }
        public string SmtpKey { get; set; }
    }
}
