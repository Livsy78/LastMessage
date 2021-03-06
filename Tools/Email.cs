﻿using System;
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

        public void Send()
        {
            Send(this);
        }
        
        public static void Send(Email email)
        {
            string smtpLogin = ConfigurationManager.AppSettings[email.ConfigKeyPrefix + ".SmtpLogin"];
            string smtpPassword = ConfigurationManager.AppSettings[email.ConfigKeyPrefix + ".SmtpPassword"];
            string smtpServer = ConfigurationManager.AppSettings[email.ConfigKeyPrefix + ".SmtpServer"];
            int smtpPort = int.Parse( ConfigurationManager.AppSettings[email.ConfigKeyPrefix + ".SmtpPort"] );
            bool smtpEnableSsl = bool.Parse( ConfigurationManager.AppSettings[email.ConfigKeyPrefix + ".SmtpEnableSsl"] );
        
            // https://forums.iis.net/t/1157046.aspx
            SmtpDeliveryMethod smtpDeliveryMethod = (SmtpDeliveryMethod) Enum.Parse(typeof(SmtpDeliveryMethod), ConfigurationManager.AppSettings[email.ConfigKeyPrefix + ".DeliveryMethod"]);


            MailAddress from = new MailAddress(email.From); // (smtpLogin, email.From);
            
            string[] tos = email.To.Split(',');
            MailAddress to = new MailAddress(tos[0].Trim());

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
            smtpClient.DeliveryMethod = smtpDeliveryMethod;

            smtpClient.UseDefaultCredentials = false;
            if(!string.IsNullOrEmpty(smtpLogin))
            {
                smtpClient.Credentials = new NetworkCredential(smtpLogin, smtpPassword);
            }
    
            smtpClient.Send(message);
        }

    }
}