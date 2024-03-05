Public Class SignIn
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub CustomerButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("CustomerSignIn.aspx")
    End Sub

    Protected Sub ProviderButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("ProviderSignIn.aspx")
    End Sub

    Protected Sub AdminButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("AdminSignIn.aspx")
    End Sub
End Class