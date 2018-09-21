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

  <div style="">

    <form id="EditMessageForm" style="text-align:center;" runat="server" defaultbutton="btnOk">

        <h5>Your message:</h5>

        <asp:TextBox ID="editTitle" CssClass="form-control mb-1"  runat="server" placeholder="Title" required MaxLength="64"></asp:TextBox>

        <asp:TextBox ID="editMessage" CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="Message" required ></asp:TextBox>

        <br/>

        <h5>Send In:</h5>

        <asp:DropDownList ID="ddlSendIn" CssClass="form-control" runat="server">
            <asp:ListItem Value="3">3 hours</asp:ListItem>
            <asp:ListItem Value="12">12 hours</asp:ListItem>
            <asp:ListItem Value="24">1 day</asp:ListItem>
            <asp:ListItem Value="72">3 days</asp:ListItem>
            <asp:ListItem Value="168">1 week</asp:ListItem>
            <asp:ListItem Value="336">2 weeks</asp:ListItem>
            <asp:ListItem Value="672">1 month</asp:ListItem>
            <asp:ListItem Value="2184">3 months</asp:ListItem>
        </asp:DropDownList>

        <br/>

        <h5>Send To:</h5>
            
        <table id="RecipientList" style="width:100%; line-height:18px;" class="mt-3">
            <asp:Repeater ID="rptRecipientList" runat="server">
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
                            <img class="cursor-pointer mr-1" src="img/remove25x25.png"/>
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
                    <img class="cursor-pointer mt-2 mr-1" src="img/add25x25.png"/>
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

        <asp:Button ID="btnOk" CssClass="btn btn-lg plt-1 pltbg-3 btn-block btn-shdw mb-3" runat="server" Text="OK" OnClick="btnOk_Click" />
 
        <asp:Button ID="btnCancel" CssClass="btn btn-lg plt-1 pltbg-3 btn-block btn-shdw mb-3" runat="server" Text="Cancel" OnClick="btnCancel_Click" UseSubmitBehavior="False" />

    </form>

  </div>

</asp:Content>
