Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Public Class dicStatus
    Inherits System.Web.UI.UserControl
    Protected m_sMTName As String
    Protected m_bMTStatus As Boolean
    Protected m_cMTColor As System.Drawing.Color
    Protected Shared m_ChkName As String
    Protected m_sQCName As String
    Protected m_bQCStatus As Boolean
    Protected m_cQCColor As System.Drawing.Color

    Protected m_sPRName As String
    Protected m_bPRStatus As Boolean
    Protected m_cPRColor As System.Drawing.Color

    Protected m_sFRName As String
    Protected m_bFRStatus As Boolean
    Protected m_cFRColor As System.Drawing.Color
    Protected Shared D_Set_MT, D_Set_QC, D_Set_PR, D_Set_FR As New DataSet
    Protected Shared DT_MT, DT_QC, DT_PR, DT_FR As New DataTable

    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        If Session("empId") = "0" Then Response.Redirect(GF.Home)
        ViewState("Counter") = 0
        Me.btnAssign.Attributes("onclick") = "return AssignSessionValues()"

        'if an InvalidCastException occurs in either of the next two lines, 
        'please make sure that you've set the TemplateDataMode to Table (because you want nested grids)
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        If (Not (TypeOf dgi.DataItem Is Data.DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If
        Dim ds As Data.DataSet = CType(dgi.DataItem, Data.DataSet)
        Me.grdDictation.DataSource = AddCounterInDataTable(ds.Tables("Dic"))
        Me.grdDictation.DataMember = "DIC"
        Me.grdDictation.DataBind()

    End Sub

    Private Function AddCounterInDataTable(ByVal dt As DataTable)
        Dim rtnDt As DataTable = CreateDataTable()
        Dim cnt As Integer = 0

        For Each dr As DataRow In dt.Rows
            Dim dr1 As DataRow = rtnDt.NewRow
            cnt += 1
            dr1(0) = cnt
            dr1(1) = dr("empID")
            dr1(2) = dr("foID")
            dr1(3) = dr("dicID")
            dr1(4) = dr("dicActualName")
            dr1(5) = dr("dicDate")
            dr1(6) = dr("dicLength")
            dr1(7) = dr("dicStatus")
            dr1(8) = dr("drID")
            rtnDt.Rows.Add(dr1)
        Next
        Return rtnDt
    End Function

    Private Function CreateDataTable() As Data.DataTable
        Dim dt As New DataTable
        dt.Columns.Add("#")
        dt.Columns.Add("empID")
        dt.Columns.Add("foID")
        dt.Columns.Add("dicID")
        dt.Columns.Add("dicActualName")
        dt.Columns.Add("dicDate")
        dt.Columns.Add("dicLength")
        dt.Columns.Add("dicStatus")
        dt.Columns.Add("drID")

        Return dt
    End Function

    Public Sub setAssignedGrid()
        'Dim hash As Hashtable = Session("AssignValue")
        Dim strEmpIDMT As String = Me.ddlMT.SelectedValue 'hash("MT")
        Dim strEmpIDQC As String = Me.ddlQC.SelectedValue 'hash("QC")
        Dim strEmpIDPR As String = Me.ddlPR.SelectedValue 'hash("PR")
        Dim strEmpIDFR As String = Me.ddlFR.SelectedValue 'hash("FR")

        For Each item1 As GridViewRow In Me.grdDictation.Rows
            Dim chkMT As CheckBox = item1.FindControl("chkMT")
            Dim chkQC As CheckBox = item1.FindControl("chkQC")
            Dim chkPR As CheckBox = item1.FindControl("chkPR")
            Dim chkFR As CheckBox = item1.FindControl("chkFR")
            Dim strdicID As Long = Me.grdDictation.DataKeys(item1.RowIndex).Values.Item(0)
            If chkMT.Checked Then UpdateMT(strdicID, strEmpIDMT)
            If chkQC.Checked Then UpdateLayer(strdicID, "QC", strEmpIDQC)
            If chkPR.Checked Then UpdateLayer(strdicID, "PR", strEmpIDPR)
            If chkFR.Checked Then UpdateLayer(strdicID, "FR", strEmpIDFR)
        Next
    End Sub

    Private Sub UpdateMT(ByVal udicID As Long, ByVal uEmpID As String)
        Dim ConMT As New DBTaskBO
        ConMT.saveDataValues("UPDATE boDictationLayers SET empID='" & uEmpID & "' " _
                             & "WHERE dicID = " & udicID & " AND rolID = 'MT'")

        ConMT = Nothing
    End Sub

    Private Sub UpdateLayer(ByVal udicID As Long, ByVal vsrolID As String, ByVal uEmpID As String)
        Dim cnQC As New DBTaskBO
        Dim strQry As String
        Dim dsQC As DataSet
        Dim strOldEmp As String
        Dim bolTag As Boolean
        Dim intStatus As Int16

        strQry = "SELECT * FROM boDictationLayers WHERE dicID = " & udicID & " " _
                 & "AND rolID = '" & vsrolID & "'"
        dsQC = cnQC.getDataSet(strQry)

        strOldEmp = dsQC.Tables(0).Rows(0)("empID").ToString.Trim
        bolTag = dsQC.Tables(0).Rows(0)("diclTag")
        intStatus = dsQC.Tables(0).Rows(0)("diclStatus")

        dsQC.Dispose()

        If intStatus = 2 Or intStatus = 3 Or uEmpID = strOldEmp Then Exit Sub
        If uEmpID = "Skipped" Then uEmpID = "0"

        If intStatus = 0 Then
            strQry = "UPDATE boDictationLayers SET empID = '" & uEmpID & "', " _
                     & "diclSkip = " & IIf(uEmpID = "0", 1, 0) & " " _
                     & "WHERE dicID = " & udicID & " AND rolID = '" & vsrolID & "'"
            cnQC.saveDataValues(strQry)
        ElseIf intStatus = 1 Then
            If Not bolTag And strOldEmp <> "0" And uEmpID = "0" Then
                If vsrolID = "QC" Then
                    Call assignNextLayer(udicID, "QC", "PR")
                ElseIf vsrolID = "PR" Then
                    Call assignNextLayer(udicID, "PR", "FR")
                End If
            ElseIf Not bolTag And strOldEmp = "0" And uEmpID <> "0" Then
                If vsrolID = "QC" Then
                    Call assignPreviouseLayer(udicID, "PR", "QC", uEmpID)
                ElseIf vsrolID = "PR" Then
                    Call assignPreviouseLayer(udicID, "FR", "PR", uEmpID)
                End If
            Else
                strQry = "UPDATE boDictationLayers SET empID = '" & uEmpID & "' " _
                         & "WHERE dicID = " & udicID & " AND rolID = '" & vsrolID & "'"
                cnQC.saveDataValues(strQry)

                strQry = "UPDATE boTranscriptionLayers SET empID = '" & uEmpID & "' " _
                         & "WHERE dicID = " & udicID & " AND rolID = '" & vsrolID & "'"
                cnQC.saveDataValues(strQry)
            End If
        End If
        dsQC.Dispose()
        dsQC = Nothing
        cnQC = Nothing
    End Sub

    Protected Sub assignNextLayer(ByVal udicID As Long, ByVal vsFromRole As String, ByVal vsToRole As String)
        Dim cnLL As New DBTaskBO
        Dim dsLL As DataSet

        Dim strQry As String
        Dim iRecordsEffected As Int16

        strQry = "SELECT * FROM boDictationLayers WHERE dicID = " & udicID & " " _
                 & "AND diclSkip = 0 AND rolID = '" & vsToRole & "'"

        dsLL = cnLL.getDataSet(strQry)
        If dsLL.Tables(0).Rows.Count > 0 Then
            strQry = "UPDATE boTranscriptionLayers SET rolID = '" & vsToRole & "', " _
            & "empID = '" & dsLL.Tables(0).Rows(0)("empID") & "' " _
            & "WHERE dicID = " & udicID & " AND rolID = '" & vsFromRole & "'"
            iRecordsEffected = cnLL.saveData(strQry)

            If iRecordsEffected > 0 Then
                strQry = "UPDATE boDictationLayers SET empID = '0', " _
                         & "diclTranscriptions = " & iRecordsEffected & ", " _
                         & "diclSkip = 1, diclStatus = 1 "
                If vsFromRole = "QC" And vsToRole = "PR" Then
                    strQry = strQry & "WHERE dicID = " & udicID & " " _
                                    & "AND rolID = 'QC'"
                ElseIf vsFromRole = "QC" And vsToRole = "FR" Then
                    strQry = strQry & "WHERE dicID = " & udicID & " " _
                                    & "AND (rolID = 'QC' OR rolID = 'PR')"
                ElseIf vsFromRole = "PR" And vsToRole = "FR" Then
                    strQry = strQry & "WHERE dicID = " & udicID & " " _
                                    & "AND rolID = 'PR'"
                End If
                iRecordsEffected = cnLL.saveData(strQry)

                strQry = "UPDATE boDictationLayers SET diclStatus = 1 " _
                            & "WHERE dicID = " & udicID & " AND rolID = '" & vsToRole & "'"
                iRecordsEffected = cnLL.saveData(strQry)
            End If
        Else
            If vsFromRole = "QC" Then
                dsLL.Dispose()
                Call assignNextLayer(udicID, "QC", "FR")
            End If
        End If

        dsLL.Dispose()
        dsLL = Nothing
        cnLL = Nothing
    End Sub

    Protected Sub assignPreviouseLayer(ByVal udicID As Long, ByVal vsFromRole As String, ByVal vsToRole As String, ByVal vsempID As String)
        Dim cnLL As New DBTaskBO
        Dim dsLL As DataSet

        Dim strQry As String
        Dim iRecordsEffected As Int16


        strQry = "SELECT * FROM boDictationLayers WHERE dicID = " & udicID & " " _
                         & "AND diclSkip = 0 AND rolID = '" & vsFromRole & "'"
        dsLL = cnLL.getDataSet(strQry)

        If dsLL.Tables(0).Rows.Count > 0 Then
            strQry = "UPDATE boTranscriptionLayers SET rolID = '" & vsToRole & "', " _
                     & "empID = '" & vsempID & "' " _
                     & "WHERE dicID = " & udicID & " AND rolID = '" & vsFromRole & "'"
            iRecordsEffected = cnLL.saveData(strQry)

            If iRecordsEffected > 0 Then
                strQry = "UPDATE boDictationLayers SET diclTranscriptions = 0, diclStatus = 0 "
                If vsFromRole = "PR" And vsToRole = "QC" Then
                    strQry = strQry & "WHERE dicID = " & udicID & " " _
                                    & "AND rolID = 'PR'"
                ElseIf vsFromRole = "FR" And vsToRole = "QC" Then
                    strQry = strQry & "WHERE dicID = " & udicID & " " _
                                    & "AND (rolID = 'FR' OR rolID = 'PR')"
                ElseIf vsFromRole = "FR" And vsToRole = "PR" Then
                    strQry = strQry & "WHERE dicID = " & udicID & " " _
                                    & "AND rolID = 'FR'"
                End If
                iRecordsEffected = cnLL.saveData(strQry)

                strQry = "UPDATE boDictationLayers SET diclTranscriptions = 0, " _
                         & "diclSkip = 0, diclStatus = 1, empID = '" & vsempID & "' " _
                         & "WHERE dicID = " & udicID & " AND rolID = '" & vsToRole & "'"
                iRecordsEffected = cnLL.saveData(strQry)
            End If
        Else
            If vsToRole = "QC" Then
                dsLL.Dispose()
                Call assignPreviouseLayer(udicID, "FR", "QC", vsempID)
            End If
        End If

        dsLL.Dispose()
        dsLL = Nothing
        cnLL = Nothing
    End Sub

    'Private Sub UpdateValuesPR(ByVal udicID As Long, ByVal uEmpID As String)
    '    Dim ConPR As New DBTaskBO
    '    If uEmpID = "0" Then
    '        ConPR.saveDataValues("Update boDictationLayers set empID='" & uEmpID & "', diclSkip = 1 where dicID=" & udicID & " and rolID='PR'")
    '    Else
    '        ConPR.saveDataValues("Update boDictationLayers set empID='" & uEmpID & "', diclSkip = 0 where dicID=" & udicID & " and rolID='PR'")
    '    End If
    'End Sub

    'Private Sub UpdateValuesFR(ByVal udicID As Long, ByVal uEmpID As String)
    '    Dim ConFR As New DBTaskBO
    '    If uEmpID = "0" Then
    '        ConFR.saveDataValues("Update boDictationLayers set empID='" & uEmpID & "', diclSkip = 1 where dicID=" & udicID & " and rolID='FR'")
    '    Else
    '        ConFR.saveDataValues("Update boDictationLayers set empID='" & uEmpID & "', diclSkip = 0 where dicID=" & udicID & " and rolID='FR'")
    '    End If
    'End Sub

    Protected Function getCounterDaily() As String
        Dim intCountDaily As Integer = Session("sccintDaily")
        intCountDaily += 1
        Session("sccintDaily") = intCountDaily
        Return intCountDaily.ToString
    End Function

    Protected Sub getDictationDetail(ByVal vidicID As Int32)
        Dim Con As New DBTaskBO
        Dim ds As DataSet
        Dim Qry As String = "SELECT boDictationLayers.empID, boDictationLayers.rolID, empFirstName +' '+ substring(empLastName,1,1) as empName, diclStatus " _
                            & "FROM boDictationLayers INNER JOIN boEmployee " _
                            & "ON boDictationLayers.empID = boEmployee.empID " _
                            & "INNER JOIN boDictation ON boDictationLayers.dicID = boDictation.dicID " _
                            & "WHERE boDictationLayers.dicID = " & vidicID & " AND dicStatus >= 0"

        ds = Con.getDataSet(Qry)
        For Each dr As DataRow In ds.Tables(0).Rows
            Select Case dr("rolID")
                Case "MT"
                    If dr("empID").ToString.Trim <> "0" Then
                        m_sMTName = dr("empName")
                    Else
                        m_sMTName = "-"
                    End If
                    If dr("diclStatus") < 2 Then
                        m_bMTStatus = True
                    Else
                        m_bMTStatus = False
                    End If
                    Select Case dr("diclStatus")
                        Case 0
                            m_cMTColor = System.Drawing.Color.Gray
                        Case 1
                            m_cMTColor = System.Drawing.Color.Orange
                        Case 2
                            m_cMTColor = System.Drawing.Color.Blue
                        Case 3
                            m_cMTColor = System.Drawing.Color.Green
                        Case Else
                            m_cMTColor = System.Drawing.Color.Red
                    End Select
                Case "QC"
                    If dr("empID").ToString.Trim <> "0" Then
                        m_sQCName = dr("empName")
                    Else
                        m_sQCName = "-"
                    End If
                    If dr("diclStatus") < 2 Then
                        m_bQCStatus = True
                    Else
                        m_bQCStatus = False
                    End If
                    Select Case dr("diclStatus")
                        Case 0
                            m_cQCColor = System.Drawing.Color.Gray
                        Case 1
                            m_cQCColor = System.Drawing.Color.Orange
                        Case 2
                            m_cQCColor = System.Drawing.Color.Blue
                        Case 3
                            m_cQCColor = System.Drawing.Color.Green
                        Case Else
                            m_cQCColor = System.Drawing.Color.Red
                    End Select
                Case "PR"
                    If dr("empID").ToString.Trim <> "0" Then
                        m_sPRName = dr("empName")
                    Else
                        m_sPRName = "-"
                    End If
                    If dr("diclStatus") < 2 Then
                        m_bPRStatus = True
                    Else
                        m_bPRStatus = False
                    End If
                    Select Case dr("diclStatus")
                        Case 0
                            m_cPRColor = System.Drawing.Color.Gray
                        Case 1
                            m_cPRColor = System.Drawing.Color.Orange
                        Case 2
                            m_cPRColor = System.Drawing.Color.Blue
                        Case 3
                            m_cPRColor = System.Drawing.Color.Green
                        Case Else
                            m_cPRColor = System.Drawing.Color.Red
                    End Select

                Case "FR"
                    If dr("empID").ToString.Trim <> "0" Then
                        m_sFRName = dr("empName")
                    Else
                        m_sFRName = "-"
                    End If
                    If dr("diclStatus") < 2 Then
                        m_bFRStatus = True
                    Else
                        m_bFRStatus = False
                    End If
                    Select Case dr("diclStatus")
                        Case 0
                            m_cFRColor = System.Drawing.Color.Gray
                        Case 1
                            m_cFRColor = System.Drawing.Color.Orange
                        Case 2
                            m_cFRColor = System.Drawing.Color.Blue
                        Case 3
                            m_cFRColor = System.Drawing.Color.Green
                        Case Else
                            m_cFRColor = System.Drawing.Color.Red
                    End Select
            End Select
        Next
        ds.Dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Protected Function getCounter() As String
        Dim intCount As Integer = Session("cint")
        intCount += 1
        Session("cint") = intCount
        Return intCount.ToString
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empID") = "" Then Response.Redirect(GF.Home)
        Session("cint") = 0
        If Me.IsPostBack And Request.QueryString("Click") = "" Then
            If D_Set_MT.Tables.Count > 0 Then
                Call Me.PostBack_MT()
            Else
                Call Me.loadMT()
            End If
            If D_Set_QC.Tables.Count > 0 Then
                Call Me.PostBack_QC()
            Else
                Call Me.loadQC()
            End If

            If D_Set_PR.Tables.Count > 0 Then
                Call Me.PostBack_PR()
            Else
                Call Me.loadPR()
            End If
            If D_Set_FR.Tables.Count > 0 Then
                Call Me.PostBack_FR()
            Else
                Call Me.loadFR()
            End If
        End If
        If Not Me.IsPostBack Then
            Call Me.PostBack_MT()
            Call Me.PostBack_QC()
            Call Me.PostBack_PR()
            Call Me.PostBack_FR()
        End If
    End Sub

    Protected Sub btnAssign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAssign.Click
        setAssignedGrid()
        Response.Redirect("dictationassignment.aspx?qStr='Assigned'")
    End Sub

    Protected Function getChkStatus(ByVal id As String) As String
        If ID > 2 Then
            Return "False"
        Else
            Return "True"
        End If
    End Function

    Protected Sub grdDictation_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDictation.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dicid As Int32
            dicid = grdDictation.DataKeys(e.Row.RowIndex).Values.Item(0)
            getDictationDetail(dicid)
        End If
    End Sub

    Protected Sub grdDictation_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDictation.RowDataBound
        'If e.Row.RowType = DataControlRowType.DataRow Then

        '    Dim dicid As Int32
        '    dicid = grdDictation.DataKeys(e.Row.RowIndex).Values.Item(0)
        '    getDictationDetail(dicid)
        'End If
    End Sub

    'Protected Function checkLastLayer(ByVal udicID As Long, ByVal urolID As String) As Boolean
    '    Dim cnLL As New DBTaskBO
    '    Dim dsLL As DataSet
    '    Dim strQry As String

    '    strQry = "SELECT * FROM boDictationLayers WHERE dicID = " & udicID & " " _
    '             & "AND diclSkip = 1 AND "
    '    If urolID = "QC" Then
    '        strQry = strQry & "rolID = 'PR' AND rolID = 'FR'"
    '    ElseIf urolID = "PR" Then
    '        strQry = strQry & "rolID = 'FR'"
    '    End If

    '    dsLL = cnLL.getDataSet(strQry)
    '    If dsLL.Tables(0).Rows.Count > 0 Then
    '        checkLastLayer = False
    '    Else
    '        checkLastLayer = True
    '    End If

    '    dsLL.Dispose()

    '    Return checkLastLayer
    'End Function    

    Protected Function getDate(ByVal dat As DateTime) As String
        Try
            Dim d As String = dat.ToShortDateString().ToString
            Return d
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Protected Function getMin(ByVal second As String) As String
        Return GF.GetMin(second)
    End Function

    Protected Function tagImage(ByVal dicId As Long, ByVal RollID As String) As String
        Dim Qry = "SELECT diclTag FROM boDictationlayers WHERE dicID=" & dicId & "AND rolID='" & RollID & "'"
        Dim tag As Int16
        Dim con As New DBTaskBO
        tag = con.getScalar(Qry)
        Try
            If tag = 1 Then
                RollID = "~/images/tag.gif"
            ElseIf tag = 0 Then
                RollID = "~/images/tag1.gif"
            End If
        Catch ex As Exception
        Finally
            con.objConnection.Close()
            con.objConnection.Dispose()
        End Try
        Return RollID
    End Function

    Private Sub loadMT()
        Dim Con As New DBTaskBO
        Dim Qry As String
        Dim strMT As String = Nothing
        Qry = "SELECT boEmployeeRoles.rolID, boEmployeeRoles.empID, " _
              & "boEmployee.empFirstName + ' ' + SUBSTRING(boEmployee.empLastName,1,1) " _
              & "AS empName FROM boEmployee INNER JOIN " _
              & "boEmployeeRoles ON boEmployee.empID = boEmployeeRoles.empID " _
              & "WHERE boEmployeeRoles.rolID = 'MT' AND boEmployeeRoles.empID <> '0' AND boEmployeeRoles.empEnable=1 AND boEmployee.empEnable=1 " _
              & "ORDER BY empName"
        DT_MT = Con.getDataSet(Qry).Tables(0)
        ddlMT.DataSource = DT_MT
        ddlMT.DataTextField = "empName"
        ddlMT.DataValueField = "empID"
        ddlMT.DataBind()
        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Private Sub loadQC()
        Dim Con As New DBTaskBO
        Dim Qry As String
        Dim strQC As String = Nothing
        Qry = "SELECT boEmployeeRoles.rolID, boEmployeeRoles.empID, " _
              & "boEmployee.empFirstName + ' ' + SUBSTRING(boEmployee.empLastName,1,1) " _
              & "AS empName FROM boEmployee INNER JOIN " _
              & "boEmployeeRoles ON boEmployee.empID = boEmployeeRoles.empID " _
              & "WHERE boEmployeeRoles.rolID = 'QC' AND boEmployeeRoles.empID <> '0' AND boEmployeeRoles.empEnable=1 AND boEmployee.empEnable=1 " _
              & "ORDER BY empName"
        DT_QC = Con.getDataSet(Qry).Tables(0)
        ddlQC.DataSource = DT_QC
        ddlQC.DataTextField = "empName"
        ddlQC.DataValueField = "empID"
        Dim dr As DataRow = DT_QC.NewRow
        dr("empName") = "Skipped"
        dr("empID") = "0"
        DT_QC.Rows.InsertAt(dr, DT_QC.Rows.Count)
        ddlQC.DataBind()
        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Private Sub loadPR()
        Dim Con As New DBTaskBO
        Dim Qry As String
        Dim strPR As String = Nothing
        Qry = "SELECT boEmployeeRoles.rolID, boEmployeeRoles.empID, " _
              & "boEmployee.empFirstName + ' ' + SUBSTRING(boEmployee.empLastName,1,1) " _
              & "AS empName FROM boEmployee INNER JOIN " _
              & "boEmployeeRoles ON boEmployee.empID = boEmployeeRoles.empID " _
              & "WHERE boEmployeeRoles.rolID = 'PR' AND boEmployeeRoles.empID <> '0' AND boEmployeeRoles.empEnable=1 AND boEmployee.empEnable=1 " _
              & "ORDER BY empName"
        DT_PR = Con.getDataSet(Qry).Tables(0)
        ddlPR.DataSource = DT_PR
        ddlPR.DataTextField = "empName"
        ddlPR.DataValueField = "empID"
        Dim dr As DataRow = DT_PR.NewRow
        dr("empName") = "Skipped"
        dr("empID") = "0"
        DT_PR.Rows.InsertAt(dr, DT_PR.Rows.Count)
        ddlPR.DataBind()
        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Private Sub loadFR()
        Dim Con As New DBTaskBO
        Dim Qry As String
        Dim strFR As String = Nothing
        Qry = "SELECT boEmployeeRoles.rolID, boEmployeeRoles.empID, " _
              & "boEmployee.empFirstName + ' ' + SUBSTRING(boEmployee.empLastName,1,1) " _
              & "AS empName FROM boEmployee INNER JOIN " _
              & "boEmployeeRoles ON boEmployee.empID = boEmployeeRoles.empID " _
              & "WHERE boEmployeeRoles.rolID = 'FR' AND boEmployeeRoles.empID <> '0' AND boEmployeeRoles.empEnable=1 AND boEmployee.empEnable=1 " _
              & "ORDER BY empName"
        DT_FR = Con.getDataSet(Qry).Tables(0)
        ddlFR.DataSource = DT_FR
        ddlFR.DataTextField = "empName"
        ddlFR.DataValueField = "empID"
        Dim dr As DataRow = DT_FR.NewRow
        dr("empName") = "Skipped"
        dr("empID") = "0"
        DT_FR.Rows.InsertAt(dr, DT_FR.Rows.Count)
        ddlFR.DataBind()
        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Private Sub PostBack_MT()
        If Not DT_MT.Rows.Count > 0 Then
            Call Me.loadMT()
        Else
            ddlMT.DataSource = DT_MT
            ddlMT.DataTextField = "empName"
            ddlMT.DataValueField = "empID"
            ddlMT.DataBind()
        End If
    End Sub
    Private Sub PostBack_QC()
        If Not DT_QC.Rows.Count > 0 Then
            Call Me.loadQC()
        Else
            ddlQC.DataSource = DT_QC
            ddlQC.DataTextField = "empName"
            ddlQC.DataValueField = "empID"
            ddlQC.DataBind()
        End If
       
    End Sub
    Private Sub PostBack_PR()
        If Not DT_PR.Rows.Count > 0 Then
            Call Me.loadPR()
        Else
            ddlPR.DataSource = DT_PR
            ddlPR.DataTextField = "empName"
            ddlPR.DataValueField = "empID"
            ddlPR.DataBind()
        End If
    
    End Sub
    Private Sub PostBack_FR()
        If Not DT_FR.Rows.Count > 0 Then
            Call Me.loadFR()
        Else
            ddlFR.DataSource = DT_FR
            ddlFR.DataTextField = "empName"
            ddlFR.DataValueField = "empID"
            ddlFR.DataBind()
        End If
    End Sub
    Protected Function PostBackUrl() As String
        Return "dictationassignment.aspx?Click='true'"
    End Function
End Class
