
Imports System.Data.SqlClient
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


End Class





