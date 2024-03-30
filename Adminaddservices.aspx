<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Adminaddservices.aspx.vb" Inherits="roadresqconnect.Adminaddservices" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add Service</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f8f8;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 500px;
            margin: 50px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            color: coral;
            text-align: center;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
            color: coral;
            font-weight: bold;
        }

        .form-group input[type="text"],
        .form-group textarea {
            width: calc(100% - 12px); /* Adjust for padding and border */
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .form-group textarea {
            height: 100px;
            resize: vertical;
        }

        .btn-container {
            text-align: center;
        }

        .btn {
            padding: 10px 20px;
            background-color: coral;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .btn:hover {
            background-color: #ff6b4a;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Add Service</h2>
            <div class="form-group">
                <label for="txtServiceName">Service Name:</label>
                <asp:TextBox ID="txtServiceName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtBaseCost">Base Cost:</label>
                <asp:TextBox ID="txtBaseCost" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDescription">Description:</label>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtAdditionalCharges">Additional Charges Description:</label>
                <asp:TextBox ID="txtAdditionalCharges" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="btn-container">
                <asp:Button ID="btnAddService" runat="server" Text="Add Service" OnClick="btnAddService_Click" CssClass="btn" />
                <asp:Button ID="Button1" runat="server" Text="Back to Dashboard" OnClick="btnAddService_Click1" CssClass="btn" />
            </div>
        </div>
    </form>
</body>
</html>
