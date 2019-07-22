<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestEmail.aspx.cs" Inherits="LastMessage.TestEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        From: <asp:TextBox ID="editFrom" runat="server">noreply@lastmessage.in</asp:TextBox>
        <br/>
        To: <asp:TextBox ID="editTo" runat="server">albirukov@gmail.com</asp:TextBox>
        <br/>
        Subj: <asp:TextBox ID="editSubject" runat="server">test</asp:TextBox>
        <br/>
        Body: <asp:TextBox ID="editBody" runat="server" TextMode="MultiLine">this is test</asp:TextBox>
        <br/>
        is HTML: <asp:CheckBox ID="isHtml" runat="server" />
        <br/>
        <asp:Button ID="btnSend" runat="server" Text="SEND" OnClick="btnSend_Click" Width="100px" />
        <hr/>
        login: <asp:TextBox ID="editLogin" runat="server"></asp:TextBox>
        <br/>
        password: <asp:TextBox ID="editPassword" runat="server"></asp:TextBox>
        <br/>
        server: <asp:TextBox ID="editServer" runat="server"></asp:TextBox>
        <br/>
        port: <asp:TextBox ID="editPort" runat="server" TextMode="Number">25</asp:TextBox>
        <br/>
        default credentials: <asp:CheckBox ID="isDefaultCredentials" runat="server" />
        <br/>
        SSL: <asp:CheckBox ID="isSsl" runat="server" />
        <br/>
        delivery method: <asp:DropDownList ID="editDeliveryMethod" runat="server">
            <asp:ListItem>Network</asp:ListItem>
            <asp:ListItem>PickupDirectoryFromIis</asp:ListItem>
            <asp:ListItem Enabled="False">SpecifiedPickupDirectory</asp:ListItem>
        </asp:DropDownList> 
        <br/>
    
    </div>
    </form>
</body>
</html>
