<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerHistory.aspx.vb" Inherits="roadresqconnect.CustomerHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:GridView ID="GridViewHistory" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridViewHistory_RowDataBound">
    <Columns>
        <asp:BoundField DataField="RequestId" HeaderText="Request ID" />
        <asp:BoundField DataField="Status" HeaderText="Status" />
        <asp:BoundField DataField="VehicleType" HeaderText="Vehicle Type" />
        <asp:BoundField DataField="Make" HeaderText="Make" />
        <asp:BoundField DataField="Model" HeaderText="Model" />
        <asp:BoundField DataField="Year" HeaderText="Year" />
        <asp:BoundField DataField="LicensePlateNumber" HeaderText="LicensePlate Number" />
        
        <asp:BoundField DataField="RequestTime" HeaderText="Request Time" />
        <asp:BoundField DataField="AssistanceType" HeaderText="Assistance Type" />
        <asp:BoundField DataField="ProviderID" HeaderText="Provider ID" />
        <asp:BoundField DataField="MechanicName" HeaderText="Provider Name" />
       <asp:BoundField DataField="Contactno" HeaderText="Contact Number" />
    </Columns>
</asp:GridView>

    </div>
    </form>
</body>
</html>
