Imports System.Data.SqlClient

Public Class CustomerHistory
    Inherits System.Web.UI.Page
    Dim co As roadresq = New roadresq
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindServiceRequestHistory()
        End If
    End Sub

    Private Sub BindServiceRequestHistory()
        ' Get the customer ID
        Dim customerId As Integer = GetCustomerId()

        ' Fetch the service request history for the customer
        Dim serviceRequests As DataTable = FetchServiceRequestHistory(customerId)

        ' Bind the service request history to the GridView
        GridViewHistory.DataSource = serviceRequests
        GridViewHistory.DataBind()
    End Sub

    Private Function FetchServiceRequestHistory(customerId As Integer) As DataTable
        Dim serviceRequests As New DataTable()

        ' Use your connection string
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"

        ' Query to fetch service request history
        Dim query As String = "SELECT sr.requestid AS RequestId, sr.status AS Status, sr.vehicletype AS VehicleType, sr.make As Make, sr.model As Model, sr.year As Year, sr.licenseplatenumber As LicensePlateNumber, sr.requesttime As RequestTime, sr.assistancetype As AssistanceType, sr.providerid As ProviderID, sp.name AS MechanicName, sp.contactnumber As Contactno " &
                              "FROM CServiceRequest sr " &
                              "INNER JOIN ServiceProvider sp ON sr.providerid = sp.providerid " &
                              "WHERE sr.customerid = @customerId"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@customerId", customerId)

                Dim adapter As New SqlDataAdapter(command)
                adapter.Fill(serviceRequests)
            End Using
        End Using

        Return serviceRequests
    End Function

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

    ' Optionally, you can format the data in the GridView during row data binding
    Protected Sub GridViewHistory_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' You can format data here if needed
            ' For example, you can convert status codes to meaningful text
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("CustomerProfile.aspx")
    End Sub
End Class
