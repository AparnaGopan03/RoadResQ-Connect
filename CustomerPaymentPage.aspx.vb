Imports System.Data.SqlClient

Public Class CustomerPaymentPage
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Retrieve the request ID from the query string
            Dim requestId As String = Request.QueryString("RequestId")

            If Not String.IsNullOrEmpty(requestId) Then
                Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123;"
                Dim query As String = "SELECT sd.servicename, sd.basecost, sd.extracost, sd.extracostdetails " & _
                                      "FROM paymentdetail sd " & _
                                      "INNER JOIN cservicerequest sr ON sd.requestid = sr.requestid " & _
                                      "WHERE sr.requestid = @RequestId"

                Using connection As New SqlConnection(connectionString)
                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@RequestId", requestId)

                        Try
                            connection.Open()
                            Dim reader As SqlDataReader = command.ExecuteReader()

                            If reader.HasRows Then
                                reader.Read()

                                ' Populate labels with payment details
                                LabelServiceName.Text = reader("servicename").ToString()
                                LabelBaseCost.Text = Convert.ToDecimal(reader("basecost")).ToString("C")
                                LabelExtraCost.Text = Convert.ToDecimal(reader("extracost")).ToString("C")
                                LabelExtraCostDetails.Text = reader("extracostdetails").ToString()

                            Else
                                ' No payment details found for the provided request ID
                                ' Handle this scenario (e.g., display an error message)
                            End If
                        Catch ex As Exception
                            ' Handle any exceptions (e.g., log or display error message)
                        Finally
                            connection.Close()
                        End Try
                    End Using
                End Using
            Else
                ' Request ID is not available in the query string
                ' Handle this scenario (e.g., display an error message or redirect)
            End If
        End If
    End Sub




    Protected Sub ButtonPay_Click(sender As Object, e As EventArgs) Handles ButtonPay.Click
        Response.Redirect("PaymentFrom.aspx")
    End Sub

End Class