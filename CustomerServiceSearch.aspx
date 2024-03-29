﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerServiceSearch.aspx.vb" Inherits="roadresqconnect.CustomerServiceSearch" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Search by Service</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f2f2f2;
        }

        .container {
            width: 80%;
            margin: 0 auto; /* Center align the container */
            overflow: hidden;
        }

        h2 {
            text-align: center;
            margin-top: 20px;
            margin-bottom: 30px;
            color: #333;
        }

        .search-form {
            background-color: #f9f9f9;
            border-radius: 5px;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
            color: #333;
        }

        input[type="text"], select, input[type="submit"] {
            width: calc(100% - 10px);
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        input[type="text"] {
            width: calc(100% - 30px);
        }

        input[type="submit"] {
            background-color: #FF8066;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        input[type="submit"]:hover {
            background-color: #FF8066;
        }

        .mechanic-card {
            background-color: #fff;
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
            transition: 0.3s;
            width: calc(50% - 20px);
            margin: 10px auto; /* Center align the cards */
            float: left;
            border-radius: 5px;
            overflow: hidden;
            border: 2px solid #FF8066;
            position: relative;
            height: 300px;
        }

        .mechanic-card:before {
            content: "";
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: linear-gradient(to bottom, rgba(255, 255, 255, 0.3), rgba(255, 255, 255, 0.1));
            z-index: 1;
            pointer-events: none;
        }

        .mechanic-card:hover:before {
            background: linear-gradient(to bottom, rgba(255, 255, 255, 0.1), rgba(255, 255, 255, 0));
        }

        .mechanic-card:hover {
            box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2);
        }

        .mechanic-info {
            padding: 20px;
            position: relative;
            z-index: 2;
        }

        .mechanic-info h3 {
            margin-top: 0;
            color: #FF8066;
        }

        .mechanic-info p {
            color: #333;
        }

        /* Clear floats after two cards */
        .clear {
            clear: both;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Search by Service</h2>
            <div class="search-form">
                <label for="txtSearch">Search by Service Area:</label>
                <input type="text" id="txtSearch" runat="server" />
                <label for="ddlAssistanceType">Filter by Assistance Type:</label>
                <asp:DropDownList ID="ddlAssistanceType" runat="server">
                    <asp:ListItem Text="Roadside Assistance" Value="Roadside Assistance"></asp:ListItem>
                    <asp:ListItem Text="Towing" Value="Towing"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                <br />
                <br />
                 <asp:Button ID="Button1" runat="server" Text="Back To profile" OnClick="btnSearch_Click1" />
            </div>
            <div id="mechanicsContainer" runat="server" class="container">
                <!-- Mechanics' data will be dynamically added in cards here -->
            </div>
            <!-- Clear floats after two cards -->
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>




