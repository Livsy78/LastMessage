<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMessage.aspx.cs" Inherits="LastMessage.EditMessage" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

    <style>
        #RecipientList td
        {
            padding:5px 2px 7px 2px;
        }
    </style>

    <title>Last Message - Edit Message "TODO"</title>

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

    <form id="EditMessageForm" style="text-align:center;" runat="server" defaultbutton="btnSave">

        <div class="mywidth-inner" style="position:fixed; top:32px;">
            <input id="btnBack" type="button" value="&nbsp;&nbsp;&nbsp;Back" class="btn plt-1 pltbg-3 btn-shdw btn-back" onclick="window.location.href='Home.aspx';" />
            <asp:Button ID="btnSave" runat="server" Text="&nbsp;&nbsp;&nbsp;Save" CssClass="btn plt-1 pltbg-3 btn-shdw btn-save" OnClick="btnSave_Click"/>
        </div>
        <div style=""> </div>


        <h5>Message:</h5>

        <asp:TextBox ID="editTitle" CssClass="form-control mb-1"  runat="server" placeholder="Title" MaxLength="64" required></asp:TextBox>

        <asp:TextBox ID="editMessage" CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="Message" required></asp:TextBox>

        <br/>

        <h5>Send In:</h5>

        <asp:DropDownList ID="ddlSendIn" CssClass="form-control" runat="server">
            <asp:ListItem Value="3">    3 hours  </asp:ListItem>
            <asp:ListItem Value="12">   12 hours </asp:ListItem>
            <asp:ListItem Value="24">   1 day    </asp:ListItem>
            <asp:ListItem Value="72">   3 days   </asp:ListItem>
            <asp:ListItem Value="168">  1 week   </asp:ListItem>
            <asp:ListItem Value="336">  2 weeks  </asp:ListItem>
            <asp:ListItem Value="720">  1 month  </asp:ListItem>
            <asp:ListItem Value="2184"> 3 months </asp:ListItem>
        </asp:DropDownList>

        <br/>

        <h5>Send To:</h5>
            
        <table id="RecipientList" style="width:100%; line-height:18px;" class="mt-3">
            <asp:Repeater ID="rptRecipientList" runat="server" OnItemCommand="rptRecipientList_ItemCommand">
                 <ItemTemplate>
                    <tr style="border-bottom:solid; border-bottom-color:#b6bbcc; border-bottom-width:1px;">
                        <td>
                            <a href="EditRecipient.aspx?ID=<%# Eval("RecipientID") %>" class="plt-3">
                                <%# Eval("Name") %>
                            </a>
                        </td>
                        <td style="text-align:left;">
                            <%# Eval("Destinations") %>
                        </td>
                        <td style="width:25px;">
                            <a href="EditRecipient.aspx?ID=<%# Eval("RecipientID") %>">
                                <img class="cursor-pointer mr-1" src="img/edit25x25.png"/>
                            </a>
                        </td>
                        <td style="width:25px;">
                            <asp:ImageButton ID="btnDeleteRecipient" runat="server"  
                                ImageUrl="~/img/delete25x25.png" 
                                CommandName="delete" 
                                CommandArgument='<%# Eval("RecipientID") %>' 
                                OnClientClick="javascript: return confirm('Are you sure you want to delete this recipient?');"
                            />

                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <a href="EditRecipient.aspx?ID=-1&MessageID=<%= CurrentMessageID %>">
                        <img class="cursor-pointer mt-2 mr-1" src="img/add25x25.png"/>
                    </a>
                </td>
            </tr>
        </table>


        <br/>
        <h5>Notify me before:</h5>

        <asp:DropDownList ID="ddlNotifyBefore" CssClass="form-control" runat="server">
            <asp:ListItem Value="0">Don't notify</asp:ListItem>
            <asp:ListItem Value="1">1 hour</asp:ListItem>
            <asp:ListItem Value="3">3 hours</asp:ListItem>
            <asp:ListItem Value="12">12 hours</asp:ListItem>
            <asp:ListItem Value="24">1 day</asp:ListItem>
            <asp:ListItem Value="72">3 days</asp:ListItem>
            <asp:ListItem Value="168">1 week</asp:ListItem>
        </asp:DropDownList>

        <br/>

    </form>

</asp:Content>
