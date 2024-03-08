<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProviderProfile.aspx.vb" Inherits="roadresqconnect.ProviderProfile" %>

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

        .profile-info {
            margin-bottom: 15px;
            text-align: left;
        
        }

        .profile-info label {
            display: inline-block;
            width: 200px;
            font-weight: bold;
            color: #555;
            margin-bottom: 5px;
        }

        .profile-info span {
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


    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var latitude = position.coords.latitude;
                var longitude = position.coords.longitude;
                window.location.href = 'ProviderSaveLocation.aspx?permission=true&latitude=' + latitude + '&longitude=' + longitude;
            });
        }
</script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="sidebar" id="sidebar">
                <br />
                <br />
                <br />
                <a href="ProviderProfile.aspx">&nbsp;&nbsp;&nbsp;&nbsp;Profile</a>
                <a href="ProviderLocationAccessConfirmation.aspx" id="saveLocationLink" >&nbsp;&nbsp;&nbsp;&nbsp;Save Location</a>
                <a href="ProviderServiceRequest.aspx">&nbsp;&nbsp;&nbsp;&nbsp;View Requests</a>
                <a href="ProviderHistory.aspx">&nbsp;&nbsp;&nbsp;&nbsp;History</a>
                <a href="ProviderDeleteAccount.aspx">&nbsp;&nbsp;&nbsp;&nbsp;Delete Account</a>
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
                <div class="profile-info">
                    <label>Years of Experience:</label>
                    <span><asp:Label ID="lblExperience" runat="server" Text=""></asp:Label></span>
                </div>
                <div class="profile-info">
                    <label>Service Area:</label>
                    <span><asp:Label ID="lblarea" runat="server" Text=""></asp:Label></span>
                </div>
                <br />
                <div class="profile-info">
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
    </form>
</body>
</html>
