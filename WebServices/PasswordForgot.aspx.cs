using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LastMessage.WebServices
{
    public partial class PasswordForgot : BaseTemplate<PasswordForgot_Input, PasswordForgot_Output>
    {

        public override PasswordForgot_Output GetData(PasswordForgot_Input input)
        {
            PasswordForgot_Output output = new PasswordForgot_Output()
            {
                Status = "OK"
            };

            DB.User user = DB.User.GetByFieldValue("Email", input.Email);
            
            if(user==null)
            {
                output.Status = "Email not found";
                return output;
            }
            
            
            if(output.Status=="OK")
            {
                // TODO token

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