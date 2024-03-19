Imports System.Data.SqlClient
Public Class PaymentDetailsPage
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Check if RequestId is provided in the query string
            If Request.QueryString("RequestId") IsNot Nothing Then
                Dim requestId As String = Request.QueryString("RequestId")
                ' You can use the requestId as needed, for example, to display it on the page or store it for later use.
            End If
            ' Load services into dropdown
            LoadServices()
        End If
    End Sub



    Protected Sub LoadServices()
        ' Retrieve services from the database
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "SELECT ServiceName, BaseCost FROM services"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                DropDownListService.DataSource = reader
                DropDownListService.DataTextField = "ServiceName"
                DropDownListService.DataValueField = "BaseCost"
                DropDownListService.DataBind()
                reader.Close()
            End Using
        End Using
    End Sub

    Protected Sub DropDownListService_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListService.SelectedIndexChanged
        ' Display cost for selected service
        TextBoxCost.Text = DropDownListService.SelectedValue
    End Sub

    Protected Sub ButtonSubmit_Click(sender As Object, e As EventArgs)
        ' Save payment details to the database
        Dim requestId As String = Request.QueryString("RequestId")
        Dim serviceName As String = DropDownListService.SelectedItem.Text
        Dim cost As Decimal = Decimal.Parse(TextBoxCost.Text)
        Dim extracost As String = TextBoxExtracost.Text
        Dim extraDetails As String = TextBoxExtracostDetails.Text


        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "INSERT INTO paymentdetail (RequestId, ServiceName, BaseCost, ExtraCost, ExtraCostDetails) VALUES (@RequestId, @ServiceName, @BaseCost, @ExtraCost, @ExtraCostDetails)"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@RequestId", requestId)
                command.Parameters.AddWithValue("@ServiceName", serviceName)
                command.Parameters.AddWithValue("@BaseCost", cost)
                command.Parameters.AddWithValue("@ExtraCost", extracost)
                command.Parameters.AddWithValue("@ExtraCostDetails", extraDetails)
                connection.Open()
                command.ExecuteNonQuery()
            End Using

            TextBoxCost.Text = ""
            TextBoxExtracost.Text = ""
            TextBoxExtracostDetails.Text = ""

        End Using

        
    End Sub

   

    Protected Sub btnSearch_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("ProviderProfile.aspx")
    End Sub
End Class





