using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;  // NetworkCredential
using System.Net.Mail; // email stuff

using System.Configuration;


namespace LastMessage.Tools
{
    /// <summary>
    /// Email
    /// </summary>
    /// <value To> Comma separated emails </value>
    public class Email
    {
        public string From {get;set;}
        public string To {get;set;}
        public string Subject {get;set;}
        public string Body {get;set;}

        public string ConfigKeyPrefix {get;set;}

        
        public static void Send(Email email)
        {
            string smtpLogin = ConfigurationManager.AppSettings[email.ConfigKeyPrefix + ".SmtpLogin"];
            string smtpPassword = ConfigurationManager.AppSettings[email.ConfigKeyPrefix + ".SmtpPassword"];
            string smtpServer = ConfigurationManager.AppSettings[email.ConfigKeyPrefix + ".SmtpServer"];
            int smtpPort = int.Parse( ConfigurationManager.AppSettings[email.ConfigKeyPrefix + ".SmtpPort"] );
            bool smtpEnableSsl = bool.Parse( ConfigurationManager.AppSettings[email.ConfigKeyPrefix + ".SmtpEnableSsl"] );

            MailAddress from = new MailAddress(smtpLogin, email.From);
            
            string[] tos = email.To.Split(',');
            MailAddress to = new MailAddress(tos[0]);

            MailMessage message = new MailMessage(from, to);

            for(int idx=1; idx<tos.Count(); idx++)
            {
                message.CC.Add(tos[idx].Trim());
            }

            message.Subject = email.Subject;
            message.Body = email.Body;
            message.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);

            smtpClient.EnableSsl = smtpEnableSsl;

            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new NetworkCredential(smtpLogin, smtpPassword);
    
            smtpClient.Send(message);
        }

    }
}