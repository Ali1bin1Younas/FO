
Imports System.Data
Imports System.Web.Services
Imports Microsoft.Web.Script.Services

Partial Class BO_singleassign3
    Inherits System.Web.UI.Page
    Protected Dset As New System.Data.DataSet
    Protected Counter, InCounter As Int16
    Protected dicID_val As Boolean

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
    Public Shared g_Qry As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empID") = "" Then Response.Redirect(GF.Home)
        Counter = 0
        If Not Me.IsPostBack Then
            Me.CPMain.SelectedDate = Now.AddDays(-1)
            Me.CPMain.VisibleDate = Now.AddDays(-1)

            Me.CPDateMainMT.SelectedDate = Now.AddDays(-1)
            Me.CPDateMainMT.VisibleDate = Now.AddDays(-1)

            Me.CPDateMainQC.SelectedDate = Now.AddDays(-1)
            Me.CPDateMainQC.VisibleDate = Now.AddDays(-1)

            Me.CPDateMainPR.SelectedDate = Now.AddDays(-1)
            Me.CPDateMainPR.VisibleDate = Now.AddDays(-1)

            Me.CPDateMainFR.SelectedDate = Now.AddDays(-1)
            Me.CPDateMainFR.VisibleDate = Now.AddDays(-1)

            PostBack_MT()
            PostBack_QC()
            PostBack_PR()
            PostBack_FR()
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Session("SelectedDate") = Me.CPMain.SelectedDate

        Me.CPDateMainMT.SelectedDate = Me.CPMain.SelectedDate
        Me.CPDateMainMT.VisibleDate = Me.CPMain.SelectedDate

        Me.CPDateMainQC.SelectedDate = Me.CPMain.SelectedDate
        Me.CPDateMainQC.VisibleDate = Me.CPMain.SelectedDate

        Me.CPDateMainPR.SelectedDate = Me.CPMain.SelectedDate
        Me.CPDateMainPR.VisibleDate = Me.CPMain.SelectedDate

        Me.CPDateMainFR.SelectedDate = Me.CPMain.SelectedDate
        Me.CPDateMainFR.VisibleDate = Me.CPMain.SelectedDate

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

    Private Sub PostBack_MT()
        Dim Con As New MTBMS.DAL.DBTaskBO
        Dim Qry As String

        Qry = "SELECT boEmployeeRoles.rolID, boEmployeeRoles.empID, " _
              & "boEmployee.empFirstName + ' ' + SUBSTRING(boEmployee.empLastName,1,1) " _
              & "AS empName FROM boEmployee INNER JOIN " _
              & "boEmployeeRoles ON boEmployee.empID = boEmployeeRoles.empID " _
              & "WHERE boEmployeeRoles.rolID = 'MT' AND boEmployeeRoles.empID <> '0' AND boEmployeeRoles.empEnable=1 AND boEmployee.empEnable=1 " _
              & "ORDER BY empName"
        Dim dsMT As DataSet = Con.getDataSet(Qry)

        ddlMainMT.DataSource = dsMT.Tables(0)
        ddlMainMT.DataTextField = "empName"
        ddlMainMT.DataValueField = "empID"
        ddlMainMT.DataBind()
    End Sub
    Private Sub PostBack_QC()
        Dim Con As New MTBMS.DAL.DBTaskBO
        Dim Qry As String
        Dim strQC As String = Nothing
        Qry = "SELECT boEmployeeRoles.rolID, boEmployeeRoles.empID, " _
              & "boEmployee.empFirstName + ' ' + SUBSTRING(boEmployee.empLastName,1,1) " _
              & "AS empName FROM boEmployee INNER JOIN " _
              & "boEmployeeRoles ON boEmployee.empID = boEmployeeRoles.empID " _
              & "WHERE boEmployeeRoles.rolID = 'QC' AND boEmployeeRoles.empID <> '0' AND boEmployeeRoles.empEnable=1 AND boEmployee.empEnable=1 " _
              & "ORDER BY empName"
        Dim dsQC As DataSet = Con.getDataSet(Qry)
        ddlMainQC.DataSource = dsQC.Tables(0)
        ddlMainQC.DataTextField = "empName"
        ddlMainQC.DataValueField = "empID"
        ddlMainQC.DataBind()
        ddlMainQC.Items.Add("Skipped")
    End Sub
    Private Sub PostBack_PR()
        Dim Con As New MTBMS.DAL.DBTaskBO
        Dim Qry As String
        Dim strPR As String = Nothing
        Qry = "SELECT boEmployeeRoles.rolID, boEmployeeRoles.empID, " _
              & "boEmployee.empFirstName + ' ' + SUBSTRING(boEmployee.empLastName,1,1) " _
              & "AS empName FROM boEmployee INNER JOIN " _
              & "boEmployeeRoles ON boEmployee.empID = boEmployeeRoles.empID " _
              & "WHERE boEmployeeRoles.rolID = 'PR' AND boEmployeeRoles.empID <> '0' AND boEmployeeRoles.empEnable=1 AND boEmployee.empEnable=1 " _
              & "ORDER BY empName"
        Dim dsPR As DataSet = Con.getDataSet(Qry)
        ddlMainPR.DataSource = dsPR.Tables(0)
        ddlMainPR.DataTextField = "empName"
        ddlMainPR.DataValueField = "empID"
        ddlMainPR.DataBind()
        ddlMainPR.Items.Add("Skipped")
    End Sub
    Private Sub PostBack_FR()
        Dim Con As New MTBMS.DAL.DBTaskBO
        Dim Qry As String
        Dim strFR As String = Nothing
        Qry = "SELECT boEmployeeRoles.rolID, boEmployeeRoles.empID, " _
              & "boEmployee.empFirstName + ' ' + SUBSTRING(boEmployee.empLastName,1,1) " _
              & "AS empName FROM boEmployee INNER JOIN " _
              & "boEmployeeRoles ON boEmployee.empID = boEmployeeRoles.empID " _
              & "WHERE boEmployeeRoles.rolID = 'FR' AND boEmployeeRoles.empID <> '0' AND boEmployeeRoles.empEnable=1 AND boEmployee.empEnable=1 " _
              & "ORDER BY empName"
        Dim dsFR As DataSet = Con.getDataSet(Qry)
        ddlMainFR.DataSource = dsFR.Tables(0)
        ddlMainFR.DataTextField = "empName"
        ddlMainFR.DataValueField = "empID"
        ddlMainFR.DataBind()
        ddlMainFR.Items.Add("Skipped")
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

            Dim ddlMT As DropDownList = CType(e.Row.FindControl("ddlMT"), DropDownList)
            Dim ddlQC As DropDownList = CType(e.Row.FindControl("ddlQC"), DropDownList)
            Dim ddlPR As DropDownList = CType(e.Row.FindControl("ddlPR"), DropDownList)
            Dim ddlFR As DropDownList = CType(e.Row.FindControl("ddlFR"), DropDownList)
            fill_ddlMT(ddlMT)
            fill_ddlQC(ddlQC)
            fill_ddlPR(ddlPR)
            fill_ddlFR(ddlFR)

            Dim CPDateMT As eWorld.UI.CalendarPopup = CType(e.Row.FindControl("CPDateMT"), eWorld.UI.CalendarPopup)
            CPDateMT.SelectedDate = CPMain.SelectedDate
            Dim CPDateQC As eWorld.UI.CalendarPopup = CType(e.Row.FindControl("CPDateQC"), eWorld.UI.CalendarPopup)
            CPDateQC.SelectedDate = CPMain.SelectedDate
            Dim CPDatePR As eWorld.UI.CalendarPopup = CType(e.Row.FindControl("CPDatePR"), eWorld.UI.CalendarPopup)
            CPDatePR.SelectedDate = CPMain.SelectedDate
            Dim CPDateFR As eWorld.UI.CalendarPopup = CType(e.Row.FindControl("CPDateFR"), eWorld.UI.CalendarPopup)
            CPDateFR.SelectedDate = CPMain.SelectedDate
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
            Dim mt As String = dr(1).ToString()
            If mt.Trim() = "MT" Then


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
            ElseIf dr("rolID").ToString().Trim() = "QC" Then
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
            ElseIf dr("rolID").ToString().Trim() = "PR" Then
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

            ElseIf dr("rolID").ToString().Trim() = "FR" Then
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
            End If
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

            'Dim headerRow As GridViewRow = GridDetial.HeaderRow
            'headerRow.BackColor = System.Drawing.Color.FromName("#C0C0C0")
            'If e.Row.RowIndex Mod 2 = 0 Then
            '    e.Row.BackColor = System.Drawing.Color.FromName("#e0e0e0")
            'Else
            '    e.Row.BackColor = System.Drawing.Color.FromName("#e4e4e4")
            'End If

            Dim Qry As String
            Dim Con As New MTBMS.DAL.DBTaskBO
            Dim dicID As Int32 = Me.GridDetial.DataKeys(e.Row.RowIndex).Values.Item(0)
            Dim dicActualName As String = Me.GridDetial.DataKeys(e.Row.RowIndex).Values.Item(1)
            Dim dicLength As Long = Me.GridDetial.DataKeys(e.Row.RowIndex).Values.Item(2)
            Dim dicDuplicateCheck As Boolean = CBool(Me.GridDetial.DataKeys(e.Row.RowIndex).Values.Item(3))
            Dim dicUrgent As Boolean = CBool(Me.GridDetial.DataKeys(e.Row.RowIndex).Values.Item(4))

            'dicIDs being assign to the checkboxes of Roles (MT,QC,PR,FR), can not change this
            Dim chkDics As CheckBox = CType(e.Row.FindControl("chkDic"), CheckBox)
            chkDics.ID = dicID

            Dim chkMT As CheckBox = CType(e.Row.FindControl("chkMT"), CheckBox)
            chkMT.ID = dicID
            Dim chkQC As CheckBox = CType(e.Row.FindControl("chkQC"), CheckBox)
            chkQC.ID = dicID
            Dim chkPR As CheckBox = CType(e.Row.FindControl("chkPR"), CheckBox)
            chkPR.ID = dicID
            Dim chkFR As CheckBox = CType(e.Row.FindControl("chkFR"), CheckBox)
            chkFR.ID = dicID

            Dim lblMT As Label = CType(e.Row.FindControl("lblMT"), Label)
            lblMT.ID = "lblMT" & dicID
            Dim lblQC As Label = CType(e.Row.FindControl("lblQC"), Label)
            lblQC.ID = "lblQC" & dicID
            Dim lblPR As Label = CType(e.Row.FindControl("lblPR"), Label)
            lblPR.ID = "lblPR" & dicID
            Dim lblFR As Label = CType(e.Row.FindControl("lblFR"), Label)
            lblFR.ID = "lblFR" & dicID

            Dim lblMTDate As Label = CType(e.Row.FindControl("lblMTDate"), Label)
            lblMTDate.ID = "lblMTDate" & dicID
            Dim lblQCDate As Label = CType(e.Row.FindControl("lblQCDate"), Label)
            lblQCDate.ID = "lblQCDate" & dicID
            Dim lblPRDate As Label = CType(e.Row.FindControl("lblPRDate"), Label)
            lblPRDate.ID = "lblPRDate" & dicID
            Dim lblFRDate As Label = CType(e.Row.FindControl("lblFRDate"), Label)
            lblFRDate.ID = "lblFRDate" & dicID
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not dicDuplicateCheck Then
                Qry = "Select count(*) from boDictation where dicActualName = '" & dicActualName & "' AND dicLength = " & dicLength & " AND dicID <> " & dicID
                If Con.getScalar(Qry) > 0 Then
                    dicID_val = True
                Else
                    dicID_val = False
                End If
            Else
                dicID_val = True
            End If

            If dicUrgent Then
                e.Row.Cells(1).BackColor = System.Drawing.Color.FromName("#EB2D2D")
            End If
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)

        'Dim dicId As Int32 = GridDetial.DataKeys(e.CommandArgument.ToString).Values.Item(0)

        'If e.CommandName = "duplicate_dictation" Then
        '    Dim str1 As String = "popupduplicate.aspx?dicID=" & dicId
        '    Dim str As String = "<script>void window.open('" & str1 & "' ,'_blank','scrollbars=0,toolbar=0,menubar=0,location=0,directories=0,resizable=0,status=0,titlebar=0,height=' + screen.availHeight/2.7 + ',width=' + screen.availWidth/3 + ',top=' + screen.availHeight/4 + ',left=' + screen.availWidth/4 + '')</script>"
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "OpenWindow", str)
        'End If
    End Sub

    Private Sub fill_ddlMT(ByVal ddlMT As DropDownList)
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
    Private Sub fill_ddlQC(ByVal ddlQC As DropDownList)
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
    Private Sub fill_ddlPR(ByVal ddlPR As DropDownList)
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
    Private Sub fill_ddlFR(ByVal ddlFR As DropDownList)
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

    <WebMethod()> _
    <ScriptMethod()> _
    Public Shared Function Assign_roles_to_dictations(ByVal drID As String, ByVal CPMainDate As String, ByVal dicIDs_MT As String, ByVal dicIDs_QC As String, _
                                                      ByVal dicIDs_PF As String, ByVal dicIDs_FR As String, _
                                                      ByVal chkMT As Boolean, ByVal chkQC As Boolean, ByVal chkPR As Boolean, ByVal chkFR As Boolean, _
                                                      ByVal empIDMT As String, ByVal empIDQC As String, ByVal empIDPR As String, ByVal empIDFR As String, _
                                                      ByVal dateMT As String, ByVal dateQC As String, ByVal datePR As String, ByVal dateFR As String) As String
        Try
            Dim rolClauseMT As String = ""

            Dim dMain As Date
            Dim dMT As Date
            Dim dQC As Date
            Dim dPR As Date
            Dim dFR As Date

            Dim dts() As String
            Dim dt As String

            dts = CPMainDate.Split("/")
            dt = dts(0) & "/" & dts(1) & "/" & dts(2)
            dMain = DateTime.Parse(dt)

            Dim roleID As String = ""
            If dicIDs_MT <> "" Then
                If chkMT Then
                    dts = dateMT.Split("/")
                    dt = dts(0) & "/" & dts(1) & "/" & dts(2)
                    dMT = DateTime.Parse(dt)

                    UpdateMT(dicIDs_MT, empIDMT, dMT)
                    rolClauseMT = "'MT'"
                End If
            End If

            If dicIDs_QC <> "" Then
                If chkQC Then
                    dts = dateQC.Split("/")
                    dt = dts(0) & "/" & dts(1) & "/" & dts(2)
                    dQC = DateTime.Parse(dt)

                    UpdateLayer(dicIDs_QC, "QC", empIDQC, dQC)
                    If chkMT Then
                        rolClauseMT = rolClauseMT & ",'QC'"
                    Else
                        rolClauseMT = "'QC'"
                    End If
                End If
            End If

            If dicIDs_PF <> "" Then
                If chkPR Then
                    dts = datePR.Split("/")
                    dt = dts(0) & "/" & dts(1) & "/" & dts(2)
                    dPR = DateTime.Parse(dt)

                    UpdateLayer(dicIDs_PF, "PR", empIDPR, dPR)
                    If chkMT OrElse chkQC Then
                        rolClauseMT = rolClauseMT & ",'PR'"
                    Else
                        rolClauseMT = "'PR'"
                    End If
                End If
            End If

            If dicIDs_FR <> "" Then
                If chkFR Then
                    dts = dateFR.Split("/")
                    dt = dts(0) & "/" & dts(1) & "/" & dts(2)
                    dFR = DateTime.Parse(dt)

                    UpdateLayer(dicIDs_FR, "FR", empIDFR, dFR)

                    If chkMT OrElse chkQC OrElse chkPR Then
                        rolClauseMT = rolClauseMT & ",'FR'"
                    Else
                        rolClauseMT = "'FR'"
                    End If

                End If
            End If

            If drID <> "" Then
                Dim andClause As String = ""
                If rolClauseMT <> "" Then
                    andClause = " AND boDictationLayers.rolID IN (" & rolClauseMT & ")"
                End If
                Dim Con As New MTBMS.DAL.DBTaskBO
                Dim Qry As String = "SELECT boDictation.dicID, boDictationLayers.empID ,IsNull(boDictationLayers.diclWorkloadDate, '01/01/1999') as diclWorkloadDate, boDictationLayers.rolID, " _
                                    & "empFirstName +' '+ substring(empLastName,1,1) as empName, diclStatus " _
                                    & "FROM boDictationLayers INNER JOIN boEmployee " _
                                    & "ON boDictationLayers.empID = boEmployee.empID " _
                                    & "INNER JOIN boDictation ON boDictationLayers.dicID = boDictation.dicID " _
                                    & "WHERE boDictation.drID = " & drID & " AND dicDate = '" & Format(dMain, "MM/dd/yyyy") & "' AND dicStatus >= 0"

                Dim ds As DataSet = Con.getDataSet(Qry)
                ds.Tables(0).TableName = "dics"
                Dim dRow As DataRow
                ds.Tables(0).Columns.Add("dicDT", Type.GetType("System.String"))
                For Each dRow In ds.Tables(0).Rows
                    dRow("dicDT") = Format(dRow("diclWorkloadDate"), "dd/MM/yy")
                Next
                Return ds.GetXml()
            Else
                Return "1"
            End If
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Shared Function UpdateMT(ByVal dicIDs As String, ByVal uEmpID As String, ByVal workloadDate As Date) As String
        Dim ConMT As New MTBMS.DAL.DBTaskBO
        Dim dsMT As New DataSet
        Try

            Dim IDs() As String = dicIDs.Split(",")

            For Each udicID As String In IDs
                Dim strQry As String = "SELECT diclStatus FROM boDictationLayers WHERE dicID = " & udicID & " AND rolID = 'MT'"
                dsMT = ConMT.getDataSet(strQry)
                Dim intStatus As Int16 = dsMT.Tables(0).Rows(0)("diclStatus")

                If intStatus <> 2 And intStatus <> 3 Then
                    ConMT.saveDataValues("UPDATE boDictationLayers SET empID='" & uEmpID & "', diclWorkloadDate = '" & Format(workloadDate, "MM/dd/yyyy") & "'" _
                                     & " WHERE dicID = " & udicID & " AND rolID = 'MT'")
                End If
            Next

            Return "1"
        Catch ex As Exception
            Return ex.Message.ToString()
        Finally
            ConMT = Nothing
            dsMT.Dispose()
        End Try

    End Function
    Private Shared Sub UpdateLayer(ByVal dicIDs As String, ByVal vsrolID As String, ByVal uEmpID As String, ByVal workLoadDate As Date)

        Dim cnQC As New MTBMS.DAL.DBTaskBO
        Dim strQry As String
        Dim dsQC As DataSet
        Dim strOldEmp As String
        Dim bolTag As Boolean
        Dim intStatus As Int16

        Dim IDs() As String = dicIDs.Split(",")

        For Each udicID As String In IDs

            strQry = "SELECT * FROM boDictationLayers WHERE dicID = " & udicID & " AND rolID = '" & vsrolID & "'"
            dsQC = cnQC.getDataSet(strQry)
            strOldEmp = dsQC.Tables(0).Rows(0)("empID").ToString.Trim
            bolTag = dsQC.Tables(0).Rows(0)("diclTag")
            intStatus = dsQC.Tables(0).Rows(0)("diclStatus")

            dsQC.Dispose()

            'If intStatus = 2 Or intStatus = 3 Or uEmpID = strOldEmp Then Exit Sub
            If intStatus = 2 Or intStatus = 3 Then Continue For
            If uEmpID = "Skipped" Then uEmpID = "0"

            If intStatus = 0 Then

                If vsrolID = "QC" Then
                    strQry = "UPDATE boDictationLayers SET empID = '" & uEmpID & "', diclWorkloadDate = '" & Format(workLoadDate, "MM/dd/yyyy") & "', " _
                         & "diclSkip = " & IIf(uEmpID = "0", 1, 0) & " " _
                         & "WHERE dicID = " & udicID & " AND rolID = '" & vsrolID & "'"
                ElseIf vsrolID = "PR" Then
                    strQry = "UPDATE boDictationLayers SET empID = '" & uEmpID & "', diclWorkloadDate = '" & Format(workLoadDate, "MM/dd/yyyy") & "', " _
                         & "diclSkip = " & IIf(uEmpID = "0", 1, 0) & " " _
                         & "WHERE dicID = " & udicID & " AND rolID = '" & vsrolID & "'"
                ElseIf vsrolID = "FR" Then
                    strQry = "UPDATE boDictationLayers SET empID = '" & uEmpID & "', diclWorkloadDate = '" & Format(workLoadDate, "MM/dd/yyyy") & "', " _
                         & "diclSkip = " & IIf(uEmpID = "0", 1, 0) & " " _
                         & "WHERE dicID = " & udicID & " AND rolID = '" & vsrolID & "'"
                End If


                cnQC.saveDataValues(strQry)
            ElseIf intStatus = 1 Then
                If Not bolTag And strOldEmp <> "0" And uEmpID = "0" Then
                    If vsrolID = "QC" Then
                        Call assignNextLayer(udicID, "QC", "PR", workLoadDate)
                    ElseIf vsrolID = "PR" Then
                        Call assignNextLayer(udicID, "PR", "FR", workLoadDate)
                    End If
                ElseIf Not bolTag And strOldEmp = "0" And uEmpID <> "0" Then
                    If vsrolID = "QC" Then
                        Call assignPreviouseLayer(udicID, "PR", "QC", uEmpID, workLoadDate)
                    ElseIf vsrolID = "PR" Then
                        Call assignPreviouseLayer(udicID, "FR", "PR", uEmpID, workLoadDate)
                    End If
                Else

                    If vsrolID = "QC" Then
                        strQry = "UPDATE boDictationLayers SET empID = '" & uEmpID & "', diclWorkloadDate = '" & Format(workLoadDate, "MM/dd/yyyy") & "'" _
                              & "WHERE dicID = " & udicID & " AND rolID = '" & vsrolID & "'"
                    ElseIf vsrolID = "PR" Then
                        strQry = "UPDATE boDictationLayers SET empID = '" & uEmpID & "', diclWorkloadDate = '" & Format(workLoadDate, "MM/dd/yyyy") & "'" _
                             & "WHERE dicID = " & udicID & " AND rolID = '" & vsrolID & "'"
                    ElseIf vsrolID = "FR" Then
                        strQry = "UPDATE boDictationLayers SET empID = '" & uEmpID & "', diclWorkloadDate = '" & Format(workLoadDate, "MM/dd/yyyy") & "'" _
                             & "WHERE dicID = " & udicID & " AND rolID = '" & vsrolID & "'"
                    End If


                    cnQC.saveDataValues(strQry)

                    strQry = "UPDATE boTranscriptionLayers SET empID = '" & uEmpID & "' " _
                             & "WHERE dicID = " & udicID & " AND rolID = '" & vsrolID & "'"
                    cnQC.saveDataValues(strQry)
                End If
            End If

        Next

        dsQC.Dispose()
        dsQC = Nothing
        cnQC = Nothing
    End Sub

    Protected Shared Sub assignNextLayer(ByVal udicID As String, ByVal vsFromRole As String, ByVal vsToRole As String, ByVal workLoadDate As Date)

        Dim cnLL As New MTBMS.DAL.DBTaskBO
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

                If vsToRole = "QC" Then
                    strQry = "UPDATE boDictationLayers SET empID = '0', diclWorkloadDate = '" & Format(workLoadDate, "MM/dd/yyyy") & "', " _
                         & "diclTranscriptions = " & iRecordsEffected & ", " _
                         & "diclSkip = 1, diclStatus = 1 "
                ElseIf vsToRole = "PR" Then
                    strQry = "UPDATE boDictationLayers SET empID = '0', diclWorkloadDate = '" & Format(workLoadDate, "MM/dd/yyyy") & "', " _
                         & "diclTranscriptions = " & iRecordsEffected & ", " _
                         & "diclSkip = 1, diclStatus = 1 "
                ElseIf vsToRole = "FR" Then
                    strQry = "UPDATE boDictationLayers SET empID = '0', diclWorkloadDate = '" & Format(workLoadDate, "MM/dd/yyyy") & "', " _
                         & "diclTranscriptions = " & iRecordsEffected & ", " _
                         & "diclSkip = 1, diclStatus = 1 "
                End If


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
                Call assignNextLayer(udicID, "QC", "FR", workLoadDate)
            End If
        End If

        dsLL.Dispose()
        dsLL = Nothing
        cnLL = Nothing
    End Sub

    Protected Shared Sub assignPreviouseLayer(ByVal udicID As String, ByVal vsFromRole As String, ByVal vsToRole As String, ByVal vsempID As String, ByVal workLoadDate As Date)

        Dim cnLL As New MTBMS.DAL.DBTaskBO
        Dim dsLL As DataSet

        Dim strQry As String
        Dim iRecordsEffected As Int16

        strQry = "SELECT * FROM boDictationLayers WHERE dicID = " & udicID & " " _
                         & " AND diclSkip = 0 AND rolID = '" & vsFromRole & "'"
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

                If vsToRole = "QC" Then
                    strQry = "UPDATE boDictationLayers SET diclTranscriptions = 0, diclWorkloadDate = '" & Format(workLoadDate, "MM/dd/yyyy") & "', " _
                         & "diclSkip = 0, diclStatus = 1, empID = '" & vsempID & "' " _
                         & "WHERE dicID = " & udicID & " AND rolID = '" & vsToRole & "'"
                ElseIf vsToRole = "PR" Then
                    strQry = "UPDATE boDictationLayers SET diclTranscriptions = 0, diclWorkloadDate = '" & Format(workLoadDate, "MM/dd/yyyy") & "', " _
                        & "diclSkip = 0, diclStatus = 1, empID = '" & vsempID & "' " _
                        & "WHERE dicID = " & udicID & " AND rolID = '" & vsToRole & "'"
                ElseIf vsToRole = "FR" Then
                    strQry = "UPDATE boDictationLayers SET diclTranscriptions = 0, diclWorkloadDate = '" & Format(workLoadDate, "MM/dd/yyyy") & "', " _
                        & "diclSkip = 0, diclStatus = 1, empID = '" & vsempID & "' " _
                        & "WHERE dicID = " & udicID & " AND rolID = '" & vsToRole & "'"
                End If

                iRecordsEffected = cnLL.saveData(strQry)
            End If
        Else
            If vsToRole = "QC" Then
                dsLL.Dispose()
                Call assignPreviouseLayer(udicID, "FR", "QC", vsempID, workLoadDate)
            End If
        End If

        dsLL.Dispose()
        dsLL = Nothing
        cnLL = Nothing
    End Sub

    Public Function getWorloadDate(ByVal dicID As String, ByVal rolID As String) As String
        Dim cnLL As New MTBMS.DAL.DBTaskBO
        Dim qry As String = "Select diclWorkloadDate from boDictationLayers where dicID = '" & dicID & "' AND rolID = '" & rolID & "'"

        If IsDBNull(cnLL.getScalar(qry)) Then
            Return "-"
        Else
            Dim workloadDate As String = Format(cnLL.getScalar(qry), "d/M/yy")
            Return workloadDate
        End If
    End Function
    <WebMethod> _
    <ScriptMethod> _
    Public Shared Function reupload_dictation(ByVal dicID As String) As String
        Try
            Dim Con As New MTBMS.DAL.DBTaskBO
            Dim Qry As String
            Qry = "Select count(*) from boTranscription where dicId = " & dicID

            If Con.getScalar(Qry) > 0 Then
                Qry = "Select count(*) from boTranscription where dicId = " & dicID & " AND traStatus = 0"

                If Con.getScalar(Qry) = 0 Then
                    Qry = "Select count(*) from boTranscription where dicId = " & dicID
                    Dim docCount As Integer = Con.getScalar(Qry)

                    Qry = "UPDATE boDictationLayers SET diclStatus=3, diclTranscriptions=" & docCount & " WHERE dicID = " & dicID & ";"
                    Qry &= "UPDATE boTranscriptionLayers SET tralStatus=2 WHERE dicID = " & dicID & ";"
                    Qry &= "UPDATE boDictation SET dicStatus=2, dicTranscriptions=" & docCount & " WHERE dicID = " & dicID & ";"
                    Qry &= "UPDATE boTranscription SET traStatus=1 WHERE dicID = " & dicID & ";"

                    Con.saveData(Qry)
                    Qry = "SELECT boDictation.dicID, boDictationLayers.empID ,IsNull(boDictationLayers.diclWorkloadDate, '01/01/1999') as diclWorkloadDate, boDictationLayers.rolID, " _
                                        & "empFirstName +' '+ substring(empLastName,1,1) as empName, diclStatus " _
                                        & "FROM boDictationLayers INNER JOIN boEmployee " _
                                        & "ON boDictationLayers.empID = boEmployee.empID " _
                                        & "INNER JOIN boDictation ON boDictationLayers.dicID = boDictation.dicID " _
                                        & "WHERE boDictationLayers.dicID IN ( " & dicID & " ) AND dicStatus >= 0"
                    Dim ds As DataSet = Con.getDataSet(Qry)
                    ds.Tables(0).TableName = "dics"
                    Dim dRow As DataRow
                    ds.Tables(0).Columns.Add("dicDT", Type.GetType("System.String"))
                    For Each dRow In ds.Tables(0).Rows
                        dRow("dicDT") = Format(dRow("diclWorkloadDate"), "dd/MM/yy")
                    Next

                    Return "1," & ds.GetXml()
                Else
                    Return "0,Transcription(s) in already in progress, can not reupload"
                End If
            Else
                Return "0,No Trascription for this Dictation have been created yet"
            End If
        Catch ex As Exception
            Return ex.Message().ToString()
        End Try
    End Function

    <WebMethod> _
    <ScriptMethod> _
    Public Shared Function reset_dictation(ByVal dicID As String) As String
        Try
            Dim Con As New MTBMS.DAL.DBTaskBO
            Dim Qry As String
            Qry = "Select count(*) from boDictation where dicStatus IN('4','3') AND dicId = " & dicID
            If Con.getScalar(Qry) = 0 Then
                Qry = "DELETE boTranscriptionLayers where dicID = " & dicID & ";"
                Qry &= "DELETE boTranscription where dicID = " & dicID & ";"
                Qry &= "UPDATE boDictationLayers SET diclStatus=0, diclTag=0, diclTranscriptions=0 WHERE dicID = " & dicID & ";"
                Qry &= "UPDATE boDictationLayers SET diclStatus=1 WHERE dicID = " & dicID & " AND rolID='MT';"
                Qry &= "UPDATE boDictationLayers SET empID=0 WHERE dicID = " & dicID & " AND diclSkip=1;"
                Qry &= "UPDATE boDictation SET dicStatus=0, dicTranscriptions=0 WHERE dicID = " & dicID & ";"
                Con.getScalar(Qry)
                Qry = "SELECT boDictation.dicID, boDictationLayers.empID ,IsNull(boDictationLayers.diclWorkloadDate, '01/01/1999') as diclWorkloadDate, boDictationLayers.rolID, " _
                                        & "empFirstName +' '+ substring(empLastName,1,1) as empName, diclStatus " _
                                        & "FROM boDictationLayers INNER JOIN boEmployee " _
                                        & "ON boDictationLayers.empID = boEmployee.empID " _
                                        & "INNER JOIN boDictation ON boDictationLayers.dicID = boDictation.dicID " _
                                        & "WHERE boDictationLayers.dicID IN ( " & dicID & " ) AND dicStatus >= 0"
                Dim ds As DataSet = Con.getDataSet(Qry)
                ds.Tables(0).TableName = "dics"
                Dim dRow As DataRow
                ds.Tables(0).Columns.Add("dicDT", Type.GetType("System.String"))
                For Each dRow In ds.Tables(0).Rows
                    dRow("dicDT") = Format(dRow("diclWorkloadDate"), "dd/MM/yy")
                Next

                Return "1," & ds.GetXml()
            Else
                Return "0,This Dictaion have already been Uploaded, cannot Reset"
            End If

        Catch ex As Exception
            Return ex.Message().ToString()
        End Try
    End Function

    <WebMethod> _
    <ScriptMethod> _
    Public Shared Function delete_dictation(ByVal dicIDs As String) As String
        Try
            Dim IdsList() As String = dicIDs.Split(",")
            Dim Qry As String
            Dim Con As New MTBMS.DAL.DBTaskBO

            For Each id As String In IdsList
                Qry = "Select count(*) from boDictation where dicStatus IN('4','3') AND dicId = " & id
                If Con.getScalar(Qry) = 0 Then
                    Qry = "UPDATE boDictation SET dicEnable = 0 WHERE dicID = " & id
                    Con.getScalar(Qry)
                End If
            Next

            Qry = "SELECT dicID, dicEnable from boDictation where dicID IN (" & dicIDs & ")"
            Dim ds As DataSet = Con.getDataSet(Qry)
            ds.Tables(0).TableName = "dics"

            Return ds.GetXml()
        Catch ex As Exception
            Return ex.Message().ToString()
        End Try
    End Function

    <WebMethod> _
    <ScriptMethod> _
    Public Shared Function Change_dic_minutes_save(ByVal dicID As String, ByVal sec As String) As String
        Try
            Dim Qry As String
            Dim Con As New MTBMS.DAL.DBTaskBO

            Qry = "UPDATE boDictation set dicLength='" & sec & "' where dicId=" & dicID
            If Con.saveData(Qry) Then
                Return "1"
            Else
                Return "-1"
            End If
        Catch ex As Exception
            Return ex.Message().ToString()
        End Try
    End Function

    <WebMethod> _
    <ScriptMethod> _
    Public Shared Function mark_dictation_urgent(ByVal dicID As String) As String
        Try
            Dim Qry As String
            Dim Con As New MTBMS.DAL.DBTaskBO

            Qry = "select dicUrgent from boDictation where dicId=" & dicID
            Dim urgent As Boolean = CType(Con.getScalar(Qry), Boolean)
            If urgent Then
                Qry = "UPDATE boDictation set dicUrgent='0' where dicId=" & dicID
                Con.saveData(Qry)
                Return "0"
            Else
                Qry = "UPDATE boDictation set dicUrgent='1' where dicId=" & dicID
                Con.saveData(Qry)
                Return "1"
            End If
        Catch ex As Exception
            Return ex.Message().ToString()
        End Try
    End Function

    <WebMethod> _
    <ScriptMethod> _
    Public Shared Function get_dic_trans(ByVal dicID As String) As String
        Try
            Dim Qry As String
            Dim Con As New MTBMS.DAL.DBTaskBO

            Qry = "Select tD.dicID, tD.drID, tD.foID, tT.traID, tT.traName, isNull(traPatFirstName,'') as traPatFirstName , isNull(traPatLastName,'') as traPatLastName, isNull(traPatientNo,'') as traPatientNo from boDictation tD inner join boTranscription tT on tT.dicID = tD.dicID where tD.dicId=" & dicID
            Dim ds As DataSet = Con.getDataSet(Qry)
            ds.Tables(0).TableName = "trans"
            Return ds.GetXml()
        Catch ex As Exception
            Return ex.Message().ToString()
        End Try
    End Function

    <WebMethod> _
    <ScriptMethod> _
    Public Shared Function reverse_trascription(ByVal traID As String, ByVal dicID As String) As String
        Try
            Dim Qry As String
            Dim html As String = ""
            Dim Con As New MTBMS.DAL.DBTaskBO

            Qry = "Select dicStatus from boDictation where dicID =" & dicID
            If Con.getScalar(Qry) > 2 Then
                Return "0"
            Else
                Qry = "select bD.rolID,bD.empId,bE.empFirstName+ ' ' + bE.empLastName as empName, isNull(bT.tralStatus,-1) As tralStatus from boDictationLayers  bD " _
               & "Left Outer Join boTranscriptionLayers bT on bD.dicId = bT.dicID AND bD.rolID = bT.rolID " _
               & "inner join boEmployee bE on bD.empId = bE.empID " _
               & "inner join boRoles bR on bR.rolID = bD.rolID " _
               & "where(bD.dicID = '" & dicID & "' AND traID= '" & traID & "') Order By rolOrder"

                Dim ds As DataSet = Con.getDataSet(Qry)

                For Each dr As DataRow In ds.Tables(0).Rows
                    Select Case dr("rolID").ToString().Trim()
                        Case "MT"
                            If dr("empID").ToString.Trim <> "0" Then
                                If dr("tralStatus") = 1 Then
                                    html &= "<span class='roles_styling' title='" & dr("empName") & "'>MT</span>"
                                Else : dr("tralStatus") = 2
                                    html &= "<span class='roles_styling_enable' title='" & dr("empName") & "' onClick='btn_reverse_tra_role(" & dicID & "," & traID & ",&quot;MT&quot;)'>MT</span>"
                                End If
                            Else
                                html &= "<span class='roles_styling'>MT </span>" & "-"
                            End If
                        Case "QC"
                            If dr("empID").ToString.Trim <> "0" Then
                                If dr("tralStatus") = 1 Then
                                    html &= "<span class='roles_styling' title='" & dr("empName") & "'>QC</span>"
                                ElseIf dr("tralStatus") = 2 Then
                                    html &= "<span class='roles_styling_enable' title='" & dr("empName") & "' onClick='btn_reverse_tra_role(" & dicID & "," & traID & ",&quot;QC&quot;)'>QC</span>"
                                End If
                            Else
                                html &= "<span class='roles_styling' title='-'>QC</span>"
                            End If
                        Case "PR"
                            If dr("empID").ToString.Trim <> "0" Then
                                If dr("tralStatus") = 1 Then
                                    html &= "<span class='roles_styling' title='" & dr("empName") & "'>PR</span>"
                                ElseIf dr("tralStatus") = 2 Then
                                    html &= "<span class='roles_styling_enable' title='" & dr("empName") & "' onClick='btn_reverse_tra_role(" & dicID & "," & traID & ",&quot;PR&quot;)'>PR</span>"
                                End If
                            Else
                                html &= "<span class='roles_styling' title='-'>PR</span>"
                            End If
                        Case "FR"
                            If dr("empID").ToString.Trim <> "0" Then
                                If dr("tralStatus") = 1 Then
                                    html &= "<span class='roles_styling' title='" & dr("empName") & "'>FR</span>"
                                ElseIf dr("tralStatus") = 2 Then
                                    html &= "<span class='roles_styling_enable' title='" & dr("empName") & "' onClick='btn_reverse_tra_role(" & dicID & "," & traID & ",&quot;FR&quot;)'>FR</span>"
                                End If
                            Else
                                html &= "<span class='roles_styling' title='-'>FR</span>"
                            End If
                    End Select
                Next

                ds.Dispose()
                ds = Nothing

                Con.objConnection.Close()
                Con = Nothing
                Return html
            End If

        Catch ex As Exception
            Return ex.Message().ToString()
        End Try
    End Function

    <WebMethod> _
    <ScriptMethod> _
    Public Shared Function reverse_tra_role_save(ByVal dicID As String, ByVal traID As String, ByVal SelectedRole As String) As String
        Dim sQry As String = ""
        Dim Con As New MTBMS.DAL.DBTaskBO

        Try
            sQry = "SELECT COUNT(traID) FROM boTranscription WHERE dicID = " & dicID
            Dim iTranscriptions As Int16 = Con.getScalar(sQry)

            g_Qry = "Update boDictation set dicStatus=1 where dicId=" & dicID & ";"
            g_Qry += "Update boTranscription set traStatus=0 where traId=" & traID & ";"

            g_Qry += "UPDATE boTranscriptionLayers SET tralStatus = 1 " _
                & "WHERE traID = " & traID & " AND rolID = '" & SelectedRole & "';"

            g_Qry += "UPDATE boDictationLayers SET diclTranscriptions=diclTranscriptions-1, diclStatus=2 " _
                & "WHERE dicID=" & dicID & " AND rolID='" & SelectedRole & "';"

            If SelectedRole = "MT" Then
                If iTranscriptions = 1 Then
                    g_Qry += "Update boDictationLayers set diclStatus=0, diclTranscriptions=0, diclTag=0 " _
                        & "where dicId=" & dicID & " AND rolID<>'MT';"

                    g_Qry += "DELETE FROM boTranscriptionLayers WHERE traID=" & traID & " AND rolID IN ('QC','PR','FR')"
                Else
                    Call checkNextLayer(dicID, traID, "QC")
                    Call checkNextLayer(dicID, traID, "PR")
                    Call checkNextLayer(dicID, traID, "FR")
                End If


            ElseIf SelectedRole = "QC" Then
                If iTranscriptions = 1 Then
                    g_Qry += "UPDATE boDictationLayers SET diclStatus=0, diclTranscriptions=0, diclTag=0 " _
                        & "WHERE dicID=" & dicID & " AND rolID IN ('PR','FR');"

                    g_Qry += "DELETE FROM boTranscriptionLayers WHERE traID=" & traID & " AND rolID IN ('PR','FR')"
                Else
                    Call checkNextLayer(dicID, traID, "PR")
                    Call checkNextLayer(dicID, traID, "FR")
                End If


            ElseIf SelectedRole = "PR" Then
                If iTranscriptions = 1 Then
                    g_Qry += "UPDATE boDictationLayers SET diclStatus=0, diclTranscriptions=0, diclTag=0 " _
                        & "WHERE dicID=" & dicID & " AND rolID IN ('FR');"

                    g_Qry += "DELETE FROM boTranscriptionLayers WHERE traID=" & traID & " AND rolID IN ('FR')"
                Else
                    Call checkNextLayer(dicID, traID, "FR")
                End If
            ElseIf SelectedRole = "FR" Then

            End If

            Con.saveData(g_Qry)
            Dim Qry As String = "SELECT boDictation.dicID, boDictationLayers.empID ,IsNull(boDictationLayers.diclWorkloadDate, '01/01/1999') as diclWorkloadDate, boDictationLayers.rolID, " _
                                        & "empFirstName +' '+ substring(empLastName,1,1) as empName, diclStatus " _
                                        & "FROM boDictationLayers INNER JOIN boEmployee " _
                                        & "ON boDictationLayers.empID = boEmployee.empID " _
                                        & "INNER JOIN boDictation ON boDictationLayers.dicID = boDictation.dicID " _
                                        & "WHERE boDictationLayers.dicID IN ( " & dicID & " ) AND dicStatus >= 0"
            Dim ds As DataSet = Con.getDataSet(Qry)
            ds.Tables(0).TableName = "dics"
            Dim dRow As DataRow
            ds.Tables(0).Columns.Add("dicDT", Type.GetType("System.String"))
            For Each dRow In ds.Tables(0).Rows
                dRow("dicDT") = Format(dRow("diclWorkloadDate"), "dd/MM/yy")
            Next

            Return "1," & ds.GetXml()

        Catch ex As Exception
            Return ex.Message().ToString()
        Finally
            Con.objConnection.ConnectionString = Nothing
        End Try
    End Function

    Public Shared Function checkNextLayer(ByVal dicID As String, ByVal traID As String, ByVal vRolID As String) As String
        Dim Con As New MTBMS.DAL.DBTaskBO
        Dim sQry As String = ""

        sQry = "SELECT tralStatus FROM boTranscriptionLayers WHERE traID = " & traID & " AND rolID = '" & vRolID & "'"
        Dim tralStatus As Integer = Con.getScalar(sQry)

        If tralStatus = 2 Then
            g_Qry += "Update boDictationLayers set diclTranscriptions=diclTranscriptions-1 " _
                & "WHERE dicId=" & dicID & " AND rolID = '" & vRolID & "';"
        End If

        sQry = "SELECT diclTranscriptions FROM boDictationLayers WHERE dicID = " & dicID & " AND rolID = '" & vRolID & "'"
        Dim diclTranscriptions As Integer = Con.getScalar(sQry)

        If diclTranscriptions <= 1 Then
            g_Qry += "Update boDictationLayers set diclStatus = 0, diclTag = 0 " _
                & "WHERE dicId=" & dicID & " AND rolID = '" & vRolID & "';"
        Else
            g_Qry += "Update boDictationLayers set diclStatus = 2 " _
                & "WHERE dicId=" & dicID & " AND rolID = '" & vRolID & "' AND diclStatus = 3;"
        End If

        g_Qry += "DELETE FROM boTranscriptionLayers WHERE traID=" & traID & " AND rolID = '" & vRolID & "';"
        Return ""
    End Function

    <WebMethod> _
    <ScriptMethod> _
    Public Shared Function get_transcriptions_roles_files(ByVal traID As String) As String
        Try
            Dim Con As New MTBMS.DAL.DBTaskBO
            Dim html As String = ""

            g_Qry = "SELECT * FROM boTranscriptionLayers WHERE traID = " & traID
            Dim ds As DataSet = Con.getDataSet(g_Qry)

            Dim docMT As String = "#"
            Dim docQC As String = "#"
            Dim docPR As String = "#"
            Dim docFR As String = "#"

            For Each dr As DataRow In ds.Tables(0).Rows
                If dr("rolID") = "MT" Then
                    docMT = dr("tralName")
                ElseIf dr("rolID") = "QC" Then
                    docQC = dr("tralName")
                ElseIf dr("rolID") = "PR" Then
                    docPR = dr("tralName")
                ElseIf dr("rolID") = "FR" Then
                    docFR = dr("tralName")
                End If
            Next

            If docMT <> "#" Then
                html &= "<a class='roles_styling_enable' title='" & docMT & "' target='_blank' href='../data/mt/" & docMT & "'>MT</a>"
            Else
                html &= "<span class='roles_styling'>MT</span>"
            End If

            If docQC <> "#" Then
                html &= "<a class='roles_styling_enable' title='" & docQC & "' target='_blank' href='../data/qc/" & docQC & "'>QC</a>"
            Else
                html &= "<span class='roles_styling'>QC</span>"
            End If

            If docPR <> "#" Then
                html &= "<a class='roles_styling_enable' title='" & docPR & "' target='_blank' href='../data/pr/" & docPR & "'>PR</a>"
            Else
                html &= "<span class='roles_styling'>PR</span>"
            End If

            If docFR <> "#" Then
                html &= "<a class='roles_styling_enable' title='" & docFR & "' target='_blank' href='../data/fr/" & docFR & "'>FR</a>"
            Else
                html &= "<span class='roles_styling'>FR</span>"
            End If

            If html <> "" Then
                Return html
            Else
                Return "0"
            End If
        Catch ex As Exception
            Return ex.Message().ToString()
        End Try
    End Function

    <WebMethod> _
    <ScriptMethod> _
    Public Shared Function delete_transcription_file(ByVal dicID As String, ByVal traID As String) As String
        Dim Con As New MTBMS.DAL.DBTaskBO
        Try
            g_Qry = "SELECT dicTranscriptions FROM boDictation WHERE dicID = " & dicID
            Dim iTranscriptions As Int16 = Con.getScalar(g_Qry)

            If iTranscriptions = 1 Then
                g_Qry = "DELETE FROM boTranscriptionLayers WHERE traID = " & traID & ";"
                g_Qry += "DELETE FROM boTranscription WHERE traID = " & traID & ";"
                g_Qry += "Update boDictationLayers set diclStatus=0, diclTranscriptions = 0, diclTag = 0 " _
                       & "where dicId=" & dicID & ";"
                g_Qry += "Update boDictationLayers set diclStatus=1 " _
                       & "where dicId=" & dicID & " AND rolID='MT';"
                g_Qry += "Update boDictationLayers set empID = '0' " _
                       & "where dicId=" & dicID & " AND diclSkip = 1;"
                g_Qry += "Update boDictation set dicStatus=1, dicTranscriptions=0 " _
                       & "WHERE dicID=" & dicID & ";"
            Else
                Call deleteTranscriptionLayer(dicID, traID, "FR")
                Call deleteTranscriptionLayer(dicID, traID, "PR")
                Call deleteTranscriptionLayer(dicID, traID, "QC")
                Call deleteTranscriptionLayer(dicID, traID, "MT")

                g_Qry = "DELETE FROM boTranscription WHERE traID = " & traID & ";"
                g_Qry += "Update boDictation set dicTranscriptions=dicTranscriptions-1 " _
                       & "WHERE dicID=" & dicID & ";"
            End If

            Con.saveData(g_Qry)

            Dim Qry As String = "SELECT boDictation.dicID, boDictationLayers.empID ,IsNull(boDictationLayers.diclWorkloadDate, '01/01/1999') as diclWorkloadDate, boDictationLayers.rolID, " _
                                        & "empFirstName +' '+ substring(empLastName,1,1) as empName, diclStatus " _
                                        & "FROM boDictationLayers INNER JOIN boEmployee " _
                                        & "ON boDictationLayers.empID = boEmployee.empID " _
                                        & "INNER JOIN boDictation ON boDictationLayers.dicID = boDictation.dicID " _
                                        & "WHERE boDictationLayers.dicID IN ( " & dicID & " ) AND dicStatus >= 0"
            Dim ds As DataSet = Con.getDataSet(Qry)
            ds.Tables(0).TableName = "dics"
            Dim dRow As DataRow
            ds.Tables(0).Columns.Add("dicDT", Type.GetType("System.String"))
            For Each dRow In ds.Tables(0).Rows
                dRow("dicDT") = Format(dRow("diclWorkloadDate"), "dd/MM/yy")
            Next

            Return "1," & ds.GetXml()

        Catch ex As Exception
            Return ex.Message().ToString()
        Finally
            Con.objConnection.ConnectionString = Nothing
        End Try
    End Function

    Protected Shared Sub deleteTranscriptionLayer(ByVal dicID As String, ByVal traID As String, ByVal vsrolID As String)
        Dim Con As New MTBMS.DAL.DBTaskBO
        Try
            g_Qry = "DELETE FROM boTranscriptionLayers WHERE traID = " & traID & " " _
                              & "AND rolID = '" & vsrolID & "' AND tralStatus = 2;"
            If Con.saveData(g_Qry) > 0 Then
                g_Qry = "Update boDictationLayers set diclTranscriptions = diclTranscriptions-1 " _
                       & "where dicId=" & dicID & " AND rolID = '" & vsrolID & "'"
                Call Con.saveData(g_Qry)
            Else
                g_Qry = "DELETE FROM boTranscriptionLayers WHERE traID = " & traID & " " _
                      & "AND rolID = '" & vsrolID & "' AND tralStatus = 0;"
                If Con.saveData(g_Qry) = 0 Then
                    g_Qry = "Update boDictationLayers set diclTranscriptions = diclTranscriptions - 1 " _
                          & "where dicId=" & dicID & " AND rolID = '" & vsrolID & "' " _
                          & "AND diclStatus > 0"
                    Call Con.saveData(g_Qry)
                End If
            End If
            g_Qry = "SELECT COUNT(traID) FROM boTranscriptionLayers " _
                  & "WHERE dicID = " & dicID & " AND traTag = 1 AND rolID = '" & vsrolID & "'"
            If Con.saveData(g_Qry) = 0 Then
                g_Qry = "Update boDictationLayers set diclTag = 0 " _
                      & "where dicId=" & dicID & " AND rolID = '" & vsrolID & "';"
                g_Qry += "Update boDictationLayers set empID = '0' " _
                      & "where dicId=" & dicID & " AND rolID = '" & vsrolID & "' AND diclSkip = 1;"
                Call Con.saveData(g_Qry)
            End If
        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

    <WebMethod> _
    <ScriptMethod> _
    Public Shared Function refresh_dictation(ByVal drID As String, ByVal CPMainDate As String) As String
        Try
            Dim Con As New MTBMS.DAL.DBTaskBO
            Dim Qry As String

            Dim dMain As Date
            Dim dts() As String
            Dim dt As String

            dts = CPMainDate.Split("/")
            dt = dts(0) & "/" & dts(1) & "/" & dts(2)
            dMain = DateTime.Parse(dt)

            Qry = "SELECT boDictation.dicID, boDictationLayers.empID ,IsNull(boDictationLayers.diclWorkloadDate, '01/01/1999') as diclWorkloadDate, boDictationLayers.rolID, " _
                        & "empFirstName +' '+ substring(empLastName,1,1) as empName, diclStatus " _
                        & "FROM boDictationLayers INNER JOIN boEmployee " _
                        & "ON boDictationLayers.empID = boEmployee.empID " _
                        & "INNER JOIN boDictation ON boDictationLayers.dicID = boDictation.dicID " _
                        & "WHERE boDictation.drID = " & drID.Trim() & " AND dicDate = '" & Format(dMain, "MM/dd/yyyy") & "' AND dicStatus >= 0"
            Dim ds As DataSet = Con.getDataSet(Qry)
            ds.Tables(0).TableName = "dics"
            Dim dRow As DataRow
            ds.Tables(0).Columns.Add("dicDT", Type.GetType("System.String"))
            For Each dRow In ds.Tables(0).Rows
                dRow("dicDT") = Format(dRow("diclWorkloadDate"), "dd/MM/yy")
            Next

            Return "1," & ds.GetXml()
        Catch ex As Exception
            Return ex.Message().ToString()
        End Try
    End Function

    <WebMethod> _
    <ScriptMethod> _
    Public Shared Function mark_duplicate_checked(ByVal dicID As String) As String
        Dim con As New MTBMS.DAL.DBTaskBO
        Dim ds As New DataSet
        Dim Qry As String = ""
        Try
            Qry = "UPDATE boDictation SET dicDuplicateCheck = 1 WHERE dicID = " & dicID
            con.update(Qry)
            Return "1"
        Catch ex As Exception
            Return ex.Message.ToString()
        Finally
            ds.Clear()
            ds = Nothing
            con = Nothing
        End Try
    End Function

    <WebMethod> _
    <ScriptMethod> _
    Public Shared Function get_duplicate_dics(ByVal dicID As String) As String
        Dim Qry As String = ""
        Dim con As New MTBMS.DAL.DBTaskBO
        Dim ds As New DataSet
        Try
            Qry = "SELECT dicID, dicDate, drID, dicActualName, dicLength from boDictation WHERE dicActualName = (SELECT dicActualName FROM boDictation WHERE dicID = " & dicID & ") AND dicLength = (SELECT dicLength FROM boDictation WHERE dicID = " & dicID & ")"
            ds = con.getDataSet(Qry)
            ds.Tables(0).TableName = "dics"
            Dim dRow As DataRow
            ds.Tables(0).Columns.Add("dicDT", Type.GetType("System.String"))
            For Each dRow In ds.Tables(0).Rows
                dRow("dicDT") = Format(dRow("dicDate"), "dd/MM/yy")
            Next
            Return ds.GetXml()
        Catch ex As Exception
            Return "0"
        Finally
            ds.Clear()
            ds = Nothing
            con = Nothing
        End Try
    End Function
End Class
