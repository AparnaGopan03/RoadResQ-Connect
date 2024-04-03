<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ChatInterface.aspx.vb" Inherits="roadresqconnect.ChatInterface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Chat Interface</title>
        <style>
        /* General styles */
        body {
            font-family: Arial, sans-serif; /* Use Arial font for consistency */
            margin: 0; /* Remove default margin */
            padding: 0; /* Remove default padding */
            background-color: #f0f0f0; /* Set background color */
        }

        /* Chat area container */
        #chatContainer {
            max-width: 600px; /* Limit chat container width */
            margin: 20px auto; /* Center chat container horizontally */
            background-color: #fff; /* Set background color */
            border-radius: 10px; /* Add border radius */
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); /* Add shadow for depth */
            overflow: hidden; /* Hide overflowing content */
        }

        /* Chat header */
        #chatHeader {
            background-color: #128C7E; /* Set header background color */
            color: #fff; /* Set text color */
            padding: 15px; /* Add padding */
            text-align: center; /* Center text */
            border-bottom: 1px solid #0a665d; /* Add bottom border */
        }

        /* Chat messages area */
        #chatArea {
            max-height: 390px; /* Limit chat area height */
            overflow-y: auto; /* Add vertical scrollbar when needed */
            padding: 10px; /* Add padding */
        }

        /* Chat input area */
        #chatInput {
            display: flex; /* Use flexbox for layout */
            align-items: center; /* Center items vertically */
            padding: 10px; /* Add padding */
        }

        #txtMessage {
            flex: 1; /* Take remaining space */
            border-radius: 20px; /* Add border radius */
            padding: 10px; /* Add padding */
            border: 1px solid #ddd; /* Add border */
            margin-right: 10px; /* Add margin */
        }

        #btnSend {
            background-color: #128C7E; /* Set button background color */
            color: #fff; /* Set text color */
            border: none; /* Remove border */
            border-radius: 20px; /* Add border radius */
            padding: 10px 20px; /* Add padding */
            cursor: pointer; /* Set cursor to pointer */
        }

        #customerInfoContainer {
    display: flex;
    align-items: center;
    padding: 10px;
    background-color: #f0f0f0;
    border-radius: 5px;
    margin-bottom: 10px;
}

#customerInfoContainer label {
    margin-right: 10px;
    color: #555;
}

.whatsapp-input {
    flex: 1;
    padding: 8px;
    border: 1px solid #ddd;
    border-radius: 5px;
}

.whatsapp-button {
    background-color: #128C7E;
    color: #fff;
    border: none;
    border-radius: 5px;
    padding: 8px 15px;
    cursor: pointer;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="customerInfoContainer">
    <asp:Label ID="lblCustomerId" runat="server" Text="Enter Customer ID: "></asp:Label>
    <asp:TextBox ID="txtCustomerId" runat="server" CssClass="whatsapp-input"></asp:TextBox>
    <asp:Button ID="btnStartChat" runat="server" Text="Start Chat" OnClick="btnStartChat_Click" CssClass="whatsapp-button" />
            &nbsp; &nbsp; &nbsp;
    <asp:Button ID="Button1" runat="server" Text="Back" OnClick="btnStartChat_Click1" CssClass="whatsapp-button" />
</div>

            <div id="chatContainer">
            <div id="chatHeader">
                <h2>Chat Interface</h2>
            </div>
            <div id="chatArea" runat="server">
                <!-- Chat messages will be displayed here -->
            </div>
                <div id="chatInput">
            <asp:Panel ID="pnlChatInterface" runat="server" Visible="False">
                <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox>
                <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
                <br />
                <asp:Label ID="lblChat" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </div>
                </div>
    </form>
</body>
</html>

