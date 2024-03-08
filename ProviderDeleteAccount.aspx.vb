Imports System.Data.SqlClient
Public Class ProviderDeleteAccount
    Inherits System.Web.UI.Page
    Dim co As roadresq = New roadresq
    Dim lblErrorMessage As Object


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub btnYes_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnYes.Click
        ' Show the confirmation panel
        pnlConfirmation.Visible = True
    End Sub

    Protected Sub btnNo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNo.Click
        ' Redirect to another page or perform other actions
        Response.Redirect("ProviderProfile.aspx")
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click


        ' Get the logged-in username
        Dim loggedInUser As String = Session("Username")

        ' Get the entered username and password
        Dim enteredUsername As String = txtUsername.Text
        Dim enteredPassword As String = txtPassword.Text

        ' Check if the entered username matches the logged-in user
        If loggedInUser = enteredUsername Then
            ' Perform database operations (replace with your actual SQL query)



            ' Delete user account based on username
            Dim query As String = "DELETE FROM ServiceProvider WHERE Username = @Username "
            Using cmd As New SqlCommand(query, co.connect())
                cmd.Parameters.AddWithValue("@Username", enteredUsername)

                cmd.ExecuteNonQuery()
            End Using

            ' Redirect to another page after deletion 
            Response.Redirect("Home.aspx")

        Else
            ' Display an error message if the entered username does not match the logged-in user
            lblErrorMessage.Text = "Invalid username. Please enter the correct username."
            lblErrorMessage.Visible = True
        End If
    End Sub
End Class







