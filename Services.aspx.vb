Public Class ProviderServices
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub CustomerButton_Click(sender As Object, e As EventArgs) Handles CustomerButton.Click
        Response.Redirect("ProviderSignUp.aspx")
    End Sub

    Protected Sub ProviderButton_Click(sender As Object, e As EventArgs) Handles ProviderButton.Click
        Response.Redirect("TowingSignUp.aspx")
    End Sub
End Class