<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProviderServiceRequest.aspx.vb" Inherits="roadresqconnect.ProviderServiceRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
        /* Style for GridView */
        #GridViewRequests {
            border-collapse: collapse;
            width: 100%;
        }

        #GridViewRequests th, #GridViewRequests td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        #GridViewRequests th {
            background-color: #FBCEB1; /* Lighter shade */
        }

        #GridViewRequests tr:nth-child(even) {
            background-color:#E5E4E2; /*  shade */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
<asp:GridView ID="GridViewRequests" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewRequests_RowCommand"  DataKeyNames="RequestId">
    <Columns>
        <asp:BoundField DataField="RequestId" HeaderText="Request ID" />
        <asp:BoundField DataField="CustomerId" HeaderText="Customer ID" />
        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
        <asp:BoundField DataField="Customercno" HeaderText="Customer Contact" />
        <asp:BoundField DataField="VehicleType" HeaderText="Vehicle Type" />
        <asp:BoundField DataField="Make" HeaderText="Make" />
        <asp:BoundField DataField="Model" HeaderText="Model" />
        <asp:BoundField DataField="Year" HeaderText="Year" />
        <asp:BoundField DataField="LicensePlateNumber" HeaderText="License Plate" />
        <asp:BoundField DataField="Color" HeaderText="Color" />
        <asp:BoundField DataField="RequestTime" HeaderText="Request Time" />
        <asp:TemplateField HeaderText="Status">
    <ItemTemplate>
        <%# If(Eval("status") IsNot DBNull.Value, Eval("status"), "N/A") %>
    </ItemTemplate>
</asp:TemplateField>

        <asp:ButtonField ButtonType="Button" CommandName="ViewLocation" Text="View Location" />

        <asp:ButtonField ButtonType="Button" CommandName="Accept" Text="Accept" HeaderText="Accept" />
        <asp:ButtonField ButtonType="Button" CommandName="Reject" Text="Reject" HeaderText="Reject" />
    </Columns>
</asp:GridView>



    </div>
    </form>
</body>
</html>
