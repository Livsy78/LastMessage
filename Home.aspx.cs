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
            //btnResetTimers.Text = "I'm OK" + Environment.NewLine + "Reset all timers";
            //btnResetTimers.Text = "I'm OK\r\nReset all timers";
            //btnResetTimers.Text = Server.HtmlDecode("I'm OK&#13;&#10;Reset all timers");
            //btnResetTimers.Text = Server.HtmlDecode("I'm OK\r\nReset all timers");

        }

        protected void btnResetTimers_Click(object sender, ImageClickEventArgs e)
        {
            // had to set CausesValidation property to False to make it firing, wtf?...

            DB.Message[] messages = DB.Message.GetAllByFieldValue<int>("UserID", CurrentUserID);

            DateTime now = DateTime.Now;
            foreach(DB.Message message in messages)
            {
                message.TimeToSend = now.AddDays(message.SendIn_Days);
                message.Save();
            }
        }

    }

}