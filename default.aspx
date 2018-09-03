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
                        To reset timers for all your messages just visit this site and press big main button "I'M SAFE" any time BEFO
                        Visit this site any time BEFORE timeout will expire, and press big main button "I'M SAFE" to reset timers for all your messages.
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

        <form id="RegisterForm" style="text-align:center;">
            <h5>Sign Up</h5>
            <input type="email" id="editEmail_Register" class="form-control mb-1" placeholder="Email address" required />
            <input type="text" id="Name" class="form-control mb-1" placeholder="Name" required />
            <input type="password" id="editPassword_Register" class="form-control mb-1" placeholder="Password" required />
            <input type="password" id="editPasswordConfirm_Register" class="form-control mb-1" placeholder="Confirm password" required />
            <div class="checkbox mt-1">
                <label>
                    <input type="checkbox" id="editRememberMe_Register" value="remember-me" checked="checked" /> Remember me
                </label>
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
            </script>

            <br/><br/>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

        </form>

        <form id="LoginForm" style="text-align:center; display:none;">
            <h5>Sign In</h5>
            <input type="email" id="editEmail_Login" class="form-control mb-1" placeholder="Email address" required autofocus />
            <input type="password" id="editPassword_Login" class="form-control mb-1" placeholder="Password" required />
            <a href="#" class="plt-3" style="float:right; font-size:12px;"> Forgot password? </a>
            <div class="checkbox mt-1">
                <label>
                    <input type="checkbox" id="editRememberMe_Login" value="remember-me" checked="checked" /> Remember me
                </label>
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
            </script>

    
        </form>
  </div>

</asp:Content>
