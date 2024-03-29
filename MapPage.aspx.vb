Public Class MapPage
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Retrieve latitude and longitude from query string
            Dim latitude As String = Request.QueryString("latitude")
            Dim longitude As String = Request.QueryString("longitude")

            ' Check if latitude and longitude are not empty
            If Not String.IsNullOrEmpty(latitude) AndAlso Not String.IsNullOrEmpty(longitude) Then
                ' Call JavaScript function to initialize map with formatted latitude and longitude values
                Dim script As String = "initMap('" & latitude & "', '" & longitude & "');"
                ClientScript.RegisterStartupScript(Me.GetType(), "initMap", script, True)
            Else
                ' Handle case where latitude or longitude is missing
                ' For example, you could display an error message or redirect to a different page
                ' Response.Redirect("ErrorPage.aspx")
                ' Or display a message to the user
                ' lblErrorMessage.Text = "Latitude or Longitude not provided."
            End If
        End If
    End Sub




End Class