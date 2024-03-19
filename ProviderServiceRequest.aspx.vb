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
        Dim query As String = "SELECT sr.requestid, sr.customerid, c.name AS CustomerName, c.contactnumber AS Customercno, sr.vehicletype, sr.make, sr.model, sr.year, sr.licenseplatenumber, sr.color, sr.requesttime, sr.status, sr.completionstatus " &
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

        If e.CommandName = "ViewLocation" Then
            ' Get the row index of the clicked button
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ' Assuming RequestID is the identifier stored in the GridView's row
            Dim requestId As Integer = Convert.ToInt32(GridViewRequests.DataKeys(index).Value)

            ' Query the ServiceRequest table to get latitude and longitude based on requestId
            Dim latitude As String = ""
            Dim longitude As String = ""

            Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
            ' Assume conn is your database connection object
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT Latitude, Longitude FROM CServiceRequest WHERE RequestID = @RequestId"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@RequestId", requestId)
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        latitude = reader("Latitude").ToString()
                        longitude = reader("Longitude").ToString()
                    End If
                End Using
            End Using

            ' Redirect to the map page with latitude and longitude parameters
            Response.Redirect("MapPage.aspx?latitude=" & latitude & "&longitude=" & longitude)
        End If



        If e.CommandName = "Complete" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim requestId As Integer = Convert.ToInt32(GridViewRequests.DataKeys(index).Value)

            ' Update the completion status of the service request to "Completed"
            UpdateCompletionStatus(requestId, "Completed")

            ' Set the completion status in the GridView
            SetCompletionStatusInGridView(index, "Completed")

            ' Rebind the GridView to reflect the changes
            BindServiceRequests()
        End If

        If e.CommandName = "Payment" Then
            ' Retrieve the index of the row from the CommandArgument
            Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)

            ' Retrieve data from the GridView using the row index
            Dim requestId As String = GridViewRequests.DataKeys(rowIndex).Value.ToString()

            ' Redirect to another page for payment
            Response.Redirect("PaymentDetailsPage.aspx?RequestId=" & requestId)
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

    Private Sub SetCompletionStatusInGridView(ByVal index As Integer, ByVal status As String)
        ' Find the GridView row and update the value of the completion status column
        Dim row As GridViewRow = GridViewRequests.Rows(index)
        Dim completionStatusCell As TableCell = row.Cells(row.Cells.Count - 1) ' Index of the completion status column
        completionStatusCell.Text = status
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

    Private Sub UpdateCompletionStatus(requestId As Integer, status As String)
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "UPDATE CServiceRequest SET CompletionStatus = @status WHERE requestid = @requestId"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@status", status)
                command.Parameters.AddWithValue("@requestId", requestId)

                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("ProviderProfile.aspx")
    End Sub

   
End Class
