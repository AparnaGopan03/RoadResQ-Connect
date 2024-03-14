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
        <asp:BoundField DataField="MechanicName" HeaderText="Mechanic Name" />
       
    </Columns>
</asp:GridView>

    </div>
    </form>
</body>
</html>
