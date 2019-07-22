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
        public int MessageID
        {
            get
            {
                return int.Parse(Request.QueryString["ID"]);
            }
            set{}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    if(MessageID >= 0)
                    {
                        DB.Message message = DB.Message.Get(MessageID);

                        // at 1st check the message belongs to CurrentUserID
                        if(message.UserID != CurrentUser.ID)
                        {
                            throw new Exception();
                        }
                        
                        editTitle.Text = message.Title;
                        editMessage.Text = message.Text;
                        ddlSendIn.SelectedValue = message.SendIn_Hours.ToString();
                        ddlNotifyBefore.SelectedValue = message.NotifyBefore_Hours.ToString();

                        UpdateRecipientList(message.ID);

                    }
                }
                catch
                {
                    Response.Redirect(".");
                }
                
            }

        }


        protected void UpdateRecipientList(int messageID)
        {
            //WebServices.GetRecipientList_Output data = WebServices.GetRecipientList.GetData(messageID); // fail
            
            WebServices.GetRecipientList_Output data = (new WebServices.GetRecipientList())  // no other way
                .GetData(new WebServices.GetRecipientList_Input() 
                {
                    MessageID = messageID,
                }
            );

            rptRecipientList.DataSource = data.Items;
            rptRecipientList.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DB.Message message = null;
            
            if(MessageID >= 0)
            {
                message = DB.Message.Get(MessageID);
            }
            else
            {
                message = new DB.Message()
                {
                    ID = -1,
                    Status = DB.MessageStatus.ACTIVE,
                    UserID = CurrentUser.ID,
                };
            }

            message.Title = editTitle.Text;
            message.Text = editMessage.Text;
            message.SendIn_Hours = int.Parse(ddlSendIn.SelectedValue);
            message.NotifyBefore_Hours = int.Parse(ddlNotifyBefore.SelectedValue);

            // reset timer // TODO? RESET ALL ?????
            message.SendTime = DateTime.Now.AddHours(message.SendIn_Hours);

            message = message.Save();

            if(MessageID >= 0)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Redirect("EditMessage.aspx?ID=" + message.ID.ToString() ); // let user to not leave the new message and to add recipients
            }

        }

        protected void rptRecipientList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int recipientID = int.Parse(e.CommandArgument.ToString());

                DB.Recipient recipient = DB.Recipient.Get(recipientID);
                if(recipient != null)
                {
                    recipient.Delete();
                }

                UpdateRecipientList(MessageID);
            }
        }

    }
}