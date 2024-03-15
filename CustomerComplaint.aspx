<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerComplaint.aspx.vb" Inherits="roadresqconnect.CustomerComplaint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Register a Complaint</title>
   <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #FBCEB1;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        
        .form-container {
            background-color: #D3D3D3;
            padding: 20px;
            border-radius: 10px;
            width: 600px;
        }
        
        h2 {
            margin-top: 0;
        }
        
        label {
            display: block;
            margin-bottom: 10px;
            color: #333;
        }
        
        input[type="text"],
        textarea {
            width: 100%;
            padding: 12px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 6px;
            box-sizing: border-box;
            font-size: 18px;
        }
        
        textarea {
            resize: vertical;
        }
        
        input[type="submit"] {
            background-color: #D3D3D3;
            color: #333;
            border: none;
            padding: 15px 30px;
            border-radius: 6px;
            cursor: pointer;
            font-size: 20px;
        }
        
        input[type="submit"]:hover {
            background-color: #FFA07A;
        }
        
        .message {
            color: red;
            margin-top: 20px;
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Register a Complaint</h2>
            
            <asp:Label ID="lblProviderId" runat="server" Text="Provider ID:"></asp:Label>
            <asp:TextBox ID="txtProviderId" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblComplaintDetails" runat="server" Text="Complaint Details:"></asp:Label>
            <asp:TextBox ID="txtComplaintDetails" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox><br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Go Back" OnClick="btnSubmit_Click1" />
            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
