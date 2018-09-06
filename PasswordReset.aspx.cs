using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security; // FormsAuthentication

namespace LastMessage
{
    public partial class PasswordReset : System.Web.UI.Page
    {
        private DB.User user = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            string tokenStr = Request.QueryString["token"];
            Guid token = Guid.Parse(tokenStr);

            Object userEmailCacheEntry = Cache["PASSWORD_RESET_TOKEN_"+token.ToString()];
            if(userEmailCacheEntry==null)
            {
                Response.Redirect("Message.aspx?ID=PasswordResetTokenExpired&link=PasswordForgot.aspx");
                return;
            }

            string userEmail = userEmailCacheEntry.ToString();

            user = DB.User.GetByFieldValue("Email", userEmail);
            if(user == null)
            {
                // should not happen
                Response.Redirect("Message.aspx?ID=PasswordResetEmailNotFound&link=PasswordForgot.aspx");
                return;
            }

            lblEmail.Text = user.Email;
        }

        protected void btnSaveNewPassword_Click(object sender, EventArgs e)
        {
            if(editNewPassword.Text != editNewPasswordConfirm.Text)
            {
                lblErrorMessage.Visible=true;
                lblErrorMessage.Style["display"] = "block";
                lblErrorMessage.Text="Please confirm password";
                return;
            }
            
            // save new password
            user.Password = editNewPassword.Text;
            user.Save();

            // make user logged in
            FormsAuthentication.SetAuthCookie(user.Email, cbRememberMe.Checked);

            Response.Redirect("Message.aspx?ID=PasswordResetUpdated");
        }

    }
}
