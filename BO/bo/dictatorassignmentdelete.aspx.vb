Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class dictatorassignmentdelete
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Try
        If Session("empId") = "" Then Response.Redirect(GF.Home)

        Dim strfoID As String = Request.QueryString("foID").ToString
        Dim strdrID As String = Request.QueryString("drID").ToString

        Dim Con As New DBTaskBO

        Con.deleteDataValues("Delete from bodictatorlayers where foID='" + strfoID + "' and drID='" + strdrID + "'")

        Response.Redirect("dictatorassignment.aspx")




        'Catch ex As Exception

        'End Try


    End Sub
End Class
