Imports System.Data.SqlClient

Public Class Adminviewcust
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGridView()
        End If
    End Sub

    Protected Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim customerid As String = txtCustomerID.Text.Trim()

        If Not String.IsNullOrEmpty(customerid) Then
            Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"
            Dim query As String = "SELECT customerid, username, email, name, dob, gender, address, contactnumber FROM customer WHERE customerid = @custID"

            Using con As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@custID", customerid)
                    Dim dt As New DataTable()
                    con.Open()
                    dt.Load(cmd.ExecuteReader())
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                End Using
            End Using
        Else
            ' If the customer ID is empty, bind the grid with all data
            BindGridView()
        End If
    End Sub


    Private Sub BindGridView()
        ' Assuming you have a SQL Server database with a Users table
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"
        Dim query As String = "SELECT customerid, username, email, name, dob, gender, address, contactnumber FROM customer"

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, con)
                Dim dt As New DataTable()
                con.Open()
                dt.Load(cmd.ExecuteReader())
                GridView1.DataSource = dt
                GridView1.DataBind()
            End Using
        End Using
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim custID As String = GridView1.DataKeys(e.RowIndex).Value.ToString()

        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"
        Dim query As String = "DELETE FROM customer WHERE customerid = @custID"

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@custID", custID)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using


        BindGridView()
    End Sub

    Protected Function GetServiceRequests(customerId As Object) As String
        Dim totalRequests As Integer = 0

        ' Your connection string
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"

        ' SQL query to count the number of service requests for the given customer ID
        Dim query As String = "SELECT COUNT(*) FROM Cservicerequest WHERE customerid = @customerId"

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, con)
                ' Parameterized query to prevent SQL injection
                cmd.Parameters.AddWithValue("@customerId", customerId)
                con.Open()

                ' Execute the query and get the count of service requests
                totalRequests = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using

        ' Return the total number of service requests as a string
        Return totalRequests.ToString()
    End Function

End Class