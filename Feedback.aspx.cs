﻿using System;
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
            DB.Log[] currentUserRecords = DB.Log.GetAllByFieldValue<int>("UserID", CurrentUserID);

            // no more than 3 message per user per day...
            DB.Log[] lastDayLogs = currentUserRecords.Where(r=> r.Time > DateTime.Now.AddDays(-1)).ToArray();
            if(lastDayLogs.Count() >= 3)
            {
                lblMessage.Text = "Max 3 reports per day";
                lblMessage.Visible = true;
                return;
            }

            DB.Log.Add(new DB.Log()
                {
                    UserID = CurrentUserID,
                    Type = DB.LogType.FEEDBACK,
                    Text = "TITLE: " + editTitle.Text + " MESSAGE: " + editMessage.Text,
                }
            );

            Response.Redirect("Message.aspx?ID=FeedbackSent");
        }

    }
}