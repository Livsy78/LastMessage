<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LastMessage.Home" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

    <script src="js/FormatTime.js" type="text/javascript"></script>

    <style>
        #MessageList td
        {
            padding:5px 2px 7px 2px;
        }

    </style>

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

  <div style="">

    <form id="ResetForm" style="text-align:center;" runat="server">

        <!--  <button type="submit" class="btn btn-lg plt-1 pltbg-3 btn-block btn-shdw pt-3 pb-3 mb-3">I'm OK<br/>Reset all timers</button>  -->
        <asp:ImageButton ID="btnResetTimers" runat="server" ImageUrl="img/ResetButton.png" CssClass="btn btn-lg plt-1 pltbg-3 btn-shdw pt-3 pb-3 mb-3" OnClick="btnResetTimers_Click" />		
        

        <h5>There will be send</h5>

        <table id="MessageList" style="width:100%; line-height:18px;" class="mt-3">
            
            <tr id="MessageTemplate" style="border-bottom:solid; border-bottom-color:#b6bbcc; border-bottom-width:1px;  display:none;">
                <td class="Message_Title" style="width:25%;">
                    Title
                </td>
                <td>
                   <b>TO:</b>
                </td>
                <td class="Message_Recipients" style="width:25%;">
                    Recipient1, 
                    <br/>
                    Recipient123,
                    <br/>
                    Recipient3
                </td>
                <td>
                   <b>IN:</b>
                </td>
                <td class="Message_Timer" style="width:25%;">
                    2m 23d 14:53:18
                </td>
                <td style="width:25px;">
                    <img class="cursor-pointer mr-1" src="img/remove25x25.png"/>
                </td>
            </tr>

            <tr id="MessageList_LastRow">
                <td style="width:25%;">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="line-height:18px; width:25%;">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="width:25%;">
                    &nbsp;
                </td>
                <td style="width:25px;">
                    <img class="cursor-pointer mr-1" src="img/add25x25.png"/>
                </td>
            </tr>
            
        </table>

        <script>
            window.onload = function()
            {
                GetAndUpdateMessageList();
            }

            function GetAndUpdateMessageList()
            {
                var input =
                {
                    UserID : <%= CurrentUserID %>,
                };

                // TODO: wait screen
                    
                $.post("WebServices/GetMessageList.aspx", JSON.stringify(input), "json")
                .done(function(output) 
                {
                    /*DBG*/ console.log(output);

                    if(output.Status=="OK")
                    {
                        UpdateMessageList(output);
                        setInterval(OnTimer, 1000, output);
                    }
                    else
                    {
                        // TODO: catch error
                        console.log(output);
                    }
                })
                .fail(function(output) 
                {
                    // TODO: catch error
                    console.log(output);
                })
                ;

            }

            function UpdateMessageList(data)
            {
                for(var msgIdx=0; msgIdx<data.TotalItems; msgIdx++)
                {
                    var msg = data.Items[msgIdx];
                    /*DBG*/ console.log(msg);

                    var messageElem = $("#MessageTemplate")
                            .clone()
                            .attr("id", "Message" + msg.MessageID)
                            .insertBefore("#MessageList_LastRow");

                    messageElem.find(".Message_Title")
                        .html(msg.Title);

                    messageElem.find(".Message_Recipients")
                        .html(msg.Recipients.replace(",", ",<br/>"));

                    messageElem.find(".Message_Timer")
                        .html(FormatTime(msg.SendIn_Seconds));

                    messageElem.show();
                }
            }

            function OnTimer(data)
            {
                for(var msgIdx=0; msgIdx<data.TotalItems; msgIdx++)
                {
                    var msg = data.Items[msgIdx];
                    if(msg.Status != "ACTIVE")
                    {
                        continue;
                    }

                    var messageElem = $("#Message" + msg.MessageID);

                    msg.SendIn_Seconds--;

                    messageElem.find(".Message_Timer")
                        .html(FormatTime(msg.SendIn_Seconds));
                }
                
            }

        </script>
    </form>


  </div>

</asp:Content>
