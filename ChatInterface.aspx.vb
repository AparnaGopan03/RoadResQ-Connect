Imports System.Data.SqlClient

Public Class ChatInterface
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DisplayChatHistory()
    End Sub

    Protected Sub btnStartChat_Click(sender As Object, e As EventArgs)
        ' Get the logged in provider's username from the session
        Dim providerUsername As String = Session("Username")

        ' Get the provider ID using the username
        Dim providerId As Integer = GetProviderIdByUsername(providerUsername)

        ' Get the customer ID entered by the provider
        Dim customerId As Integer
        If Integer.TryParse(txtCustomerId.Text, customerId) Then
            ' Validate if the customer ID exists and initiate the chat
            If CustomerExists(customerId) Then
                ' If the customer ID is valid, show the chat interface
                pnlChatInterface.Visible = True
                ' You can also provide a message indicating successful validation, if needed
                lblChat.Text = "Chat initiated with customer ID: " & customerId

            Else
                lblChat.Text = "Customer not found."
            End If
        Else
            lblChat.Text = "Invalid customer ID."
        End If

    End Sub


    Private Function GetProviderIdByUsername(username As String) As Integer
        Dim providerId As Integer = -1 ' Default value indicating failure to retrieve ID

        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "SELECT ProviderID FROM ServiceProvider WHERE Username = @Username"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Username", username)

                connection.Open()
                Dim result As Object = command.ExecuteScalar()

                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    providerId = Convert.ToInt32(result)
                End If
            End Using
        End Using

        Return providerId
    End Function

    Protected Sub btnSend_Click(sender As Object, e As EventArgs)
        ' Get the logged-in provider's ID
        Dim providerUsername As String = Session("Username")
        Dim providerId As Integer = GetProviderIdByUsername(providerUsername)

        ' Get the customer ID from the text box
        Dim customerId As Integer = Integer.Parse(txtCustomerId.Text)

        ' Get the message text from the text box
        Dim messageText As String = txtMessage.Text

        ' Insert the message into the database
        InsertMessage(customerId, providerId, messageText)

        'Display the sent message in the chat area
        chatArea.InnerHtml &= "<p><strong>Provider:</strong> " & messageText & "</p>"
    End Sub

    Private Sub InsertMessage(senderId As Integer, receiverId As Integer, messageText As String)
        ' Your database connection string
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"

        ' SQL query to insert the message into the database
        Dim query As String = "INSERT INTO Messages (customerid, providerid, MessageText) VALUES (@SenderID, @ReceiverID, @MessageText)"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@SenderID", senderId)
                command.Parameters.AddWithValue("@ReceiverID", receiverId)
                command.Parameters.AddWithValue("@MessageText", messageText)

                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub



    Private Function CustomerExists(customerId As Integer) As Boolean
        Dim exists As Boolean = False

        ' Connection string to your database
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"

        ' SQL query to check if the customer exists
        Dim query As String = "SELECT COUNT(*) FROM Customer WHERE CustomerID = @CustomerId"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Parameterized query to prevent SQL injection
                command.Parameters.AddWithValue("@CustomerId", customerId)

                connection.Open()
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())

                ' If count is greater than 0, customer exists
                If count > 0 Then
                    exists = True
                End If
            End Using
        End Using

        Return exists
    End Function

    Private Sub DisplayChatHistory()
        ' Get the logged-in provider's username from the session
        Dim providerUsername As String = Session("Username")
        Dim providerId As Integer = GetProviderIdByUsername(providerUsername)

        ' Initialize customerId variable
        Dim customerId As Integer

        ' Attempt to parse the text from the txtCustomerId TextBox to an integer
        If Integer.TryParse(txtCustomerId.Text, customerId) Then
            ' Fetch previous chats from the database
            Dim chatHistory As String = GetChatHistory(providerId, customerId)

            ' Display the chat history in the chat area
            chatArea.InnerHtml = chatHistory
        Else
            ' Handle the case where the text in txtCustomerId TextBox is not a valid integer
            ' For example, you could display an error message or take other appropriate action
            lblChat.Text = "Invalid customer ID."
        End If
    End Sub


    Private Function GetChatHistory(providerId As Integer, customerId As Integer) As String
        Dim chatHistory As New StringBuilder()

        Try
            ' Your database connection string
            Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"

            ' SQL query to fetch all messages for the given provider and customer
            Dim query As String = "SELECT customerID, providerID, MessageText FROM Messages WHERE (ProviderID = @ProviderID AND CustomerID = @CustomerID) OR (ProviderID = @CustomerID AND CustomerID = @ProviderID) ORDER BY MessageID"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ProviderID", providerId)
                    command.Parameters.AddWithValue("@CustomerID", customerId)

                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()

                    ' Iterate through the result set and append messages to chat history
                    While reader.Read()
                        Dim senderId As Integer = Convert.ToInt32(reader("providerID"))
                        Dim receiverId As Integer = Convert.ToInt32(reader("customerID"))
                        Dim messageText As String = reader("MessageText").ToString()

                        ' Determine whether the message was sent by the provider or the customer
                        Dim senderType As String = If(senderId = providerId, "Provider", "Customer")

                        ' Append the message to chat history
                        chatHistory.AppendLine("<p><strong>" & senderType & ":</strong> " & messageText & "</p>")
                    End While
                End Using
            End Using
        Catch ex As Exception
            ' Handle any exceptions (e.g., display error message, log error)
            Console.WriteLine("Error retrieving chat history: " & ex.Message)
        End Try

        Return chatHistory.ToString()
    End Function



End Class