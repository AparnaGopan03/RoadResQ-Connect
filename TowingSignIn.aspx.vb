Imports System.Data.SqlClient
Public Class TowingSignIn
    Inherits System.Web.UI.Page
    Dim co As roadresq = New roadresq
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        If AuthenticateUser(username, password) Then
            ' If authentication is successful, set the username in the session
            Session("Username") = username
            ' Redirect to the profile page
            Response.Redirect("TowingProfile.aspx")
        Else
            ' Authentication failed, display error message
            lblErrorMessage.Text = "Invalid username or password"
        End If

    End Sub

    Private Function AuthenticateUser(username As String, password As String) As Boolean

        Dim query As String = "SELECT COUNT(*) FROM Towing WHERE Username = @Username  AND Password = @Password"

        Using cmd As New SqlCommand(query, co.connect())
            cmd.Parameters.AddWithValue("@Username", username)
            cmd.Parameters.AddWithValue("@Password", password)


            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            ' If count is greater than 0, user is authenticated
            Return count > 0
        End Using
    End Function
End Class




