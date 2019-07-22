<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="LastMessage.TestPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Subj: <asp:TextBox ID="editSubj" runat="server">test</asp:TextBox>
        <br/>
        Body: <asp:TextBox ID="editBody" runat="server">this is test</asp:TextBox>
        <br/>
        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
        <br/>
        <asp:Button ID="btnSend" runat="server" Text="SEND" OnClick="btnSend_Click" Width="100px" />
    </div>
    </form>
</body>
</html>
