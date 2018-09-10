<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LastMessage.Home" MasterPageFile="HeaderFooter.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">

    <script src="js/FormatTime.js" type="text/javascript"></script>

    <style>
        #MessageList td
        {
            padding:5px 1px 7px 1px;
        }
    </style>

</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

  <div style="">

    <form id="ResetForm" style="text-align:center;" onsubmit="ResetForm_OnSubmit(); return false;">

        <button type="submit" class="btn btn-lg plt-1 pltbg-3 btn-block btn-shdw pt-3 pb-3 mb-3">I'm OK<br/>Reset all timers</button>

        <h5>There will be send</h5>

        <table id="MessageList" style="width:100%; line-height:18px;" class="mt-3">
            
            <tr id="MessageTemplate" style="border-bottom:solid; border-bottom-color:#b6bbcc; border-bottom-width:1px;  display:none;">
                <td class="Message_Title" style="width:20%;">
                    Title
                </td>
                <td>
                    <i>to</i>
                </td>
                <td class="Message_Recipients" style=" width:20%;">
                    Recipient1, 
                    <br/>
                    Recipient123,
                    <br/>
                    Recipient3
                </td>
                <td>
                    <i>in</i>
                </td>
                <td class="Message_Timer" style="width:40%;">
                    2m 23d 14:53:18
                </td>
                <td>
                    <img class="btn" src="img/remove25x25.png"/>
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
                <td>
                    <img class="btn" src="img/add25x25.png"/>
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

            function ResetForm_OnSubmit()
            {

            }
        </script>
    </form>


  </div>

</asp:Content>
