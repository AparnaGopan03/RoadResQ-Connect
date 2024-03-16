Imports System.Data.SqlClient

Public Class CustomerServiceSearch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Load mechanics data initially
            LoadMechanics()
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ' Perform search based on service area and assistance type
        Dim serviceArea As String = txtSearch.Value
        Dim assistanceType As String = ddlAssistanceType.SelectedValue

        ' Call method to filter mechanics based on search criteria
        Dim filteredMechanics As DataTable = FilterMechanics(serviceArea, assistanceType)

        ' Display filtered mechanics
        DisplayMechanics(filteredMechanics)
    End Sub

    Private Sub LoadMechanics()
        ' Load all mechanics initially
        Dim allMechanics As DataTable = GetAllMechanics()

        ' Display all mechanics
        DisplayMechanics(allMechanics)
    End Sub

    Private Function GetAllMechanics() As DataTable
        ' Fetch all mechanics data from the database
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "SELECT Name, ContactNumber, AssistanceType, YearsOfExperience,Address FROM ServiceProvider"

        Dim dt As New DataTable()
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                Dim adapter As New SqlDataAdapter(command)
                adapter.Fill(dt)
            End Using
        End Using

        Return dt
    End Function

    Private Function FilterMechanics(ByVal serviceArea As String, ByVal assistanceType As String) As DataTable
        ' Filter mechanics based on service area and assistance type
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "SELECT Name, ContactNumber,Address, AssistanceType, YearsOfExperience,Address FROM ServiceProvider WHERE ServiceArea = @ServiceArea AND AssistanceType = @AssistanceType"

        Dim dt As New DataTable()
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ServiceArea", serviceArea)
                command.Parameters.AddWithValue("@AssistanceType", assistanceType)
                connection.Open()
                Dim adapter As New SqlDataAdapter(command)
                adapter.Fill(dt)
            End Using
        End Using

        Return dt
    End Function

    Private Sub DisplayMechanics(ByVal mechanics As DataTable)
        ' Clear previous content
        mechanicsContainer.InnerHtml = ""

        ' Check if there are any rows in the DataTable
        If mechanics.Rows.Count > 0 Then
            ' Iterate over mechanics and create card elements
            For Each row As DataRow In mechanics.Rows
                Dim name As String = row("Name").ToString()
                Dim contactNumber As String = row("ContactNumber").ToString()
                Dim assistanceType As String = row("AssistanceType").ToString()
                Dim yearsOfExperience As String = row("YearsOfExperience").ToString()
                Dim address As String = row("Address").ToString()

                Dim cardHtml As String = "<div class='mechanic-card'><div class='container'>"
                cardHtml &= "<h3>" & name & "</h3>"
                cardHtml &= "<p>Contact Number: " & contactNumber & "</p>"
                cardHtml &= "<p>Assistance Type: " & assistanceType & "</p>"
                cardHtml &= "<p>Years of Experience: " & yearsOfExperience & "</p>"
                cardHtml &= "<p>Address: " & address & "</p>"
                cardHtml &= "</div></div>"

                mechanicsContainer.InnerHtml &= cardHtml
            Next
        Else
            ' Display "No records available" message
            mechanicsContainer.InnerHtml = "<p>No records available</p>"
        End If
    End Sub

End Class
