<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AdminComplaints.aspx.vb" Inherits="roadresqconnect.AdminComplaints" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Complaints</title>
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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" DataKeyNames="complaintid" CssClass="payment-grid">
                <Columns>
                    <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" />
                    <asp:BoundField DataField="ProviderID" HeaderText="Provider ID" />
                    <asp:BoundField DataField="ComplaintDetails" HeaderText="Complaint Details" />
                    <asp:BoundField DataField="ComplaintStatus" HeaderText="Status" />
                    <asp:BoundField DataField="ComplaintTime" HeaderText="Complaint Time" />
                    <asp:BoundField DataField="ComplaintResTime" HeaderText="Complaint Resolved Time" />
                    <asp:ButtonField ButtonType="Button" CommandName="ResolveComplaint" Text="Resolve"  HeaderText="Action"  />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

