using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LastMessage
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // to BasePage !?
            int userID = DB.User.GetByFieldValue("Email", HttpContext.Current.User.Identity.Name).ID;

            DB.Message[] messages = DB.Message.GetAllByFieldValue<int>("UserID", userID);

            lblMessage.Text=string.Format("count: {0}", messages.Count() );
        }
    }
}