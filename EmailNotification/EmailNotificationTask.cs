using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scheduler.Base;
using EmailNotificationTask.Configuration;
using System.Net.Mail;


namespace EmailNotification
{
    public class EmailNotificationTask : TaskBase
    {

        private MailMessage _message = null;
        private SmtpClient _smtp = null;

        public EmailNotificationTask()
            : base()
        {

        }

        public override void Run()
        {
            try
            {
                _message = GetMailMessage();
                _smtp = GetSMTPClient();
                _smtp.Send(_message);
                OnSendingSuccess();
            }
            catch (Exception e)
            {
                //TODO: Log Error
                OnSendingFailure(e);
            }
            finally
            {

            }
        }

        protected virtual SmtpClient GetSMTPClient()
        {
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(MailServerConfiguration.SMTPServer);
            smtp.Credentials = new System.Net.NetworkCredential(MailServerConfiguration.MailSenderAccount, MailServerConfiguration.Password);
            smtp.EnableSsl = MailServerConfiguration.EnableSSL;
            smtp.Port = MailServerConfiguration.Port;
            return smtp;
        }

        protected virtual MailMessage GetMailMessage()
        {
            MailMessage _message = new MailMessage("appdev.ringconfig@gmail.com", "arunmozhi@appdev.be");
            _message.Subject = "Email Notification";
            _message.Body = "Sample Alert";
            _message.IsBodyHtml = true;
            return _message;
        }

        protected virtual void OnSendingSuccess()
        {
 
        }

        protected virtual void OnSendingFailure(Exception e)
        {

        }
    }
}
