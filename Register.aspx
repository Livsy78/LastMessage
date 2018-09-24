<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LastMessage.Register" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

    <div style=""> <!-- TODO: BACKGROUND MILITARY IMAGE IN THEME COLOR; SHADOWED FONT -->
        <h5> Getting RISK on your life? This service is for you!</h5>
        <b>How it works:</b>
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
                    Set up one or more messages, timeout to send, and recipient(s)
                </td>
            </tr>
            <tr>
                <td style="vertical-align:top;">
                    <img src="img/dot.png"/>
                </td>
                <td>
                    <b>Get the risk on your life.</b>
                    <br/>
                    If something will happen with you <i>(oh no God!)</i> and you will NOT be able to reset timers, the messages will be send to the specified recipients when timeout will expire.
                </td>
            </tr>
            <tr>
                <td style="vertical-align:top;">
                    <img src="img/dot.png"/>
                </td>
                <td>
                    To reset timers for all your messages just visit this site and press big main button <img src="img/imok.png" style="height:18px;"/> any time BEFORE timeout will expire.
                    <br/>
                    <i>Note:</i> You will get notification about timeout going to be expired
                </td>
            </tr>
        </table>
    </div>


    <form id="RegisterForm" style="text-align:center;" runat="server" defaultbutton="btnRegister">
        <b style="text-align:left;">It's really easy and it works!</b>
        <h5 class="mt-3">Sign Up</h5>
        <asp:TextBox ID="editEmail" CssClass="form-control mb-1" runat="server" TextMode="Email" placeholder="Email address" required ></asp:TextBox>
        <asp:TextBox ID="editName" CssClass="form-control mb-1" runat="server" placeholder="Name" required ></asp:TextBox>
        <asp:TextBox ID="editPassword" CssClass="form-control mb-1" runat="server" TextMode="Password" placeholder="Password" required></asp:TextBox>
        <asp:TextBox ID="editPasswordConfirm" CssClass="form-control mb-1" runat="server" TextMode="Password" placeholder="Confirm password" required></asp:TextBox>

        <div class="checkbox mt-1">
            <asp:CheckBox ID="cbRememberMe" runat="server" Text="Remember me" Checked="True" />
        </div>

        <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" CssClass="error-box mb-1"></asp:Label>

        <asp:Button ID="btnRegister" runat="server" Text="Sign Up" CssClass="btn btn-lg plt-1 pltbg-3 btn-block btn-shdw mb-3" OnClick="btnRegister_Click" />

        Already have an account?
        <br/>
        <a href="Login.aspx" class="plt-3"> Click here to sign in </a>
        
    
    </form>

</asp:Content>
