
Partial Class MD_confirmation
    Inherits System.Web.UI.Page

    Protected Sub btnDone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDone.Click
        Response.Redirect("dailyworkload.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empID") = "" Then Response.Redirect(GF.Home)
        Dim strConfirmationMessage As String = Nothing
        strConfirmationMessage = Session("confirmationMessage")
        lblConfirmationMessage.Text = strConfirmationMessage
    End Sub
End Class
