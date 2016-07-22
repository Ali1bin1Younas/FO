Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Public Class dictationassignment
    Inherits System.Web.UI.Page
    Protected intNODProgress As Integer
    Protected intNOOProgress As Integer
    Protected empRoll As String
    Protected Query_Back_Log, Query_Current As String
    Protected Shared SelectedDate As Date = Now.Date
    Protected Shared SelectedRolID, SelectedEmployeeID As String
    Protected GrandMinutes, GrandOutMinutes, GrandDictation, GrandOutDictation As Integer
    Protected Counter As Int32

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Ajax.Utility.RegisterTypeForAjax(GetType(dictationassignment))
        If Session("empID") = "" Then Response.Redirect(GF.Home)
        Counter = 0
        If Page.IsPostBack Then
            'Me.CPMain.SelectedDate = Session("DTMainValue")
            'Me.CPMain.VisibleDate = Session("DTMainValue")
            'Me.cmbMainPR.SelectedValue = Session("PRMainValue")
            If Me.chkBacklog.Checked Then
                Me.lblBacklog.Visible = True
            Else
                Me.lblBacklog.Visible = False
            End If
        Else
            Me.chkBacklog.Checked = False
            Me.lblBacklog.Visible = False
            loadMainPR("PR")
            If Request.QueryString("qStr") = "" Then
                Me.CPMain.SelectedDate = Now.Date.Date
                Me.CPMain.VisibleDate = Now.Date.Date
                'Me.cmbMainPR.SelectedValue = "All"
                Session("DTMainValue") = Now.Date.Date
                'Session("PRMainValue") = "All"
            Else
                Me.CPMain.SelectedDate = SelectedDate
                Me.CPMain.VisibleDate = SelectedDate
                Me.cmbMainPR.SelectedValue = SelectedEmployeeID
                Me.ddlEmployeeRoll.SelectedIndex = SelectedRolID
            End If
            Dim ObjDictation As New dicassignment
            ObjDictation.EmployeeRoll = Me.ddlEmployeeRoll.SelectedItem.Text
            ObjDictation.SelectedDate = Me.CPMain.SelectedDate.Date.ToString
            ObjDictation.EmplyeeID = Me.cmbMainPR.SelectedValue
            Query_Current = ObjDictation.Generate_Query("Current")
            Query_Back_Log = ObjDictation.Generate_Query("Backlog")
            loadGridPR()
            If Me.chkBacklog.Checked Then
                dgMainBacklog.Visible = True
                loadgrdMainBacklog()
            Else
                dgMainBacklog.Visible = False
            End If
        End If
    End Sub

    Private Sub loadMainPR(ByVal Roll As String)
        Dim Con As New DBTaskBO
        Dim Qry As String
        Dim ds As DataSet
        Dim strPR As String = Nothing

        Qry = "SELECT boEmployeeRoles.rolID, boEmployeeRoles.empID, " _
              & "boEmployee.empFirstName + ' ' + SUBSTRING(boEmployee.empLastName,1,1) " _
              & "AS empName FROM boEmployee INNER JOIN " _
              & "boEmployeeRoles ON boEmployee.empID = boEmployeeRoles.empID " _
              & "WHERE boEmployeeRoles.rolID = '" & Roll & "' AND boEmployeeRoles.empID <> '0' AND boEmployeeRoles.empEnable=1 AND boEmployee.empEnable=1 " _
              & "ORDER BY empName"
        ds = Con.getDataSet(Qry)

        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow = dt.NewRow()

        dr("empID") = "-1"
        dr("empName") = "All"
        dt.Rows.InsertAt(dr, 0)

        'Dim dr1 As DataRow = dt.NewRow()
        'dr1("empID") = "-1"
        'dr1("empName") = "-------------"
        'dt.Rows.InsertAt(dr1, 1)

        cmbMainPR.DataSource = dt
        cmbMainPR.DataTextField = "empName"
        cmbMainPR.DataValueField = "empID"

        'Dim dr2 As DataRow = dt.NewRow()
        'dr2("empID") = "-1"
        'dr2("empName") = "-------------"
        'dt.Rows.InsertAt(dr2, dt.Rows.Count)

        If Roll <> "MT" Then
            Dim dr3 As DataRow = dt.NewRow()
            dr3("empID") = "0"
            dr3("empName") = "Skipped"
            dt.Rows.InsertAt(dr3, dt.Rows.Count)
        End If
        

        cmbMainPR.DataBind()

        'cmbMainPR.Items.Add("-------------")
        'cmbMainPR.Items.Add("Skipped")

        ds.Dispose()
        Con.objConnection.Close()
        Con = Nothing
    End Sub

    '<Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
    'Public Function AssignRights(ByVal cmMT As String, ByVal cmQC As String, ByVal cmPR As String, ByVal cmFR As String) As String
    '    Try
    '        Dim hash As New Hashtable
    '        hash.Add("MT", cmMT)
    '        hash.Add("QC", cmQC)
    '        hash.Add("PR", cmPR)
    '        hash.Add("FR", cmFR)
    '        Session("AssignValue") = hash
    '        Return True
    '    Catch
    '        Return False
    '    End Try
    'End Function

    Private Sub loadGridPR()
        Dim d As DateTime = Me.CPMain.SelectedDate
        Dim Con As New DBTaskBO
        Dim ds As New DataSet
        ds = Con.getDataSet(Query_Current)
        ds.Tables(0).TableName = "PR"
        ds.Tables(1).TableName = "DR"
        ds.Tables(2).TableName = "DIC"
        ds.Relations.Add("PK", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
        Dim objFirstDataColumn() As DataColumn = {ds.Tables(1).Columns(0), ds.Tables(1).Columns(1), ds.Tables(1).Columns(2)}
        Dim objSecondDataColumn() As DataColumn = {ds.Tables(2).Columns(0), ds.Tables(2).Columns(1), ds.Tables(2).Columns(2)}
        ds.Relations.Add("PK1", objFirstDataColumn, objSecondDataColumn, False)
        Me.dgPRMain.DataSource = ds
        If ds.Tables(0).Rows.Count <> 0 Then
            Call GrandTotal(ds.Tables(0))
            Me.dgPRMain.DataMember = "PR"
            Me.dgPRMain.DataBind()
            Me.dgPRMain.Visible = True
            Me.dgPRMain.RowExpanded.ExpandAll()
        Else
            Me.dgPRMain.Visible = False
        End If
        ds.Dispose()
        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Private Sub loadgrdMainBacklog()
        Dim d As DateTime = Me.CPMain.SelectedDate
        Dim Con As New DBTaskBO
        Dim ds As New DataSet
        ds = Con.getDataSet(Query_Back_Log)
        ds.Tables(0).TableName = "PR1"
        ds.Tables(1).TableName = "DR1"
        ds.Tables(2).TableName = "DIC1"

        ds.Relations.Add("PK", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
        Dim objFirstDataColumn() As DataColumn = {ds.Tables(1).Columns(0), ds.Tables(1).Columns(1), ds.Tables(1).Columns(2)}
        Dim objSecondDataColumn() As DataColumn = {ds.Tables(2).Columns(0), ds.Tables(2).Columns(1), ds.Tables(2).Columns(2)}
        ds.Relations.Add("PK1", objFirstDataColumn, objSecondDataColumn, False)

        Me.dgMainBacklog.DataSource = ds

        If ds.Tables(0).Rows.Count > 0 And Me.chkBacklog.Checked = True Then
            Call Me.GrandTotal(ds.Tables(0))
            Me.dgMainBacklog.DataMember = "PR1"
            Me.dgMainBacklog.DataBind()
            Me.dgMainBacklog.Visible = True
            Me.dgMainBacklog.RowExpanded.ExpandAll()
        Else
            Me.dgMainBacklog.Visible = False

        End If
       

        ds.Dispose()
        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Protected Sub dgPRMain_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPRMain.ItemCreated
        If e.Item.ItemType <> ListItemType.Header Then
            Counter += 1
        End If
    End Sub

    Protected Sub dgPRMain_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPRMain.ItemDataBound
        Dim strZeroEmployee As String = e.Item.Cells(1).Text.Trim

        If strZeroEmployee = "0" Then

            e.Item.Cells(1).Text = "--"
        End If
    End Sub

    Protected Sub CPMain_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CPMain.DateChanged
        Session("DTMainValue") = Me.CPMain.SelectedDate.Date
        'loadGridPR()
        'loadgrdMainBacklog()
    End Sub

    Protected Sub cmbMainPR_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMainPR.TextChanged
        'If Me.cmbMainPR.SelectedValue = "-1" Then Exit Sub

        Session("PRMainValue") = Me.cmbMainPR.Text.Trim
        'loadGridPR()
        'loadgrdMainBacklog()
    End Sub

    Protected Function getEmpFullName(ByVal id As String) As String
        Dim strFullName As String = Nothing
        If id.Trim <> "0" Then
            Dim Con As New DBTaskBO
            Dim Qry As String = "SELECT empFirstName +' '+ empLastName as empName FROM boEmployee Where empID='" + id + "'"
            Dim ds As DataSet
            ds = Con.getDataSet(Qry)
            strFullName = ds.Tables(0).Rows(0)("empName")
        Else
            strFullName = "Skipped"
        End If
        Return strFullName

    End Function

    Protected Sub chkBacklog_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBacklog.CheckedChanged
        If Me.chkBacklog.Checked Then
            Session("sBacklog") = True
            'loadgrdMainBacklog()
        Else
            Session("sBacklog") = False
            'loadgrdMainBacklog()
        End If
    End Sub

   


    Protected Sub dgMainBacklog_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles dgMainBacklog.TemplateSelection
        e.TemplateFilename = "drstatusbacklog.ascx"
    End Sub

    Protected Sub dgPRMain_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles dgPRMain.TemplateSelection
        e.TemplateFilename = "drstatus.ascx"
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SelectedRolID = Me.ddlEmployeeRoll.SelectedIndex
        SelectedDate = Me.CPMain.SelectedDate.Date
        SelectedEmployeeID = Me.cmbMainPR.SelectedValue
        Dim ObjDictation As New dicassignment
        ObjDictation.EmployeeRoll = Me.ddlEmployeeRoll.SelectedItem.Text
        ObjDictation.SelectedDate = Me.CPMain.SelectedDate.Date
        ObjDictation.EmplyeeID = Me.cmbMainPR.SelectedValue
        empRoll = Me.ddlEmployeeRoll.SelectedItem.Text
        Query_Current = ObjDictation.Generate_Query("Current")
        loadGridPR()
        If Me.chkBacklog.Checked Then
            dgMainBacklog.Visible = True
            Query_Back_Log = ObjDictation.Generate_Query("Backlog")
            loadgrdMainBacklog()
        Else
            dgMainBacklog.Visible = False
        End If
    End Sub

    Protected Sub ddlEmployeeRoll_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmployeeRoll.SelectedIndexChanged
        Me.lblBacklog.Visible = False
        dgMainBacklog.Visible = False
        Me.dgPRMain.Visible = False
        If Me.ddlEmployeeRoll.SelectedValue = "0" Then
            Call Me.loadMainPR("PR")
            Session("EmpRoll") = "PR"
        Else
            Call Me.loadMainPR(Me.ddlEmployeeRoll.SelectedItem.ToString)
            Session("EmpRoll") = Me.ddlEmployeeRoll.SelectedItem.Text
        End If
    End Sub

    Protected Function getmin(ByVal seconds As String) As String
        Return GF.GetMin(seconds)
    End Function

    Protected Sub GrandTotal(ByVal dt As DataTable)
        For Each Item As DataRow In dt.Rows
            Me.GrandMinutes += CType(Item("dicLength"), Integer)
            Me.GrandDictation += CType(Item("Dictations"), Integer)
            Me.GrandOutMinutes += CType(Item("OutdicLength"), Integer)
            Me.GrandOutDictation += CType(Item("OutDictations"), Integer)
        Next
    End Sub

    'Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
    '    If Request.QueryString("Theme") <> "" Then
    '        Me.Page.Theme = Request.QueryString("Theme")
    '    Else
    '        If Session("rolid") = "" Then
    '            Me.Page.Theme = "QC"
    '        Else
    '            Me.Page.Theme = Session("rolid")
    '        End If
    '    End If

    'End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("EmpRoll") = "" Then
            Page.Theme = "PR"
        Else
            Page.Theme = Session("EmpRoll")
        End If

    End Sub
End Class