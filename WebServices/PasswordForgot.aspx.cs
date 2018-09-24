using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO; // File
using System.Configuration; // ConfigurationManager.AppSettings["..."]

namespace LastMessage.WebServices
{
    public partial class PasswordForgot : BaseTemplate<PasswordForgot_Input, PasswordForgot_Output>
    {

        public override PasswordForgot_Output GetData(PasswordForgot_Input input)
        {
            PasswordForgot_Output output = new PasswordForgot_Output();

            DB.User user = DB.User.GetByFieldValue("Email", input.Email);
            
            if(user==null)
            {
                output.Status = "Email not found";
                return output;
            }
            
            
            if(output.Status=="OK")
            {
                // create token
                Guid token = Guid.NewGuid();
                int expireMinutes = int.Parse(ConfigurationManager.AppSettings["PasswordReset.TokenTimeoutMinutes"]);
                HttpContext.Current.Cache.Insert("PASSWORD_RESET_TOKEN_"+token.ToString(), user.Email, null, DateTime.Now.AddMinutes(expireMinutes), System.Web.Caching.Cache.NoSlidingExpiration);

                // send email
                try
                {
                    
                    string emailTemplate = File.ReadAllText(Server.MapPath("~/WebServices/PasswordForgot.EmailTemplate"));

                    // string link = "http://" /*TODO: SSL?? NO, auto-forced for this page //https:// */ + Request.Url.Host + "/PasswordReset.aspx?token="+token.ToString();
                    string link = Request.Url.Host + "/PasswordReset.aspx?token="+token.ToString();
                    string body = string.Format(emailTemplate, user.Name, link, link, expireMinutes, Request.Url.Host);


                    Tools.Email.Send(new Tools.Email()  //"support", user.Email, "password recovery", body, "Support");
                    {
                        To = user.Email,
                        From = "noreply@lastmessage.in",
                        Subject = "[LastMessage.in] Password reset",
                        Body = body,
                        ConfigKeyPrefix = "NoReply",
                    });

                }
                catch(Exception ex)
                {
                    output.Status = "Send Email failed: " + ex.Message;
                }

            }
            
            return output;
        }

    }

    public class PasswordForgot_Input
    {
        public string Email {get;set;}
    }

    public class PasswordForgot_Output : BaseOutput
    {
    }

}