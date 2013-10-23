using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler.Configuration
{
    public class MailServerConfiguration
    {
        public const string SMTPServer = "smtp.gmail.com";
        public const int Port = 25;
        public const bool EnableSSL = true;
        public const string MailSenderAccount = "appdev.ringconfig@gmail.com";
        public const string Password = "Appdev@123";
    }
}
