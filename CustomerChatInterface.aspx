<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerChatInterface.aspx.vb" Inherits="roadresqconnect.CustomerChatInterface" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Customer Chat Interface</title>
        <style>
        /* Style for the chat area */
        #chatArea {
            width: 300px;
            height: 200px;
            border: 1px solid #ccc;
            overflow-y: scroll;
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Chat Interface</h2>
            <div id="chatArea" runat="server">
                <!-- Chat messages will be displayed here -->
            </div>
            <div>
                <!-- Textbox to send messages -->
                <asp:TextBox runat="server" ID="txtMessage" placeholder="Type your message..." TextMode="MultiLine" style="width: 100%;"></asp:TextBox>
                <!-- Button to send messages -->
                <asp:Button runat="server" ID="btnSend" Text="Send" OnClick="btnSend_Click" />
            </div>
        </div>
    </form>
</body>
</html>

