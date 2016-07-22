Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class MMO_viewfax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        Dim strdrID As String = Request.QueryString("drID")
        Dim Con As New DBTaskBO
        Dim Qry As String = "Select * From mmoFax where drID='" & strdrID & "'"
        Dim ds As DataSet
        ds = Con.getDataSet(Qry)
        grdFax.DataSource = ds
        grdFax.DataBind()


    End Sub
End Class
