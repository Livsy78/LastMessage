using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LastMessage
{
    public partial class EditMessage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DB.Message message = DB.Message.Get(int.Parse(Request.QueryString["ID"]));

                // at 1st check the message belongs to CurrentUserID
                if(message.UserID != CurrentUserID)
                {
                    throw new Exception();
                }


            }
            catch
            {
                Response.Redirect("Home.aspx");
            }
        }


    }
}