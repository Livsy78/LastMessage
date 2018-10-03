<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="LastMessage.Feedback" MasterPageFile="HeaderFooter.Master" %>

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

        <h5>Feedback:</h5>

        <asp:TextBox ID="editTitle" CssClass="form-control mb-1"  runat="server" placeholder="Title" MaxLength="64" required></asp:TextBox>

        <asp:TextBox ID="editMessage" CssClass="form-control mb-1" TextMode="MultiLine" runat="server" placeholder="Message" required></asp:TextBox>

        <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" CssClass="error-box mb-1"></asp:Label>


    </form>

</asp:Content>
