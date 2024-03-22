<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PaymentDetailsPage.aspx.vb" Inherits="roadresqconnect.PaymentDetailsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Payment Details</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f3f3f3;
            margin: 0;
            padding: 0;
        }

        .container {
            background-color: #ffffff;
            padding: 30px;
            border-radius: 10px;
            width: 50%;
            margin: 50px auto;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        h2 {
            color: #FD673A;
            margin-bottom: 20px;
            text-align: center;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-label {
            display: block;
            font-size: 16px;
            color: #333333;
            margin-bottom: 5px;
        }

        .form-control {
            width: calc(100% - 24px);
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
            font-size: 16px;
        }

        .btn-submit {
            background-color: #FD673A;
            color: white;
            padding: 12px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            width: 100%;
            display: inline-block;
            transition: background-color 0.3s;
        }

        .btn-submit:hover {
            background-color: #FF8C61;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Payment Details</h2>
            <div class="form-group">
                <asp:Label ID="LabelService" runat="server" CssClass="form-label" Text="Select Service:"></asp:Label>
                <asp:DropDownList ID="DropDownListService" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListService_SelectedIndexChanged" AppendDataBoundItems="True" CssClass="form-control" onchange="calculateTotalCost()">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="LabelCost" runat="server" CssClass="form-label" Text="Cost:"></asp:Label>
                <asp:TextBox ID="TextBoxCost" runat="server" ReadOnly="true" CssClass="form-control" oninput="calculateTotalCost()"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="LabelExtracost" runat="server" CssClass="form-label" Text="Extra Cost :"></asp:Label>
                <asp:TextBox ID="TextBoxExtracost" runat="server" CssClass="form-control" oninput="calculateTotalCost()"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Labelextradetails" runat="server" CssClass="form-label" Text="Extra Cost Details :"></asp:Label>
                <asp:TextBox ID="TextBoxExtracostDetails" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Labeltotalcost" runat="server" CssClass="form-label" Text="Total Cost :"></asp:Label>
                <asp:TextBox ID="TextBoxtotalcost" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <script type="text/javascript">
                function calculateTotalCost() {
                    var cost = parseFloat(document.getElementById('<%= TextBoxCost.ClientID%>').value) || 0;
                    var extracost = parseFloat(document.getElementById('<%= TextBoxExtracost.ClientID%>').value) || 0;
                    var baseCost = parseFloat(document.getElementById('<%= DropDownListService.ClientID %>').value) || 0;
                    var totalCost = baseCost + extracost ;
        document.getElementById('<%= TextBoxtotalcost.ClientID %>').value = totalCost.toFixed(2);
    }
</script>

            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" CssClass="btn-submit" />
            <br />
            <br />
             <asp:Button ID="Button1" runat="server" Text="Back To profile" OnClick="btnSearch_Click1" />
        </div>
    </form>
</body>
</html>
