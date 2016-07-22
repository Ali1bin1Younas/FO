Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class roles
    Inherits System.Web.UI.Page
    Dim eempID As String
    Dim empFullName As String
    Dim empEnable As String
    Dim empEnableStatus As Boolean = False
    Protected iCounter As Int16

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        iCounter = 0
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        eempID = Request.QueryString("empID")
        lblEmployeeID.Text = eempID.ToString
        lblEmployeeName.Text = getEmployeeName(eempID)
        Try
            If Not Page.IsPostBack Then
                LoadGrid()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadGrid()

        'Try
        Dim Con As New DBTaskBO
        'Dim dr As SqlDataReader
        'dr = Con.getDataReader("exec MT_EmployRols '" + eempID + "'")
        'grdRoles.DataSource = dr
        'grdRoles.DataBind()

        Dim ds As DataSet
        ds = Con.getDataSet("SELECT RolId,rolDescription FROM boRoles WHERE rolEnable=1 Order By rolOrder; Select * from boEmployeeRoles Where empId='" + Request.QueryString("empID") + "'")
        Dim dGrid As New DataTable
        dGrid.Columns.Add("RolID")
        dGrid.Columns.Add("rolDescription")
        dGrid.Columns.Add("empID")
        dGrid.Columns.Add("empEnable")

        Dim dGridRow As DataRow
        For Each dsRow As DataRow In ds.Tables(0).Rows
            dGridRow = dGrid.NewRow()
            dGridRow.Item("RolID") = dsRow.Item("RolID")
            dGridRow.Item("rolDescription") = dsRow.Item("rolDescription")
            dGridRow.Item("empID") = Request.QueryString("empID") 
            dGridRow.Item("empEnable") = Me.isEmpRole(ds.Tables(1), dsRow.Item("rolID"))
            dGrid.Rows.Add(dGridRow)
        Next

        grdRoles.DataSource = dGrid
        grdRoles.DataBind()
        ds.Dispose()
        ds = Nothing
        Con.objConnection.Close()
        Con = Nothing
        'Catch ex As Exception

        'End Try

    End Sub

    Private Function getEmployeeName(ByVal strName As String) As String
        Dim Con As New DBTaskBO
        'Dim dr As SqlDataReader
        Dim ds As DataSet
        'dr = Con.getDataReader("Select * From boEmployee WHERE empID='" & strName & "'")
        ds = Con.getDataSet("Select * From boEmployee WHERE empID='" & strName & "'")
        'If dr.Read Then
        If ds.tables(0).rows.count > 0 Then
            'empFullName = dr("empLastName") + ", " + dr("empFirstName")
            empFullName = ds.tables(0).rows(0).item("empLastName") + ", " + ds.tables(0).rows(0).item("empFirstName")
        End If
        ds.dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing
        Return empFullName
    End Function

    Protected Function getEnableDisable(ByVal ED As String) As String

        If ED.ToString = "True" Then
            Return "../Icon/Ngood.gif".Trim

        Else
            Return "../Icon/cancel.gif".Trim

        End If

    End Function
    Protected Function getEnableDisable1(ByVal ED As String) As String

        If ED.ToString = "True" Then
            Return "1"
        Else
            Return "0"
        End If

    End Function

    Private Sub InsertRecords(ByVal empId As String, ByVal rolId As String)
        Dim Query As String = "INSERT INTO boEmployeeRoles(empId,rolId,empEnable) values('" + empId + "','" + rolId + "','" + empEnable + "')"
        'Dim con As New DBTaskBO
        'con.saveData(Query)
    End Sub

    'Private Sub SaveRoles(ByVal empID As String, ByVal rolID As String)
    '    Dim Query As String = "INSERT INTO boEmployeeRoles(empID,rolID) values('" + empID + "','" + rolID + "')"
    '    Dim Con As New DBTaskBO
    '    Con.deleteDataValues(Query)

    'End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("employeemain.aspx")
    End Sub

    Public Function getDescription(ByVal name As String) As String
        If name = "Medical Transcriptionist" Then
            name = name & " " & "(MT)"
        ElseIf name = "Quality Controller" Then
            name = name & " " & "(QC)"
        ElseIf name = "Proof Reader" Then
            name = name & " " & "(PR)"
        ElseIf name = "Formator" Then
            name = name & " " & "Reader" & " " & "(FR)"
        End If
        Return name
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim Query As String = "Select * from boEmployeeRoles Where empId='" + eempID + "'"
        Dim con As New DBTaskBO
        Dim chk As CheckBox
        Dim roll As HiddenField

        con.ConnectionString()
        'Dim dr As SqlDataReader = con.getDataReader(Query)
        'If dr.Read Then
        '    status = True
        'End If
        Dim ds As DataSet
        ds = Con.getDataSet(Query)
        Dim conn As New SqlConnection(con.ConnectionString())
        conn.Open()
        Dim sqlTrans As SqlTransaction = conn.BeginTransaction
        Dim dRow As DataRow()
        Try
            For Each item1 As GridViewRow In Me.grdRoles.Rows
                chk = item1.FindControl("chkRoles")
                roll = item1.FindControl("rolID")
                ID = roll.Value
                If chk.Checked Then
                    empEnable = "1"
                Else
                    empEnable = "0"
                End If

                dRow = ds.Tables(0).Select("rolID='" & ID & "'")

                If dRow.Length = 0 Then
                    Query = "INSERT INTO boEmployeeRoles(empId,rolId,empEnable) values('" + eempID + "','" + ID + "','" + empEnable + "')"
                Else
                    Query = "UPDATE boEmployeeRoles set empEnable = " & empEnable & " Where empId='" & eempID & "' and rolId='" & ID & "'"
                End If

                con.saveData(Query)
            Next
            sqlTrans.Commit()
        Catch ex As Exception
            sqlTrans.Rollback()
            MsgBox(ex.Message())
        Finally
            'dr.Close()
            ds.Dispose()
            ds = Nothing

            conn.Close()
            conn.Dispose()
        End Try
        Response.Redirect("roles.aspx?empID=" & eempID & "")
    End Sub

    Protected Sub grdRoles_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRoles.RowCreated
        If e.Row.RowIndex > 0 Then iCounter += 1
    End Sub

    Protected Function isEmpRole(ByVal dt As DataTable, ByVal rol As String) As Boolean
        Dim dRow() As DataRow
        Dim isEnable As Boolean = False
        Try
            dRow = dt.Select("RolID='" & rol & "'")
        Catch ex As Exception

        End Try

        If dRow.Length > 0 Then

            For Each row As DataRow In dRow
                isEnable = CType(row.Item("empEnable"), Boolean)
            Next
        End If

        Return isEnable
    End Function
   
End Class
