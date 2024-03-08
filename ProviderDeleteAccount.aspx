<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProviderDeleteAccount.aspx.vb" Inherits="roadresqconnect.ProviderDeleteAccount" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Delete Account</title>
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

        form {
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            overflow: hidden;
            width: 300px;
            text-align: center;
            padding: 20px;
        }

        h2 {
            color: #333;
        }

        p {
            margin-bottom: 20px;
        }

        .confirmation-panel {
            display: none;
            margin-top: 20px;
        }

        .confirmation-panel p {
            margin-bottom: 10px;
        }

        label {
            display: block;
            margin-bottom: 5px;
        }

        input {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .btn-group {
            display: flex;
            justify-content: space-between;
        }

        .btn-yes,
        .btn-no,
        .btn-submit {
            background-color: #ff7f50;
            color: #fff;
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            width: 100px;
        }

        .btn-yes:hover,
        .btn-no:hover,
        .btn-submit:hover {
            background-color: #ff4f00;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Delete Account</h2>
        <p>Are you sure you want to delete your account?</p>
        <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click" />
        <asp:Button ID="btnNo" runat="server" Text="No" OnClick="btnNo_Click" />
        <asp:Panel ID="pnlConfirmation" runat="server" Visible="false">
            <p>Enter your username and password to confirm:</p>
            <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </asp:Panel>
    </form>
</body>
</html>
