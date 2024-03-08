Imports System.Data.SqlClient

Public Class CustomerSignUp
    Inherits System.Web.UI.Page
    Dim co As roadresq = New roadresq
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSignup_Click(sender As Object, e As EventArgs) Handles btnSignup.Click
        Dim email As String = txtEmail.Text
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text
        Dim name As String = txtName.Text
        Dim dob As String = txtDOB.Text
        Dim gender As String = rblGender.SelectedItem.Value
        Dim address As String = txtAddress.Text
        Dim contactNumber As String = txtContactNumber.Text

        ' Validate email using a regular expression
        If Not IsValidEmail(email) Then
            ' Display an error message or take appropriate action
            Response.Write("<script>alert('Invalid email address. Please enter a valid email.');</script>")
            Return
        End If

        ' Validate contact number using a regular expression
        If Not IsValidContactNumber(contactNumber) Then
            ' Display an error message or take appropriate action
            Response.Write("<script>alert('Invalid contact number. Please enter a valid contact number.');</script>")
            Return
        End If

        Dim query As String = "INSERT INTO Customer (Email, Username, Password, Name, dob, Gender, Address,ContactNumber) VALUES (@Email, @Username, @Password, @Name, @DOB, @Gender, @Address, @ContactNumber)"
        Using cmd As New SqlCommand(query, co.connect())
            cmd.Parameters.AddWithValue("@Email", email)
            cmd.Parameters.AddWithValue("@Username", username)
            cmd.Parameters.AddWithValue("@Password", password)
            cmd.Parameters.AddWithValue("@Name", name)
            cmd.Parameters.AddWithValue("@DOB", dob)
            cmd.Parameters.AddWithValue("@Gender", gender)
            cmd.Parameters.AddWithValue("@Address", address)
            cmd.Parameters.AddWithValue("@ContactNumber", contactNumber)

            cmd.ExecuteNonQuery()
        End Using


        Response.Redirect("CustomerSignIn.aspx")
    End Sub

    Private Function IsValidEmail(email As String) As Boolean
        ' Use a regular expression to validate email format
        Dim emailPattern As String = "^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$"
        Return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern)
    End Function

    Private Function IsValidContactNumber(contactNumber As String) As Boolean
        ' Use a regular expression to validate contact number format
        Dim contactNumberPattern As String = "^\d{10}$" ' Assumes a 10-digit contact number
        Return System.Text.RegularExpressions.Regex.IsMatch(contactNumber, contactNumberPattern)
    End Function

End Class