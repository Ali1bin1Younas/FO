Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class BO_dictationtools
    Inherits System.Web.UI.Page
    Dim Qry As String
    Dim Con As New DBTaskBO
    Dim ds As New DataSet
    Protected Row_Counter As Int16

    Protected m_sMTName As String
    Protected m_cMTColor As System.Drawing.Color

    Protected m_sQCName As String
    Protected m_cQCColor As System.Drawing.Color

    Protected m_sPRName As String
    Protected m_cPRColor As System.Drawing.Color

    Protected m_sFRName As String
    Protected m_cFRColor As System.Drawing.Color

    Protected dic_Status As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        Row_Counter = 0
        If Not Page.IsPostBack Then
            CPFrom.SelectedDate = Now
            CPFrom.VisibleDate = Now

            CpTo.SelectedDate = Now
            CpTo.VisibleDate = Now
        End If
        

        'Me.btnReupload.Attributes.Add("onclick", "return confirmReupload();")
        'Me.btnDelete.Attributes.Add("onclick", "return confirmDelete();")
        'Me.btnReset.Attributes.Add("onclick", "return confirmReset();")
        Me.btnRestore.Attributes.Add("onclick", "return confirmRestore();")
        Me.btnPurge.Attributes.Add("onclick", "return confirmPurge();")

        'Me.btnReupload1.Attributes.Add("onclick", "return confirmReupload();")
        'Me.btnDelete1.Attributes.Add("onclick", "return confirmDelete();")
        'Me.btnReset1.Attributes.Add("onclick", "return confirmReset();")
        Me.btnRestore1.Attributes.Add("onclick", "return confirmRestore();")
        Me.btnPurge1.Attributes.Add("onclick", "return confirmPurge();")

        If Not Me.IsPostBack Then
            Call Me.Load_ddl_Dictator()
            Call Me.Load_ddl_Location()
            Call Me.Load_ddl_Employee()

            With ddlStatus
                .Items.Insert(0, "Active")
                .Items.Insert(1, "Deleted")
                .Items.Insert(2, "All")
            End With

            With ddlSorting
                .Items.Insert(0, "Dictator, Dictation Name")
                .Items.Insert(1, "Date, Dictation Name")
                .Items.Insert(2, "Dictation Name, Date")
            End With
        End If
    End Sub

    Public Sub Check_Fields()
        If Me.txtDictation.Text = "" AndAlso Me.ddlDictator.SelectedValue = "-1" _
                       AndAlso Me.CpTo.SelectedDate = Nothing _
                        AndAlso Me.CPFrom.SelectedDate = Nothing Then
            Me.gvDictation.Visible = False
            Exit Sub
        Else
            Row_Counter = 0
            Me.gvDictation.Visible = True
            Me.Load_grid_Transcription()
        End If
    End Sub


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.Check_Fields()
    End Sub


    Protected Sub Load_grid_Transcription()
        Dim sDictator, sAccount, sDate, sStatus, sSort As String

        If Me.ddlDictator.SelectedValue = "-1" Then
            sDictator = ""
        Else
            sDictator = " AND foId+drId Like '%" & Me.ddlDictator.SelectedValue & "%'"
        End If

        If Me.ddlLocation.SelectedItem.Text = "All Accounts" Then
            sAccount = ""
        Else
            sAccount = " AND boDictation.dicAccountName Like '%" & Me.ddlLocation.SelectedItem.Text & "%'"
        End If

        If Me.CPFrom.SelectedDate = Nothing And Me.CpTo.SelectedDate = Nothing Then
            sDate = ""
        ElseIf Me.CPFrom.SelectedDate <> Nothing And Me.CpTo.SelectedDate = Nothing Then
            sDate = " AND dicDate= '" & Format(Me.CPFrom.SelectedDate, "MM/dd/yyyy") & "'"
        ElseIf Me.CpTo.SelectedDate <> Nothing And Me.CPFrom.SelectedDate = Nothing Then
            sDate = " AND dicDate= '" & Format(Me.CpTo.SelectedDate, "MM/dd/yyyy") & "'"
        Else
            sDate = " AND dicDate BETWEEN '" & Format(Me.CPFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CpTo.SelectedDate, "MM/dd/yyyy") & "'"
        End If

        If ddlStatus.SelectedIndex = 0 Then
            sStatus = " AND dicEnable = 1"
        ElseIf ddlStatus.SelectedIndex = 1 Then
            sStatus = " AND dicEnable = 0"
        Else
            sStatus = ""
        End If

        If ddlSorting.SelectedIndex = 0 Then
            sSort = ",boDictation.drID,boDictation.dicActualName"
        ElseIf ddlSorting.SelectedIndex = 1 Then
            sSort = ",boDictation.dicDate,boDictation.dicActualName"
        ElseIf ddlSorting.SelectedIndex = 2 Then
            sSort = ",boDictation.dicActualName,boDictation.dicDate"
        End If

        Qry = "Select dicId,foId,drId,dicActualName,dicDate,dicAccountName, " _
                & "dicStatus,dicLength,dicEnable,dicDuplicateCheck from boDictation " _
                & "where dicTempName like '%" & Me.txtDictation.Text & "%' " _
                & sDictator & sAccount & sDate & sStatus & " ORDER BY boDictation.foID" & sSort

        ds = Con.getDataSet(Qry)
        Me.gvDictation.DataSource = ds
        Me.gvDictation.DataBind()

    End Sub

    Public Sub Load_ddl_Dictator()
        Qry = "SELECT foID+drID As UId ,foID + '-' + drID + '  ' + drLastName + ', ' + drFirstName+ ' '+ ISNULL(drMiddleName,'') As DictatorName " _
                & "FROM  boDictator where drEnable = 1 Order by foID, drID"
        ds = Con.getDataSet(Qry)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow = dt.NewRow
        dr("UId") = "-1"
        dr("DictatorName") = "All Dictators"
        dt.Rows.InsertAt(dr, 0)
        Me.ddlDictator.DataSource = dt
        Me.ddlDictator.DataBind()
    End Sub

    Protected Sub Load_ddl_Location()
        Qry = "SELECT Distinct dicAccountName FROM boDictation Order by dicAccountName"
        ds = Con.getDataSet(Qry)
        Dim dt As DataTable = ds.Tables(0)

        Me.ddlLocation.DataTextField = "dicAccountName"
        Me.ddlLocation.DataSource = dt
        Me.ddlLocation.DataBind()

        Me.ddlLocation.Items.Insert(0, "All Accounts")
    End Sub

    Protected Sub Load_ddl_Employee()
        Qry = "SELECT empID, (empFirstName +' '+ empLastName) as empName from boEmployee order by empName"
        ds = Con.getDataSet(Qry)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow = dt.NewRow
        dr("empID") = "-1"
        dr("empName") = "All Dictators"

        Me.ddlEmployee.DataTextField = "empName"
        Me.ddlEmployee.DataValueField = "empID"
        Me.ddlEmployee.DataSource = dt
        Me.ddlEmployee.DataBind()

        Me.ddlEmployee.Items.Insert(0, "All Employees")
    End Sub

    Protected Sub gvDictation_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDictation.RowCommand

        'Dim coll As Collections.Specialized.IOrderedDictionary
        Dim dicId As Int32 = Me.gvDictation.DataKeys(e.CommandArgument.ToString).Values.Item(0)
        'Dim dicId As Int32 = coll.Item(0)

        If e.CommandName = "Change_Minutes" AndAlso GF.Refresh = 1 Then
            Dim str1 As String = "popupchangeminutes.aspx?dicID=" & dicId
            Dim str = "<script>void window.open('" & str1 & "' ,'_blank','scrollbars=0,toolbar=0,menubar=0,location=0,directories=0,resizable=0,status=0,titlebar=0,height=' + screen.availHeight/2.7 + ',width=' + screen.availWidth/3 + ',top=' + screen.availHeight/4 + ',left=' + screen.availWidth/4 + '')</script>"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "OpenWindow", str)
        ElseIf e.CommandName = "duplicate_dictation" AndAlso GF.Refresh = 1 Then
            Dim str1 As String = "popupduplicate.aspx?dicID=" & dicId
            Dim str = "<script>void window.open('" & str1 & "' ,'_blank','scrollbars=0,toolbar=0,menubar=0,location=0,directories=0,resizable=0,status=0,titlebar=0,height=' + screen.availHeight/2.7 + ',width=' + screen.availWidth/3 + ',top=' + screen.availHeight/4 + ',left=' + screen.availWidth/4 + '')</script>"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "OpenWindow", str)
        Else
            GF.Refresh = 1
            Me.Load_grid_Transcription()
        End If
        'If e.CommandName = "Del" AndAlso GF.Refresh = 1 Then
        '    Dim str1 As String = "popupdeletedictation.aspx?dicID=" & dicId
        '    Dim str = "<script>void window.open('" & str1 & "' ,'_blank','scrollbars=1,toolbar=0,menubar=0,location=0,directories=0,resizable=1,status=0,titlebar=0,height=' + screen.availHeight + ',width=' + screen.availWidth + ',top=0,left=0')</script>"
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "OpenWindow", str)
        'ElseIf e.CommandName = "Reup" AndAlso GF.Refresh = 1 Then
        '    Dim str1 As String = "popupreuploaddictation.aspx?dicID=" & dicId
        '    Dim str = "<script>void window.open('" & str1 & "' ,'_blank','scrollbars=1,toolbar=0,menubar=0,location=0,directories=0,resizable=1,status=0,titlebar=0,height=' + screen.availHeight + ',width=' + screen.availWidth + ',top=0,left=0')</script>"
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "OpenWindow", str)
        'Else
        '    GF.Refresh = 1
        'End If
    End Sub

    Protected Sub gvDictation_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDictation.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            Row_Counter += 1

            Dim dicID As Int32 = Me.gvDictation.DataKeys(e.Row.RowIndex).Values.Item(0)
            Dim dicActualName As String = Me.gvDictation.DataKeys(e.Row.RowIndex).Values.Item(1)
            Dim dicLength As Long = Me.gvDictation.DataKeys(e.Row.RowIndex).Values.Item(2)
            Dim dicEnable As Boolean = CBool(Me.gvDictation.DataKeys(e.Row.RowIndex).Values.Item(3))
            Dim dicDuplicateCheck As Boolean = CBool(Me.gvDictation.DataKeys(e.Row.RowIndex).Values.Item(4))

            Call Me.getTranscriptionDetail(dicID)

            'Dim ChangeMin As ImageButton = e.Row.FindControl("ChangeMin")
            'ChangeMin.CommandArgument = e.Row.RowIndex
            'ChangeMin.CommandName = "Change_Minutes"

            'If Not dicDuplicateCheck Then
            '    Qry = "Select count(*) from boDictation where dicActualName = '" & dicActualName & "' AND dicLength = " & dicLength & " AND dicID <> " & dicID
            '    If Con.getScalar(Qry) > 0 Then
            '        Dim imgDuplicate As ImageButton = e.Row.FindControl("btnDuplicate")
            '        imgDuplicate.Visible = True

            '        imgDuplicate.CommandArgument = e.Row.RowIndex
            '        imgDuplicate.CommandName = "duplicate_dictation"
            '    Else
            '        Dim imgDummy As ImageButton = e.Row.FindControl("imgDummy")
            '        imgDummy.Visible = True
            '    End If
            'Else
            '    Qry = "Select count(*) from boDictation where dicActualName = '" & dicActualName & "' AND dicLength = " & dicLength & " AND dicID <> " & dicID
            '    If Con.getScalar(Qry) > 0 Then
            '        Dim imgDuplicateCheck As ImageButton = e.Row.FindControl("btnDuplicateCheck")
            '        imgDuplicateCheck.Visible = True

            '        imgDuplicateCheck.CommandArgument = e.Row.RowIndex
            '        imgDuplicateCheck.CommandName = "duplicate_dictation"
            '    Else
            '        Dim imgDummy As ImageButton = e.Row.FindControl("imgDummy")
            '        imgDummy.Visible = True
            '    End If
            'End If

            If Not dicEnable Then
                e.Row.Cells(1).BackColor = Drawing.Color.Red
            End If
        End If
    End Sub

    Protected Sub getTranscriptionDetail(ByVal vidicID As Int32)
        Dim empclause As String = ""
        Dim Con As New DBTaskBO
        Dim ds As DataSet

        If ddlEmployee.SelectedValue.ToString <> "-1" Then
            empclause = ""
        End If

        Dim Qry As String = "Select bDL.empId,empFirstName +' '+substring(empLastName,1,1) as empName,rolId, " _
                            & "diclStatus from boDictationLayers bDL " _
                            & "Inner join boEmployee bE on bDL.empID = bE.empID " _
                            & "Inner join boDictation bD on bDL.dicId = bD.dicId " _
                            & "where bDL.dicId= " & vidicID & "AND bD.dicStatus >= 0"

        ds = Con.getDataSet(Qry)
        For Each dr As DataRow In ds.Tables(0).Rows
            Select Case dr("rolID")
                Case "MT"
                    If dr("empID").ToString.Trim <> "0" Then
                        m_sMTName = dr("empName")
                    Else
                        m_sMTName = "-"
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

    Protected Function Status(ByVal dicStatus As Int32) As String
        Select Case dicStatus
            Case 0
                dic_Status = "New"
                Exit Select
            Case 1
                dic_Status = "Processing"
                Exit Select
            Case 2
                dic_Status = "Complete"
                Exit Select
            Case 3
                dic_Status = "Gathered"
                Exit Select
            Case 4
                dic_Status = "Uploaded"
                Exit Select
            Case Else
                dic_Status = "Error"
                Exit Select
        End Select

        Return dic_Status

    End Function

    Protected Function getMin(ByVal second As String) As String
        Return GF.GetMin(second)
    End Function

    'Protected Sub btnReupload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReupload.Click, btnReupload1.Click
    '    Call DictationTools("reupload")
    'End Sub

    'Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click, btnDelete1.Click
    '    Call DictationTools("delete")
    'End Sub

    'Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click, btnReset1.Click
    '    Call DictationTools("reset")
    'End Sub

    Protected Sub btnRestore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRestore.Click, btnRestore1.Click
        Call DictationTools("restore")
    End Sub

    Protected Sub btnPurge_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPurge.Click, btnPurge1.Click
        Call DictationTools("purge")
    End Sub

    Private Sub DictationTools(ByVal sAction As String)
        Dim chkDictation As CheckBox
        Dim dicID As Label
        Dim dicStatus As Label

        For Each item As GridViewRow In Me.gvDictation.Rows
            chkDictation = item.FindControl("chkDictation")
            dicID = item.FindControl("lblDicID")
            dicStatus = item.FindControl("lblDicStatus")

            If chkDictation.Checked Then
                If sAction = "delete" Then
                    If dicStatus.Text <> "Gathered" Or dicStatus.Text <> "Uploaded" Then
                        Qry = "UPDATE boDictation SET dicEnable = 0 WHERE dicID = " & dicID.Text
                    End If
                ElseIf sAction = "reupload" Then
                    Qry = "Select count(*) from boTranscription where dicId = " & dicID.Text

                    If Con.getScalar(Qry) > 0 Then
                        Qry = "Select count(*) from boTranscription where dicId = " & dicID.Text & " AND traStatus = 0"

                        If Con.getScalar(Qry) = 0 Then
                            Qry = "Select count(*) from boTranscription where dicId = " & dicID.Text
                            Dim docCount As Integer = Con.getScalar(Qry)

                            Qry = "UPDATE boDictationLayers SET diclStatus=3, diclTranscriptions=" & docCount & " WHERE dicID = " & dicID.Text & ";"
                            Qry &= "UPDATE boTranscriptionLayers SET tralStatus=2 WHERE dicID = " & dicID.Text & ";"
                            Qry &= "UPDATE boDictation SET dicStatus=2, dicTranscriptions=" & docCount & " WHERE dicID = " & dicID.Text & ";"
                            Qry &= "UPDATE boTranscription SET traStatus=1 WHERE dicID = " & dicID.Text & ";"
                        End If
                    End If
                ElseIf sAction = "reset" Then
                    If dicStatus.Text <> "Gathered" Or dicStatus.Text <> "Uploaded" Then
                        Qry = "DELETE boTranscriptionLayers where dicID = " & dicID.Text & ";"
                        Qry &= "DELETE boTranscription where dicID = " & dicID.Text & ";"
                        Qry &= "UPDATE boDictationLayers SET diclStatus=0, diclTag=0, diclTranscriptions=0 WHERE dicID = " & dicID.Text & ";"
                        Qry &= "UPDATE boDictationLayers SET diclStatus=1 WHERE dicID = " & dicID.Text & " AND rolID='MT';"
                        Qry &= "UPDATE boDictationLayers SET empID=0 WHERE dicID = " & dicID.Text & " AND diclSkip=1;"
                        Qry &= "UPDATE boDictation SET dicStatus=0, dicTranscriptions=0 WHERE dicID = " & dicID.Text & ";"
                    End If
                ElseIf sAction = "restore" Then
                    Qry = "UPDATE boDictation SET dicEnable = 1 WHERE dicID = " & dicID.Text
                ElseIf sAction = "purge" Then
                    If item.Cells(1).BackColor = Drawing.Color.Red Then
                        If dicStatus.Text <> "Gathered" Or dicStatus.Text <> "Uploaded" Then
                            Qry = "DELETE boTranscriptionLayers where dicID = " & dicID.Text & ";"
                            Qry &= "DELETE boTranscription where dicID = " & dicID.Text & ";"
                            Qry &= "DELETE boDictationLayers where dicID = " & dicID.Text & ";"
                            Qry &= "DELETE boDictation where dicID = " & dicID.Text & ";"
                        End If
                    End If
                End If

                    Con.saveData(Qry)
                    Me.Load_grid_Transcription()
            End If
        Next
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        ds.Dispose()
        ds = Nothing
        Con = Nothing
    End Sub

    
    
    
End Class
