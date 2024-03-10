Imports System.Data.SqlClient

Public Class ProviderSetAvailability
    Inherits System.Web.UI.Page
    Dim co As roadresq = New roadresq

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Check if the user is logged in
            If Session("Username") Is Nothing Then
                ' If not logged in, redirect to login page
                Response.Redirect("ProviderSignIn.aspx")
            End If

            
        End If

       

    End Sub

    Protected Sub btnAvailable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAvailable.Click
        UpdateAvailability(True)
    End Sub

    Protected Sub btnUnavailable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUnavailable.Click
        UpdateAvailability(False)
    End Sub

    Private Sub UpdateAvailability(ByVal isAvailable As Boolean)
        Dim username As String = Session("Username").ToString()

        ' Update availability in the database
        Dim query As String = "UPDATE ServiceProvider SET Availability = @Availability WHERE Username = @Username"

        Using command As New SqlCommand(query, co.connect())
            command.Parameters.AddWithValue("@Availability", isAvailable)
            command.Parameters.AddWithValue("@Username", username)
            command.ExecuteNonQuery()
        End Using

        ' Return availability status
        Dim availabilityStatus As String = If(isAvailable, "Available", "Unavailable")

        ' Return the availability status to update the label asynchronously
        'Response.Write(availabilityStatus)
        'Response.End()
        lblAvailability.Text = availabilityStatus

    End Sub
End Class
