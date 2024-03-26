<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProviderPassword.aspx.vb" Inherits="roadresqconnect.ProviderPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Password Change</title>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script>
        function showSweetAlert(message, redirectToPage) {
            Swal.fire({
                title: 'Success',
                text: message,
                icon: 'success',
                confirmButtonText: 'OK'
            }).then((result) => {
                if (result.isConfirmed) {
                    if (redirectToPage && redirectToPage.length > 0) {
                        window.location.href = redirectToPage;
                    }
        }
        });
        }
</script>

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

        #form1 {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 300px;
            text-align: center;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }

        .btn-primary {
            background-color: coral; /* Changed button color to coral */
            color: #fff;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
        }

        .btn-primary:hover {
            background-color: #ff7f50; /* Darken coral color on hover */
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Reset Password</h2> 
            <br />
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter your email" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" placeholder="Enter new password" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" placeholder="Confirm new password" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>


