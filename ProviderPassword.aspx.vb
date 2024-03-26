Imports System.Data.SqlClient

Public Class ProviderPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim email As String = txtEmail.Text
        Dim newPassword As String = txtNewPassword.Text
        Dim confirmPassword As String = txtConfirmPassword.Text

        ' Check if passwords match
        If newPassword <> confirmPassword Then
            ' Passwords don't match, display an error message
            ShowSweetAlert("Passwords do not match. Please make sure the passwords match.")
            Return  ' Exit the method to prevent further processing
        End If


        ' Update password in the database
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"
        Dim query As String = "UPDATE ServiceProvider SET Password = @Password WHERE Email = @Email"

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Password", newPassword)
                cmd.Parameters.AddWithValue("@Email", email)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        ' Password updated successfully, you can redirect to a success page or display a message

        ' Show a success message using SweetAlert
        ShowSweetAlert("Password updated successfully!", "CustomerSignIn.aspx")

    End Sub

    Private Sub ShowSweetAlert(ByVal message As String, Optional ByVal redirectToPage As String = "")
        Dim script As String = String.Format("showSweetAlert('{0}', '{1}');", message, redirectToPage)
        ClientScript.RegisterStartupScript(Me.GetType(), "SweetAlert", script, True)
    End Sub

End Class