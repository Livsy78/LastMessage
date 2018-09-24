<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LastMessage.Login" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

    <form id="LoginForm" style="text-align:center;" runat="server" defaultbutton="btnLogin">

        <h5 class="mt-3">Sign In</h5>
        <asp:TextBox ID="editEmail" CssClass="form-control mb-1" runat="server" TextMode="Email" placeholder="Email address" required autofocus></asp:TextBox>
        <asp:TextBox ID="editPassword" CssClass="form-control mb-1" runat="server" TextMode="Password" placeholder="Password" required></asp:TextBox>
        <a href="PasswordForgot.aspx" class="plt-3" style="float:right; font-size:12px;"> Forgot password? </a>
        <div class="checkbox mt-1">
            <asp:CheckBox ID="cbRememberMe" runat="server" Text="Remember me" Checked="True" />
        </div>

        <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" CssClass="error-box mb-1"></asp:Label>

        <asp:Button ID="btnLogin" runat="server" Text="Sign In" CssClass="btn btn-lg plt-1 pltbg-3 btn-block btn-shdw mb-3" OnClick="btnLogin_Click" />

        Don't have an account?
        <br/>
        <a href="Register.aspx" class="plt-3"> Click here to sign up </a>

    </form>

</asp:Content>
