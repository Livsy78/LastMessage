using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LastMessage.WebServices
{
    public partial class GetRecipientList : BaseTemplate<GetRecipientList_Input, GetRecipientList_Output>
    {
        public override GetRecipientList_Output GetData(GetRecipientList_Input input)
        {
            GetRecipientList_Output output = new GetRecipientList_Output();

            // TODO  check the message belongs to CurrentUserID , see EditMessage

            DB.Recipient[] recipients = DB.Recipient.GetAllByFieldValue<int>("MessageID", input.MessageID);

            List<GetRecipientList_OutputItem> items = new List<GetRecipientList_OutputItem>();
            
            foreach(DB.Recipient recipient in recipients)
            {
                DB.Destination[] destinationArr = DB.Destination.GetAllByFieldValue("RecipientID", recipient.ID);
                string destinations = string.Empty;
                foreach(DB.Destination destination in destinationArr)
                {
                    if(!string.IsNullOrEmpty(destinations))
                    {
                        destinations += "<br/>";
                    }
                    destinations += string.Format("{0}: {1}", destination.Type.ToString(), destination.Address);
                }

                items.Add(new GetRecipientList_OutputItem()
                {
                    RecipientID = recipient.ID,
                    Status = recipient.Status.ToString(),
                    Name = recipient.Name,
                    Destinations = destinations,
                });

            }

            output.TotalItems = items.Count();
            output.Items = items
                //.OrderBy(r=>)
                .ToArray();
            return output;
        }
    }


    public class GetRecipientList_Input
    {
        public int MessageID {get;set;}
    }

    public class GetRecipientList_Output : BaseOutput
    {
        public int TotalItems {get;set;}
        public GetRecipientList_OutputItem[] Items {get;set;}
    }

    public class GetRecipientList_OutputItem
    {
        public int RecipientID {get;set;}
        public string Status {get;set;}
        public string Name {get;set;}
        public string Destinations {get;set;}  // hmmm comma separated? Destination[] ?
    }



}