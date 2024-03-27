<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerSignUp.aspx.vb" Inherits="roadresqconnect.CustomerSignUp" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Customer Signup</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #ffffff; /* White background */
        }
        .container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        .left-half {
            background-color: #ff9966 ; 
            padding: 40px;
            border-top-left-radius: 8px;
            border-bottom-left-radius: 8px;
        }
        .right-half {
            background-color: #fafafa; /* Light Gray */
            padding: 40px;
            border-top-right-radius: 8px;
            border-bottom-right-radius: 8px;
        }
        .form-group label {
            font-weight: bold;
            color: #333333; /* Dark text color */
        }
        .form-control {
            width: calc(100% - 20px);
            padding: 10px;
            font-size: 16px;
            border: none;
            border-radius: 5px;
            transition: background-color 0.15s ease-in-out;
            background-color: #ffffff; /* White background */
        }
        .form-control:focus {
            outline: none;
            background-color: #f0f0f0; /* Lighter background color on focus */
        }
        .btn-primary {
            background-color:  #ff9966;
            border-color:  #ff9966;
        }
        .btn-primary:hover {
            background-color:  #ff9966;
            border-color:  #ff9966;
        }
    </style>

    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>
<script>
    function showEmailAlert(message) {
        Swal.fire({
            icon: 'error',
            title: 'Invalid Email Address',
            text: message,
            showConfirmButton: false,
            timer: 2000
        });
    }
</script>

    <script>
        function showContactAlert(message) {
            Swal.fire({
                icon: 'error',
                title: 'Invalid Contact Number',
                text: message,
                showConfirmButton: false,
                timer: 2000
            });
        }
</script>

    <script>
        function showUserAlert(message) {
            Swal.fire({
                icon: 'error',
                title: 'Username Already Exists',
                text: message,
                showConfirmButton: false,
                timer: 2000
            });
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-6 left-half">
                    <h2 class="mb-4">Personal Information</h2>
                    <div class="form-group">
                        <label for="txtName">Name:</label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtDOB">Date of Birth:</label>
                        <asp:TextBox ID="txtDOB" runat="server" placeholder="YYYY-MM-DD" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Gender:</label>
                        <asp:RadioButtonList ID="rblGender" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="form-group">
                        <label for="txtAddress">Address:</label>
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtContactNumber">Contact Number:</label>
                        <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 right-half">
                    <h2 class="mb-4">Account Information</h2>
                    <div class="form-group">
                        <label for="txtEmail">Email:</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtUsername">Username:</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtPassword">Password:</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnSignup" runat="server" Text="Sign Up" CssClass="btn btn-primary btn-block" OnClick="btnSignup_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
