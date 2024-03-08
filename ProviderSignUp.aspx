<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProviderSignUp.aspx.vb" Inherits="roadresqconnect.ProviderSignUp" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Provider Sign Up</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Sign Up</h1>
         

            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />

            <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblDOB" runat="server" Text="Date of Birth:"></asp:Label>
            <asp:TextBox ID="txtDOB" runat="server" placeholder="YYYY-MM-DD"></asp:TextBox>
            <br />

            <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
            <asp:RadioButtonList ID="rblGender" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
            </asp:RadioButtonList>
            <br />

            <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
            <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblContactNo" runat="server" Text="Contact Number:"></asp:Label>
            <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblYearsOfExperience" runat="server" Text="Years of Experience:"></asp:Label>
            <asp:TextBox ID="txtYearsOfExperience" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblServiceArea" runat="server" Text="Service Area:"></asp:Label>
            <asp:TextBox ID="txtServiceArea" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
