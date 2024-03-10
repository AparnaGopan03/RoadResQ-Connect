Imports System.Data.SqlClient

Public Class ProviderLocationAccessConfirmation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Client-side script to prompt for location access
        ClientScript.RegisterStartupScript(Me.GetType(), "confirm", "<script>if (confirm('Do you want to give access to your location?')) {window.location.href = 'ProviderSaveLocation.aspx';}</script>")

    End Sub

End Class



'Public Class ProviderLocationAccessConfirmation
'    Inherits System.Web.UI.Page

'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
'        ' Check if the location access confirmation is triggered by the user's action
'        If Request.QueryString("permission") = "true" Then
'            ' Show a confirmation prompt for location access
'            ClientScript.RegisterStartupScript(Me.GetType(), "confirm", "<script>if (confirm('Do you want to give access to your location?')) { window.location.href = 'ProviderSaveLocation.aspx?permission=true'; }</script>")
'        Else
'            ' Redirect back to profile page if permission is denied or if the request is not initiated by the user
'            Response.Redirect("ProviderProfile.aspx")
'        End If
'    End Sub

'End Class
