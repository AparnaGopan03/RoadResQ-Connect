
Imports System.Data.SqlClient

Public Class Adminviewsr
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
            Dim query As String = "SELECT * FROM cservicerequest WHERE customerid = @custID"

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
        Dim query As String = "SELECT requestid,customerid,vehicletype,make,model,year,licenseplatenumber,color,requesttime,providerid,status,assistancetype,completionstatus  FROM cservicerequest"

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


    Protected Sub btnFilter_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim providerid As String = TextBox1.Text.Trim()

        If Not String.IsNullOrEmpty(providerid) Then
            Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"
            Dim query As String = "SELECT * FROM cservicerequest WHERE providerid = @custID"

            Using con As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@custID", providerid)
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

    Protected Sub btnFilter_Click2(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sdate As String = TextBox2.Text.Trim()

        ' Validate date format
        Dim dateValue As DateTime
        If DateTime.TryParse(sdate, dateValue) Then
            Try
                Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"
                Dim query As String = "SELECT * FROM cservicerequest WHERE CONVERT(date, requesttime) = @sdate"

                Using con As New SqlConnection(connectionString)
                    Using cmd As New SqlCommand(query, con)
                        cmd.Parameters.AddWithValue("@sdate", dateValue)
                        Dim dt As New DataTable()
                        con.Open()
                        dt.Load(cmd.ExecuteReader())
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                    End Using
                End Using
            Catch ex As Exception
                ' Handle any database errors here
                ' Display a friendly error message or log the exception
                ' Don't forget to BindGridView() or handle the error appropriately
                BindGridView()
            End Try
        Else
            ' Invalid date format, display an error message or handle it appropriately
            ' For example:
            ' lblErrorMessage.Text = "Invalid date format. Please enter a valid date."
        End If
    End Sub


    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Response.Redirect("AdminDashboard.aspx")
    End Sub
End Class