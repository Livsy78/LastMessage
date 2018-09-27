<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRecipient.aspx.cs" Inherits="LastMessage.EditRecipient" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

    <style>
    </style>

    <title>Last Message - Edit Recipient for "TODO"</title>

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

  <div style="">

    <form id="EditRecipientForm" style="text-align:center;" runat="server" defaultbutton="btnSave" defaultfocus="editName">

        <div class="mywidth-inner" style="position:fixed; top:32px;">
            <input id="btnBack" type="button" value="&nbsp;&nbsp;&nbsp;Back" class="btn plt-1 pltbg-3 btn-shdw btn-back" onclick="window.location.href='EditMessage.aspx?ID=<%= CurrentMessageID %>';" />
            <asp:Button ID="btnSave" runat="server" Text="&nbsp;&nbsp;&nbsp;Save" CssClass="btn plt-1 pltbg-3 btn-shdw btn-save" OnClick="btnSave_Click"/>
        </div>


        <h5>Recipient for <br/> &laquo;<span id="MessageTitle"><%= CurrentMessage.Title %></span>&raquo; :</h5>
        <div style="height:15px;"></div>

        <asp:TextBox ID="editName" runat="server" CssClass="form-control mb-3" placeholder="Name" required autofocus></asp:TextBox>

        <asp:TextBox ID="editEmail" TextMode="Email" runat="server" CssClass="form-control mb-3"  placeholder="Email address" required ></asp:TextBox>

    </form>

  </div>

</asp:Content>
