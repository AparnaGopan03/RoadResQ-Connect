Imports System.Data.SqlClient
Public Class TowingProfile
    Inherits System.Web.UI.Page
    Dim co As roadresq = New roadresq
   





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            Dim loggedInUser As String = Session("Username")
            If Not String.IsNullOrEmpty(loggedInUser) Then

                Dim query As String = "SELECT * FROM Towing WHERE Username = @Username"
                Using cmd As New SqlCommand(query, co.connect())
                    cmd.Parameters.AddWithValue("@Username", loggedInUser)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblEmail.Text = reader("Email").ToString()
                            lblUsername.Text = reader("Username").ToString()
                            lblName.Text = reader("Name").ToString()
                            lblDOB.Text = Convert.ToDateTime(reader("DOB")).ToString("dd/MM/yyyy")

                            lblAddress.Text = reader("servicecenter").ToString()
                            lblContactNumber.Text = reader("ContactNumber").ToString()
                            
                        End If
                    End Using
                End Using


            End If
        End If
    End Sub

End Class