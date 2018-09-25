using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LastMessage.WebServices
{
    public partial class DeleteMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO check if message belongs to the current user
            
            int messageID = int.Parse(Request.QueryString["ID"]);
            
            // recipients and destinations will be deleted via db diagram voila :)
            DB.Message message = DB.Message.Get(messageID);
            if(message != null)
            {
                message.Delete();
            }

        }




    }
}