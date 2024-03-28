Imports System.Data.SqlClient
Public Class AdminComplaints
    Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            If Not IsPostBack Then
                BindGrid()
            End If
        End Sub

        Private Sub BindGrid()
            ' Retrieve complaints from database and bind to GridView
        Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"
        Dim query As String = "SELECT complaintid, customerid, providerid, complaintdetails, complaintstatus, complainttime, complaintrestime FROM complaints"
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        GridView1.DataSource = reader
                        GridView1.DataBind()
                    End Using
                End Using
            End Using
        End Sub

        Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
            If e.CommandName = "ResolveComplaint" Then
                Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
                Dim complaintID As String = GridView1.DataKeys(rowIndex).Value.ToString()
                Dim resolvedTime As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

                ' Update status and resolved time in the database
            Dim connectionString As String = "Data Source=LAPTOP-SFCGJITP;Initial Catalog=Roadside Assistance;User ID=sa;Password=123"
            Dim query As String = "UPDATE complaints SET complaintstatus = 'resolved', complaintrestime = @ResolvedTime WHERE complaintid = @ComplaintID"
                Using connection As New SqlConnection(connectionString)
                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@ResolvedTime", resolvedTime)
                        command.Parameters.AddWithValue("@ComplaintID", complaintID)
                        connection.Open()
                        command.ExecuteNonQuery()
                    End Using
                End Using

                ' Rebind the GridView to reflect changes
                BindGrid()
            End If
        End Sub

    
End Class
