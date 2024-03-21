Public Class PaymentSuccess
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnBackHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("CustomerProfile.aspx")
    End Sub
End Class