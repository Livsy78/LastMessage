using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LastMessage
{
    public partial class Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string messageResourceId = Request.QueryString["ID"];
            if(messageResourceId != null)
            {
                // see Messages.resx RESOURCE
                lblMessage.Text = Messages.ResourceManager.GetString(messageResourceId); // exception?
            }
            string link = Request.QueryString["link"];   // example: Message.aspx?message=NewAccountCongratulation&link=./ChangePassword.aspx
            linkContinue.NavigateUrl = (link==null ? "." : link);
        }
    }
}