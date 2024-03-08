Imports System.Data.SqlClient

Public Class ProviderSaveLocation
    Inherits System.Web.UI.Page
    Dim co As roadresq = New roadresq

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Request.QueryString("permission") = "true" Then
            ' Get latitude and longitude values
            Dim latitude As String = Request.QueryString("latitude")
            Dim longitude As String = Request.QueryString("longitude")

            ' Retrieve the logged-in user's ID or username
            Dim Username As String = GetLoggedInUsername()

            ' If you're using username:
            ' Dim username As String = Membership.GetUser().UserName

            ' Update location in the user's table
            UpdateUserLocation(latitude, longitude, Username)

            ' Display success message
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "<script>alert('Successfully saved location'); window.location.href = 'ProviderProfile.aspx';</script>")

        Else
            ' Redirect back to profile page if permission is denied
            Response.Redirect("ProviderProfile.aspx")
        End If
    End Sub

    Private Function GetLoggedInUsername() As String
        ' Retrieve the logged-in user's ID from the session
        If Session("Username") IsNot Nothing Then
            Return Session("Username").ToString()
        Else
            ' If user ID is not found in session, handle accordingly (e.g., redirect to login page)
            ' Alternatively, you can return an empty string or handle the scenario based on your application's requirements
            ' For demonstration purposes, we return an empty string here
            Return ""
        End If
    End Function






    Private Sub UpdateUserLocation(latitude As String, longitude As String, username As String)
        ' Your database connection and query to update location

        Dim query As String = "UPDATE ServiceProvider SET Latitude = @latitude, Longitude = @longitude WHERE Username = @username"


        Using command As New SqlCommand(query, co.connect())
            command.Parameters.AddWithValue("@latitude", latitude)
            command.Parameters.AddWithValue("@longitude", longitude)
            command.Parameters.AddWithValue("@username", username)

            command.ExecuteNonQuery()
        End Using

    End Sub
End Class