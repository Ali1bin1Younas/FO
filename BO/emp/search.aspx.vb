Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class fo_search
    Inherits System.Web.UI.Page
    Protected strCliID As String
    Dim Qry As String
    Dim ds As DataSet
    Dim Con As New DBTaskBO
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
        Try
            lblCompleteName.Text = Session("CompletePrefix") + "  " + Session("CompleteFirstNAme") + "   " + Session("CompleteLastName")

            Session("cint") = 0
            Session("cint1") = 0
            If Not Page.IsPostBack Then
                Load_ddl_Dictator()
                Load_ddl_Location()
            End If

        Catch ex As Exception
            ' Throw New Exception(ex.Message)
        End Try
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
        Dim traID As Int32 = coll.Item(0)
        Dim foID As Int32 = coll.Item(1)
        Dim drID As Int32 = coll.Item(2)
        Dim traName As String = ""

        Try
            If e.CommandName = "view" Then
                Dim str1 As String = "popupviewtranscription.aspx?traID=" & traID & "&foID=" & foID & "&drID=" & drID
                Dim str As String = "<script>void window.open('" & str1 & "' ,'_blank','scrollbars=0,toolbar=0,menubar=0,location=0,directories=0,resizable=0,status=0,titlebar=0,height=' + screen.availHeight/2.7 + ',width=' + screen.availWidth/3 + ',top=' + screen.availHeight/4 + ',left=' + screen.availWidth/4 + '')</script>"
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

            'Dim dicID, traID As Int32
            'dicID = gridTranscription.DataKeys(e.Row.RowIndex).Values.Item(0)
            'traID = gridTranscription.DataKeys(e.Row.RowIndex).Values.Item(1)

            'Call getTranscriptionDetail(dicID, traID)

            Dim imgView As ImageButton

            imgView = e.Row.FindControl("btnView")
            imgView.CommandArgument = e.Row.RowIndex
            imgView.CommandName = "view"

            'imgView = e.Row.FindControl("btnViewDoc")
            'imgView.CommandArgument = e.Row.RowIndex
            'imgView.CommandName = "viewDoc"
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

    'Protected Sub getTranscriptionDetail(ByVal vidicID As Int32, ByVal vitraID As Int32)
    '    Dim Con As New DBTaskBO
    '    Dim ds As DataSet
    '    Dim Qry As String = "SELECT boDictationLayers.empID, boDictationLayers.rolID, empFirstName +' '+ substring(empLastName,1,1) as empName, diclStatus " _
    '                        & "FROM boDictationLayers INNER JOIN boEmployee " _
    '                        & "ON boDictationLayers.empID = boEmployee.empID " _
    '                        & "INNER JOIN boDictation ON boDictationLayers.dicID = boDictation.dicID " _
    '                        & "WHERE boDictationLayers.dicID = " & vidicID & " AND dicStatus >= 0"

    '    ds = Con.getDataSet(Qry)
    '    ds.Dispose()
    '    ds = Nothing

    '    Con.objConnection.Close()
    '    Con = Nothing
    'End Sub

    'Protected Function getTranscritionStatus(ByVal vitraID As Int32, ByVal vsrolID As String) As Int16
    '    Dim Con As New DBTaskBO
    '    Dim ds As DataSet
    '    Dim Qry As String = "SELECT tralStatus " _
    '                        & "FROM boTranscriptionLayers " _
    '                        & "WHERE rolID = '" & vsrolID & "' AND traID = " & vitraID

    '    ds = Con.getDataSet(Qry)
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        getTranscritionStatus = ds.Tables(0).Rows(0).Item("tralStatus")
    '    Else
    '        getTranscritionStatus = -1
    '    End If

    '    ds.Dispose()
    '    ds = Nothing
    '    Con.objConnection.Close()
    '    Con = Nothing

    '    Return getTranscritionStatus
    'End Function

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

        Qry = "SELECT  boDictation.drID,boDictation.foID,boDictation.dicActualName, " _
                & "boTranscription.traName,boDictation.dicDate,boTranscription.traPatFirstName as fName, " _
                & "boTranscription.traPatLastName as lName ,boTranscription.traStatus, boTranscription.traPatientNo, " _
                & "boDictation.dicID, boTranscription.traID " _
                & "FROM boTranscription INNER JOIN boDictation ON boTranscription.dicID = boDictation.dicID " _
                & "Left Outer JOIN dbo.boLocation ON dbo.boTranscription.locID = dbo.boLocation.locID " _
                & "Where (traPatientNo like '%" & Me.txtDictation.Text & "%' OR traSubject like '%" & Me.txtDictation.Text & "%' OR traName like '%" & Me.txtDictation.Text & "%')" & D_Id & L_Id & D_Date & " AND traStatus >= 1 ORDER BY boDictation.foID, boDictation.dicDate DESC"

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


    'Protected Function getLocName(ByVal strLocID As String) As String
    '    Dim strlocName As String = Nothing
    '    Dim Query As String = "Select locDescription From boLocation where locID='" & strLocID & "'"
    '    ds = Con.getDataSet(Query)
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        strlocName = ds.Tables(0).Rows(0).Item("locName")
    '    End If
    '    'Con.objConnection.Close()
    '    ds.Dispose()
    '    ds = Nothing
    '    Return strlocName
    'End Function

    Protected Function getCounter() As String
        Dim intCount As Integer = Session("cint")
        intCount += 1
        Session("cint") = intCount
        Return intCount.ToString
    End Function


    'Protected Sub btnResend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResend.Click
    '    Dim filesTable As New DataTable
    '    Dim myDataRow As DataRow
    '    filesTable.Columns.Add("ID", Type.GetType("System.String"))
    '    filesTable.Columns.Add("traName", Type.GetType("System.String"))
    '    filesTable.Columns.Add("traPatFirstName", Type.GetType("System.String"))
    '    filesTable.Columns.Add("locName", Type.GetType("System.String"))
    '    filesTable.Columns.Add("datDateTime", Type.GetType("System.DateTime"))
    '    filesTable.Columns.Add("TID", Type.GetType("System.String"))
    '    filesTable.Columns.Add("DID", Type.GetType("System.String"))
    '    For Each item4 As GridViewRow In grdMain.Rows
    '        Dim chk2 As CheckBox = item4.FindControl("chk1")
    '        If chk2.Checked Then
    '            myDataRow = filesTable.NewRow()
    '            myDataRow("ID") = getCounter1()
    '            myDataRow("traName") = item4.Cells(1).Text.ToString.Trim
    '            'myDataRow("traPatFirstName") = item4.Cells(2).Text.ToString.Trim

    '            Dim lblName As System.Web.UI.DataBoundLiteralControl = CType(item4.Cells(2).Controls(0), System.Web.UI.DataBoundLiteralControl)
    '            myDataRow("traPatFirstName") = lblName.Text


    '            myDataRow("locName") = item4.Cells(3).Text.ToString.Trim
    '            Dim lblDate As Label = item4.Cells(4).Controls(1)
    '            myDataRow("datDateTime") = CDate(lblDate.Text)
    '            myDataRow("TID") = item4.Cells(7).Text.ToString.Trim
    '            myDataRow("DID") = item4.Cells(8).Text.ToString.Trim
    '            filesTable.Rows.Add(myDataRow)
    '        End If
    '    Next
    '    Session("dt") = filesTable
    '    Response.Redirect("searchresponse.aspx")
    'End Sub
    Protected Function getCounter1() As String
        Dim intCount1 As Integer = Session("cint1")
        intCount1 += 1
        Session("cint1") = intCount1
        Return intCount1.ToString
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class


