<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LastMessage.Home" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

  <div style="">

    <form id="ResetForm" style="text-align:center;" onsubmit="ResetForm_OnSubmit(); return false;">

        <button type="submit" class="btn btn-lg plt-1 pltbg-3 btn-block pt-3 pb-3 mb-3" style="box-shadow: 3px 3px 3px rgba(0,0,0,0.5);">I'm OK<br/>Reset all timers</button>


        Welcome <%= CurrentUserEmail %>
        <br/>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>


        <script>
            ResetForm_OnSubmit()
            {
                
            }
        </script>
    </form>
  </div>

</asp:Content>
