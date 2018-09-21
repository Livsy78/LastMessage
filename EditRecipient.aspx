<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRecipient.aspx.cs" Inherits="LastMessage.EditRecipient" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

    <style>
    </style>

    <title>Last Message - Edit Recipient for "TODO"</title>

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

  <div style="">

    <form id="EditRecipientForm" style="text-align:center;" runat="server">

        <h5>Recipient for message &laquo;<span id="MessageTitle"><%= CurrentMessage.Title %></span>&raquo; :</h5>
        <div style="height:15px;"></div>

        <input type="text" id="editName" class="form-control mb-3" placeholder="Name" required autofocus />

        <input type="email" id="editEmail" class="form-control mb-3" placeholder="Email address" required />

        <button type="submit" class="btn btn-lg plt-1 pltbg-3 btn-block btn-shdw mb-3">Ok</button>
 
        <button type="button" class="btn btn-lg plt-1 pltbg-3 btn-block btn-shdw mb-3">Cancel</button>


    </form>

  </div>

</asp:Content>
