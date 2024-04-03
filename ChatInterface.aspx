<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ChatInterface.aspx.vb" Inherits="roadresqconnect.ChatInterface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Chat Interface</title>
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
            <asp:Label ID="lblCustomerId" runat="server" Text="Enter Customer ID: "></asp:Label>
            <asp:TextBox ID="txtCustomerId" runat="server"></asp:TextBox>
            <asp:Button ID="btnStartChat" runat="server" Text="Start Chat" OnClick="btnStartChat_Click" />
            <br />
            <div id="chatArea" runat="server">
                <!-- Chat messages will be displayed here -->
            </div>
            <asp:Panel ID="pnlChatInterface" runat="server" Visible="False">
                <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox>
                <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
                <br />
                <asp:Label ID="lblChat" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </div>
    </form>
</body>
</html>

