<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerPaymentHistory.aspx.vb" Inherits="roadresqconnect.CustomerPaymentHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Payment History</title>
       <style>
        .payment-grid {
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            margin-top: 20px;
        }

        .payment-grid th,
        .payment-grid td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        .payment-grid th {
            background-color: coral;
            color: white;
        }

        .payment-grid tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .payment-grid tr:hover {
            background-color: #ddd;
        }

        .payment-card {
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 10px;
            margin: 10px;
            background-color: #f9f9f9;
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
            transition: 0.3s;
            width: 200px;
            float: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2><center>Payment History</center></h2>
            <asp:GridView ID="GridViewPayments" runat="server" CssClass="payment-grid" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="RequestId" HeaderText="Request ID" />
                    <asp:BoundField DataField="ServiceName" HeaderText="Service Name" />
                    <asp:BoundField DataField="BaseCost" HeaderText="Base Cost" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="ExtraCost" HeaderText="Extra Cost" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="ExtraCostDetails" HeaderText="Details" />
                    <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" DataFormatString="{0:C}" />
                 <asp:TemplateField HeaderText="Payment Method">
            <ItemTemplate>
                <asp:Label ID="lblPaymentMethod" runat="server" Text="Credit/Debit Card"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Transaction Status">
            <ItemTemplate>
                <asp:Label ID="lblPaymentstatus" runat="server" Text="Success"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>