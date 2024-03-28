Imports System.Data.SqlClient
Imports System.Linq

Public Class CustomerServiceRequest
    Inherits System.Web.UI.Page
    Dim co As roadresq = New roadresq
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim assistanceType As String = assistanceTypeDropDown.Value
        Dim vehicleType As String = vehicleTypeTextBox.Text
        Dim make As String = makeTextBox.Text
        Dim model As String = modelTextBox.Text
        Dim year As Integer = Convert.ToInt32(yearTextBox.Text)
        Dim licensePlateNumber As String = licensePlateTextBox.Text
        Dim color As String = colorTextBox.Text
        Dim latitude As Double = Convert.ToDouble(latitudeHiddenField.Value)
        Dim longitude As Double = Convert.ToDouble(longitudeHiddenField.Value)

        ' Get user ID from session or authentication
        Dim customerId As Integer = GetCustomerId()

        ' Insert service request details into the CServiceRequest table
        Dim sqlInsertRequest As String = "INSERT INTO CServiceRequest (customerid, vehicletype, make, model, year, licenseplatenumber, color, requesttime, assistancetype, latitude, longitude, status) " &
                                          "VALUES (@customerId, @vehicleType, @make, @model, @year, @licensePlateNumber, @color, GETDATE(), @assistanceType, @latitude, @longitude, 'Pending')"

        Using command As New SqlCommand(sqlInsertRequest, co.connect())
            command.Parameters.AddWithValue("@customerId", customerId)
            command.Parameters.AddWithValue("@vehicleType", vehicleType)
            command.Parameters.AddWithValue("@make", make)
            command.Parameters.AddWithValue("@model", model)
            command.Parameters.AddWithValue("@year", year)
            command.Parameters.AddWithValue("@licensePlateNumber", licensePlateNumber)
            command.Parameters.AddWithValue("@color", color)
            command.Parameters.AddWithValue("@assistanceType", assistanceType)
            command.Parameters.AddWithValue("@latitude", latitude)
            command.Parameters.AddWithValue("@longitude", longitude)


            command.ExecuteNonQuery()
        End Using

        ' Display success message
        lblMessage.Text = "Request submitted successfully."
        lblMessage.Visible = True

        ' Clear input fields
        vehicleTypeTextBox.Text = ""
        makeTextBox.Text = ""
        modelTextBox.Text = ""
        yearTextBox.Text = ""
        licensePlateTextBox.Text = ""
        colorTextBox.Text = ""

        ' Fetch available mechanics from the database
        Dim mechanics As List(Of Mechanic) = GetAvailableMechanics(latitude, longitude)

        ' Filter out mechanics who are already assigned to service requests
        mechanics = FilterAssignedMechanics(mechanics, assistanceType)


        ' Find the nearest mechanic
        Dim nearestMechanic As Mechanic = FindNearestMechanic(mechanics, latitude, longitude)

        If nearestMechanic IsNot Nothing Then
            ' Update ServiceRequest table with the nearest mechanic's providerid
            UpdateServiceRequest(nearestMechanic.ProviderId)

            ' Send service request to the nearest mechanic
            SendServiceRequest(nearestMechanic)
        Else
            ' Handle case where no mechanics are found within 5 km
            ' Or handle case where all mechanics are already assigned to service requests
            ' You can display an error message or perform any other action here
            ' For demonstration purposes, let's display a message in the browser
            Response.Write("<script>alert('Sorry, no available mechanics found nearby or all mechanics are already assigned to service requests. Please try again later.')</script>")
        End If


        ' Redirect or display confirmation message
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


    Private Function GetAvailableMechanics(customerLatitude As Double, customerLongitude As Double) As List(Of Mechanic)
        Dim mechanics As New List(Of Mechanic)()

        ' Fetch mechanics' locations from the database
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "SELECT providerid, latitude, longitude FROM ServiceProvider"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim providerId As Integer = Convert.ToInt32(reader("providerid"))
                    Dim latitude As Double = Convert.ToDouble(reader("latitude"))
                    Dim longitude As Double = Convert.ToDouble(reader("longitude"))
                    ' Create a new Mechanic object and add it to the list
                    mechanics.Add(New Mechanic With {.ProviderId = providerId, .Latitude = latitude, .Longitude = longitude})
                End While
            End Using
        End Using

        ' Return only mechanics within 5 km of the customer
        Return mechanics.Where(Function(m) CalculateDistance(customerLatitude, customerLongitude, m.Latitude, m.Longitude) <= 5).ToList()
    End Function


    Private Function FilterAssignedMechanics(mechanics As List(Of Mechanic), assistanceType As String) As List(Of Mechanic)
        ' Create a list to store mechanics not already assigned to service requests
        Dim unassignedMechanics As New List(Of Mechanic)()

        ' Establish database connection
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "SELECT providerid, assistancetype FROM ServiceProvider WHERE assistancetype = @assistanceType"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@assistanceType", assistanceType)
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    If Not reader.IsDBNull(reader.GetOrdinal("providerid")) Then
                        Dim assignedProviderId As Integer = Convert.ToInt32(reader("providerid"))
                        ' Filter out mechanics already assigned to service requests
                        If Not mechanics.Any(Function(m) m.ProviderId = assignedProviderId) Then
                            ' Add the mechanic to the list if they provide the requested assistance type and are not assigned to any service request
                            unassignedMechanics.Add(New Mechanic With {
                                .ProviderId = assignedProviderId,
                                .AssistanceType = reader.GetString(reader.GetOrdinal("assistancetype"))
                            })
                        End If
                    End If
                End While
            End Using
        End Using

        ' Return the list of mechanics not already assigned to service requests
        Return unassignedMechanics
    End Function





    Private Function FindNearestMechanic(mechanics As List(Of Mechanic), customerLatitude As Double, customerLongitude As Double) As Mechanic
        If mechanics.Count > 0 Then
            ' Find the nearest mechanic
            Return mechanics.OrderBy(Function(m) CalculateDistance(customerLatitude, customerLongitude, m.Latitude, m.Longitude)).FirstOrDefault()
        Else
            Return Nothing
        End If
    End Function

    Private Sub UpdateServiceRequest(providerId As Integer)
        ' Establish database connection
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "UPDATE CServiceRequest SET providerid = @providerId WHERE requestid = (SELECT TOP 1 requestid FROM CServiceRequest WHERE providerid IS NULL ORDER BY requesttime)"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@providerId", providerId)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub


    Private Sub SendServiceRequest(mechanic As Mechanic)
        
    End Sub

    Private Function CalculateDistance(latitude1 As Double, longitude1 As Double, latitude2 As Double, longitude2 As Double) As Double
        Dim earthRadius As Double = 6371 ' Earth radius in kilometers
        Dim dLat As Double = DegreeToRadian(latitude2 - latitude1)
        Dim dLon As Double = DegreeToRadian(longitude2 - longitude1)
        Dim a As Double = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(DegreeToRadian(latitude1)) * Math.Cos(DegreeToRadian(latitude2)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
        Dim c As Double = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))
        Dim distance As Double = earthRadius * c
        Return distance
    End Function

    Private Function DegreeToRadian(deg As Double) As Double
        Return deg * (Math.PI / 180)
    End Function


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("CustomerProfile.aspx")
    End Sub
End Class
