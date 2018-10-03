<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditAccount.aspx.cs" Inherits="LastMessage.EditAccount" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

    <style>
    </style>

    <title> My Account "TODO" - [Last Message]</title>

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

    <form id="EditAccountForm" style="text-align:center;" runat="server" defaultbutton="btnSave">
        <div class="mywidth-inner" style="position:fixed; top:32px;">
            <input id="btnBack" type="button" value="&nbsp;&nbsp;&nbsp;Back" class="btn plt-1 pltbg-3 btn-shdw btn-back" onclick="window.location.href='Home.aspx';" />
            <asp:Button ID="btnSave" runat="server" Text="&nbsp;&nbsp;&nbsp;Save" CssClass="btn plt-1 pltbg-3 btn-shdw btn-save" OnClick="btnSave_Click"/>
        </div>

        <h5>My account:</h5>
        
        <asp:TextBox ID="editEmail" CssClass="form-control mb-1" runat="server" TextMode="Email" placeholder="Email address" required ></asp:TextBox>
        <asp:TextBox ID="editName" CssClass="form-control mb-3" runat="server" placeholder="Name" required ></asp:TextBox>

        <asp:TextBox ID="editPassword" CssClass="form-control mb-1" runat="server" TextMode="Password" placeholder="New password" ></asp:TextBox>
        <asp:TextBox ID="editPasswordConfirm" CssClass="form-control mb-1" runat="server" TextMode="Password" placeholder="Confirm New password" ></asp:TextBox>

        <div class="checkbox mt-1">
            <asp:CheckBox ID="cbRememberMe" runat="server" Text="Remember me" Checked="True" />
        </div>

        <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" CssClass="error-box mb-1"></asp:Label>


    </form>

</asp:Content>
