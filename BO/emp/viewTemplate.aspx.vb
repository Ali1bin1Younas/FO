Imports MTBMS.DAL

Partial Class emp_viewTemplate
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim con As New DBTaskBO
        Dim qry As String = "Select temTempName From boTemplates where temID ='" & Request.QueryString("temid") & "'"
        Dim temName As String = con.getScalar(qry)
        Response.Redirect("../data/" & Request.QueryString("foID") & Request.QueryString("drID") & "/templates/" & temName)
    End Sub
End Class
