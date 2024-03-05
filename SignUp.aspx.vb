Public Class SignUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub CustomerButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("CustomerSignUp.aspx")
    End Sub

    Protected Sub ProviderButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("ProviderSignUp.aspx")
    End Sub
End Class