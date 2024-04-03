<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerChatInterface.aspx.vb" Inherits="roadresqconnect.CustomerChatInterface" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Customer Chat Interface</title>
    <style>
        /* Style for the chat area */
        #chatArea {
            width: 100%; /* Set width to 100% */
            height: 500px; /* Increased height to accommodate more messages */
            border: 1px solid #ddd; /* Adjusted border color */
            overflow-y: scroll;
            margin-bottom: 10px;
            background-color: #f5f5f5; /* Changed background color to match WhatsApp */
            padding: 10px; /* Added padding for better readability */
            border-radius: 5px; /* Added rounded corners */
        }
        
        /* Style for chat messages */
        .message {
            background-color: #e2ffc7; /* Changed background color for messages */
            padding: 5px 10px; /* Added padding */
            margin-bottom: 5px; /* Added margin between messages */
            border-radius: 5px; /* Added rounded corners */
            max-width: 70%; /* Added maximum width for better readability */
            word-wrap: break-word; /* Added word wrap for long messages */
        }
        
        /* Style for user's messages */
        .user-message {
            background-color: #dcf8c6; /* Changed background color for user's messages */
            align-self: flex-end; /* Aligned user's messages to the right */
        }

        /* Style for textbox and button */
        #messageContainer {
            display: flex; /* Used flexbox for better layout */
        }

        #txtMessage {
            flex: 1; /* Made textbox take remaining space */
            border: none; /* Removed border */
            border-radius: 20px; /* Added rounded corners */
            padding: 10px; /* Added padding */
            margin-right: 10px; /* Added margin between textbox and button */
        }

        #btnSend, #Button1 {
            background-color: #128C7E; /* Changed button color to match WhatsApp */
            color: white; /* Changed text color */
            border: none; /* Removed border */
            border-radius: 20px; /* Added rounded corners */
            padding: 10px 20px; /* Added padding */
            cursor: pointer; /* Changed cursor to pointer */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>
                <asp:Button ID="Button1" runat="server" Text="Back" />
            <center>Chat Interface</center></h2>
            <div id="chatArea" runat="server">
                <!-- Chat messages will be displayed here -->
                
                
            </div>
            <div id="messageContainer">
                <!-- Textbox to send messages -->
                <asp:TextBox runat="server" ID="txtMessage" placeholder="Type your message..." TextMode="MultiLine" style="width: 100%;"></asp:TextBox>
                <!-- Button to send messages -->
                <asp:Button runat="server" ID="btnSend" Text="Send" OnClick="btnSend_Click" />
            </div>
        </div>
    </form>
</body>
</html>
