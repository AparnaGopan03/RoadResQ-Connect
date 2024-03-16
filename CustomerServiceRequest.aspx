<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerServiceRequest.aspx.vb" Inherits="roadresqconnect.CustomerServiceRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Service Request</title>

  <style>
    body {
        font-family: Arial, sans-serif;
        background-color: #f4f4f4;
        margin: 0;
        padding: 0;
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
    }

    .container {
        background-color: #fff;
        padding: 30px;
        border-radius: 10px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    h2 {
        text-align: center;
        margin-bottom: 20px;
    }

    label {
        font-weight: bold;
        color: #333;
    }

    .form-group {
        margin-bottom: 20px;
    }

    .form-control {
        width: 100%;
        padding: 10px;
        border: 1px solid #ccc;
        border-radius: 5px;
        box-sizing: border-box;
        font-size: 16px;
    }

    #Button1,#Button2 {
        padding: 12px 20px;
        background-color:  #ff9966;
        color: #fff;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        font-size: 16px;
        transition: background-color 0.3s ease;
        width: 100%;
    }

    #Button1:hover {
        background-color: #087830;
    }
</style>


    <script type="text/javascript">
        window.onload = function () {
            getLocation();
        }

        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition, showError);
            } else {
                document.getElementById('locationStatus').innerHTML = "Geolocation is not supported by this browser.";
            }
        }

        function showPosition(position) {
            var latitude = position.coords.latitude;
            var longitude = position.coords.longitude;
            document.getElementById('locationStatus').innerHTML = "Location captured successfully";
            document.getElementById('<%= latitudeHiddenField.ClientID %>').value = latitude;
            document.getElementById('<%= longitudeHiddenField.ClientID %>').value = longitude;
        }

        function showError(error) {
            switch (error.code) {
                case error.PERMISSION_DENIED:
                    document.getElementById('locationStatus').innerHTML = "User denied the request for Geolocation.";
                    break;
                case error.POSITION_UNAVAILABLE:
                    document.getElementById('locationStatus').innerHTML = "Location information is unavailable.";
                    break;
                case error.TIMEOUT:
                    document.getElementById('locationStatus').innerHTML = "The request to get user location timed out.";
                    break;
                case error.UNKNOWN_ERROR:
                    document.getElementById('locationStatus').innerHTML = "An unknown error occurred.";
                    break;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <label for="assistanceTypeDropDown">Type of Assistance:</label>
        <select id="assistanceTypeDropDown" runat="server" class="form-control">
            <option value="Towing">Towing</option>
            <option value="Roadside Assistance">Roadside Assistance</option>
        </select>
    </div>

    <div>
        <label for="vehicleTypeTextBox">Vehicle Type:</label>
        <asp:TextBox ID="vehicleTypeTextBox" runat="server" CssClass="form-control" />
    </div>
    <div>
        <label for="makeTextBox">Make:</label>
        <asp:TextBox ID="makeTextBox" runat="server" CssClass="form-control" />
    </div>
    <div>
        <label for="modelTextBox">Model:</label>
        <asp:TextBox ID="modelTextBox" runat="server" CssClass="form-control" />
    </div>
    <div>
        <label for="yearTextBox">Year:</label>
        <asp:TextBox ID="yearTextBox" runat="server" CssClass="form-control" />
    </div>
    <div>
        <label for="licensePlateTextBox">License Plate Number:</label>
        <asp:TextBox ID="licensePlateTextBox" runat="server" CssClass="form-control" />
    </div>
    <div>
        <label for="colorTextBox">Color:</label>
        <asp:TextBox ID="colorTextBox" runat="server" CssClass="form-control" />
    </div>

    <div>
        <span id="locationStatus"></span>
    </div>
        <asp:HiddenField ID="latitudeHiddenField" runat="server" />
        <asp:HiddenField ID="longitudeHiddenField" runat="server" />
    <div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Submit Request" />
        <br /><br />
        <asp:Button ID="Button2" runat="server" Text="Back To Profile" />
    </div>
    </form>
</body>
</html>
