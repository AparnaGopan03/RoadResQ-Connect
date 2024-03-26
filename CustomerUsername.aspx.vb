
Imports System.Data.SqlClient

Public Class CustomerUsername
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim email As String = txtEmail.Text
        Dim newUsername As String = txtNewUsername.Text
        Dim confirmUsername As String = txtConfirmUsername.Text

        ' Check if usernames match
        If newUsername <> confirmUsername Then
            ' Usernames don't match, display a SweetAlert error message
            ShowSweetAlert("Usernames do not match. Please make sure the usernames match.")
            Return ' Exit the method to prevent further processing
        End If

        ' Update username in the database
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"
        Dim query As String = "UPDATE customer SET Username = @Username WHERE Email = @Email"

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Username", newUsername)
                cmd.Parameters.AddWithValue("@Email", email)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        ' Show a success message using SweetAlert
        ShowSweetAlert("Username updated successfully!", "ProviderSignIn.aspx")
    End Sub

    Private Sub ShowSweetAlert(ByVal message As String, Optional ByVal redirectToPage As String = "")
        Dim script As String = String.Format("showSweetAlert('{0}', '{1}');", message, redirectToPage)
        ClientScript.RegisterStartupScript(Me.GetType(), "SweetAlert", script, True)
    End Sub

End Class