
Imports System.Data.SqlClient
Imports System.Web.Security

Public Class CustomerComplaintHistory
    Inherits System.Web.UI.Page
    Dim co As roadresq = New roadresq
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim customerId As String = GetCustomerId()
            BindPaymentHistory(customerId)
        End If
    End Sub

    Private Function GetCustomerId() As String

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


        Return Membership.GetUser().ProviderUserKey.ToString()
    End Function

    Private Sub BindPaymentHistory(customerId As String)
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "SELECT ProviderId,complaintdetails,complaintstatus,complainttime,complaintrestime FROM Complaints WHERE CustomerId = @CustomerId"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@CustomerId", customerId)
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                GridViewComplaints.DataSource = reader
                GridViewComplaints.DataBind()
            End Using
        End Using
    End Sub
End Class


