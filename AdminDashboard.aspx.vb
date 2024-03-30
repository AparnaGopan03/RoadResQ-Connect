Imports System.Data.SqlClient
Imports System.Web.Script.Serialization

Public Class AdminDashboard
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim articleCustomersCount As Integer = GetCustomersCount()
            topicHeading.InnerText = articleCustomersCount.ToString() ' Assuming topicHeading is the ID of your h2 element with class "topic-heading"
        End If

        If Not IsPostBack Then
            Dim articleProvidersCount As Integer = GetProvidersCount()
            topicHeading1.InnerText = articleProvidersCount.ToString()
        End If

        If Not IsPostBack Then
            Dim articleRequestsCount As Integer = GetRequestsCount()
            topicHeading2.InnerText = articleRequestsCount.ToString()
        End If

        If Not IsPostBack Then
            ' Call a method to retrieve data from the database
            Dim data As Dictionary(Of String, Integer) = RetrieveServiceRequestsData()

            ' Convert the data to JSON format
            Dim serializer As New JavaScriptSerializer()
            Dim jsonData As String = serializer.Serialize(data)

            ' Register the JSON data to be used in JavaScript
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "ChartData", "var serviceRequestData = " & jsonData & ";", True)
        End If

        If Not IsPostBack Then
            ' Fetch data from the database
            Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"
            Dim query As String = "SELECT totalcost FROM paymentdetail"
            Dim dataTable As New DataTable()

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    connection.Open()
                    Using adapter As New SqlDataAdapter(command)
                        adapter.Fill(dataTable)
                    End Using
                End Using
            End Using

            ' Prepare data for JavaScript
            Dim totalRevenueData As New Dictionary(Of String, Integer)()

            ' Convert DataTable to Dictionary
            For Each row As DataRow In dataTable.Rows
                Dim totalCost As Integer = Convert.ToInt32(row("totalcost"))
                ' You may want to customize the labels here, for now, we'll use generic labels like "Payment 1", "Payment 2", etc.
                totalRevenueData.Add("Paymentdetail " & (totalRevenueData.Count + 1), totalCost)
            Next

            ' Serialize the data to be used in JavaScript
            Dim serializer As New JavaScriptSerializer()
            Dim serializedData As String = serializer.Serialize(totalRevenueData)

            ' Register the serialized data as a JavaScript variable
            Dim script As String = "var totalRevenueData = " & serializedData & ";"
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "TotalRevenueData", script, True)
        End If

    End Sub

    Private Function GetCustomersCount() As Integer
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"
        Dim query As String = "SELECT COUNT(*) FROM customer"
        Dim count As Integer = 0

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                count = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using

        Return count
    End Function

    Private Function GetProvidersCount() As Integer
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"
        Dim query As String = "SELECT COUNT(*) FROM ServiceProvider"
        Dim count As Integer = 0

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                count = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using

        Return count
    End Function

    Private Function GetRequestsCount() As Integer
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"
        Dim query As String = "SELECT COUNT(*) FROM CServiceRequest"
        Dim count As Integer = 0

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                count = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using

        Return count
    End Function

    Private Function RetrieveServiceRequestsData() As Dictionary(Of String, Integer)
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"
        Dim query As String = "SELECT DATENAME(month, requesttime) AS MonthName, COUNT(*) AS RequestCount FROM cservicerequest GROUP BY DATENAME(month, requesttime)"
        Dim data As New Dictionary(Of String, Integer)()

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim monthName As String = reader("MonthName").ToString()
                        Dim requestCount As Integer = Convert.ToInt32(reader("RequestCount"))
                        data.Add(monthName, requestCount)
                    End While
                End Using
            End Using
        End Using

        Return data
    End Function

End Class