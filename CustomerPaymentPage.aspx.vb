Imports System.Data.SqlClient

Public Class CustomerPaymentPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack AndAlso Request.QueryString("RequestId") IsNot Nothing Then
            Dim requestId As String = Request.QueryString("RequestId")
            FetchAndDisplayPaymentDetails(requestId)
        End If
    End Sub

    Private Sub FetchAndDisplayPaymentDetails(requestId As String)
        ' Fetch payment details from the database based on the RequestId
        Dim paymentDetails As DataTable = FetchPaymentDetails(requestId)

        If paymentDetails.Rows.Count > 0 Then
            LabelServiceName.Text = paymentDetails.Rows(0)("ServiceName").ToString()
            LabelBaseCost.Text = paymentDetails.Rows(0)("BaseCost").ToString()
            LabelExtraCost.Text = paymentDetails.Rows(0)("ExtraCost").ToString()
            LabelExtraCostDetails.Text = paymentDetails.Rows(0)("ExtraCostDetails").ToString()
        End If
    End Sub

    Private Function FetchPaymentDetails(requestId As String) As DataTable
        Dim paymentDetails As New DataTable()

        ' Use your connection string
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
        Dim query As String = "SELECT  servicename,basecost,extracost,extracostdetails FROM paymentdetail WHERE requestid = @RequestId"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@RequestId", requestId)

                Dim adapter As New SqlDataAdapter(command)
                adapter.Fill(paymentDetails)
            End Using
        End Using

        Return paymentDetails
    End Function


    Protected Sub ButtonPay_Click(sender As Object, e As EventArgs)
        ' Handle the payment process here
        ' This could involve redirecting to a payment gateway or performing any other payment-related action
    End Sub

End Class