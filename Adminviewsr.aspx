<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Adminviewsr.aspx.vb" Inherits="roadresqconnect.Adminviewsr" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: white;
            color: coral;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 800px;
            margin: 50px auto;
            padding: 20px;
            background-color: white;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
        }

        .form-group input[type="text"] {
            width: calc(100% - 100px);
            padding: 10px;
            border: 1px solid coral;
            border-radius: 5px;
            box-sizing: border-box;
        }

        .form-group button {
            width: 100px;
            padding: 10px;
            background-color: coral;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .form-group button:hover {
            background-color: #ff6b4a; /* Coral color variation on hover */
        }

        .gridview-container {
            margin-top: 20px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        th, td {
            padding: 10px;
            border-bottom: 1px solid coral;
            text-align: left;
        }

        th {
            background-color: coral;
            color: white;
        }

   
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-group">
                <label for="txtCustomerID">Enter Customer ID:</label>
                <asp:TextBox ID="txtCustomerID" runat="server"></asp:TextBox>
                <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" BackColor="Coral" />
            </div>
             <div class="form-group">
                <label for="txtProviderID">Enter Provider ID:</label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Filter" OnClick="btnFilter_Click1" BackColor="Coral" />
            </div>
             <div class="form-group">
                <label for="txtdate">Enter Date:</label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Filter" OnClick="btnFilter_Click2" BackColor="Coral" />
            </div>
            <br />
            <asp:Button ID="Button3" runat="server" Text="Back to Dashboard"  BackColor="Coral" />
        </div>

        <div class="gridview-container">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="requestid" HeaderText="Request ID" />
                    <asp:BoundField DataField="customerid" HeaderText="Customer ID" />
                    <asp:BoundField DataField="vehicletype" HeaderText="Vehicle Type" />
                    <asp:BoundField DataField="make" HeaderText="Make" />
                    <asp:BoundField DataField="model" HeaderText="Model" />
                    <asp:BoundField DataField="year" HeaderText="Year" />
                    <asp:BoundField DataField="licenseplatenumber" HeaderText="Plate Number" />
                    <asp:BoundField DataField="color" HeaderText="Color" />
                    <asp:BoundField DataField="requesttime" HeaderText="Request Time" />
                    <asp:BoundField DataField="providerid" HeaderText="Provider ID" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                    <asp:BoundField DataField="assistancetype" HeaderText="Assistance Type" />
                    <asp:BoundField DataField="completionstatus" HeaderText="Completion Status" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

