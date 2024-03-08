Imports System.Data.SqlClient
Public Class ProviderLocationAccessConfirmation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Client-side script to prompt for location access
        ClientScript.RegisterStartupScript(Me.GetType(), "confirm", "<script>if (confirm('Do you want to give access to your location?')) {window.location.href = 'ProviderSaveLocation.aspx';}</script>")

    End Sub

End Class



