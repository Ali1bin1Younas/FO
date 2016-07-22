
Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Public Class dicunassigned
    Inherits System.Web.UI.UserControl


    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        ViewState("Counter") = 0
        Me.btnAssign.Attributes("onclick") = "return AssignSessionValues()"

        'if an InvalidCastException occurs in either of the next two lines, 
        'please make sure that you've set the TemplateDataMode to Table (because you want nested grids)
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        If (Not (TypeOf dgi.DataItem Is Data.DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If
        Dim ds As Data.DataSet = CType(dgi.DataItem, Data.DataSet)
        Me.grdAssigned1.DataSource = ds
        Me.grdAssigned1.DataMember = "DIC"
        Me.grdAssigned1.DataBind()




    End Sub


    <Ajax.AjaxMethod()> _
     Public Function AssignRights1(ByVal ckMT As Boolean, ByVal ckQC As Boolean, ByVal ckPR As Boolean, ByVal ckFR As Boolean, ByVal cmMT As String, ByVal cmQC As String, ByVal cmPR As String, ByVal cmFR As String) As String
        Return "hello"
    End Function




    Private Sub setUnAssignedGrid()


        Dim hash As Hashtable = Session("AssignValue")
        Dim strEmpIDMT1 As String = hash("MT")
        Dim strEmpIDQC1 As String = hash("QC")
        Dim strEmpIDPR1 As String = hash("PR")
        Dim strEmpIDFR1 As String = hash("FR")


        For Each item1 As GridViewRow In Me.grdAssigned1.Rows
            Dim chk As CheckBox = item1.FindControl("chkAssign")
            If chk.Checked Then
                Dim strdicID As String = item1.Cells(1).Text.ToString
                Dim strEmpIDMT As String
                Dim strEmpIDQC As String
                Dim strEmpIDPR As String
                Dim strEmpIDFR As String
                If strEmpIDMT1.Trim <> "Skipped" Then
                    strEmpIDMT = strEmpIDMT1.ToString
                Else
                    strEmpIDMT = "0"
                End If
                If strEmpIDQC1.Trim <> "Skipped" Then

                    strEmpIDQC = strEmpIDQC1.ToString
                Else
                    strEmpIDQC = "0"
                End If
                If strEmpIDPR1.Trim <> "Skipped" Then

                    strEmpIDPR = strEmpIDPR1.ToString
                Else
                    strEmpIDPR = "0"

                End If
                If strEmpIDFR1.Trim <> "Skipped" Then

                    strEmpIDFR = strEmpIDFR1.ToString
                Else
                    strEmpIDFR = "0"
                End If
                'Save value one by one by one
                SaveValues(strdicID, strEmpIDMT, strEmpIDQC, strEmpIDPR, strEmpIDFR)
            End If
        Next
    End Sub








    'Private Sub setAssignedGrid()


    '    'Dim hash As Hashtable = Session("AssignValue")
    '    'Dim mt As String = hash("MT")

    '    'For Each row1 As GridViewRow In Me.grdAssigned1.Rows

    '    '    Dim chk As CheckBox = row1.FindControl("chkAssign")
    '    '    Dim chk1 As CheckBox = row1.FindControl("AssChkMT")


    '    '    If chk.Checked Then

    '    '    End If



    '    'Next


    '    Dim hash As Hashtable = Session("AssignValue")
    '    Dim strEmpIDQC1 As String = hash("QC")
    '    Dim strEmpIDMT1 As String = hash("MT")
    '    Dim strEmpIDPR1 As String = hash("PR")
    '    Dim strEmpIDFR1 As String = hash("FR")




    '    For Each item1 As GridViewRow In Me.grdAssigned1.Rows
    '        Dim chkMT As CheckBox = item1.FindControl("AssChkMT")
    '        Dim chkQC As CheckBox = item1.FindControl("AssChkQC")
    '        Dim chkPR As CheckBox = item1.FindControl("AssChkPR")
    '        Dim chkFR As CheckBox = item1.FindControl("AssChkFR")
    '        'for MT
    '        'If chkMT.Checked Then
    '        '    Dim strdicID As String = item1.Cells(1).Text.ToString
    '        '    'Dim strempID As String = item1.Cells(1).Text.ToString
    '        '    strEmpIDMT As String
    '        '    If Session("sMT") <> "Skipped" Then
    '        '        strEmpIDMT = Session("sPR")
    '        '    Else
    '        '        strEmpIDMT = "0"
    '        '    End If
    '        '    'Save value one by one by one
    '        '    UpdateValuesMT(strdicID, strEmpIDMT)
    '        'End If

    '        'For QC
    '        If chkQC.Checked Then
    '            Dim strdicID As String = item1.Cells(1).Text.ToString
    '            Dim strfoID As String = item1.Cells(1).Text.ToString

    '            Dim strEmpIDQC As String
    '            If strEmpIDQC1 <> "Skipped" Then
    '                strEmpIDQC = strEmpIDQC1.ToString
    '            Else
    '                strEmpIDQC = "0"
    '            End If
    '            'Save value one by one by one
    '            UpdateValuesQC(strdicID, strfoID, strEmpIDQC)
    '        End If
    '        ''for PR
    '        If chkPR.Checked Then
    '            Dim strdrID As String = item1.Cells(2).Text.ToString
    '            Dim strfoID As String = item1.Cells(1).Text.ToString
    '            Dim strEmpIDPR As String
    '            If strEmpIDPR1 <> "Skipped" Then
    '                strEmpIDPR = strEmpIDPR1.ToString
    '            Else
    '                strEmpIDPR = "0"
    '            End If

    '            'Save value one by one by one
    '            UpdateValuesPR(strdrID, strfoID, strEmpIDPR)
    '        End If

    '        ''for FR
    '        If chkFR.Checked Then
    '            Dim strdrID As String = item1.Cells(2).Text.ToString
    '            Dim strfoID As String = item1.Cells(1).Text.ToString
    '            Dim strEmpIDFR As String
    '            If strEmpIDFR1.Trim <> "Skipped" Then
    '                strEmpIDFR = strEmpIDFR1.ToString
    '            Else
    '                strEmpIDFR = "0"
    '            End If
    '            'Save value one by one by one
    '            UpdateValuesFR(strdrID, strfoID, strEmpIDFR)
    '        End If
    '    Next
    'End Sub
    Private Sub UpdateValuesMT(ByVal udicID As String, ByVal uEmpID As String)
        Dim ConMT As New DBTaskBO
        ConMT.saveDataValues("Update boDictationLayers set empID='" + uEmpID + "' where dicID='" + udicID + "' and rolID='MT'")

    End Sub
    Private Sub UpdateValuesQC(ByVal udicID As String, ByVal ufoID As String, ByVal uEmpID As String)
        Dim ConQC As New DBTaskBO
        ConQC.saveDataValues("Update boDictationLayers set empID='" + uEmpID + "' where drID='" + udicID + "' and foID='" + ufoID + "' and rolID='QC'")
    End Sub
    Private Sub UpdateValuesPR(ByVal udicID As String, ByVal ufoID As String, ByVal uEmpID As String)
        Dim ConPR As New DBTaskBO
        ConPR.saveDataValues("Update boDictationLayers set empID='" + uEmpID + "' where drID='" + udicID + "' and foID='" + ufoID + "'and rolID='PR'")
    End Sub
    Private Sub UpdateValuesFR(ByVal udicID As String, ByVal ufoID As String, ByVal uEmpID As String)
        Dim ConFR As New DBTaskBO
        ConFR.saveDataValues("Update boDictationLayers set empID='" + uEmpID + "' where drID='" + udicID + "' and foID='" + ufoID + "'and rolID='FR'")
    End Sub
    Private Sub SaveValues(ByVal sdicID As String, ByVal sMT As String, ByVal sQC As String, ByVal sPR As String, ByVal sFR As String)
        Dim ConMT As New DBTaskBO
        ConMT.saveDataValues("Insert into boDictationLayers(dicID,empID,rolID,diclSkip,diclStatus) values('" + sdicID + "','" + sMT + "','MT',0,1) ")
        Dim ConQC As New DBTaskBO
        ConQC.saveDataValues("Insert into boDictationLayers(dicID,empID,rolID,diclSkip,diclStatus) values('" + sdicID + "','" + sQC + "','QC',1,1)")
        Dim ConPR As New DBTaskBO
        ConPR.saveDataValues("Insert into boDictationLayers(dicID,empID,rolID,diclSkip,diclStatus) values('" + sdicID + "','" + sPR + "','PR',1,1)")
        Dim ConFR As New DBTaskBO
        ConFR.saveDataValues("Insert into boDictationLayers(dicID,empID,rolID,diclSkip,diclStatus) values('" + sdicID + "','" + sFR + "','FR',1,1)")
    End Sub

    Protected Function getCounterDaily() As String
        Dim intCountDaily As Integer = Session("sccintDaily")
        intCountDaily += 1
        Session("sccintDaily") = intCountDaily
        Return intCountDaily.ToString
    End Function
    Protected Function getMTName(ByVal strdrID As String, ByVal strfoID As String)
        Dim Con As New DBTaskBO
        Dim Qry As String = "SELECT boDictatorLayers.drID,boDictatorLayers.foID, boEmployee.empFirstName,boEmployee.empLastName FROM boDictatorLayers INNER JOIN boEmployee ON boDictatorLayers.empID = boEmployee.empID WHERE (boDictatorLayers.drID = '" + strdrID + "') AND (boDictatorLayers.foID = '" + strfoID + "') AND (boDictatorLayers.rolID = 'MT')"
        'Dim dr As SqlDataReader
        Dim ds As DataSet
        Dim strName As String = Nothing
        'dr = Con.getDataReader(Qry)
        ds = Con.getDataSet(Qry)
        'If dr.Read Then
        If ds.tables(0).rows.count > 0 Then
            Dim strFullName As String
            'strFullName = dr("empFirstName").ToString + ", " + dr("empLastName").ToString.Substring(0, 1)
            strFullName = ds.tables(0).rows(0).item(2).ToString + ", " + ds.tables(0).rows(0).item(3).ToString.Substring(0, 1)
            strName = strFullName
            Return strName
        Else
            Return "-"
        End If
        ds.dispose()
        ds = Nothing
        Con.objConnection.Close()
        Con = Nothing
        'Con.objDataReader.Close()
    End Function
    Protected Function getQCName(ByVal strdrID As String, ByVal strfoID As String)
        Dim Con As New DBTaskBO
        Dim Qry As String = "SELECT boDictatorLayers.drID,boDictatorLayers.foID, boEmployee.empFirstName,boEmployee.empLastName FROM boDictatorLayers INNER JOIN boEmployee ON boDictatorLayers.empID = boEmployee.empID WHERE (boDictatorLayers.drID = '" + strdrID + "') AND (boDictatorLayers.foID = '" + strfoID + "') AND (boDictatorLayers.rolID = 'QC')"
        'Dim dr As SqlDataReader
        Dim ds As DataSet
        Dim strName As String = Nothing
        'dr = Con.getDataReader(Qry)
        ds = Con.getDataSet(Qry)
        'If dr.Read Then
        If ds.tables(0).rows.count > 0 Then
            Dim strFullName As String
            'strFullName = dr("empFirstName").ToString + ", " + dr("empLastName").ToString.Substring(0, 1)
            strFullName = ds.tables(0).rows(0).item(2).ToString + ", " + ds.tables(0).rows(0).item(3).ToString.Substring(0, 1)
            strName = strFullName
            Return strName
        Else
            Return "-"
        End If
        ds.dispose()
        ds = Nothing
        Con.objConnection.Close()
        Con = Nothing
        'Con.objDataReader.Close()
    End Function
    Protected Function getPRName(ByVal strdrID As String, ByVal strfoID As String)
        Dim Con As New DBTaskBO
        Dim Qry As String = "SELECT boDictatorLayers.drID,boDictatorLayers.foID, boEmployee.empFirstName,boEmployee.empLastName FROM boDictatorLayers INNER JOIN boEmployee ON boDictatorLayers.empID = boEmployee.empID WHERE (boDictatorLayers.drID = '" + strdrID + "') AND (boDictatorLayers.foID = '" + strfoID + "') AND (boDictatorLayers.rolID = 'PR')"
        'Dim dr As SqlDataReader
        Dim ds As DataSet
        Dim strName As String = Nothing
        'dr = Con.getDataReader(Qry)
        ds = Con.getDataSet(Qry)
        'If dr.Read Then
        If ds.tables(0).rows.count > 0 Then
            Dim strFullName As String
            'strFullName = dr("empFirstName").ToString + ", " + dr("empLastName").ToString.Substring(0, 1)
            strFullName = ds.tables(0).rows(0).item(2).ToString + ", " + ds.tables(0).rows(0).item(3).ToString.Substring(0, 1)
            strName = strFullName
            Return strName
        Else
            Return "-"
        End If
        ds.dispose()
        ds = Nothing
        Con.objConnection.Close()
        Con = Nothing
        ' Con.objDataReader.Close()
    End Function
    Protected Function getFRName(ByVal strdrID As String, ByVal strfoID As String)
        Dim Con As New DBTaskBO
        Dim Qry As String = "SELECT boDictatorLayers.drID,boDictatorLayers.foID, boEmployee.empFirstName,boEmployee.empLastName FROM boDictatorLayers INNER JOIN boEmployee ON boDictatorLayers.empID = boEmployee.empID WHERE (boDictatorLayers.drID = '" + strdrID + "') AND (boDictatorLayers.foID = '" + strfoID + "') AND (boDictatorLayers.rolID = 'FR')"
        'Dim dr As SqlDataReader
        Dim ds As DataSet
        Dim strName As String = Nothing
        'dr = Con.getDataReader(Qry)
        ds = Con.getDataSet(Qry)
        'If dr.Read Then
        If ds.tables(0).rows.count > 0 Then
            Dim strFullName As String
            'strFullName = dr("empFirstName").ToString + ", " + dr("empLastName").ToString.Substring(0, 1)
            strFullName = ds.tables(0).rows(0).item(2).ToString + ", " + ds.tables(0).rows(0).item(3).ToString.Substring(0, 1)
            strName = strFullName
            Return strName
        Else
            Return "-"
        End If
        ds.dispose()
        ds = Nothing
        Con.objConnection.Close()
        Con = Nothing
        'Con.objDataReader.Close()
    End Function
    Protected Function getCounter() As String
        Dim intCount As Integer = Session("cint")
        intCount += 1
        Session("cint") = intCount
        Return intCount.ToString
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("cint") = 0
    End Sub
    Protected Sub btnAssign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAssign.Click

        'Dim hash As Hashtable = Session("AssignValue")
        'Dim mt As String = hash("MT")

        'For Each row1 As GridViewRow In Me.grdAssigned1.Rows

        '    Dim chk As CheckBox = row1.FindControl("chkAssign")
        '    Dim chk1 As CheckBox = row1.FindControl("AssChkMT")


        '    If chk.Checked Then

        '    End If



        'Next







        setUnAssignedGrid()
        Response.Redirect("dictationassignment.aspx")







    End Sub
End Class
