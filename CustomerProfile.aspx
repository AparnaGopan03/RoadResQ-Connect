﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerProfile.aspx.vb" Inherits="roadresqconnect.CustomerProfile" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Profile</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f5f5f5;
        }

        .container {
            display: flex;
            min-height: 100vh;
        }

        .sidebar {
            background-color: #333;
            width: 250px;
            padding-top: 20px;
            transition: width 0.3s ease; 
        }

        .sidebar.active {
            width: 0;
        }

        .sidebar a {
            padding: 10px 15px;
            text-decoration: none;
            font-size: 18px;
            color: #f1f1f1;
            display: block;
            transition: background-color 0.3s ease;
        }

        .sidebar a:hover {
            background-color: #555;
        }

        .hamburger {
            position: fixed;
            top: 20px;
            left: 20px;
            cursor: pointer;
            z-index: 999; 
            color: #ff7f50; 
            padding: 10px;
        }

        .hamburger span {
            display: block;
            width: 30px;
            height: 5px;
            background: #ff7f50;
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
            color: #333;
        }

        .content img {
            width: 150px;
            height: auto;
            margin: 20px auto;
            display: block;
        }

        .content label {
            font-weight: bold;
            color: #555;
            margin-bottom: 5px;
            display: block;
        }

        .profile-info {
            margin-bottom: 15px;
            display: inline-block;
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
                <a href="CustomerServiceRequest.aspx">&nbsp;&nbsp;&nbsp;&nbsp;Service Request</a>
                <a href="CustomerComplaint.aspx">&nbsp;&nbsp;&nbsp;&nbsp;Complaint</a>
                <a href="CustomerHistory.aspx">&nbsp;&nbsp;&nbsp;&nbsp;History</a>
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
                    
                    <label style="display: inline-block; width: 200px;">Email:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <div class="profile-info">
                     <label style="display: inline-block; width: 200px;">Username:</label>
                    <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <div class="profile-info">
                   <label style="display: inline-block; width: 200px;">Name:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <div class="profile-info">
                    <label style="display: inline-block; width: 200px;">Date of Birth:</label>&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblDOB" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <div class="profile-info">
                   <label style="display: inline-block; width: 200px;">Gender:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <div class="profile-info">
                    <label style="display: inline-block; width: 200px;">Address:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <div class="profile-info">
                    <label style="display: inline-block; width: 200px;">Contact Number:</label>
                    <asp:Label ID="lblContactNumber" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <br />
                

                <div class="profile-info">
                    <br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update Profile" OnClientClick="return confirm('Are you sure you want to update your profile?');" OnClick="btnUpdate_Click" BackColor="Coral" ForeColor="Black" Height="50px" Width="150px" />
</div>
            </div>
        </div>

        <script>
            function toggleSidebar() {
                var sidebar = document.getElementById('sidebar');
                sidebar.classList.toggle('active');
            }
        </script>

         

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>


