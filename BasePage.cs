using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastMessage
{
    public class BasePage : System.Web.UI.Page
    {
        protected int CurrentUserID
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated ? 
                    DB.User.GetByFieldValue("Email", HttpContext.Current.User.Identity.Name).ID
                    : 
                    -1;
            }
            set{}
        }

        protected string CurrentUserEmail
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated ? 
                    HttpContext.Current.User.Identity.Name
                    : 
                    null;
            }
            set{}
        }


        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            //lblMessage.Text = ex.Message;  // page will not be generated...
            //lblMessage.Visible = true;

            Server.ClearError();

            //base.Page_Error(sender, e);
            Response.Redirect("Message.aspx?ID=PageError&link=.");
        }


    }
}