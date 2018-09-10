using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastMessage
{
    public class BasePage : System.Web.UI.Page
    {
        protected int CurrentUserID
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated ? 
                    DB.User.GetByFieldValue("Email", HttpContext.Current.User.Identity.Name).ID
                    : 
                    -1;
            }
            set{}
        }

        protected string CurrentUserEmail
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated ? 
                    HttpContext.Current.User.Identity.Name
                    : 
                    null;
            }
            set{}
        }


    }
}