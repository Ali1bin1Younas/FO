
Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class companymain
    Inherits System.Web.UI.Page
    Protected iCounter As Int16

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        iCounter = 0
        Try
            If Not Page.IsPostBack Then
                LoadGrid()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadGrid()
        Try

            Dim Con As New DBTaskBO
            Dim Query As String = "Select * From boCompany ORDER BY comID"
            Dim ds As DataSet
            ds = Con.getDataSet(Query)
            grdEmployee.DataSource = ds
            grdEmployee.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Protected Function getEnableDisable(ByVal ED As String) As String

        If ED.ToString = "True" Then
            Return "../Icon/Ngood.gif".Trim
        Else
            Return "../Icon/cancel.gif".Trim
        End If

    End Function

    Protected Sub grdEmployee_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEmployee.RowCreated
        If e.Row.RowIndex > 0 Then iCounter += 1
    End Sub
End Class
