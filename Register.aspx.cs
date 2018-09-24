using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LastMessage
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            WebServices.Register_Input input = new WebServices.Register_Input()
            {
                Email = editEmail.Text,
                Name = editName.Text,
                Password = editPassword.Text,
                PasswordConfirm = editPasswordConfirm.Text,
                doRememberMe = cbRememberMe.Checked,
            };


            WebServices.Register_Output data = (new WebServices.Register())
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