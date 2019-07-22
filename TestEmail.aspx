<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestEmail.aspx.cs" Inherits="LastMessage.TestEmail" %>

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
        <asp:Button ID="btnSend" runat="server" Text="SEND" />
        <hr/>
        login: 
        password: 
        server: 
        port: 
        ssl: 

    
    </div>
    </form>
</body>
</html>
