<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Adminviewcust.aspx.vb" Inherits="roadresqconnect.Adminviewcust" %>

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

        .actions button {
            padding: 5px 10px;
            background-color: coral;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .actions button:hover {
            background-color: #ff6b4a; /* Coral color variation on hover */
        }

           #btnDelete {
            padding: 5px 10px;
            background-color: coral;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

         #btnDelete:hover {
            background-color: #ff6b4a; /* Coral color variation on hover */
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
            <br />
            <asp:Button ID="Button3" runat="server" Text="Back to Dashboard"  BackColor="Coral" />
        </div>

        <div class="gridview-container">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="customerid">
                <Columns>
                    <asp:BoundField DataField="customerid" HeaderText="Customer ID" />
                    <asp:BoundField DataField="UserName" HeaderText="Username" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="dob" HeaderText="DOB" />
                    <asp:BoundField DataField="gender" HeaderText="Gender" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="contactnumber" HeaderText="Contact Number" />
                    <asp:TemplateField HeaderText="Service Requests">
                        <ItemTemplate>
                            <%# GetServiceRequests(Eval("customerid")) %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <div class="actions">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("customerid")%>' BackColor="Coral" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
