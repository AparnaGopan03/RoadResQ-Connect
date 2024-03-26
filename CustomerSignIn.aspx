<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerSignIn.aspx.vb" Inherits="roadresqconnect.CustomerSignIn" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Customer Login</title>
     <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
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
            width: 913px;
            
            max-width: 1500px;
        }

        .form-container {
            flex: 1;
            padding: 30px;
            text-align: center;
            width: 497px;
            height: 299px;
        }

        .customer-container {
            flex: 1;
            background: url('https://img.freepik.com/free-vector/girl-taking-photo-damaged-car-flat-illustration_74855-18748.jpg?size=626&ext=jpg&ga=GA1.1.849587236.1658678723&semt=ais') center/cover no-repeat;
        }

        h2 {
            color: #333;
            height: 36px;
            width: 641px;
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
                <h2>Customer Login</h2>
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="true"></asp:Label>
                <br />
                <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="showSweetAlert(); return false;">Forget Password/Username?</asp:LinkButton>
            </div>
            <div class="customer-container"></div>
        </div>
    </form>

     <script>
         function showSweetAlert() {
             // Show a SweetAlert confirmation dialog
             Swal.fire({
                 title: 'Password Recovery',
                 text: 'Do you want to change your password or username?',
                 showDenyButton: true,
                 confirmButtonText: 'Change Password',
                 denyButtonText: 'Change Username',
             }).then((result) => {
                 if (result.isConfirmed) {
                     // If user clicks "Change Password", redirect to the password change page
                     window.location.href = 'CustomerPassword.aspx';
         } else if (result.isDenied) {
             // If user clicks "Change Username", redirect to the username change page
             window.location.href = 'CustomerUsername.aspx';
         }
         });
         }
    </script>
</body>
</html>
