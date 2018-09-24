<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordForgot.aspx.cs" Inherits="LastMessage.PasswordForgot" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">


    <form id="PasswordForgotForm" style="text-align:center;" runat="server" defaultbutton="btnSendEmail">
            
        <h5>Forgot password</h5>
            
        <asp:TextBox ID="editEmail" CssClass="form-control mt-3 mb-4" runat="server" TextMode="Email" placeholder="Email address" required autofocus></asp:TextBox>

        <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" CssClass="error-box mt-1 mb-1"></asp:Label>

        <asp:Button ID="btnSendEmail" runat="server" Text="Send Email" CssClass="btn btn-lg plt-1 pltbg-3 btn-block btn-shdw mt-4 mb-3" OnClick="btnSendEmail_Click" />
        
    </form>


</asp:Content>
