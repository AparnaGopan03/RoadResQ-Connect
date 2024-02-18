<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AdminSignIn.aspx.vb" Inherits="roadresqconnect.AdminSignIn" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admin Login</title>
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

        .car-container {
            flex: 1;
            background: url('https://img.freepik.com/premium-vector/workers-characters-car-production-line-plant-vehicle-manufacture-factory-auto-body-assembly-with-people-manage-automobile-building-process-transport-engineering-cartoon-vector-illustration_87771-15346.jpg?w=2000') center/cover no-repeat;
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
                <h2>Admin Login</h2>
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <br />
                <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>
            <div class="car-container"></div>
        </div>
    </form>
</body>
</html>
