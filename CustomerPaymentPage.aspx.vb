Imports System.Data.SqlClient

Public Class CustomerPaymentPage
    Inherits System.Web.UI.Page
    Dim co As roadresq = New roadresq

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Retrieve the customer ID from the session based on the username
            Dim username As String = Session("Username").ToString()
            Dim customerId As String = GetCustomerId()

            If Not String.IsNullOrEmpty(customerId) Then
                Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
                Dim query As String = "SELECT servicename, basecost, extracost, extracostdetails,totalcost " &
                                      "FROM paymentdetail " &
                                      "WHERE customerid = @CustomerId"

                Using connection As New SqlConnection(connectionString)
                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@CustomerId", customerId)

                        Try
                            connection.Open()
                            Dim reader As SqlDataReader = command.ExecuteReader()

                            If reader.HasRows Then
                                reader.Read()

                                ' Populate labels with payment details
                                LabelServiceName.Text = reader("servicename").ToString()
                                LabelBaseCost.Text = Convert.ToDecimal(reader("basecost")).ToString("C")
                                LabelExtraCost.Text = Convert.ToDecimal(reader("extracost")).ToString("C")
                                LabelExtraCostDetails.Text = reader("extracostdetails").ToString()
                                Label1.Text = reader("totalcost").ToString()

                            Else
                                ' No payment details found for the provided customer ID
                                ' Handle this scenario (e.g., display an error message)
                            End If
                        Catch ex As Exception
                            ' Handle any exceptions (e.g., log or display error message)
                        Finally
                            connection.Close()
                        End Try
                    End Using
                End Using
            Else
                ' Customer ID is not available for the current user
                ' Handle this scenario (e.g., display an error message or redirect)
            End If
        End If
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



    Protected Sub ButtonPay_Click(sender As Object, e As EventArgs) Handles ButtonPay.Click
        Response.Redirect("PaymentFrom.aspx")
    End Sub

End Class