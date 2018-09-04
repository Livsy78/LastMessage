using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security; // FormsAuthentication

namespace LastMessage.WebServices
{
    public partial class Login : BaseTemplate<Login_Input, Login_Output>
    {

        public override Login_Output GetData(Login_Input input)
        {
            Login_Output output = new Login_Output()
            {
                Status = "OK"
            };

            DB.User user = DB.User.GetByFieldValue("Email", input.Email);
            
            if(user==null)
            {
                output.Status = "Email not found";
                output.FocusID = "editEmail_Login";
                return output;
            }

            if(input.Password != user.Password)
            {
                output.Status = "Invalid password";
                output.FocusID = "editPassword_Login";
                return output;
            }
            
            //if( !(user.Status == DB.UserStatus.ACTIVE || user.Status == DB.UserStatus.VIP || user.Status == DB.UserStatus.ADMIN) )
            if(user.Status == DB.UserStatus.DISABLED)
            {
                output.Status = string.Format("User is disabled, contact me"); // TODO? : <a href="ContactMe.aspx"> contact me </a>
                return output;
            }
                
            // everything is OK, sign me in
            if(output.Status=="OK")
            {
                FormsAuthentication.SetAuthCookie(user.Email, input.doRememberMe);
            }

            return output;
        }
    }


    public class Login_Input
    {
        public string Email {get;set;}
        public string Password {get;set;}
        public bool doRememberMe {get;set;}
    }

    public class Login_Output : BaseOutput
    {
        public string FocusID {get;set;}
    }
}
