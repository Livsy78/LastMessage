using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LastMessage
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            WebServices.Login_Input input = new WebServices.Login_Input()
            {
                Email = editEmail.Text,
                Password = editPassword.Text,
                doRememberMe = cbRememberMe.Checked,
            };


            WebServices.Login_Output data = (new WebServices.Login())
                .GetData(input);


            if(data.Status == "OK")
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblMessage.Text = data.Status;
                lblMessage.Visible = true;

                // TODO? focus, was implemented for default.aspx... see data.FocusID
            }


        }
    }
}