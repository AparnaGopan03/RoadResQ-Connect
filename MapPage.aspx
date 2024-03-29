<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MapPage.aspx.vb" Inherits="roadresqconnect.MapPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

   <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDh2X_xILaFLflYxsCbA3AgZRZzl89zVN0&callback=initMap" async defer></script>
    <script>
        function initMap() {
            // Retrieve latitude and longitude from query string
            var latitude = parseFloat(getQueryVariable("latitude"));
            var longitude = parseFloat(getQueryVariable("longitude"));

            console.log("Latitude:", latitude);
            console.log("Longitude:", longitude);

            var mapOptions = {
                center: new google.maps.LatLng(latitude, longitude),
                zoom: 8
            };
            var map = new google.maps.Map(document.getElementById('map'), mapOptions);

            // Add marker for customer's location
            var marker = new google.maps.Marker({
                position: new google.maps.LatLng(latitude, longitude),
                map: map,
                title: 'Customer Location'
            });
        }

        // Function to retrieve query parameters from URL
        function getQueryVariable(variable) {
            var query = window.location.search.substring(1);
            var vars = query.split("&");
            for (var i = 0; i < vars.length; i++) {
                var pair = vars[i].split("=");
                if (pair[0] === variable) {
                    return pair[1];
                }
            }
            return null;
        }
    </script>
</head>

<body onload="initMap()">
    <form id="form1" runat="server">
    
    <div id="map" style="height: 400px; width: 100%;">

    </div>
    
    </form>

</body>
</html>
