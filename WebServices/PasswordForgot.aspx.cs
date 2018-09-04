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
            
            
            
            
            
            
            return null;
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