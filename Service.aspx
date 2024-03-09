<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Service.aspx.vb" Inherits="roadresqconnect.Service" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Service</title>
    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            background: linear-gradient(45deg, #ff7f50, white);
            font-family: Arial, sans-serif;
        }
        #container {
            display: flex;
            justify-content: center;
            align-items: center;
            text-align: center;
        }
        .heading {
            font-size: 36px;
            margin-bottom: 30px;
            color: white;
            text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.3);
        }
        .card-container {
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .card {
            margin: 20px;
            padding: 20px;
            border-radius: 15px;
            transition: transform 0.3s ease;
            width: 250px; /* Adjust card width */
            height: 350px; /* Adjust card height */
            background: white;
            border: 1px solid #ccc;
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.1);
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
        }
        .card:hover {
            transform: translateY(-5px);
        }
        .card img {
            width: 250px; /* Adjust image size */
            height: 190px; /* Adjust image size */
            border-radius: 50%;
            margin-bottom: 20px;
        }
        .card h3 {
            font-size: 20px;
            color: #333;
            margin: 0;
        }
        .card a {
            text-decoration: none;
            color: #333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <div class="heading">Choose your role</div>
        </div>
        <div class="card-container">
            <div class="card">
                <asp:LinkButton ID="CustomerButton" runat="server" OnClick="CustomerButton_Click">
                    <img src="https://th.bing.com/th/id/OIP.Bie3bpyk8pXyLPeYQvGLIAHaEl?w=298&h=184&c=7&r=0&o=5&dpr=1.3&pid=1.7" alt="Customer" />
                    <h3><center>Roadside Assistance</center></h3>
                </asp:LinkButton>
            </div>
            <div class="card">
                <asp:LinkButton ID="ProviderButton" runat="server" OnClick="ProviderButton_Click">
                    <img src="https://th.bing.com/th/id/OIP.HITy4U2gni5aQA_zfJM9pwHaFN?w=262&h=184&c=7&r=0&o=5&dpr=1.3&pid=1.7" alt="Provider" />
                    <h3><center>Car Towing</center></h3>
                </asp:LinkButton>
            </div>
           
        </div>
    </form>
</body>
</html>

