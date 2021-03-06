﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security; // FormsAuthentication

namespace LastMessage.WebServices
{
    public partial class Register : BaseTemplate<Register_Input, Register_Output>
    {

        public override Register_Output GetData(Register_Input input)
        {
            Register_Output output = new Register_Output();

            DB.User user = DB.User.GetByFieldValue("Email", input.Email);

            if(user!=null)
            {
                output.Status = "Email already registered";
                output.FocusID = "editEmail_Register";
                return output;
            }

            if(input.Password != input.PasswordConfirm)
            {
                output.Status = "Please confirm password";
                output.FocusID = "editPasswordConfirm_Register";
                return output;
            }

            // mroe validations

            if(output.Status=="OK")
            {
                user = new DB.User()
                {
                    ID = -1,
                    Status = DB.UserStatus.ACTIVE,
                    Email = input.Email,
                    Name = input.Name,
                    Password = input.Password
                };
                user = user.Save();

                FormsAuthentication.SetAuthCookie(user.Email, input.doRememberMe);

                
                DB.Log.Add(new DB.Log()
                    {
                        UserID = user.ID,
                        Type = DB.LogType.REGISTER_USER,
                        Text = user.Email
                    }
                );
            }

            return output;
        }

    }

    public class Register_Input
    {
        public string Email {get;set;}
        public string Name {get;set;}
        public string Password {get;set;}
        public string PasswordConfirm {get;set;}
        public bool doRememberMe {get;set;}
    }

    public class Register_Output : BaseOutput
    {
        public string FocusID {get;set;}
    }

}