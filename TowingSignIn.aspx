<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TowingSignIn.aspx.vb" Inherits="roadresqconnect.TowingSignIn" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Towing Login</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .login-container {
            display: flex;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            overflow: hidden;
            width: 700px;
            
            max-width: 1500px;
        }

        .form-container {
            flex: 1;
            padding: 30px;
            text-align: center;
        }

        .provider-container {
            flex: 1;
            background: url('https://th.bing.com/th/id/OIP.TwKrH_R2QIARj_e-GgG5hgHaFL?w=253&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7') center/cover no-repeat;
        }

        h2 {
            color: #333;
        }

        #lblErrorMessage {
            color: red;
            display: block;
            margin-top: 10px;
        }

        input {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        #btnLogin {
            background-color: #ff7f50;
            color: #fff;
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        #btnLogin:hover {
            background-color: #ff4f00;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="form-container">
                <h2>Towing Login</h2>
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="true"></asp:Label>
                <br />
                <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>
            <div class="provider-container"></div>
        </div>
    </form>
</body>
</html>

