Imports System.Web.Security

Public Class LogOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
' Clear the authentication cookie
        FormsAuthentication.SignOut()

        ' Disable caching
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1))
        Response.Cache.SetNoStore()

        ' Redirect the user to the home page or any other appropriate destination
        Response.Redirect("~/Home.aspx")
    End Sub


End Class