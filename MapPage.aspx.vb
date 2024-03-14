Public Class MapPage
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Retrieve latitude and longitude from query string
            Dim latitude As String = Request.QueryString("latitude")
            Dim longitude As String = Request.QueryString("longitude")

            ' Call JavaScript function to initialize map
            ClientScript.RegisterStartupScript(Me.GetType(), "InitializeMap", "initializeMap(" & latitude & ", " & longitude & ");", True)
        End If
    End Sub



End Class