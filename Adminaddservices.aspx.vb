Imports System.Data.SqlClient
Public Class Adminaddservices
    Inherits System.Web.UI.Page

    Protected Sub btnAddService_Click(sender As Object, e As EventArgs) Handles btnAddService.Click
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"
        Dim query As String = "INSERT INTO Services (ServiceName, BaseCost, Description, AdditionalCharges) VALUES (@ServiceName, @BaseCost, @Description, @AdditionalChargesDescription)"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ServiceName", txtServiceName.Text)
                command.Parameters.AddWithValue("@BaseCost", Convert.ToDecimal(txtBaseCost.Text))
                command.Parameters.AddWithValue("@Description", txtDescription.Text)
                command.Parameters.AddWithValue("@AdditionalChargesDescription", txtAdditionalCharges.Text)

                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using

        txtServiceName.Text = ""
        txtBaseCost.Text = ""
        txtDescription.Text = ""
        txtAdditionalCharges.Text = ""

    End Sub

    Protected Sub btnAddService_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("AdminDashboard.aspx")
    End Sub
End Class
