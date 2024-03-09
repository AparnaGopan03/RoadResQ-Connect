Imports System.Data.SqlClient
Public Class TowingSignUp
    Inherits System.Web.UI.Page
    Dim co As roadresq = New roadresq
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        ' Get form field values
        Dim email As String = txtEmail.Text
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text
        Dim name As String = txtName.Text
        Dim dob As Date = Date.Parse(txtDOB.Text)

        Dim address As String = txtAddress.Text
        Dim contactNo As String = txtContactNo.Text
       


        ' Validate email using a regular expression
        If Not IsValidEmail(email) Then
            ' Display an error message or take appropriate action
            Response.Write("<script>alert('Invalid email address. Please enter a valid email.');</script>")
            Return
        End If

        ' Validate contact number using a regular expression
        If Not IsValidContactNumber(contactNo) Then
            ' Display an error message or take appropriate action
            Response.Write("<script>alert('Invalid contact number. Please enter a valid contact number.');</script>")
            Return
        End If






        Dim query As String = "INSERT INTO Towing (Email, Username, Password, Name, DOB, servicecenter, ContactNumber) VALUES (@Email, @Username, @Password, @Name, @DOB, @Address, @ContactNo)"
        Using command As New SqlCommand(query, co.connect())
            command.Parameters.AddWithValue("@Email", email)
            command.Parameters.AddWithValue("@Username", username)
            command.Parameters.AddWithValue("@Password", password)
            command.Parameters.AddWithValue("@Name", name)
            command.Parameters.AddWithValue("@DOB", dob)

            command.Parameters.AddWithValue("@Address", address)
            command.Parameters.AddWithValue("@ContactNo", contactNo)
            

            command.ExecuteNonQuery()
        End Using

        Response.Redirect("TowingSignIn.aspx")

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
