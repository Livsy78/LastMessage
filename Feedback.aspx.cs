using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LastMessage
{
    public partial class Feedback : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // no more than 3 message per user per day...
            DB.Log[] currentUserRecords = DB.Log.GetAllByFieldValue<int>("UserID", CurrentUser.ID);
            DB.Log[] lastDayLogs = currentUserRecords.Where(r=> r.Time > DateTime.Now.AddDays(-1)).ToArray();
            if(lastDayLogs.Count() >= 3)
            {
                // Response.Redirect("Message.aspx?ID=FeedbackMaxReached"); 

                lblMessage.Text = "Max 3 reports per day";  // "Max of reports per day has been reached"
                lblMessage.Visible = true;
                return;
            }

            DB.Log.Add(new DB.Log()
                {
                    UserID = CurrentUser.ID,
                    Type = DB.LogType.FEEDBACK,
                    Text = "TITLE: " + editTitle.Text + " MESSAGE: " + editMessage.Text,
                }
            );

            Response.Redirect("Message.aspx?ID=FeedbackSent");
        }

    }
}