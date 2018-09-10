using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LastMessage
{
    public partial class Home : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB.Message[] messages = DB.Message.GetAllByFieldValue<int>("UserID", CurrentUserID);

            lblMessage.Text=string.Format("count: {0}", messages.Length );
            foreach(DB.Message msg in messages)
            {
                lblMessage.Text += string.Format("<br/>{0}", msg.SendIn_Days);
            }

        }
    }
}