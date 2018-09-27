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
        
        public int RecipientID
        {
            get
            {
                return int.Parse(Request.QueryString["ID"]);
            }
            set{}
        }
        
        public int CurrentMessageID
        {
            get
            {
                return RecipientID >= 0 
                    ? DB.Recipient.Get(RecipientID).MessageID     // TODO some optimization?
                    : int.Parse(Request.QueryString["MessageID"])  // if it's a new recipient then we need MessageID
                ;
            }
            set{}
        }

        public DB.Message CurrentMessage
        {
            get
            {
                return DB.Message.Get(CurrentMessageID);
            }
            set{}
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    if(RecipientID >= 0)
                    {
                        DB.Recipient recipient = DB.Recipient.Get(RecipientID);

                        if(CurrentUserID != CurrentMessage.UserID)
                        {
                            throw new Exception();
                        }

                        editName.Text = recipient.Name;

                        // foreach(DB.Destination) ? see below
                        DB.Destination[] destinations = DB.Destination.GetAllByFieldValue<int>("RecipientID", recipient.ID);
                        foreach(DB.Destination destination in destinations)
                        {
                            switch(destination.Type)
                            {
                                case DB.DestinationType.Email :
                                    editEmail.Text = destination.Address;
                                    break;

                                // other destinations - SMS, etc

                                default:
                                    break;
                            }
                        }

                    }

                }
                catch
                {
                    Response.Redirect(".");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DB.Recipient recipient = null;

            if(RecipientID >= 0)
            {
                recipient = DB.Recipient.Get(RecipientID);
            }
            else
            {
                recipient = new DB.Recipient()
                {
                    ID = -1,
                    Status = DB.RecipientStatus.ACTIVE,
                    MessageID = CurrentMessageID,
                };
            }

            recipient.Name = editName.Text;
            recipient = recipient.Save();

            DB.Destination[] destinations = DB.Destination.GetAllByFieldValue<int>("RecipientID", recipient.ID);

            DB.Destination destination = null;

            foreach (DB.DestinationType destinationType in (DB.DestinationType[]) Enum.GetValues(typeof(DB.DestinationType)))
            {
                destination = destinations.Where(r=> r.Type==destinationType).SingleOrDefault();
                if(destination == null)
                {
                    destination = new DB.Destination()
                    {
                        ID = -1,
                        Status = DB.DestinationtStatus.ACTIVE,
                        RecipientID = recipient.ID,
                        Type = destinationType,
                    };
                }

                switch(destinationType)
                {
                    case DB.DestinationType.Email :
                        // if(cbEmail.Checked)
                        destination.Address = editEmail.Text;
                        destination = destination.Save();

                        break;

                    // other destinations - SMS, etc

                    default : 
                        break;
                }
            }

            Response.Redirect("EditMessage.aspx?ID=" + CurrentMessageID.ToString() );
        }



    }
}