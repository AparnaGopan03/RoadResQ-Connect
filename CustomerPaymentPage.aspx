<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerPaymentPage.aspx.vb" Inherits="roadresqconnect.CustomerPaymentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>

        .card {
  border: 1px solid #ccc;
  border-radius: 8px;
  margin-bottom: 20px;
}

.card-header {
  background-color: coral;
  color: white;
  padding: 10px;
  border-top-left-radius: 8px;
  border-top-right-radius: 8px;
}

.card-body {
  padding: 20px;
}

.btn-primary {
  background-color: coral;
  border-color: coral;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="card">
  <div class="card-header">
    Payment Details
  </div>
  <div class="card-body">
    <h3 class="card-title">Service Name: <asp:Label ID="LabelServiceName" runat="server" /></h3>
    <p class="card-text">Base Cost: <asp:Label ID="LabelBaseCost" runat="server" /></p>
    <p class="card-text">Extra Cost: <asp:Label ID="LabelExtraCost" runat="server" /></p>
    <p class="card-text">Extra Cost Details: <asp:Label ID="LabelExtraCostDetails" runat="server" /></p>
    <p class="card-text">Total Cost: <asp:Label ID="Label1" runat="server" /></p>
    <asp:Button ID="ButtonPay" runat="server" Text="Pay Now" CssClass="btn btn-primary" OnClick="ButtonPay_Click" />
  </div>
</div>
    </form>
</body>
</html>
