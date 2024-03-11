<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerServiceRequest.aspx.vb" Inherits="roadresqconnect.CustomerServiceRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
            document.getElementById('locationStatus').innerHTML = "Location shared successfully (Latitude: " + latitude + ", Longitude: " + longitude + ")";
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
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Submit Request" />
    </div>
    </form>
</body>
</html>
