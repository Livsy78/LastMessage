using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LastMessage
{
    public partial class EditRecipient : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //at 1st check the recipient belongs to CurrentUserID
                if(CurrentMessage.UserID != CurrentUserID)
                {
                    throw new Exception();
                }

            }
            catch
            {
                Response.Redirect("Home.aspx");
            }

        }


        private DB.Recipient _CurrentRecipient = null;
        public DB.Recipient CurrentRecipient
        {
            get
            {
                if(_CurrentRecipient == null)
                {
                    _CurrentRecipient = DB.Recipient.Get(int.Parse(Request.QueryString["ID"]));
                }
                return _CurrentRecipient;
            }
            set{}
        }

        private DB.Message _CurrentMessage = null;
        public DB.Message CurrentMessage
        {
            get
            {
                if(_CurrentMessage == null)
                {
                    _CurrentMessage = DB.Message.Get(CurrentRecipient.MessageID);
                }
                return _CurrentMessage;
            }
            set{}
        }

    }
}