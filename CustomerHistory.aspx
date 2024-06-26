﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerHistory.aspx.vb" Inherits="roadresqconnect.CustomerHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
        /* Style for GridView */
        #GridViewHistory {
            border-collapse: collapse;
            width: 100%;
        }

        #GridViewHistory th, #GridViewHistory td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        #GridViewHistory th {
            background-color: #FBCEB1; /* Lighter shade */
        }

        #GridViewHistory tr:nth-child(even) {
            background-color:#E5E4E2; /*  shade */
        }
        /* Style for the button */
.top-left-button {
    position: absolute;
    top: 10px;
    left: 10px;
    
}

         #Button2 {
             background-color: #FF8066;
         }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="Button2" runat="server" Text="Back To Profile" />
        <br />
        <br />
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

        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="btnViewPayment" runat="server" Text=" Payment " CommandName="ViewPaymentDetails" CommandArgument='<%# Container.DataItemIndex %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Communicate">
            <ItemTemplate>
        <asp:Button ID="btnChat" runat="server" Text="Chat" CommandName="Chat" CommandArgument='<%# Container.DataItemIndex %>' />
         </ItemTemplate>
        </asp:TemplateField> 
    </Columns>
</asp:GridView>

    </div>
    </form>
</body>
</html>
