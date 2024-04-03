Imports System.Data.SqlClient

Public Class CustomerChatInterface
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Display previous messages
            DisplayChatHistory()
        End If
    End Sub

    Protected Sub btnSend_Click(sender As Object, e As EventArgs)
        ' Get the logged-in customer's username from the session
        Dim username As String = Session("Username")

        ' Get the customer ID using the username
        Dim customerId As Integer = GetCustomerIdByUsername(username)

        ' Parse provider ID from the query string or session
        Dim providerId As Integer
        If Integer.TryParse(Request.QueryString("providerId"), providerId) Then
            ' Get the message text from the text box
            Dim messageText As String = txtMessage.Text

            ' Insert the message into the database
            InsertMessage(customerId, providerId, messageText)

            ' Display the sent message in the chat area
            chatArea.InnerHtml &= "<p><strong>Customer:</strong> " & messageText & "</p>"
        Else
            ' Handle the case where providerId cannot be parsed as an integer
            ' This could be due to an invalid or missing providerId in the query string
            ' You can display an error message or take other appropriate action
        End If
    End Sub

    Private Sub DisplayChatHistory()
        ' Check if the query string parameter "providerId" exists
        Dim providerIdQueryString As String = Request.QueryString("providerId")
        Dim providerId As Integer

        If Not String.IsNullOrEmpty(providerIdQueryString) AndAlso Integer.TryParse(providerIdQueryString, providerId) Then
            ' Get the logged-in customer's username from the session
            Dim username As String = Session("Username")

            ' Get the customer ID using the username
            Dim customerId As Integer = GetCustomerIdByUsername(username)

            ' Fetch previous chats from the database
            Dim chatHistory As String = GetChatHistory(customerId, providerId)

            ' Display the chat history in the chat area
            chatArea.InnerHtml = chatHistory
        Else
            ' Handle the case where "providerId" is missing or not a valid integer
            ' For example, you could display an error message or take other appropriate action
            chatArea.InnerHtml = "Error: Invalid or missing provider ID."
        End If
    End Sub


    Private Function GetCustomerIdByUsername(username As String) As Integer
        ' Initialize the customer ID variable
        Dim customerId As Integer = -1

        ' Your connection string to the SQL Server database
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"

        ' SQL query to select the customer ID based on the username
        Dim query As String = "SELECT CustomerID FROM Customer WHERE Username = @Username"

        ' Create a new SQL connection
        Using connection As New SqlConnection(connectionString)
            ' Create a SQL command with parameters
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Username", username)

                Try
                    ' Open the database connection
                    connection.Open()

                    ' Execute the SQL command to fetch the customer ID
                    Dim result As Object = command.ExecuteScalar()

                    ' Check if the result is not null and convert it to an integer
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        customerId = Convert.ToInt32(result)
                    End If
                Catch ex As Exception
                    ' Handle any exceptions (e.g., log error, display error message)
                    ' For example:
                    ' Console.WriteLine("Error retrieving customer ID: " & ex.Message)
                End Try
            End Using
        End Using

        ' Return the customer ID
        Return customerId
    End Function


    Private Function GetChatHistory(customerId As Integer, providerId As Integer) As String
        ' Initialize the chat history string builder
        Dim chatHistory As New StringBuilder()

        ' Your connection string to the SQL Server database
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"

        ' SQL query to select messages between the customer and provider
        Dim query As String = "SELECT CustomerID, ProviderID, MessageText FROM Messages WHERE (CustomerID = @CustomerId AND ProviderID = @ProviderId) OR (CustomerID = @ProviderId AND ProviderID = @CustomerId) ORDER BY MessageID"

        ' Create a new SQL connection
        Using connection As New SqlConnection(connectionString)
            ' Create a SQL command with parameters
            Using command As New SqlCommand(query, connection)
                ' Add parameters for customer ID and provider ID
                command.Parameters.AddWithValue("@CustomerId", customerId)
                command.Parameters.AddWithValue("@ProviderId", providerId)

                Try
                    ' Open the database connection
                    connection.Open()

                    ' Execute the SQL command to fetch messages
                    Dim reader As SqlDataReader = command.ExecuteReader()

                    ' Iterate through the result set and append messages to chat history
                    While reader.Read()
                        ' Determine whether the message was sent by the provider or the customer
                        ' Determine whether the message was sent by the provider or the customer
                        Dim senderId As Integer = Convert.ToInt32(reader("CustomerID"))

                        Dim senderType As String
                        If senderId = providerId Then
                            senderType = "Provider"
                        ElseIf senderId = customerId Then
                            senderType = "Customer"
                        Else
                            ' Handle the case where senderId does not match either providerId or customerId
                            senderType = "Unknown" ' Or you can skip this message entirely
                        End If

                        ' Debugging statements
                        Console.WriteLine("SenderId: " & senderId)
                        Console.WriteLine("CustomerId: " & customerId)
                        Console.WriteLine("ProviderId: " & providerId)
                        Console.WriteLine("SenderType: " & senderType)



                        ' Append the message with the sender's identifier to the chat history string builder
                        chatHistory.AppendLine("<p><strong>" & senderType & ":</strong> " & reader("MessageText").ToString() & "</p>")
                    End While

                Catch ex As Exception
                    ' Handle any exceptions (e.g., log error, display error message)
                    ' For example:
                    ' Console.WriteLine("Error retrieving chat history: " & ex.Message)
                End Try
            End Using
        End Using

        ' Return the chat history as a string
        Return chatHistory.ToString()
    End Function

    Private Sub InsertMessage(customerId As Integer, providerId As Integer, messageText As String)
        ' Your connection string to the SQL Server database
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"

        ' SQL query to insert a new message into the Messages table
        Dim query As String = "INSERT INTO Messages (CustomerId, ProviderId, MessageText) VALUES (@CustomerId, @ProviderId, @MessageText)"

        ' Create a new SQL connection
        Using connection As New SqlConnection(connectionString)
            ' Create a SQL command with parameters
            Using command As New SqlCommand(query, connection)
                ' Add parameters for customer ID, provider ID, and message text
                command.Parameters.AddWithValue("@CustomerId", customerId)
                command.Parameters.AddWithValue("@ProviderId", providerId)
                command.Parameters.AddWithValue("@MessageText", messageText)

                Try
                    ' Open the database connection
                    connection.Open()

                    ' Execute the SQL command to insert the message
                    command.ExecuteNonQuery()
                Catch ex As Exception
                    ' Handle any exceptions (e.g., log error, display error message)
                    ' For example:
                    ' Console.WriteLine("Error inserting message: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

End Class
