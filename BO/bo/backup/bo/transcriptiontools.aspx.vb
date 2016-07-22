Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class BO_transcriptiontools
    Inherits System.Web.UI.Page
    Dim Qry As String
    Dim Con As New DBTaskBO
    Dim ds As New DataSet
    Protected iCounter As Int16
    Protected Flag As Boolean

    Protected m_sMTName As String
    Protected m_iMTStatus As Int16
    Protected m_cMTColor As System.Drawing.Color

    Protected m_sQCName As String
    Protected m_iQCStatus As Int16
    Protected m_cQCColor As System.Drawing.Color

    Protected m_sPRName As String
    Protected m_iPRStatus As Int16
    Protected m_cPRColor As System.Drawing.Color

    Protected m_sFRName As String
    Protected m_iFRStatus As Int16
    Protected m_cFRColor As System.Drawing.Color

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empID") = "" Then Response.Redirect(GF.Home)
        iCounter = 0
        If Not Me.IsPostBack Then
            Flag = True
            Load_ddl_Dictator()
            Load_ddl_Location()

            With ddlSorting
                .Items.Insert(0, "Dictator, Dictation Name")
                .Items.Insert(1, "Date, Dictation Name")
                .Items.Insert(2, "Dictation Name, Date")
            End With
        Else
            Flag = False
        End If
    End Sub

    Public Sub Load_ddl_Dictator()
        Qry = "SELECT foID+drID As UId ,foID + '-' + drID + '  ' + drLastName + ', ' + drFirstName+ ' '+ ISNULL(drMiddleName,'') As DictatorName " _
                & "FROM  boDictator Order by foID, drID"
        ds = Con.getDataSet(Qry)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow = dt.NewRow
        dr("UId") = -1
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

    Protected Sub gridTranscription_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridTranscription.RowCommand
        Dim coll As Collections.Specialized.IOrderedDictionary
        coll = Me.gridTranscription.DataKeys(e.CommandArgument.ToString).Values
        Dim dicId As Int32 = coll.Item(0)
        Dim traID As Int32 = coll.Item(1)
        Try
            If e.CommandName = "reverse" AndAlso GF.Refresh = 1 Then
                Dim str1 As String = "popupreversetranscription.aspx?traID=" & traID & "&dicID=" & dicId
                Dim str = "<script>void window.open('" & str1 & "' ,'_blank','scrollbars=0,toolbar=0,menubar=0,location=0,directories=0,resizable=0,status=0,titlebar=0,height=270,width=396,top=' + screen.availHeight/4 + ',left=' + screen.availWidth/4 + '')</script>"
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "OpenWindow", str)
            ElseIf e.CommandName = "delete" AndAlso GF.Refresh = 1 Then
                'Dim str1 As String = "popupdeletetranscription.aspx?traID=" & traID & "&dicID=" & dicId
                'Dim str = "<script>void window.open('" & str1 & "' ,'_blank','scrollbars=0,toolbar=0,menubar=0,location=0,directories=0,resizable=0,status=0,titlebar=0,height=' + screen.availHeight/2.7 + ',width=' + screen.availWidth/3 + ',top=' + screen.availHeight/4 + ',left=' + screen.availWidth/4 + '')</script>"
                'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "OpenWindow", str)
            ElseIf e.CommandName = "view" Then
                Dim str1 As String = "popupviewtranscription.aspx?traID=" & traID & "&dicID=" & dicId
                Dim str = "<script>void window.open('" & str1 & "' ,'_blank','scrollbars=0,toolbar=0,menubar=0,location=0,directories=0,resizable=0,status=0,titlebar=0,height=' + screen.availHeight/2.7 + ',width=' + screen.availWidth/3 + ',top=' + screen.availHeight/4 + ',left=' + screen.availWidth/4 + '')</script>"
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "OpenWindow", str)
            Else
                GF.Refresh = 1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gridTranscription_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridTranscription.RowCreated

        If e.Row.RowType = DataControlRowType.DataRow Then
            iCounter += 1

            Dim dicID, traID As Int32
            dicID = gridTranscription.DataKeys(e.Row.RowIndex).Values.Item(0)
            traID = gridTranscription.DataKeys(e.Row.RowIndex).Values.Item(1)

            Call getTranscriptionDetail(dicID, traID)

            Dim imgRe, imgDe, imgView As ImageButton

            'imgRe = e.Row.FindControl("btnRe")
            'imgRe.CommandArgument = e.Row.RowIndex
            'imgRe.CommandName = "reverse"

            'imgDe = e.Row.FindControl("btnDel")
            'imgDe.CommandArgument = e.Row.RowIndex
            'imgDe.CommandName = "delete"

            imgView = e.Row.FindControl("btnView")
            imgView.CommandArgument = e.Row.RowIndex
            imgView.CommandName = "view"
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Me.txtDictation.Text = "" AndAlso Me.ddlDictator.SelectedValue = "-1" _
        AndAlso Me.ddlLocation.SelectedValue = "-1" AndAlso Me.CpTo.SelectedDate = Nothing _
        AndAlso Me.CPFrom.SelectedDate = Nothing Then
            Me.gridTranscription.Visible = False
            Exit Sub
        Else
            Me.gridTranscription.Visible = True
            Me.Load_grid_Transcription()
        End If

    End Sub

    Protected Sub getTranscriptionDetail(ByVal vidicID As Int32, ByVal vitraID As Int32)
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
                    If dr("diclStatus") > 0 Then
                        m_iMTStatus = getTranscritionStatus(vitraID, "MT")
                    Else
                        m_iMTStatus = -1
                    End If
                    Select Case m_iMTStatus
                        Case -1
                            m_cMTColor = System.Drawing.Color.Gray
                        Case 0
                            m_cMTColor = System.Drawing.Color.Orange
                        Case 1
                            m_cMTColor = System.Drawing.Color.Blue
                        Case 2
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
                    If dr("diclStatus") > 0 Then
                        m_iQCStatus = getTranscritionStatus(vitraID, "QC")
                    Else
                        m_iQCStatus = -1
                    End If
                    Select Case m_iQCStatus
                        Case -1
                            m_cQCColor = System.Drawing.Color.Gray
                        Case 0
                            m_cQCColor = System.Drawing.Color.Orange
                        Case 1
                            m_cQCColor = System.Drawing.Color.Blue
                        Case 2
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
                    If dr("diclStatus") > 0 Then
                        m_iPRStatus = getTranscritionStatus(vitraID, "PR")
                    Else
                        m_iPRStatus = -1
                    End If
                    Select Case m_iPRStatus
                        Case -1
                            m_cPRColor = System.Drawing.Color.Gray
                        Case 0
                            m_cPRColor = System.Drawing.Color.Orange
                        Case 1
                            m_cPRColor = System.Drawing.Color.Blue
                        Case 2
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
                    If dr("diclStatus") > 0 Then
                        m_iFRStatus = getTranscritionStatus(vitraID, "FR")
                    Else
                        m_iFRStatus = -1
                    End If
                    Select Case m_iFRStatus
                        Case -1
                            m_cFRColor = System.Drawing.Color.Gray
                        Case 0
                            m_cFRColor = System.Drawing.Color.Orange
                        Case 1
                            m_cFRColor = System.Drawing.Color.Blue
                        Case 2
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

    Protected Function getTranscritionStatus(ByVal vitraID As Int32, ByVal vsrolID As String) As Int16
        Dim Con As New DBTaskBO
        Dim ds As DataSet
        Dim Qry As String = "SELECT tralStatus " _
                            & "FROM boTranscriptionLayers " _
                            & "WHERE rolID = '" & vsrolID & "' AND traID = " & vitraID

        ds = Con.getDataSet(Qry)
        If ds.Tables(0).Rows.Count > 0 Then
            getTranscritionStatus = ds.Tables(0).Rows(0).Item("tralStatus")
        Else
            getTranscritionStatus = -1
        End If

        ds.Dispose()
        ds = Nothing
        Con.objConnection.Close()
        Con = Nothing

        Return getTranscritionStatus
    End Function

    Protected Sub Load_grid_Transcription()

        Dim L_Id, D_Id, D_Date, sSort As String

        If Me.ddlLocation.SelectedItem.Text = "All Accounts" Then
            L_Id = ""
        Else
            L_Id = " AND boDictation.dicAccountName Like '%" & Me.ddlLocation.SelectedItem.Text & "%'"
        End If

        If Me.ddlDictator.SelectedValue = "-1" Then
            D_Id = ""
        Else
            D_Id = " AND boDictation.foId+boDictation.drId Like '%" & Me.ddlDictator.SelectedValue & "%'"
        End If

        If Me.CPFrom.SelectedDate = Nothing And Me.CpTo.SelectedDate = Nothing Then
            D_Date = ""
        ElseIf Me.CPFrom.SelectedDate <> Nothing And Me.CpTo.SelectedDate = Nothing Then
            D_Date = " AND boDictation.dicDate= '" & Format(Me.CPFrom.SelectedDate, "MM/dd/yyyy") & "'"
        ElseIf Me.CpTo.SelectedDate <> Nothing And Me.CPFrom.SelectedDate = Nothing Then
            D_Date = " AND boDictation.dicDate= '" & Format(Me.CpTo.SelectedDate, "MM/dd/yyyy") & "'"
        Else
            D_Date = " AND boDictation.dicDate BETWEEN '" & Format(Me.CPFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CpTo.SelectedDate, "MM/dd/yyyy") & "'"
        End If

        If ddlSorting.SelectedIndex = 0 Then
            sSort = ",boDictation.drID,boDictation.dicActualName"
        ElseIf ddlSorting.SelectedIndex = 1 Then
            sSort = ",boDictation.dicDate,boDictation.dicActualName"
        ElseIf ddlSorting.SelectedIndex = 2 Then
            sSort = ",boDictation.dicActualName,boDictation.dicDate"
        End If

        Qry = "SELECT  boDictation.drID,boDictation.foID,boDictation.dicActualName,boDictation.dicAccountName, " _
                & "boTranscription.traName,boDictation.dicDate,boTranscription.traPatFirstName as fName, " _
                & "boTranscription.traPatLastName as lName,boTranscription.traPatientNo,boTranscription.traStatus, " _
                & "boDictation.dicID, boTranscription.traID " _
                & "FROM boTranscription INNER JOIN boDictation ON boTranscription.dicID = boDictation.dicID " _
                & "Left Outer JOIN dbo.boLocation ON dbo.boTranscription.locID = dbo.boLocation.locID " _
                & "Where traName like '%" & Me.txtDictation.Text & "%'" & D_Id & L_Id & D_Date & " ORDER BY boDictation.foID" & sSort

        ds = Con.getDataSet(Qry)
        Me.gridTranscription.DataSource = ds
        Me.gridTranscription.DataBind()
    End Sub

    Protected Function getPatientName(ByVal patFirstName As String, ByVal patLastName As String) As String
        If patFirstName = "" And patLastName = "" Then
            getPatientName = ""
        ElseIf patLastName = "" Then
            getPatientName = patFirstName
        ElseIf patFirstName = "" Then
            getPatientName = patLastName
        Else
            getPatientName = patLastName & ", " & patFirstName
        End If
    End Function
End Class
