
Partial Class BO_MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("empID") = Nothing Then
            Response.Redirect("../index.aspx")
        End If

    End Sub
End Class

