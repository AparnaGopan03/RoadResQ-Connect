<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerProfile.aspx.vb" Inherits="roadresqconnect.CustomerProfile" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Profile</title>
 <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f8f9fa;
            color: #333;
        }

        .container {
            display: flex;
            min-height: 100vh;
        }

        .sidebar {
            background: linear-gradient(to right, #ff7f50, #ffcc5c);
            width: 250px;
            padding-top: 20px;
            transition: width 0.3s ease;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
            border-top-right-radius: 30px;
            border-bottom-right-radius: 30px;
        }

        .sidebar.active {
            width: 0;
        }

        .sidebar a {
            padding: 15px;
            text-decoration: none;
            font-size: 18px;
            color: #fff;
            display: block;
            transition: background-color 0.3s ease;
            border-bottom: 1px solid rgba(255, 255, 255, 0.1);
        }

        .sidebar a:hover {
            background-color: rgba(255, 255, 255, 0.1);
        }

        .hamburger {
            position: fixed;
            top: 20px;
            left: 20px;
            cursor: pointer;
            z-index: 999;
            color: #fff;
            padding: 10px;
            border-radius: 5px;
            background-color: rgba(0, 0, 0, 0.5);
        }

        .hamburger span {
            display: block;
            width: 30px;
            height: 5px;
            background: #fff;
            margin: 5px 0;
            transition: 0.4s;
        }

        .hamburger.active span:nth-child(1) {
            transform: rotate(-45deg) translate(-9px, 6px);
        }

        .hamburger.active span:nth-child(2) {
            opacity: 0;
        }

        .hamburger.active span:nth-child(3) {
            transform: rotate(45deg) translate(-8px, -8px);
        }

        .content {
            flex: 1;
            padding: 20px;
            text-align: center;
        }

        .content h2 {
            color: #ff7f50;
            font-size: 28px;
            margin-bottom: 20px;
        }

        .content img {
            width: 150px;
            height: 150px;
            border-radius: 50%;
            margin: 20px auto;
            display: block;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
        }

        .profile-info {
            margin-bottom: 15px;
            text-align: left;
        }

        .profile-info label {
            display: inline-block;
            width: 150px;
            font-weight: bold;
            color: #555;
            margin-bottom: 5px;
        }

        .profile-info span {
            display: inline-block;
            color: #777;
        }

        @media (max-width: 768px) {
            .container {
                flex-direction: column;
            }

            .sidebar.active {
                width: 100%;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="sidebar" id="sidebar">
                <br />
                <br />
                <br />
                <a href="CustomerProfile.aspx">&nbsp;&nbsp;&nbsp;&nbsp;Profile</a>
                <a href="CustomerServiceRequest.aspx">&nbsp;&nbsp;&nbsp;&nbsp;Request for a Service</a>
                <a href="CustomerServiceSearch.aspx">&nbsp;&nbsp;&nbsp;&nbsp;Search by Service Area</a>
                <a href="CustomerHistory.aspx">&nbsp;&nbsp;&nbsp;&nbsp;Service Requests</a>
                <a href="CustomerComplaint.aspx">&nbsp;&nbsp;&nbsp;&nbsp;Register a Complaint</a>

                <a href="CustomerPaymentHistory.aspx">&nbsp;&nbsp;&nbsp;&nbsp;Payment History</a>
                <a href="CustomerComplaintHistory.aspx">&nbsp;&nbsp;&nbsp;&nbsp;Complaint History</a>
                <a href="CustomerDeleteAccount.aspx">&nbsp;&nbsp;&nbsp;&nbsp;Delete Account</a>
                <a href="Logout.aspx">&nbsp;&nbsp;&nbsp;&nbsp;Logout</a>
            </div>

            <div class="content">
                <div class="hamburger" onclick="toggleSidebar()">
                    <span></span>
                    <span></span>
                    <span></span>
                </div>

                <h2>Profile</h2>
                <img src="https://www.business2community.com/wp-content/uploads/2014/08/My_profile-orange-300x300.png" alt="Profile Image">
                
                <div class="profile-info">
                    <label>Email:</label>
                    <span><asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></span>
                </div>
                <div class="profile-info">
                    <label>Username:</label>
                    <span><asp:Label ID="lblUsername" runat="server" Text=""></asp:Label></span>
                </div>
                <div class="profile-info">
                    <label>Name:</label>
                    <span><asp:Label ID="lblName" runat="server" Text=""></asp:Label></span>
                </div>
                <div class="profile-info">
                    <label>Date of Birth:</label>
                    <span><asp:Label ID="lblDOB" runat="server" Text=""></asp:Label></span>
                </div>
                <div class="profile-info">
                    <label>Gender:</label>
                    <span><asp:Label ID="lblGender" runat="server" Text=""></asp:Label></span>
                </div>
                <div class="profile-info">
                    <label>Address:</label>
                    <span><asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></span>
                </div>
                <div class="profile-info">
                    <label>Contact Number:</label>
                    <span><asp:Label ID="lblContactNumber" runat="server" Text=""></asp:Label></span>
                </div>

                <br />
                
            </div>
        </div>

        <script>
            function toggleSidebar() {
                var sidebar = document.getElementById('sidebar');
                sidebar.classList.toggle('active');
            }
        </script>
    </form>
</body>
</html>






