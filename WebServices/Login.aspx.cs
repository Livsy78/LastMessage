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
        protected void Page_Load(object sender, EventArgs e)
        {
            Login_Input input = DeserializePostInput();
            
            Login_Output output = new Login_Output();

            if(input==default(Login_Input))
            {
                output.Status = "Invalid arguments";
            }
            else
            {
                output = GetData(input);
            }

            SerializeOutput(output);
        }

        public Login_Output GetData(Login_Input input)
        {
            Login_Output output = new Login_Output()
            {
                Status = "OK"
            };

            DB.User user = DB.User.GetByFieldValue("Email", input.Email);
            
            if(user==null)
            {
                output.Status = "E-Mail not found";
                output.FocusControlID = "editEmail_Login";
                return output;
            }

            if(input.Password != user.Password)
            {
                output.Status = "Invalid password";
                output.FocusControlID = "editPassword_Login";
                return output;
            }
            
            //if( !(user.Status == DB.UserStatus.ACTIVE || user.Status == DB.UserStatus.VIP || user.Status == DB.UserStatus.ADMIN) )
            if(user.Status == DB.UserStatus.DISABLED)
            {
                output.Status = string.Format("User is disabled, contact me");
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

    public class Login_Output
    {
        public string Status {get;set;}
        public string FocusControlID {get;set;}
    }
}