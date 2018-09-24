using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LastMessage
{
    public partial class PasswordForgot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            WebServices.PasswordForgot_Input input = new WebServices.PasswordForgot_Input()
            {
                Email = editEmail.Text,
            };


            WebServices.PasswordForgot_Output data = (new WebServices.PasswordForgot())
                .GetData(input);


            if(data.Status == "OK")
            {
                Response.Redirect("Message.aspx?ID=PasswordResetEmailSent");
            }
            else
            {
                lblMessage.Text = data.Status;
                lblMessage.Visible = true;

                editEmail.Focus();
            }

        }
    }
}