Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class rolesenable
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Try
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        Dim eempID As String = Request.QueryString("empID").ToString
        Dim erolID As String = Request.QueryString("rolID").ToString
        Dim evalED As String = Request.QueryString("valED").ToString

        Dim Con As New DBTaskBO
        'Dim dr As SqlDataReader
        'dr = Con.getDataReader("Select * From boEmployeeRoles WHERE empID='" & eempID & "' and rolID='" & erolID & "' ")
        Dim Query As String

        If evalED = True Then
            Query = "Update boEmployeeRoles set empEnable='0' where empID='" & eempID & "' and  rolID='" & erolID & "'"
            Con.deleteDataValues(Query)
        Else
            Query = "Update boEmployeeRoles set empEnable='1' where empID='" & eempID & "' and  rolID='" & erolID & "'"
            Con.deleteDataValues(Query)
        End If
        Response.Redirect("roles.aspx?empID=" & eempID & "")




        'Catch ex As Exception

        'End Try


    End Sub
End Class
