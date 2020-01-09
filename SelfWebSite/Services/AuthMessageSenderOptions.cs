using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfWebSite.Services
{
    /// <summary>
    /// Вспомогательный класс для отсылки сообщений через службу SenderGreed
    /// </summary>
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
}
