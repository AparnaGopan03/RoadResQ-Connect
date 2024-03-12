Imports System.Data.SqlClient
Imports System.Web.Services

Public Class ProviderSaveLocation
    Inherits System.Web.UI.Page

    <WebMethod()>
    Public Shared Function SaveUserLocation(latitude As Double, longitude As Double) As String
        ' Get the username from the session
        Dim username As String = HttpContext.Current.Session("Username").ToString()

        ' Connection string for your database
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"

        ' SQL query to update the location in the table
        Dim query As String = "UPDATE ServiceProvider SET Latitude = @Latitude, Longitude = @Longitude WHERE Username = @Username"

        Try
            Using connection As New SqlConnection(connectionString)
                ' Open the connection
                connection.Open()

                ' Create a SqlCommand object
                Using command As New SqlCommand(query, connection)
                    ' Add parameters to the command
                    command.Parameters.AddWithValue("@Latitude", latitude)
                    command.Parameters.AddWithValue("@Longitude", longitude)
                    command.Parameters.AddWithValue("@Username", username)

                    ' Execute the command
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    ' Check if any rows were affected
                    If rowsAffected > 0 Then
                        ' Return a success message
                        Return "Location updated successfully."
                    Else
                        ' Return a message if no rows were affected (e.g., if no existing record was found for the user)
                        Return "No location to update for the current user."
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' If an error occurs, return an error message
            Return "Failed to update location: " & ex.Message
        End Try
    End Function

End Class







'Imports System.Data.SqlClient

'Public Class ProviderSaveLocation
'    Inherits System.Web.UI.Page
'    Dim co As roadresq = New roadresq

'    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
'        If Request.QueryString("permission") = "true" Then
'            ' Get latitude and longitude values
'            Dim latitude As String = Request.QueryString("latitude")
'            Dim longitude As String = Request.QueryString("longitude")

'            ' Retrieve the logged-in user's ID or username
'            Dim Username As String = GetLoggedInUsername()

'            ' If you're using username:
'            ' Dim username As String = Membership.GetUser().UserName

'            ' Update location in the user's table
'            UpdateUserLocation(latitude, longitude, Username)

'            ' Display success message
'            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "<script>alert('Successfully saved location');window.location.href = 'ProviderProfile.aspx'; </script>")


'        Else
'            ' Redirect back to profile page if permission is denied
'            Response.Redirect("ProviderProfile.aspx")
'        End If
'    End Sub

'    Private Function GetLoggedInUsername() As String
'        ' Retrieve the logged-in user's ID from the session
'        If Session("Username") IsNot Nothing Then
'            Return Session("Username").ToString()
'        Else
'            ' If user ID is not found in session, handle accordingly (e.g., redirect to login page)
'            ' Alternatively, you can return an empty string or handle the scenario based on your application's requirements
'            ' For demonstration purposes, we return an empty string here
'            Return ""
'        End If
'    End Function






'    Private Sub UpdateUserLocation(latitude As String, longitude As String, username As String)
'        ' Your database connection and query to update location

'        Dim query As String = "UPDATE ServiceProvider SET Latitude = @latitude, Longitude = @longitude WHERE Username = @username"


'        Using command As New SqlCommand(query, co.connect())
'            command.Parameters.AddWithValue("@latitude", latitude)
'            command.Parameters.AddWithValue("@longitude", longitude)
'            command.Parameters.AddWithValue("@username", username)

'            command.ExecuteNonQuery()
'        End Using

'    End Sub
'End Class



'Imports System.Data.SqlClient

'Public Class ProviderSaveLocation
'    Inherits System.Web.UI.Page
'    Dim co As roadresq = New roadresq

'    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
'        ' Check if the request is initiated by the user and has necessary parameters
'        If Not IsPostBack Then
'            ' Get latitude and longitude values
'            Dim latitude As String = Request.QueryString("latitude")
'            Dim longitude As String = Request.QueryString("longitude")

'            ' Retrieve the logged-in user's username
'            Dim username As String = GetLoggedInUsername()

'            ' If username is available, update the location in the user's table
'            If Not String.IsNullOrEmpty(username) Then
'                UpdateUserLocation(latitude, longitude, username)

'                ' Display success message
'                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "<script>alert('Successfully saved location');window.location.href = 'ProviderBack.aspx';</script>")
'            Else
'                ' Redirect back to profile page if username is not found
'                Response.Redirect("ProviderSignIn.aspx")
'            End If
'            'Else
'            '    ' Redirect back to profile page if permission is denied or if it's a postback
'            '    Response.Redirect("ProviderProfile.aspx")
'        End If
'    End Sub

'    Private Function GetLoggedInUsername() As String
'        ' Retrieve the logged-in user's username from the session
'        If Session("Username") IsNot Nothing Then
'            Return Session("Username").ToString()
'        Else
'            ' If username is not found in session, handle accordingly 
'            Return ""
'        End If
'    End Function

'    Private Sub UpdateUserLocation(latitude As String, longitude As String, username As String)
'        ' Your database connection and query to update location   

'        Dim query As String = "UPDATE ServiceProvider SET Latitude = @latitude, Longitude = @longitude WHERE Username = @username"

'        Using command As New SqlCommand(query, co.connect())
'            command.Parameters.AddWithValue("@latitude", latitude)
'            command.Parameters.AddWithValue("@longitude", longitude)
'            command.Parameters.AddWithValue("@username", username)
'            command.ExecuteNonQuery()
'        End Using
'    End Sub
'End Class


