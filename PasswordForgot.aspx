<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordForgot.aspx.cs" Inherits="LastMessage.PasswordForgot" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

    <div style="">

        <form id="PasswordForgotForm" style="text-align:center;" onsubmit="PasswordForgotForm_OnSubmit(); return false;">
            
            <br/>
            <h5>Forgot password</h5>
            
            <input type="email" id="editEmail_PasswordForgot" class="form-control mt-5 mb-5" placeholder="Email address" required autofocus />

            <div id="messagePasswordForgot" class="error-box mb-1">
            </div>

            <button type="submit" class="btn btn-lg plt-1 pltbg-3 btn-block mb-5 mt-5"> Send Email </button>
        
            <script>

                function PasswordForgotForm_OnSubmit()
                {
                    var input = 
                    {
                        Email : $("#editEmail_PasswordForgot").val(),
                    };

                    // TODO: wait screen

                    $.post("WebServices/PasswordForgot.aspx", JSON.stringify(input), "json")
                    .done(function(output) 
                    {
                        if(output.Status=="OK")
                        {
                            window.location.href="Message.aspx?ID=PasswordEmailSent";
                        }
                        else
                        {
                            $("#messagePasswordForgot")
                                .text(output.Status)
                                .show();
                            
                            $("#editEmail_PasswordForgot")
                                .focus();
                        }
                    })
                    .fail(function(output) 
                    {
                        $("#messagePasswordForgot").text("Can't send request, please try again").show();
                        console.log(output);
                    })
                    ;

                }

            </script>

        </form>

    </div>

</asp:Content>
