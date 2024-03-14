Imports System.Data.SqlClient

Public Class ProviderServiceRequest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindServiceRequests()
        End If
    End Sub

    Private Sub BindServiceRequests()
        ' Fetch service requests assigned to the mechanic along with customer details
        Dim mechanicId As Integer = GetMechanicId()

        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "SELECT sr.requestid, sr.customerid, c.name AS CustomerName, c.email AS CustomerEmail, sr.vehicletype, sr.make, sr.model, sr.year, sr.licenseplatenumber, sr.color, sr.requesttime, sr.status " &
                              "FROM CServiceRequest sr " &
                              "INNER JOIN Customer c ON sr.customerid = c.customerid " &
                              "WHERE sr.providerid = @providerId"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@providerId", mechanicId)

                Dim adapter As New SqlDataAdapter(command)
                Dim dataTable As New DataTable()

                connection.Open()
                adapter.Fill(dataTable)

                ' Check if the status column already exists
                If Not dataTable.Columns.Contains("status") Then
                    ' Add the status column if it doesn't exist
                    dataTable.Columns.Add("status", GetType(String))
                End If

                ' Bind the GridView with the modified DataTable
                GridViewRequests.DataSource = dataTable
                GridViewRequests.DataBind()
            End Using
        End Using
    End Sub



    Private Function GetMechanicId() As Integer
        Dim mechanicId As Integer = 0

        ' Retrieve the username from session
        Dim username As String = Session("Username")

        ' Check if the username is not null or empty
        If Not String.IsNullOrEmpty(username) Then
            ' Establish connection and query the database
            Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
            Dim query As String = "SELECT Providerid FROM ServiceProvider WHERE username = @username"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@username", username)

                    connection.Open()
                    Dim result As Object = command.ExecuteScalar()

                    ' Check if the result is not null or DBNull
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        mechanicId = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        End If

        Return mechanicId
    End Function


    Protected Sub GridViewRequests_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "Accept" OrElse e.CommandName = "Reject" Then
            ' Get the row index of the clicked button
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ' Get the request ID from the row
            Dim requestId As Integer = Convert.ToInt32(GridViewRequests.DataKeys(index).Value)

            If e.CommandName = "Accept" Then
                ' Update the status of the service request to "Accepted"
                UpdateServiceRequestStatus(requestId, "Accepted")
                ' Set the status in the GridView
                SetStatusInGridView(index, "Accepted")
                '' Inform the customer about the acceptance
                'InformCustomer(requestId, "Accepted")
            ElseIf e.CommandName = "Reject" Then
                ' Update the status of the service request to "Rejected"
                UpdateServiceRequestStatus(requestId, "Rejected")
                ' Set the status in the GridView
                SetStatusInGridView(index, "Rejected")
                '' Inform the customer about the rejection
                'InformCustomer(requestId, "Rejected")
            End If

            ' Rebind the GridView to reflect the changes
            BindServiceRequests()
        End If
    End Sub

    Private Sub SetStatusInGridView(ByVal index As Integer, ByVal status As String)
        ' Find the status label in the GridView row and update its text
        Dim row As GridViewRow = GridViewRequests.Rows(index)
        Dim statusLabel As Label = CType(row.FindControl("StatusLabel"), Label)
        If statusLabel IsNot Nothing Then
            statusLabel.Text = status
        End If
    End Sub


    Private Sub UpdateServiceRequestStatus(requestId As Integer, status As String)
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "UPDATE CServiceRequest SET status = @status WHERE requestid = @requestId"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@status", status)
                command.Parameters.AddWithValue("@requestId", requestId)

                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    
End Class
