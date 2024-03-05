Imports System.Data.SqlClient
Imports System.Configuration

Public Class AdminSignIn
    Inherits System.Web.UI.Page

    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If IsValidAdmin(username, password) Then
            Response.Redirect("AdminDashboard.aspx")
        Else
            lblErrorMessage.Text = "Invalid username or password."
            lblErrorMessage.Visible = True
        End If
    End Sub

    Private Function IsValidAdmin(username As String, password As String) As Boolean
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString

        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT COUNT(*) FROM Admin WHERE Username = @username AND Password = @password"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@username", Username)
                cmd.Parameters.AddWithValue("@password", password)
                con.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function
End Class

