using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security; // FormsAuthentication

namespace LastMessage
{
    public partial class EditAccount : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DB.User user = DB.User.Get(CurrentUser.ID);
                
                editEmail.Text = user.Email;
                editName.Text = user.Name;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DB.User user = DB.User.Get(CurrentUser.ID);

            if(user.Email != editEmail.Text)
            {
                DB.User user2 = DB.User.GetByFieldValue<string>("Email", editEmail.Text);
                if(user2 != null)
                {
                    lblMessage.Text = "Email already registered";
                    lblMessage.Visible = true;
                    return;
                }
            }
            
            user.Email = editEmail.Text;
            user.Name = editName.Text;

            if(!string.IsNullOrEmpty(editPassword.Text))
            {
                if(editPassword.Text != editPasswordConfirm.Text)
                {
                    lblMessage.Text = "Please confirm password";
                    lblMessage.Visible = true;
                    return;
                }

                user.Password = editPassword.Text;
            }

            user = user.Save();
            FormsAuthentication.SetAuthCookie(user.Email, cbRememberMe.Checked);
            Response.Redirect(".");
        }



    }
}