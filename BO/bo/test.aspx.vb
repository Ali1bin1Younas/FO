Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class BO_test
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        If Not Page.IsPostBack Then
            Dim Con As New DBTaskBO
            'Dim dr As SqlDataReader
            'dr = Con.getDataReader("exec MT_EmployRols 'DP0002'")
            'GridView1.DataSource = dr
            'GridView1.DataBind()

            Dim ds As DataSet
            ds = Con.getDataSet("exec MT_EmployRols 'DP0002'")
            GridView1.DataSource = ds
            GridView1.DataBind()

            ds.Dispose()
            ds = Nothing

        End If
    End Sub
    Protected Function getEnableDisable(ByVal ED As String) As String

        If ED.ToString = "True" Then
            Return "Enable"
        Else
            Return "Disable"
        End If

    End Function
    Protected Function getEnableDisable1(ByVal ED As String) As String

        If ED.ToString = "True" Then
            Return "1"
        Else
            Return "0"
        End If

    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Con As New DBTaskBO
        Dim Query As String = "Delete From boEmployeeRoles Where empID='DP0002'"
        Con.deleteDataValues(Query)

        For Each item1 As GridViewRow In Me.GridView1.Rows
            Dim chk As CheckBox = item1.FindControl("chkRoles")
            Dim objHF As HiddenField = item1.FindControl("rolID")
            Dim id As String = objHF.Value
            If chk.Checked Then
                SaveRoles("DP0002", id)
            End If
        Next
    End Sub

    Private Sub SaveRoles(ByVal empID As String, ByVal rolID As String)
        Dim Query As String = "Insert into boEmployeeRoles(empID,rolID) values('" + empID + "','" + rolID + "')"

        Dim Con As New DBTaskBO
        Con.deleteDataValues(Query)

    End Sub
End Class
