using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;  // NetworkCredential
using System.Net.Mail; // email stuff

namespace LastMessage
{
    public partial class TestEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            MailAddress from = new MailAddress(editFrom.Text);
            MailAddress to = new MailAddress(editTo.Text);

            MailMessage message = new MailMessage(from, to);

            message.Subject = editSubject.Text;
            message.Body = editBody.Text;
            message.IsBodyHtml = isHtml.Checked;


            SmtpClient smtpClient = new SmtpClient(editServer.Text, int.Parse(editPort.Text));

            smtpClient.EnableSsl = isSsl.Checked;
            smtpClient.DeliveryMethod = (SmtpDeliveryMethod) Enum.Parse(typeof(SmtpDeliveryMethod), editDeliveryMethod.SelectedValue);

            smtpClient.UseDefaultCredentials = isDefaultCredentials.Checked;
            if(!string.IsNullOrEmpty(editLogin.Text))
            {
                smtpClient.Credentials = new NetworkCredential(editLogin.Text, editPassword.Text);
            }
    
            smtpClient.Send(message);
        }
    }
}