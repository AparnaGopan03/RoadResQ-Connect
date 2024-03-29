Imports System.Web
Imports System.Web.Services
Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class CheckForUpdates
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        ' Check if the user is authenticated
        If Not context.Request.IsAuthenticated Then
            context.Response.StatusCode = 403 ' Forbidden
            Return
        End If

        Try
            ' Check for updates in the database
            Dim updatedProviderId As Integer = CheckForUpdatedProviderId()

            ' Prepare JSON response
            Dim serializer As New JavaScriptSerializer()
            Dim jsonResponse As String = serializer.Serialize(New With {
                .updatedProviderId = updatedProviderId
            })

            ' Send JSON response back to the client
            context.Response.ContentType = "application/json"
            context.Response.Write(jsonResponse)
        Catch ex As Exception
            ' Log the error
            ' You can use a logging framework or simply output the error to a log file
            ' Example: System.IO.File.AppendAllText("error.log", ex.ToString())

            ' Set HTTP status code to 500 (Internal Server Error)
            context.Response.StatusCode = 500

            ' Write the error message to the response
            context.Response.ContentType = "text/plain"
            context.Response.Write("An error occurred while processing the request: " & ex.Message)
        End Try
    End Sub

    Function CheckForUpdatedProviderId() As Integer
        Dim updatedProviderId As Integer = 0

        ' Connection string to your SQL Server database
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"

        ' SQL query to check for the latest providerid updates
        Dim query As String = "SELECT TOP 1 providerid FROM cservicerequest ORDER BY requesttime DESC"

        Try
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    connection.Open()
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        updatedProviderId = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Log the error
            ' You can use a logging framework or simply output the error to a log file
            ' Example: System.IO.File.AppendAllText("error.log", ex.ToString())

            ' Rethrow the exception to be caught by the ProcessRequest method
            Throw New Exception("An error occurred while querying the database.", ex)
        End Try

        Return updatedProviderId
    End Function

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class
