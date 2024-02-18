﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SignIn.aspx.vb" Inherits="roadresqconnect.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sign In</title>
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
                    <img src="https://media.istockphoto.com/id/1341515868/vector/car-breakdown.jpg?s=612x612&w=0&k=20&c=t-uOTEjLeVeDxIYeyMyZfwL8HO-xDOVjc94lwMaDDjo=" alt="Customer" />
                    <h3><center>Customer</center></h3>
                </asp:LinkButton>
            </div>
            <div class="card">
                <asp:LinkButton ID="ProviderButton" runat="server" OnClick="ProviderButton_Click">
                    <img src="https://media.istockphoto.com/id/1255905616/vector/car-repair-semi-flat-rgb-color-vector-illustration.jpg?s=612x612&w=0&k=20&c=VBNmg2XRokMtTnvB2HOLnJpUQVbB1UWh24qVS_wyxkc=" alt="Provider" />
                    <h3><center>Service Provider</center></h3>
                </asp:LinkButton>
            </div>
            <div class="card">
                <asp:LinkButton ID="AdminButton" runat="server" OnClick="AdminButton_Click">
                    <img src="https://media.istockphoto.com/id/1289417766/vector/monitor-display-with-yellow-folders-documents-and-media-content-office-clerks-or-employees.jpg?s=612x612&w=0&k=20&c=UrrNhI-pU4u688m1PIGe9WNCrSsxOHyAWrUJjRNZpGM=" alt="Admin" />
                    <h3><center>Admin</center></h3>
                </asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
