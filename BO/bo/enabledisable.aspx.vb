Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class FO_enabledisable
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        Try
            Dim Query As String
            Dim Con As New DBTaskBO
            Dim tblName As String = Request.QueryString("tbl").ToString
            Dim colName As String = Request.QueryString("colEnable").ToString
            Dim iidGeneral As String = Request.QueryString("idGeneral").ToString
            Dim ED As String = Request.QueryString("valED")
            Dim colPrimary As String = Request.QueryString("colPrimary").ToString

            Dim rdirPage As String = Request.QueryString("rdPage").ToString
            If ED = True Then
                Query = "Update " + tblName + " set " + CStr(colName) + "=" + "'" + CStr(0) + "'" + " where" + " " + colPrimary + "=" + "'" + CStr(iidGeneral) + "'"
            Else
                Query = "Update " + tblName + " set " + CStr(colName) + "=" + "'" + CStr(1) + "'" + " where" + " " + colPrimary + "=" + "'" + CStr(iidGeneral) + "'"
            End If
            Con.deleteDataValues(Query)
            Response.Redirect(rdirPage)

        Catch ex As Exception

        End Try

        
    End Sub
End Class
