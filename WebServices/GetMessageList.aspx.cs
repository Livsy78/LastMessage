using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LastMessage.WebServices
{
    public partial class GetMessageList : BaseTemplate<GetMessageList_Input, GetMessageList_Output>
    {
        public override GetMessageList_Output GetData(GetMessageList_Input input)
        {
            GetMessageList_Output output = new GetMessageList_Output();

            DB.Message[] messages = DB.Message.GetAllByFieldValue<int>("UserID", input.UserID);

            List<GetMessageList_OutputItem> items = new List<GetMessageList_OutputItem>();

            DateTime now = DateTime.Now;
            foreach(DB.Message message in messages)
            {
                DB.Recipient[] recipientArr = DB.Recipient.GetAllByFieldValue<int>("MessageID", message.ID);
                string recipients = string.Empty;
                foreach(DB.Recipient recipient in recipientArr)
                {
                    if(!string.IsNullOrEmpty(recipients))
                    {
                        recipients += ", ";
                    }
                    recipients += recipient.Name;
                }


                items.Add(new GetMessageList_OutputItem()
                {
                    MessageID = message.ID,
                    Status = message.Status.ToString(),
                    Recipients = recipients,
                    SendIn_Seconds = message.Status != DB.MessageStatus.SENT ? 
                                    Convert.ToInt32( (message.SendTime - now).TotalSeconds ) 
                                    : 
                                    int.MaxValue, // make sent message go to the end of list in OrderBy(r=> r.SendIn_Seconds) (see bellow)
                    Title = message.Title,
                    Text = message.Text,
                });
            }
            
            output.TotalItems = items.Count();
            output.Items = items
                .OrderBy(r=> r.SendIn_Seconds)
                .ToArray();
            return output;
        }

    }

    public class GetMessageList_Input
    {
        public int UserID {get;set;}
    }

    public class GetMessageList_Output : BaseOutput
    {
        public int TotalItems {get;set;}
        public GetMessageList_OutputItem[] Items {get;set;}
    }

    public class GetMessageList_OutputItem
    {
        public int MessageID {get;set;}
        public string Status {get;set;}
        public string Recipients {get;set;}  // hmmm comma separated? Recipient[] ?
        public int SendIn_Seconds {get;set;}
        public string Title {get;set;}
        public string Text {get;set;}        // need ?
    }

}