<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerComplaintHistory.aspx.vb" Inherits="roadresqconnect.CustomerComplaintHistory" %>

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
            <h2><center>Complaint History</center></h2>
            <asp:GridView ID="GridViewComplaints" runat="server" CssClass="payment-grid" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ProviderId" HeaderText="Provider ID" />
                    <asp:BoundField DataField="Complaintdetails" HeaderText="Complaint Details" />
                    
                    <asp:BoundField DataField="Complaintstatus" HeaderText="Complaint Status" />
                    <asp:BoundField DataField="Complainttime" HeaderText="Complaint Time" />
                    <asp:BoundField DataField="Complaintrestime" HeaderText="Complaint Resolved Time" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>