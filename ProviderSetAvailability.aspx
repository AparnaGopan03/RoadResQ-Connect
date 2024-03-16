<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProviderSetAvailability.aspx.vb" Inherits="roadresqconnect.ProviderSetAvailability" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Set Availability</title>

    

    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f9f9f9;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        
        .container {
            text-align: center;
        }
        
        h1 {
            color: #333;
            margin-bottom: 30px;
            font-size: 36px;
            letter-spacing: 1px;
        }
        
        .btn {
            display: inline-block;
            padding: 15px 30px;
            background-color: #ff6f61;
            color: #fff;
            border: none;
            border-radius: 6px;
            cursor: pointer;
            font-size: 18px;
            text-decoration: none;
            transition: background-color 0.3s ease;
        }
        
        .btn:hover {
            background-color: #ff4136;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Set Availability</h1>
            <asp:Button ID="btnAvailable" CssClass="btn" runat="server" Text="Available" onclick="btnAvailable_Click" />
            <asp:Button ID="btnUnavailable" CssClass="btn" runat="server" Text="Unavailable" OnClick="btnUnavailable_Click" />
            <br />
            <br />
            <asp:Label ID="lblAvailability0" runat="server" Text="Availability Status : " EnableViewState="true" ></asp:Label>

            <asp:Label ID="lblAvailability" runat="server" Text="" EnableViewState="true" ></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnAnotherButton" CssClass="btn" runat="server" Text="Back To profile" OnClick="btnAnotherButton_Click" />

        </div>
    </form>

   <script type="text/javascript">
       function updateAvailability(isAvailable) {
           var xmlHttp = new XMLHttpRequest();

           xmlHttp.onreadystatechange = function () {
               if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
                   document.getElementById('<%= lblAvailability.ClientID %>').innerText = xmlHttp.responseText;
            }
        };

        xmlHttp.open("GET", "ProviderSetAvailability.aspx?isAvailable=" + isAvailable, true);
        xmlHttp.send();
    }
</script>



    
</body>
</html>
