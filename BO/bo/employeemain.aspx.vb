
Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class employeemain
    Inherits System.Web.UI.Page
    Protected iCounter As Int16

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        iCounter = 1
        Try
            If Not Page.IsPostBack Then
                LoadGrid()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadGrid()
        Dim status As String = cmbStatus.SelectedValue.ToString
        Dim Query As String
        If status = "all" Then
            Query = "Select * From boEmployee emp INNER JOIN boCompany com " _
            & " ON emp.comID = com.comID INNER JOIN boDepartment dep ON emp.depID = dep.depID " _
            & " INNER JOIN boEmployeeTypes etp ON emp.etpID = etp.etpID " _
            & " WHERE emp.empID <> '0' ORDER BY emp.empFirstName, emp.empLastName"
        Else
            Query = "Select * From boEmployee emp INNER JOIN boCompany com " _
            & " ON emp.comID = com.comID INNER JOIN boDepartment dep ON emp.depID = dep.depID " _
            & " INNER JOIN boEmployeeTypes etp ON emp.etpID = etp.etpID " _
            & " WHERE emp.empID <> '0' AND emp.empEnable='" & status & "' ORDER BY emp.empFirstName, emp.empLastName"
        End If

        Dim Con As New DBTaskBO
        Dim ds As DataSet
        ds = Con.getDataSet(Query)

        grdEmployee.DataSource = ds
        grdEmployee.DataBind()

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

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim ImageDefault As ImageButton = e.Row.FindControl("ImageButtonED")
            ImageDefault.CommandArgument = e.Row.RowIndex
            ImageDefault.CommandName = "EnableDisable"
        End If
    End Sub

    Protected Sub grdEmployee_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdEmployee.RowCommand
        If e.CommandName = "EnableDisable" Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ' Retrieve the row that contains the button clicked 
            ' by the user from the Rows collection.
            Dim row As GridViewRow = grdEmployee.Rows(index)
            Dim empID As String = Me.grdEmployee.DataKeys(e.CommandArgument.ToString).Values.Item("empID")
            Dim ED As String = CBool(Me.grdEmployee.DataKeys(e.CommandArgument).Values.Item("empEnable"))
            Dim Qry As String
            Dim Con As New DBTaskBO
            Dim zero As Integer = 0
            Dim one As Integer = 1
            If ED = True Then
                Qry = "Update boEmployee SET empEnable='" & zero & "' WHERE empID='" & empID & "'"
            Else
                Qry = "Update boEmployee SET empEnable='" & one & "' WHERE empID='" & empID & "'"
            End If
            Con.saveData(Qry)

            LoadGrid()
        End If
    End Sub
    Protected Sub grdEmployee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdEmployee.SelectedIndexChanged
        LoadGrid()
    End Sub

    Protected Sub btnStatus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStatus.Click
        Try
            Dim Con As New DBTaskBO
            Dim Query As String
            If cmbStatus.SelectedValue = "all" Then
                Query = "Select * From boEmployee emp INNER JOIN boCompany com " _
            & " ON emp.comID = com.comID INNER JOIN boDepartment dep ON emp.depID = dep.depID " _
            & " INNER JOIN boEmployeeTypes etp ON emp.etpID = etp.etpID " _
            & " WHERE emp.empID <> '0' ORDER BY emp.empID"
            Else
                Query = "Select * From boEmployee emp INNER JOIN boCompany com " _
            & " ON emp.comID = com.comID INNER JOIN boDepartment dep ON emp.depID = dep.depID " _
            & " INNER JOIN boEmployeeTypes etp ON emp.etpID = etp.etpID " _
            & " WHERE emp.empID <> '0' AND emp.empEnable='" & cmbStatus.SelectedValue & "' ORDER BY empID"
            End If

            Dim ds As DataSet
            ds = Con.getDataSet(Query)

            grdEmployee.DataSource = ds
            grdEmployee.DataBind()
        Catch ex As Exception

        End Try
    End Sub
End Class
