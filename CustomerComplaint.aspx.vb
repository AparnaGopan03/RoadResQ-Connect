Imports System.Data.SqlClient
Public Class CustomerComplaint
    Inherits System.Web.UI.Page
    Dim co As roadresq = New roadresq
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Check if user is logged in
        If Session("username") Is Nothing Then
            ' Redirect to login page if not logged in
            Response.Redirect("~/CustomerSignIn.aspx")
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        ' Get current logged-in customer's ID
        Dim customerId As Integer = GetCustomerId()

        ' Get other input values
        Dim providerId As String = txtProviderId.Text.Trim()
        Dim complaintDetails As String = txtComplaintDetails.Text.Trim()
        Dim complaintTime As DateTime = DateTime.Now
        Dim status As String = "Pending"

        ' Insert complaint into the database
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO complaints (customerid, providerid, complaintdetails, complainttime, complaintstatus) VALUES (@customerId, @providerId, @complaintDetails, @complaintTime, @status)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@customerId", customerId)
                command.Parameters.AddWithValue("@providerId", providerId)
                command.Parameters.AddWithValue("@complaintDetails", complaintDetails)
                command.Parameters.AddWithValue("@complaintTime", complaintTime)
                command.Parameters.AddWithValue("@status", status)

                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using

        ' Display success message
        lblMessage.Text = "Complaint submitted successfully."
        lblMessage.Visible = True

        ' Clear input fields
        txtProviderId.Text = ""
        txtComplaintDetails.Text = ""
    End Sub


    Private Function GetCustomerId() As Integer
        ' Check if the username is stored in session
        If Session("Username") IsNot Nothing Then
            ' Retrieve the username from session
            Dim username As String = Session("Username").ToString()

            ' Query the database to fetch the customer ID based on the username
            Dim customerId As Integer = 0
            Dim query As String = "SELECT customerid FROM Customer WHERE username = @username"


            Using command As New SqlCommand(query, co.connect())
                command.Parameters.AddWithValue("@username", username)

                Try

                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        customerId = Convert.ToInt32(result)
                    End If
                Catch ex As Exception
                    ' Log any exceptions
                    System.Diagnostics.Debug.WriteLine("Exception: " & ex.Message)
                End Try
            End Using


            Return customerId
        Else
            ' Username is not stored in session, handle the case accordingly
            ' For demonstration purposes, return 0
            Return 0
        End If
    End Function

    
    Protected Sub btnSubmit_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("CustomerProfile.aspx")

    End Sub
End Class



