Imports System.Data.SqlClient
Public Class ProviderSignUp
    Inherits System.Web.UI.Page
    Dim co As roadresq = New roadresq
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        ' Get form field values
        Dim email As String = txtEmail.Text
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text
        Dim name As String = txtName.Text
        Dim dob As Date = Date.Parse(txtDOB.Text)
        Dim gender As String = rblGender.SelectedValue
        Dim address As String = txtAddress.Text
        Dim contactNo As String = txtContactNo.Text
        Dim yearsOfExperience As Integer = Integer.Parse(txtYearsOfExperience.Text)
        Dim serviceArea As String = txtServiceArea.Text
        Dim assistanceType As String = assistanceTypeDropDown.Value

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

        If UsernameExists(username) Then
            ' Display an error message
            Response.Write("<script>alert('Username already exists. Please choose a different username.');</script>")
            Return
        End If

        ' Insert mechanic data into database
        Dim connectionString As String = "YourConnectionString"

        Dim query As String = "INSERT INTO ServiceProvider (Email, Username, Password, Name, DOB, Gender, Address, ContactNumber, YearsofExperience, ServiceArea,AssistanceType) VALUES (@Email, @Username, @Password, @Name, @DOB, @Gender, @Address, @ContactNo, @YearsOfExperience, @ServiceArea, @assistanceType)"
        Using command As New SqlCommand(query, co.connect())
            command.Parameters.AddWithValue("@Email", email)
            command.Parameters.AddWithValue("@Username", username)
            command.Parameters.AddWithValue("@Password", password)
            command.Parameters.AddWithValue("@Name", name)
            command.Parameters.AddWithValue("@DOB", dob)
            command.Parameters.AddWithValue("@Gender", gender)
            command.Parameters.AddWithValue("@Address", address)
            command.Parameters.AddWithValue("@ContactNo", contactNo)
            command.Parameters.AddWithValue("@YearsOfExperience", yearsOfExperience)
            command.Parameters.AddWithValue("@ServiceArea", serviceArea)
            command.Parameters.AddWithValue("@assistanceType", assistanceType)


            command.ExecuteNonQuery()
        End Using

        Response.Redirect("ProviderSignIn.aspx")

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

    Private Function UsernameExists(username As String) As Boolean
        ' Check if the username already exists in the database

        Dim query As String = "SELECT COUNT(*) FROM ServiceProvider WHERE Username = @Username"

        Using command As New SqlCommand(query, co.connect())
            command.Parameters.AddWithValue("@Username", username)
            Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
            Return count > 0
        End Using

    End Function

End Class


