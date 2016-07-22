
Imports System.Data

Partial Class BO_singleassign
    Inherits System.Web.UI.Page
    Protected Dset As New System.Data.DataSet
    Protected Counter, InCounter As Int16

    Protected m_sMTName As String
    Protected m_bMTStatus As Boolean
    Protected m_cMTColor As System.Drawing.Color

    Protected m_sQCName As String
    Protected m_bQCStatus As Boolean
    Protected m_cQCColor As System.Drawing.Color

    Protected m_sPRName As String
    Protected m_bPRStatus As Boolean
    Protected m_cPRColor As System.Drawing.Color

    Protected m_sFRName As String
    Protected m_bFRStatus As Boolean
    Protected m_cFRColor As System.Drawing.Color
    Protected GridDetial As New GridView
    Protected BtnClick As Boolean
    Shared D_Set_MT, D_Set_QC, D_Set_PR, D_Set_FR As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Counter = 0
        If Not Me.IsPostBack Then
            Me.CPMain.SelectedDate = Now
            Me.CPMain.VisibleDate = Now
            Call Me.loadMT()
            Call Me.loadQC()
            Call Me.loadPR()
            Call Me.loadFR()
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Session("SelectedDate") = Me.CPMain.SelectedDate
        Dim objDictation As New dicassignment
        objDictation.SelectedDate = Me.CPMain.SelectedDate
        objDictation.EmplyeeID = "-1"

        Dim ConStr As New MTBMS.DAL.DBTaskBO
        Dset = ConStr.getDataSet(objDictation.Dic_Query(Format(Me.CPMain.SelectedDate, "MM/dd/yyyy"), chkShowAll.Checked))
        Dset.Tables(0).TableName = "Dictators"
        Dset.Tables(1).TableName = "Dictations"

        Me.BtnClick = True
        Me.grdcurrent.DataSource = Dset

        If Dset.Tables(0).Rows.Count > 0 Then
            Me.grdcurrent.DataMember = "Dictators"
            Me.grdcurrent.DataBind()
            Me.grdcurrent.Visible = True
        Else
            Me.grdcurrent.Visible = False
        End If
    End Sub

    Protected Sub grdcurrent_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdcurrent.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            Counter += 1
        End If
    End Sub

    Protected Sub grdcurrent_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdcurrent.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            InCounter = 0
            Me.GridDetial = e.Row.FindControl("GridView1")
            Dim DV As New DataView(Dset.Tables(1))
            DV.RowFilter = "foID+drID='" & Me.grdcurrent.DataKeys(e.Row.RowIndex).Values.Item("foID") & Me.grdcurrent.DataKeys(e.Row.RowIndex).Values.Item("drID") & "'"
            Me.GridDetial.DataSource = DV
            Me.GridDetial.DataMember = "Dictations"
            Me.GridDetial.DataBind()
        End If
    End Sub
    Protected Sub getDictationDetail(ByVal vidicID As Int32)
        Dim Con As New MTBMS.DAL.DBTaskBO
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

    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow And Me.BtnClick Then
            InCounter += 1
            getDictationDetail(Me.GridDetial.DataKeys(e.Row.RowIndex).Values.Item("dicID"))

            Dim Qry As String
            Dim Con As New MTBMS.DAL.DBTaskBO
            Dim dicID As Int32 = Me.GridDetial.DataKeys(e.Row.RowIndex).Values.Item(0)
            Dim dicActualName As String = Me.GridDetial.DataKeys(e.Row.RowIndex).Values.Item(1)
            Dim dicLength As Long = Me.GridDetial.DataKeys(e.Row.RowIndex).Values.Item(2)
            Dim dicDuplicateCheck As Boolean = CBool(Me.GridDetial.DataKeys(e.Row.RowIndex).Values.Item(3))


            If Not dicDuplicateCheck Then
                Qry = "Select count(*) from boDictation where dicActualName = '" & dicActualName & "' AND dicLength = " & dicLength & " AND dicID <> " & dicID
                If Con.getScalar(Qry) > 0 Then
                    Dim imgDuplicate As ImageButton = e.Row.FindControl("btnDuplicate")
                    imgDuplicate.Visible = True

                    imgDuplicate.CommandArgument = e.Row.RowIndex
                    imgDuplicate.CommandName = "duplicate_dictation"
                Else
                    Dim imgDummy As ImageButton = e.Row.FindControl("imgDummy")
                    imgDummy.Visible = True
                End If
            Else
                Qry = "Select count(*) from boDictation where dicActualName = '" & dicActualName & "' AND dicLength = " & dicLength & " AND dicID <> " & dicID
                If Con.getScalar(Qry) > 0 Then
                    Dim imgDuplicateCheck As ImageButton = e.Row.FindControl("btnDuplicateCheck")
                    imgDuplicateCheck.Visible = True

                    imgDuplicateCheck.CommandArgument = e.Row.RowIndex
                    imgDuplicateCheck.CommandName = "duplicate_dictation"
                Else
                    Dim imgDummy As ImageButton = e.Row.FindControl("imgDummy")
                    imgDummy.Visible = True
                End If
            End If

        End If
    End Sub
    Private Sub loadMT()
        Dim Con As New MTBMS.DAL.DBTaskBO
        Dim Qry As String
        Dim strMT As String = Nothing
        Qry = "SELECT boEmployeeRoles.rolID, boEmployeeRoles.empID, " _
              & "boEmployee.empFirstName + ' ' + SUBSTRING(boEmployee.empLastName,1,1) " _
              & "AS empName FROM boEmployee INNER JOIN " _
              & "boEmployeeRoles ON boEmployee.empID = boEmployeeRoles.empID " _
              & "WHERE boEmployeeRoles.rolID = 'MT' AND boEmployeeRoles.empID <> '0' AND boEmployeeRoles.empEnable=1 AND boEmployee.empEnable=1 " _
              & "ORDER BY empName"
        D_Set_MT = Con.getDataSet(Qry)
        ddlMT.DataSource = D_Set_MT.Tables(0)
        ddlMT.DataTextField = "empName"
        ddlMT.DataValueField = "empID"
        ddlMT.DataBind()
        Con.objConnection.Close()
        Con = Nothing
    End Sub
    Private Sub loadQC()
        Dim Con As New MTBMS.DAL.DBTaskBO
        Dim Qry As String
        Dim strQC As String = Nothing
        Qry = "SELECT boEmployeeRoles.rolID, boEmployeeRoles.empID, " _
              & "boEmployee.empFirstName + ' ' + SUBSTRING(boEmployee.empLastName,1,1) " _
              & "AS empName FROM boEmployee INNER JOIN " _
              & "boEmployeeRoles ON boEmployee.empID = boEmployeeRoles.empID " _
              & "WHERE boEmployeeRoles.rolID = 'QC' AND boEmployeeRoles.empID <> '0' AND boEmployeeRoles.empEnable=1 AND boEmployee.empEnable=1 " _
              & "ORDER BY empName"
        D_Set_QC = Con.getDataSet(Qry)
        ddlQC.DataSource = D_Set_QC.Tables(0)
        ddlQC.DataTextField = "empName"
        ddlQC.DataValueField = "empID"
        ddlQC.DataBind()
        ddlQC.Items.Add("Skipped")
        Con.objConnection.Close()
        Con = Nothing
    End Sub
    Private Sub loadPR()
        Dim Con As New MTBMS.DAL.DBTaskBO
        Dim Qry As String
        Dim strPR As String = Nothing
        Qry = "SELECT boEmployeeRoles.rolID, boEmployeeRoles.empID, " _
              & "boEmployee.empFirstName + ' ' + SUBSTRING(boEmployee.empLastName,1,1) " _
              & "AS empName FROM boEmployee INNER JOIN " _
              & "boEmployeeRoles ON boEmployee.empID = boEmployeeRoles.empID " _
              & "WHERE boEmployeeRoles.rolID = 'PR' AND boEmployeeRoles.empID <> '0' AND boEmployeeRoles.empEnable=1 AND boEmployee.empEnable=1 " _
              & "ORDER BY empName"
        D_Set_PR = Con.getDataSet(Qry)
        ddlPR.DataSource = D_Set_PR.Tables(0)
        ddlPR.DataTextField = "empName"
        ddlPR.DataValueField = "empID"
        ddlPR.DataBind()
        ddlPR.Items.Add("Skipped")
        Con.objConnection.Close()
        Con = Nothing
    End Sub
    Private Sub loadFR()
        Dim Con As New MTBMS.DAL.DBTaskBO
        Dim Qry As String
        Dim strFR As String = Nothing
        Qry = "SELECT boEmployeeRoles.rolID, boEmployeeRoles.empID, " _
              & "boEmployee.empFirstName + ' ' + SUBSTRING(boEmployee.empLastName,1,1) " _
              & "AS empName FROM boEmployee INNER JOIN " _
              & "boEmployeeRoles ON boEmployee.empID = boEmployeeRoles.empID " _
              & "WHERE boEmployeeRoles.rolID = 'FR' AND boEmployeeRoles.empID <> '0' AND boEmployeeRoles.empEnable=1 AND boEmployee.empEnable=1 " _
              & "ORDER BY empName"
        D_Set_FR = Con.getDataSet(Qry)
        ddlFR.DataSource = D_Set_FR.Tables(0)
        ddlFR.DataTextField = "empName"
        ddlFR.DataValueField = "empID"
        ddlFR.DataBind()
        ddlFR.Items.Add("Skipped")
        Con.objConnection.Close()
        Con = Nothing
    End Sub
    Private Sub PostBack_MT()
        ddlMT.DataSource = D_Set_MT.Tables(0)
        ddlMT.DataTextField = "empName"
        ddlMT.DataValueField = "empID"
        ddlMT.DataBind()
    End Sub
    Private Sub PostBack_QC()
        ddlQC.DataSource = D_Set_QC.Tables(0)
        ddlQC.DataTextField = "empName"
        ddlQC.DataValueField = "empID"
        ddlQC.DataBind()
        ddlQC.Items.Add("Skipped")
    End Sub
    Private Sub PostBack_PR()
        ddlPR.DataSource = D_Set_PR.Tables(0)
        ddlPR.DataTextField = "empName"
        ddlPR.DataValueField = "empID"
        ddlPR.DataBind()
        ddlPR.Items.Add("Skipped")
    End Sub
    Private Sub PostBack_FR()
        ddlFR.DataSource = D_Set_FR.Tables(0)
        ddlFR.DataTextField = "empName"
        ddlFR.DataValueField = "empID"
        ddlFR.DataBind()
        ddlFR.Items.Add("Skipped")
    End Sub

    Protected Sub btnAssign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAssign.Click
        For Each GR As GridViewRow In Me.grdcurrent.Rows
            Me.GridDetial = GR.FindControl("GridView1")
            Dim ChkMT, ChkQC, ChkPR, ChkFR As CheckBox
            For Each GRD As GridViewRow In Me.GridDetial.Rows
                Dim p_dicID As Long = Me.GridDetial.DataKeys(GRD.RowIndex).Values.Item("dicID")
                ChkMT = CType(GRD.FindControl("chkMT"), CheckBox)
                ChkQC = CType(GRD.FindControl("chkQC"), CheckBox)
                ChkPR = CType(GRD.FindControl("chkPR"), CheckBox)
                ChkFR = CType(GRD.FindControl("chkFR"), CheckBox)
                If ChkMT.Checked Then UpdateMT(p_dicID, Me.ddlMT.SelectedValue)
                If ChkQC.Checked Then UpdateLayer(p_dicID, "QC", Me.ddlQC.SelectedValue)
                If ChkPR.Checked Then UpdateLayer(p_dicID, "PR", Me.ddlPR.SelectedValue)
                If ChkFR.Checked Then UpdateLayer(p_dicID, "FR", Me.ddlFR.SelectedValue)

                'If p_dicID = 700807 Or p_dicID = 700900 Then UpdateMT(p_dicID, Me.ddlMT.SelectedValue)
                'If p_dicID = 700807 Or p_dicID = 700900 Then UpdateLayer(p_dicID, "QC", Me.ddlQC.SelectedValue)
                'If p_dicID = 700807 Or p_dicID = 700900 Then UpdateLayer(p_dicID, "PR", Me.ddlPR.SelectedValue)
                'If p_dicID = 700807 Or p_dicID = 700900 Then UpdateLayer(p_dicID, "FR", Me.ddlFR.SelectedValue)

            Next
        Next
        Me.CPMain.SelectedDate = Session("SelectedDate")
        Me.CPMain.VisibleDate = Session("SelectedDate")
        Dim ObjDictation As New dicassignment
        ObjDictation.SelectedDate = Session("SelectedDate")
        objDictation.EmplyeeID = "-1"
        Dim ConStr As New MTBMS.DAL.DBTaskBO
        Dset = ConStr.getDataSet(ObjDictation.Dic_Query(Format(Me.CPMain.SelectedDate, "MM/dd/yyyy"), chkShowAll.Checked))
        Dset.Tables(0).TableName = "Dictators"
        Dset.Tables(1).TableName = "Dictations"
        Me.BtnClick = True
        Me.grdcurrent.DataSource = Dset
        If Dset.Tables.Count > 0 Then
            Me.grdcurrent.DataMember = "Dictators"
            Me.grdcurrent.DataBind()
        End If
    End Sub

    Private Sub UpdateMT(ByVal udicID As Long, ByVal uEmpID As String)
        Dim ConMT As New MTBMS.DAL.DBTaskBO
        ConMT.saveDataValues("UPDATE boDictationLayers SET empID='" & uEmpID & "' " _
                             & "WHERE dicID = " & udicID & " AND rolID = 'MT'")

        ConMT = Nothing
    End Sub
    Private Sub UpdateLayer(ByVal udicID As Long, ByVal vsrolID As String, ByVal uEmpID As String)
        Dim cnQC As New MTBMS.DAL.DBTaskBO
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
                     & "diclSkip = " & IIf(uEmpID = "0", 1, 0) & "" _
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
                strQry = "UPDATE boDictationLayers SET empID = '" & uEmpID & "'" _
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
        Dim cnLL As New MTBMS.DAL.DBTaskBO
        Dim dsLL As DataSet

        Dim strQry As String
        Dim iRecordsEffected As Int16

        strQry = "SELECT * FROM boDictationLayers WHERE dicID = " & udicID & " " _
                 & "AND diclSkip = 0 AND rolID = '" & vsToRole & "'"

        dsLL = cnLL.getDataSet(strQry)
        If dsLL.Tables(0).Rows.Count > 0 Then
            strQry = "UPDATE boTranscriptionLayers SET rolID = '" & vsToRole & "', " _
            & "empID = '" & dsLL.Tables(0).Rows(0)("empID") & "'" _
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
        Dim cnLL As New MTBMS.DAL.DBTaskBO
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

End Class