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

                'SetStatusInGridView(index, "Rejected")
                ' Assuming you have variables to store the required values
                Dim currentMechanicId As Integer = GetMechanicId() ' Implement this method to get the current mechanic's ID
                Dim customerLatitude As Double = GetCustomerLatitude(requestId) ' Implement this method to get the customer's latitude for the given request ID
                Dim customerLongitude As Double = GetCustomerLongitude(requestId) ' Implement this method to get the customer's longitude for the given request ID

                ' Call the ReassignServiceRequest method with all required parameters
                ReassignServiceRequest(requestId, currentMechanicId, customerLatitude, customerLongitude)


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
                Dim query As String = "SELECT latitude, longitude FROM CServiceRequest WHERE RequestID = @RequestId"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@RequestId", requestId)
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        latitude = reader("latitude").ToString()
                        longitude = reader("longitude").ToString()
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

   
   Private Sub ReassignServiceRequest(ByVal requestId As Integer, ByVal currentMechanicId As Integer, ByVal customerLatitude As Double, ByVal customerLongitude As Double)
        Dim newMechanicId As Integer = FindAnotherMechanic(currentMechanicId, customerLatitude, customerLongitude)
        If newMechanicId <> 0 Then
            UpdateProviderId(requestId, newMechanicId)
        Else
            ' Handle the case where no other mechanic is available
            ' You can display a message or take any other appropriate action
        End If
    End Sub


    Private Function FindAnotherMechanic(ByVal currentMechanicId As Integer, ByVal customerLatitude As Double, ByVal customerLongitude As Double) As Integer
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "SELECT providerid, latitude, longitude FROM ServiceProvider WHERE providerid <> @currentMechanicId"

        Dim availableMechanicId As Integer = 0
        Dim minDistance As Double = Double.MaxValue

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@currentMechanicId", currentMechanicId)

                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()

                While reader.Read()
                    Dim mechanicId As Integer = Convert.ToInt32(reader("providerid"))
                    Dim mechanicLatitude As Double = Convert.ToDouble(reader("latitude"))
                    Dim mechanicLongitude As Double = Convert.ToDouble(reader("longitude"))

                    ' Calculate distance between customer and mechanic
                    Dim distance As Double = CalculateDistance(customerLatitude, customerLongitude, mechanicLatitude, mechanicLongitude)

                    ' Check if the mechanic is closer than the current minimum distance
                    If distance < minDistance Then
                        minDistance = distance
                        availableMechanicId = mechanicId
                    End If
                End While
            End Using
        End Using

        Return availableMechanicId
    End Function

    Private Function CalculateDistance(ByVal lat1 As Double, ByVal lon1 As Double, ByVal lat2 As Double, ByVal lon2 As Double) As Double
        Dim earthRadius As Double = 6371 ' Radius of the Earth in kilometers

        ' Convert latitude and longitude from degrees to radians
        Dim dLat As Double = DegreeToRadian(lat2 - lat1)
        Dim dLon As Double = DegreeToRadian(lon2 - lon1)

        ' Apply Haversine formula
        Dim a As Double = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                          Math.Cos(DegreeToRadian(lat1)) * Math.Cos(DegreeToRadian(lat2)) *
                          Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
        Dim c As Double = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))
        Dim distance As Double = earthRadius * c

        Return distance
    End Function

    Private Function DegreeToRadian(ByVal deg As Double) As Double
        Return deg * (Math.PI / 180)
    End Function


    Private Sub UpdateProviderId(ByVal requestId As Integer, ByVal mechanicId As Integer)
        ' Update the providerid column of the service request with the ID of the new mechanic
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "UPDATE CServiceRequest SET providerid = @mechanicId WHERE requestid = @requestId"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@mechanicId", mechanicId)
                command.Parameters.AddWithValue("@requestId", requestId)

                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Function GetCustomerLatitude(ByVal requestId As Integer) As Double
        ' Retrieve the latitude of the customer associated with the given request ID
        Dim latitude As Double = 0

        ' Example implementation:
        ' Query the database to get the latitude based on the request ID
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "SELECT latitude FROM CServiceRequest WHERE RequestID = @RequestId"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@RequestId", requestId)

                connection.Open()
                Dim result As Object = command.ExecuteScalar()

                ' Check if the result is not null or DBNull
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    latitude = Convert.ToDouble(result)
                End If
            End Using
        End Using

        Return latitude
    End Function

    Private Function GetCustomerLongitude(ByVal requestId As Integer) As Double
        ' Retrieve the longitude of the customer associated with the given request ID
        Dim longitude As Double = 0

        ' Example implementation:
        ' Query the database to get the longitude based on the request ID
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "SELECT longitude FROM CServiceRequest WHERE RequestID = @RequestId"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@RequestId", requestId)

                connection.Open()
                Dim result As Object = command.ExecuteScalar()

                ' Check if the result is not null or DBNull
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    longitude = Convert.ToDouble(result)
                End If
            End Using
        End Using

        Return longitude
    End Function

End Class
