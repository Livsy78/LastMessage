using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LastMessage
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB.User.GetByFieldValue("Email", "");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Tools.Email email = new Tools.Email()
            {
                From = "noreply@lastmessage.in",
                To = "albirukov@gmail.com",
                Subject = editSubj.Text,
                Body = editBody.Text,

                ConfigKeyPrefix = "Notify",
            };

            try
            {
                email.Send();
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }

}