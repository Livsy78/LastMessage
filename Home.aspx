<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LastMessage.Home" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

  <div style="">

    Welcome <%= CurrentUserEmail %>
    <br/>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

  </div>

</asp:Content>
