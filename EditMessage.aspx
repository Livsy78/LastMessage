<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMessage.aspx.cs" Inherits="LastMessage.EditMessage" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

    <style>
    </style>

    <title>Last Message - Edit Message "TODO"</title>

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

  <div style="">

    <form id="EditMessageForm" style="text-align:center;" runat="server">

        <h5>Your message</h5>

        <input type="text" id="editTitle" class="form-control mb-1" placeholder="Title" required />

        <textarea id="editMessage" class="form-control" placeholder="Message"></textarea>

        <br/>

        <h5>Send In:</h5>

        <select class="form-control">
            <option>1 day</option>
            <option>7 days</option>
        </select>

        <br/>

        <h5>Send To:</h5>
            
        <table style="width:100%; line-height:18px;" class="mt-3">
            <asp:Repeater ID="rptRecipientList" runat="server">
                 <ItemTemplate>
                    <tr style="border-bottom:solid; border-bottom-color:#b6bbcc; border-bottom-width:1px;">
                        <td>
                            <%# Eval("Name") %>
                        </td>
                        <td style="text-align:left;">
                            <%# Eval("Destinations") %>
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
                    <img class="cursor-pointer mt-2 mr-1" src="img/add25x25.png"/>
                </td>
            </tr>
        </table>


        <br/>
        <h5>Notify me before:</h5>

        <select class="form-control">
            <option>Don't notify</option>
            <option>1 day</option>
            <option>7 days</option>
        </select>

        <br/>

        <button type="submit" class="btn btn-lg plt-1 pltbg-3 btn-block btn-shdw mb-3">Ok</button>
 
        <button type="button" class="btn btn-lg plt-1 pltbg-3 btn-block btn-shdw mb-3">Cancel</button>

    </form>

  </div>

</asp:Content>
