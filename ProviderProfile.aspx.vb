Imports System.Data.SqlClient
Public Class ProviderProfile
    Inherits System.Web.UI.Page
    Dim co As roadresq = New roadresq
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            Dim loggedInUser As String = Session("Username")
            If Not String.IsNullOrEmpty(loggedInUser) Then

                Dim query As String = "SELECT * FROM ServiceProvider WHERE Username = @Username"
                Using cmd As New SqlCommand(query, co.connect())
                    cmd.Parameters.AddWithValue("@Username", loggedInUser)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblEmail.Text = reader("Email").ToString()
                            lblUsername.Text = reader("Username").ToString()
                            lblName.Text = reader("Name").ToString()
                            lblDOB.Text = Convert.ToDateTime(reader("DOB")).ToString("dd/MM/yyyy")
                            lblGender.Text = reader("Gender").ToString()
                            lblAddress.Text = reader("Address").ToString()
                            lblContactNumber.Text = reader("ContactNumber").ToString()
                            lblExperience.Text = reader("yearsofexperience").ToString()
                            lblarea.Text = reader("ServiceArea").ToString()
                        End If
                    End Using
                End Using


            End If
        End If
    End Sub

   

    
    'Protected Sub btnUpdate1_Click(sender As Object, e As EventArgs) Handles btnUpdate1.Click
    '    ' Client-side script to prompt for location access
    '    ClientScript.RegisterStartupScript(Me.GetType(), "confirm", "<script>if (confirm('Do you want to give access to your location?')) {window.location.href = 'ProviderSaveLocation.aspx';}</script>")

    'End Sub

End Class





