<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="LastMessage._default" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

  <div style="">

        <div style=""> <!-- TODO: BACKGROUND MILITARY IMAGE IN THEME COLOR; SHADOWED FONT -->
            <h5> Getting risk on your life? </h5> 
            This service is for you!
            How it works:
            <table>
                <tr>
                    <td style="width:16px; vertical-align:top;">
                        <img src="img/dot.png"/>
                    </td>
                    <td>
                        Sign up
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        <img src="img/dot.png"/>
                    </td>
                    <td>
                        Set up one or more messages, timeout to send, and recipient
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        <img src="img/dot.png"/>
                    </td>
                    <td>
                        To reset timers for all your messages just visit this site and press big main button "I'M SAFE" any time BEFORE timeout will expire.
                        <br/>
                        <i>Note:</i> You will get notification about timeout going to be expired
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        <img src="img/dot.png"/>
                    </td>
                    <td>
                        Get the risk on your life.
                        <br/>
                        If something will happen with you (oh no God!) and you will NOT be able to reset timers, the messages will be send to the specified recipients when timeout will expire.
                    </td>
                </tr>
            </table>
        </div>

        <h5 class="mt-4"> So it's time to </h5>

        <!-- Register form -->
        <form id="RegisterForm" style="text-align:center;" onsubmit="RegisterForm_OnSubmit(); return false;">
            <h5>Sign Up</h5>
            <input type="email" id="editEmail_Register" class="form-control mb-1" placeholder="Email address" required />
            <input type="text" id="editName_Register" class="form-control mb-1" placeholder="Name" required />
            <input type="password" id="editPassword_Register" class="form-control mb-1" placeholder="Password" required />
            <input type="password" id="editConfirmPassword_Register" class="form-control mb-1" placeholder="Confirm password" required />
            <div class="checkbox mt-1">
                <label>
                    <input type="checkbox" id="cbRememberMe_Register" checked="checked" /> Remember me
                </label>
            </div>

            <div id="messageRegister" class="error-box mb-1">
            </div>

            <button type="submit" class="btn btn-lg plt-1 pltbg-3 btn-block mb-3">Sign Up</button>

            Already have an account?
            <br/>
            <a href="#" class="plt-3" onclick="ShowLoginForm(); return false;"> Click here to sign in </a>

            <script>
                function ShowLoginForm()
                {
                    $("#RegisterForm").hide();
                    $("#LoginForm").show();
                }

                function RegisterForm_OnSubmit()
                {
                    var input = 
                    {
                        Email : $("#editEmail_Register").val(),
                        Name : $("#editName_Register").val(),
                        Password : $("#editPassword_Register").val(),
                        ConfirmPassword: $("#editConfirmPassword_Register").val(),
                        doRememberMe : $("#cbRememberMe_Register").is(':checked'),  // .prop("checked"),
                    };

                    
                    // TODO: wait screen
                    
                    $.post("WebServices/Register.aspx", JSON.stringify(input), "json")
                    .done(function(output) 
                    {
                        if(output.Status=="OK")
                        {
                            window.location.href="Home.aspx";
                        }
                        else
                        {
                            $("#messageRegister")
                                .text(output.Status)
                                .show();
                            
                            $("#"+output.FocusID)
                                .focus();
                        }
                    })
                    .fail(function(output) 
                    {
                        $("#messageRegister").text("Can't send request, please try again").show();
                        console.log(output);
                    })
                    ;
                }
            </script>

        </form>

        <!-- Login form -->
        <form id="LoginForm" style="text-align:center; display:none;" onsubmit="LoginForm_OnSubmit(); return false;">
            <h5>Sign In</h5>
            <input type="email" id="editEmail_Login" class="form-control mb-1" placeholder="Email address" required autofocus />
            <input type="password" id="editPassword_Login" class="form-control mb-1" placeholder="Password" required />
            <a href="#" class="plt-3" style="float:right; font-size:12px;"> Forgot password? </a>
            <div class="checkbox mt-1">
                <label>
                    <input type="checkbox" id="cbRememberMe_Login" checked="checked" /> Remember me
                </label>
            </div>

            <div id="messageLogin" class="error-box mb-1">
            </div>

            <button type="submit" class="btn btn-lg plt-1 pltbg-3 btn-block mb-3">Sign In</button>

            Don't have an account?
            <br/>
            <a href="#" class="plt-3" onclick="ShowRegisterForm(); return false;"> Click here to sign up </a>

            <script>
                
                function ShowRegisterForm()
                {
                    $("#LoginForm").hide();
                    $("#RegisterForm").show();
                }

                
                function LoginForm_OnSubmit()
                {
                    var input = 
                    {
                        Email : $("#editEmail_Login").val(),
                        Password : $("#editPassword_Login").val(),
                        doRememberMe : $("#cbRememberMe_Login").is(':checked'),  // .prop("checked"),
                    };

                    
                    // TODO: wait screen
                    
                    $.post("WebServices/Login.aspx", JSON.stringify(input), "json")
                    .done(function(output) 
                    {
                        if(output.Status=="OK")
                        {
                            window.location.href="Home.aspx";
                        }
                        else
                        {
                            $("#messageLogin")
                                .text(output.Status)
                                .show();
                            
                            $("#"+output.FocusID)
                                .focus();
                        }
                    })
                    .fail(function(output) 
                    {
                        $("#messageLogin").text("Can't send request, please try again").show();
                        console.log(output);
                    })
                    ;
                }
            </script>

    
        </form>
  </div>

</asp:Content>
