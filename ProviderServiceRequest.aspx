<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProviderServiceRequest.aspx.vb" Inherits="roadresqconnect.ProviderServiceRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
<asp:GridView ID="GridViewRequests" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewRequests_RowCommand"  DataKeyNames="RequestId">
    <Columns>
        <asp:BoundField DataField="RequestId" HeaderText="Request ID" />
        <asp:BoundField DataField="CustomerId" HeaderText="Customer ID" />
        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
        <asp:BoundField DataField="CustomerEmail" HeaderText="Customer Email" />
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

        <asp:ButtonField ButtonType="Button" CommandName="Accept" Text="Accept" HeaderText="Accept" />
        <asp:ButtonField ButtonType="Button" CommandName="Reject" Text="Reject" HeaderText="Reject" />
    </Columns>
</asp:GridView>



    </div>
    </form>
</body>
</html>
