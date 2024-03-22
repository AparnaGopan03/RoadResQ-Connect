<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PaymentSuccess.aspx.vb" Inherits="roadresqconnect.PaymentSuccess" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Payment Success</title>
    <style>
        /* Add your CSS styles here */
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            margin: 0;
            padding: 0;
        }
        
        .container {
            max-width: 800px;
            margin: 50px auto;
            background-color: #fff;
            border-radius: 10px;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        
        h1 {
            color: coral;
            text-align: center;
        }
        
        .message {
            text-align: center;
            margin-top: 20px;
            font-size: 18px;
            color: #28a745;
        }
        
        .button-container {
            text-align: center;
            margin-top: 30px;
        }
        
        .button {
            background-color: coral;
            color: #fff;
            border: none;
            padding: 10px 20px;
            font-size: 16px;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }
        
        .button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Payment Success</h1>
            <div class="message">
                Your payment was successful!
            </div>
            <div class="button-container">
                <asp:Button ID="btnBackHomee" runat="server" Text="Back to Profile" CssClass="button" OnClick="btnBackHome_Click" />
            </div>
        </div>
    </form>
</body>
</html>
