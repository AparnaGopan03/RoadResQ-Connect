Imports System.Data.SqlClient

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

End Class