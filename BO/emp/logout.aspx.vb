


Partial Class MD_logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session.RemoveAll()
        Session("traId") = 0
        Response.Redirect("../index.aspx")
    End Sub
End Class
