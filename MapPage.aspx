<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MapPage.aspx.vb" Inherits="roadresqconnect.MapPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDh2X_xILaFLflYxsCbA3AgZRZzl89zVN0"></script>
</head>


<body>
    <form id="form1" runat="server">
    
    <div id="map" style="width: 100%; height: 400px;"></div>
    
    </form>

   <script>
       function initializeMap(latitude, longitude) {
           var mapOptions = {
               center: new google.maps.LatLng(latitude, longitude),
               zoom: 12
           };
           var map = new google.maps.Map(document.getElementById('map'), mapOptions);

           // Add marker for customer's location
           var marker = new google.maps.Marker({
               position: new google.maps.LatLng(latitude, longitude),
               map: map,
               title: 'Customer Location'
           });
       }
</script>


</body>
</html>
