Imports System.Data.SqlClient

Public Class ProviderServiceRequest
    Inherits System.Web.UI.Page
    Dim co As roadresq = New roadresq
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
            ' Get the latitude and longitude from the row
            Dim latitude As String = GridViewRequests.Rows(index).Cells(11).Text
            Dim longitude As String = GridViewRequests.Rows(index).Cells(12).Text

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


        If e.CommandName = "RejectMechanic" Then
            ' Get the row index of the clicked button
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ' Get the request ID from the row
            Dim requestId As Integer = Convert.ToInt32(GridViewRequests.DataKeys(index).Value)

            ' Update the status of the service request to "Rejected"
            UpdateServiceRequestStatus(requestId, "Rejected")
            ' Set the status in the GridView
            SetStatusInGridView(index, "Rejected")

            ' Assign another nearest mechanic
            AssignAnotherMechanic(requestId)
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


    Private Sub AssignAnotherMechanic(requestId As Integer)
        ' Fetch available mechanics from the database
        Dim latitude As Double = GetLatitude(requestId)
        Dim longitude As Double = GetLongitude(requestId)
        Dim mechanics As List(Of Mechanic) = GetAvailableMechanics(latitude, longitude)

        ' Filter out mechanics who are already assigned to service requests
        mechanics = FilterAssignedMechanics(mechanics)

        ' Find the nearest mechanic
        Dim nearestMechanic As Mechanic = FindNearestMechanic(mechanics, latitude, longitude)

        If nearestMechanic IsNot Nothing Then
            ' Update ServiceRequest table with the nearest mechanic's providerid
            UpdateServiceRequest(requestId, nearestMechanic.ProviderId)

            ' Send service request to the nearest mechanic
            'SendServiceRequest(nearestMechanic)
        Else
            ' Handle case where no mechanics are found within 5 km
            ' Or handle case where all mechanics are already assigned to service requests
            ' You can display an error message or perform any other action here
            ' For demonstration purposes, let's display a message in the browser
            Response.Write("<script>alert('Sorry, no available mechanics found nearby or all mechanics are already assigned to service requests. Please try again later.')</script>")
        End If
    End Sub


    Private Function GetLatitude(requestId As Integer) As Double
        Dim latitude As Double = 0.0

        Dim query As String = "SELECT latitude FROM CServiceRequest WHERE requestid = @requestId"

        Using connection As New SqlConnection(co.connect())
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@requestId", requestId)
                connection.Open()
                Dim result As Object = command.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    latitude = Convert.ToDouble(result)
                End If
            End Using
        End Using

        Return latitude
    End Function

    Private Function GetLongitude(requestId As Integer) As Double
        Dim longitude As Double = 0.0

        Dim query As String = "SELECT longitude FROM CServiceRequest WHERE requestid = @requestId"

        Using connection As New SqlConnection(co.connect())
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@requestId", requestId)
                connection.Open()
                Dim result As Object = command.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    longitude = Convert.ToDouble(result)
                End If
            End Using
        End Using

        Return longitude
    End Function

    Private Function GetAvailableMechanics(latitude As Double, longitude As Double) As List(Of Mechanic)
        Dim mechanics As New List(Of Mechanic)()

        ' Fetch mechanics' locations from the database
        Dim query As String = "SELECT providerid, latitude, longitude FROM ServiceProvider"

        Using connection As New SqlConnection(co.connect())
            Using command As New SqlCommand(query, connection)
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim providerId As Integer = Convert.ToInt32(reader("providerid"))
                    Dim mechanicLatitude As Double = Convert.ToDouble(reader("latitude"))
                    Dim mechanicLongitude As Double = Convert.ToDouble(reader("longitude"))
                    ' Calculate the distance between the customer and mechanic
                    Dim distance As Double = CalculateDistance(latitude, longitude, mechanicLatitude, mechanicLongitude)
                    ' If the mechanic is within 5 km, add it to the list
                    If distance <= 5 Then
                        mechanics.Add(New Mechanic With {.ProviderId = providerId, .Latitude = mechanicLatitude, .Longitude = mechanicLongitude})
                    End If
                End While
            End Using
        End Using

        ' Return the list of mechanics within 5 km
        Return mechanics
    End Function

    Private Function FilterAssignedMechanics(mechanics As List(Of Mechanic)) As List(Of Mechanic)
        Dim unassignedMechanics As New List(Of Mechanic)()

        ' Query the database to fetch mechanics who are not already assigned to service requests
        Dim query As String = "SELECT providerid FROM ServiceProvider WHERE providerid NOT IN (SELECT DISTINCT providerid FROM CServiceRequest WHERE status <> 'Completed')"

        Using connection As New SqlConnection(co.connect())
            Using command As New SqlCommand(query, connection)
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim providerId As Integer = Convert.ToInt32(reader("providerid"))
                    ' Check if the mechanic is in the list of available mechanics
                    If mechanics.Any(Function(m) m.ProviderId = providerId) Then
                        unassignedMechanics.Add(mechanics.FirstOrDefault(Function(m) m.ProviderId = providerId))
                    End If
                End While
            End Using
        End Using

        ' Return the list of mechanics who are not already assigned to service requests
        Return unassignedMechanics
    End Function


    Private Function FindNearestMechanic(mechanics As List(Of Mechanic), customerLatitude As Double, customerLongitude As Double) As Mechanic
        Dim nearestMechanic As Mechanic = Nothing
        Dim shortestDistance As Double = Double.MaxValue

        For Each mechanic As Mechanic In mechanics
            Dim distance As Double = CalculateDistance(customerLatitude, customerLongitude, mechanic.Latitude, mechanic.Longitude)
            If distance < shortestDistance Then
                nearestMechanic = mechanic
                shortestDistance = distance
            End If
        Next

        Return nearestMechanic
    End Function

    Private Sub UpdateServiceRequest(requestId As Integer, providerId As Integer)
        ' Update the service request in the database with the provider ID of the nearest mechanic
        Dim query As String = "UPDATE CServiceRequest SET providerid = @providerId WHERE requestid = @requestId"

        Using connection As New SqlConnection(co.connect())
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@providerId", providerId)
                command.Parameters.AddWithValue("@requestId", requestId)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub


    Private Function CalculateDistance(latitude1 As Double, longitude1 As Double, latitude2 As Double, longitude2 As Double) As Double
        Dim earthRadius As Double = 6371 ' Earth radius in kilometers

        ' Convert latitude and longitude from degrees to radians
        Dim dLat As Double = DegreeToRadian(latitude2 - latitude1)
        Dim dLon As Double = DegreeToRadian(longitude2 - longitude1)

        ' Apply Haversine formula
        Dim a As Double = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                          Math.Cos(DegreeToRadian(latitude1)) * Math.Cos(DegreeToRadian(latitude2)) *
                          Math.Sin(dLon / 2) * Math.Sin(dLon / 2)

        Dim c As Double = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))

        ' Calculate the distance
        Dim distance As Double = earthRadius * c

        Return distance
    End Function

    Private Function DegreeToRadian(deg As Double) As Double
        Return deg * (Math.PI / 180)
    End Function



End Class
