<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="LastMessage.PasswordReset" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

  <div style="">

    <form id="PasswordResetForm" style="text-align:center;" runat="server">

        <h5>Please enter new password</h5>
        <h5>for <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></h5>

        <asp:TextBox ID="editNewPassword" runat="server" CssClass="form-control mt-4 mb-2" TextMode="Password" placeholder="New password"></asp:TextBox>
        <asp:TextBox ID="editNewPasswordConfirm" runat="server" CssClass="form-control mb-2" TextMode="Password" placeholder="Confirm new password"></asp:TextBox>
        <asp:CheckBox ID="cbRememberMe" runat="server" CssClass="mb-2" Text="Remember me"/>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="error-box mb-2"></asp:Label>
        <asp:Button ID="btnSaveNewPassword" runat="server" CssClass="btn btn-lg plt-1 pltbg-3 btn-block mb-3" Text="Save new password" OnClick="btnSaveNewPassword_Click" />

    </form>

  </div>

</asp:Content>
