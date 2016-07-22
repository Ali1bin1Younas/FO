Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Imports System.IO
Imports System.Collections.Generic
Partial Class dictatorassignment
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empID") = "" Then Response.Redirect(GF.Home)
        Session("cint") = 0
        If Not Page.IsPostBack Then
            loadMT()
            loadQC()
            loadPR()
            loadFR()
            loadUnassignedGrid()
            loadAssignedGrid()
        End If

        'On every page visit we need to build up the CheckBoxIDs array
        'Get the header CheckBox

        If grdUnassigned.Rows.Count <> 0 Then
            Dim cbHeader As CheckBox = CType(grdUnassigned.HeaderRow.FindControl("HeaderLevelCheckBox"), CheckBox)

            'Run the ChangeCheckBoxState client-side function whenever the
            'header checkbox is checked/unchecked
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"
            'Add the CheckBox's ID to the client-side CheckBoxIDs array
            ClientScript.RegisterArrayDeclaration("CheckBoxIDs", String.Concat("'", cbHeader.ClientID, "'"))

            For Each gvr As GridViewRow In grdUnassigned.Rows
                'Get a programmatic reference to the CheckBox control
                Dim cb As CheckBox = CType(gvr.FindControl("drCheck"), CheckBox)

                'If the checkbox is unchecked, ensure that the Header CheckBox is unchecked
                cb.Attributes("onclick") = "ChangeHeaderAsNeeded();"

                'Add the CheckBox's ID to the client-side CheckBoxIDs array
                ClientScript.RegisterArrayDeclaration("CheckBoxIDs", String.Concat("'", cb.ClientID, "'"))
            Next
        End If

    End Sub

    Private Sub loadMT()
        Dim Con As New DBTaskBO
        Dim Qry As String
        Dim ds As DataSet

        Qry = "SELECT boEmployeeRoles.empID,(boEmployee.empFirstName +', '+ substring(boEmployee.empLastName,1,1)) as empName,boEmployeeRoles.rolID FROM boEmployeeRoles INNER JOIN boEmployee ON boEmployeeRoles.empID = boEmployee.empID Where boEmployeeRoles.rolID='MT' AND boEmployee.empID <> '0' AND boEmployee.empEnable = 1 ORDER BY empName"
        ds = Con.getDataSet(Qry)
        cmbMT.DataSource = ds.Tables(0)
        cmbMT.DataTextField = "empName"
        cmbMT.DataValueField = "empID"
        cmbMT.DataBind()

        ds.Dispose()
        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Private Sub loadQC()
        Dim Con As New DBTaskBO
        Dim Qry As String = "SELECT boEmployeeRoles.empID,(boEmployee.empFirstName +', '+ substring(boEmployee.empLastName,1,1)) as empName,boEmployeeRoles.rolID FROM boEmployeeRoles INNER JOIN boEmployee ON boEmployeeRoles.empID = boEmployee.empID Where boEmployeeRoles.rolID='QC' AND boEmployee.empID <> '0' AND boEmployee.empEnable = 1 ORDER BY empName"
        Dim ds As DataSet

        ds = Con.getDataSet(Qry)
        cmbQC.DataSource = ds.Tables(0)
        cmbQC.DataTextField = "empName"
        cmbQC.DataValueField = "empID"
        cmbQC.DataBind()
        cmbQC.Items.Add("Skipped")

        ds.Dispose()
        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Private Sub loadPR()
        Dim Con As New DBTaskBO
        Dim Qry As String = "SELECT boEmployeeRoles.empID,(boEmployee.empFirstName +', '+ substring(boEmployee.empLastName,1,1)) as empName,boEmployeeRoles.rolID FROM boEmployeeRoles INNER JOIN boEmployee ON boEmployeeRoles.empID = boEmployee.empID Where boEmployeeRoles.rolID='PR' AND boEmployee.empID <> '0' AND boEmployee.empEnable = 1 ORDER BY empName"
        Dim ds As DataSet

        ds = Con.getDataSet(Qry)
        cmbPR.DataSource = ds.Tables(0)
        cmbPR.DataTextField = "empName"
        cmbPR.DataValueField = "empID"
        cmbPR.DataBind()
        cmbPR.Items.Add("Skipped")

        ds.Dispose()
        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Private Sub loadFR()
        Dim Con As New DBTaskBO
        Dim Qry As String = "SELECT boEmployeeRoles.empID,(boEmployee.empFirstName +', '+ substring(boEmployee.empLastName,1,1)) as empName,boEmployeeRoles.rolID FROM boEmployeeRoles INNER JOIN boEmployee ON boEmployeeRoles.empID = boEmployee.empID Where boEmployeeRoles.rolID='FR' AND boEmployee.empID <> '0' AND boEmployee.empEnable = 1 ORDER BY empName"
        Dim ds As DataSet

        ds = Con.getDataSet(Qry)
        cmbFR.DataSource = ds.Tables(0)
        cmbFR.DataTextField = "empName"
        cmbFR.DataValueField = "empID"
        cmbFR.DataBind()
        cmbFR.Items.Add("Skipped")

        ds.Dispose()
        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Private Sub loadUnassignedGrid()
        Dim Con As New DBTaskBO
        'Dim Qry As String = "select distinct * from boDictator a where not a.drid in(select drid from boDictatorLayers b where b.drid=a.drid and a.foid=b.foid ) AND a.drEnable = 1 ORDER BY a.foID, a.drID"
        Dim Qry As String = "SELECT * FROM boDictator a " _
                            & "WHERE NOT a.drID IN(SELECT DISTINCT drID FROM boDictatorLayers) " _
                                                & "AND a.drEnable = 1 " _
                                                & "ORDER BY a.foID, a.drID"
        Dim ds As DataSet

        ds = Con.getDataSet(Qry)
        grdUnassigned.DataSource = ds.Tables(0)
        grdUnassigned.DataBind()

        ds.Dispose()
        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Private Sub loadAssignedGrid()
        Dim Con As New DBTaskBO
        Dim Qry As String = "SELECT DISTINCT a.drID,a.foID,a.drFirstName,a.drLastName " _
                            & "FROM boDictator a  " _
                            & "INNER JOIN boDictatorLayers C ON a.drID=c.drID " _
                            & "AND a.foID=c.foID " _
                            & "WHERE  a.drID IN(SELECT drID FROM boDictatorLayers b " _
                                                & "WHERE b.drID = a.drID " _
                                                & "AND a.foID = b.foID ) " _
                                                & "AND a.drEnable = 1 " _
                                                & "ORDER BY a.foID, a.drID"
        Dim ds As DataSet

        ds = Con.getDataSet(Qry)
        grdAssigned.DataSource = ds.Tables(0)
        grdAssigned.DataBind()

        ds.Dispose()
        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Protected Function getEmployeeName(ByVal vsdrID As String, ByVal vsfoID As String, ByVal vsRolID As String) As String
        Dim Con As New DBTaskBO
        Dim ds As DataSet
        Dim Qry As String = "SELECT boEmployee.empID, boEmployee.empFirstName, boEmployee.empLastName " _
                            & "FROM boDictatorLayers INNER JOIN boEmployee ON boDictatorLayers.empID = boEmployee.empID " _
                            & "WHERE (boDictatorLayers.drID = '" & vsdrID & "') AND (boDictatorLayers.foID = '" & vsfoID & "') " _
                            & "AND (boDictatorLayers.rolID = '" & vsRolID & "') and boEmployee.empID <> '0'"
        ds = Con.getDataSet(Qry)
        
        If ds.tables(0).rows.count > 0 Then
            Return ds.tables(0).rows(0).item(1).ToString + " " + ds.tables(0).rows(0).item(2).ToString.Substring(0, 1)
        Else
            Return "--"
        End If


        'If dr.Read Then
        '    Return dr("empFirstName").ToString + " " + dr("empLastName").ToString.Substring(0, 1)
        'Else
        '    Return "--"
        'End If

        ds.dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing
    End Function

    Protected Sub btnAssign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAssign.Click
        setAssignedGrid()
        setUnAssignedGrid()
        loadUnassignedGrid()
        loadAssignedGrid()
    End Sub

    Private Sub setUnAssignedGrid()
        Dim Con As New DBTaskBO

        For Each item1 As GridViewRow In Me.grdUnassigned.Rows
            Dim chk As CheckBox = item1.FindControl("drCheck")
            If chk.Checked Then
                Dim strfoID As String = Me.grdUnassigned.DataKeys(item1.RowIndex).Values.Item(0)
                Dim strdrID As String = Me.grdUnassigned.DataKeys(item1.RowIndex).Values.Item(1)

                Con.saveDataValues("Insert into boDictatorLayers(foID,drID,empID,rolID,drlEnable) " _
                                   & "values('" + strfoID + "','" + strdrID + "','" _
                                   & IIf(cmbMT.SelectedValue.ToString = "Skipped", "0", cmbMT.SelectedValue.ToString) _
                                   & "','MT',1)")
                Con.saveDataValues("Insert into boDictatorLayers(foID,drID,empID,rolID,drlEnable) " _
                                   & "values('" + strfoID + "','" + strdrID + "','" _
                                   & IIf(cmbQC.SelectedValue.ToString = "Skipped", "0", cmbQC.SelectedValue.ToString) _
                                   & "','QC',1)")
                Con.saveDataValues("Insert into boDictatorLayers(foID,drID,empID,rolID,drlEnable) " _
                                   & "values('" + strfoID + "','" + strdrID + "','" _
                                   & IIf(cmbPR.SelectedValue.ToString = "Skipped", "0", cmbPR.SelectedValue.ToString) _
                                   & "','PR',1)")
                Con.saveDataValues("Insert into boDictatorLayers(foID,drID,empID,rolID,drlEnable) " _
                                   & "Values('" + strfoID + "','" + strdrID + "','" _
                                   & IIf(cmbFR.SelectedValue.ToString = "Skipped", "0", cmbFR.SelectedValue.ToString) _
                                   & "','FR',1)")
                
            End If
        Next

        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Private Sub setAssignedGrid()
        Dim Con As New DBTaskBO

        For Each item1 As GridViewRow In Me.grdAssigned.Rows
            Dim chkMT As CheckBox = item1.FindControl("AssChkMT")
            Dim chkQC As CheckBox = item1.FindControl("AssChkQC")
            Dim chkPR As CheckBox = item1.FindControl("AssChkPR")
            Dim chkFR As CheckBox = item1.FindControl("AssChkFR")

            Dim strfoID As String = Me.grdAssigned.DataKeys(item1.RowIndex).Values.Item(0)
            Dim strdrID As String = Me.grdAssigned.DataKeys(item1.RowIndex).Values.Item(1)

            If chkMT.Checked Then
                Con.saveDataValues("UPDATE boDictatorLayers SET empID='" _
                              & IIf(cmbMT.SelectedValue.ToString = "Skipped", "0", cmbMT.SelectedValue.ToString) + "' " _
                              & "WHERE drID='" + strdrID + "' AND foID='" + strfoID + "' " _
                              & "AND rolID='MT'")
            End If

            If chkQC.Checked Then
                Con.saveDataValues("UPDATE boDictatorLayers SET empID='" _
                              & IIf(cmbQC.SelectedValue.ToString = "Skipped", "0", cmbQC.SelectedValue.ToString) + "' " _
                              & "WHERE drID='" + strdrID + "' AND foID='" + strfoID + "' " _
                              & "AND rolID='QC'")
            End If

            If chkPR.Checked Then
                Con.saveDataValues("UPDATE boDictatorLayers SET empID='" _
                              & IIf(cmbPR.SelectedValue.ToString = "Skipped", "0", cmbPR.SelectedValue.ToString) + "' " _
                              & "WHERE drID='" + strdrID + "' AND foID='" + strfoID + "' " _
                              & "AND rolID='PR'")
            End If

            If chkFR.Checked Then
                Con.saveDataValues("UPDATE boDictatorLayers SET empID='" _
                              & IIf(cmbFR.SelectedValue.ToString = "Skipped", "0", cmbFR.SelectedValue.ToString) + "' " _
                              & "WHERE drID='" + strdrID + "' AND foID='" + strfoID + "' " _
                              & "AND rolID='FR'")
            End If
        Next

        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Protected Function getCounter() As String
        Dim intCount As Integer = Session("cint")
        intCount += 1
        Session("cint") = intCount
        Return intCount.ToString
    End Function
End Class