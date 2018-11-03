<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="LastMessage.Message" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

    <div style="">

        <form id="PasswordForgotForm" style="text-align:center;">

            <br/>

            <h5> <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label> </h5>

            <br/><br/>
        
            <h5> <asp:HyperLink ID="linkContinue" runat="server" CssClass="plt-3" NavigateUrl=".">Click here to continue</asp:HyperLink> </h5>
            
            <br/><br/>

        </form>
    </div>
</asp:Content>