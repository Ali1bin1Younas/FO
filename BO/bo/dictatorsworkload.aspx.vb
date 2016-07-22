Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class dictatorworkload
    Inherits System.Web.UI.Page
    Protected intTMinutes, intDicDaily, intDone, intOut, intDoneM, intOutM As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ViewState("ccint1") = 0
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        ViewState("ccint") = 0

        If Not Page.IsPostBack Then
            Me.cpFrom.SelectedDate = Now.Date.Date
            Me.cpFrom.VisibleDate = Now.Date.Date
            Me.cpTo.SelectedDate = Now.Date.Date
            Me.cpTo.VisibleDate = Now.Date.Date
        End If
        'loadDailyworkload()
    End Sub

    'Protected Function getCounter() As String
    '    Dim intCount As Integer = ViewState("ccint1")
    '    intCount += 1
    '    ViewState("ccint1") = intCount
    '    Return intCount.ToString
    'End Function

    Protected Function getCounter() As String
        Dim intCount As Integer = ViewState("ccint")
        intCount += 1
        ViewState("ccint") = intCount
        Return intCount.ToString
    End Function

    Protected Function getMin(ByVal second As String) As String
        Return GF.GetMin(second)
    End Function

    Private Sub loadDailyworkload()
        Dim Qry As String
        Dim Con As New DBTaskBO
        Dim ds As DataSet
        Qry = "SELECT b.foID,b.drID,b.foID + '-' + b.drID as drCID,c.drFirstName, " _
                & "COUNT(b.dicActualName) AS TotalDictation, " _
                & "SUM(b.dicLength) AS TotalMinutes," _
                & "(Select Count(dicID) From boDictation " _
                & "where dicStatus >= 2 and dicDate BETWEEN '" & Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy") & "'AND '" & Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") & "' and b.foID+drID=foID+b.drID ) " _
                & "As doneDictations," _
                & "IsNull((Select sum(dicLength) From boDictation " _
                & "where dicStatus >= 2 and dicDate BETWEEN '" & Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy") & "'AND '" & Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") & "' and b.foID+drID=foID+b.drID ),0) " _
                & "As doneMinutes," _
                & "(Select Count(dicID) From boDictation " _
                & "where dicStatus < 2 and dicDate BETWEEN '" & Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy") & "'AND '" & Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") & "' and b.foID+drID=foID+b.drID ) " _
                & "As outDictations," _
                & "IsNull((Select sum(dicLength) From boDictation " _
                & "where dicStatus < 2 and dicDate BETWEEN '" & Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy") & "'AND '" & Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") & "' and b.foID+drID=foID+b.drID ),0) " _
                & "As outMinutes," _
                & "c.drLastname, c.drMiddleName " _
                & "FROM boDictation B INNER JOIN boDictator C ON b.drID = c.drID " _
                & "AND b.foID = c.foID WHERE (b.dicEnable = 1) " _
                & "AND (b.dicDate BETWEEN '" & Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy") & "'AND '" & Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") & "') " _
                & "GROUP BY b.foID,b.drID,c.drFirstName,c.drLastName,c.drMiddleName;"
        Qry += "Select * From boDictation where (dicEnable=1 AND dicDate BETWEEN '" + Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy") + "'AND '" & Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") & "') order by dicDate Desc, dicActualName"
        ds = Con.getDataSet(Qry)
        ds.Tables(0).TableName = "WorkLoadDaily"
        ds.Tables(1).TableName = "Dic"

        Dim FCRelation() As DataColumn = {ds.Tables(0).Columns("drID"), ds.Tables(0).Columns("foID")}
        Dim SCRelation() As DataColumn = {ds.Tables(1).Columns("drID"), ds.Tables(1).Columns("foID")}
        ds.Relations.Add("PK", FCRelation, SCRelation, False)

        Me.dgDailyWorkLoad.DataSource = ds
        If ds.Tables(0).Rows.Count <> 0 Then
            dgDailyWorkLoad.Visible = True
            Label1.Visible = True
            Me.dgDailyWorkLoad.DataMember = "WorkLoadDaily"
            Me.GrandTotal(ds.Tables(0))
            Me.dgDailyWorkLoad.DataBind()
        Else
            dgDailyWorkLoad.Visible = False
            Label1.Visible = False
        End If
    End Sub

    'Protected Sub dgDailyWorkLoad_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDailyWorkLoad.ItemDataBound
    '    If e.Item.Cells(1).Text <> "" And e.Item.Cells(1).Text <> "#" And e.Item.Cells(1).Text <> "&nbsp;" Then
    '        e.Item.Cells(1).Text = "ali"
    '    End If
    'End Sub

    Protected Sub dgDailyWorkLoad_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles dgDailyWorkLoad.TemplateSelection
        e.TemplateFilename = "dictatorworkloaddetail.ascx"
    End Sub

    Protected Sub GrandTotal(ByVal dt As DataTable)
        For Each dr As DataRow In dt.Rows
            intDicDaily += CType(dr("TotalDictation"), Integer)
            intTMinutes += CType(dr("TotalMinutes"), Integer)
            intDone += CType(dr("doneDictations"), Integer)
            intDoneM += CType(dr("doneMinutes"), Integer)
            intOut += CType(dr("outDictations"), Integer)
            intOutM += CType(dr("outMinutes"), Integer)
        Next
    End Sub

    'Private Sub loadPendingWorkload()
    '    Dim Qry As String
    '    Dim Con As New DBTaskBO
    '    Dim ds As DataSet

    '    'Qry = "SELECT boDictation.drID,boDictator.drFirstName,COUNT(dbo.boDictation.dicActualName) AS TotalDictation, SUM(boDictation.dicLength) AS TotalMinutes FROM boDictation INNER JOIN boDictator ON boDictation.drID = boDictator.drID AND boDictation.foID = boDictator.foID WHERE (boDictation.dicEnable = 1) AND (boDictation.dicDate < '" & Me.CPMain.SelectedDate & "') GROUP BY dbo.boDictation.drID,boDictator.drFirstName;"
    '    Qry = "SELECT b.drID,c.drFirstName,COUNT(b.dicActualName) AS TotalDictation, SUM(b.dicLength) AS TotalMinutes,(Select Count(dicActualName) From boDictation where dicStatus<4 and dicDate<'" & Me.CPMain.SelectedDate & "' and drID=b.drID ) As Outstanding,c.drLastname,c.drMiddleName FROM boDictation B INNER JOIN boDictator C ON b.drID = c.drID AND b.foID = c.foID WHERE (b.dicEnable = 1) AND (b.dicDate < '" & Me.CPMain.SelectedDate & "') GROUP BY b.drID,c.drFirstName,c.drLastName,c.drMiddleName;"
    '    Qry += "Select * From boDictation where (dicEnable=1 AND dicDate<'" + Me.CPMain.SelectedDate + "') order by dicDate Desc, dicActualName"
    '    ds = Con.getDataSet(Qry)
    '    ds.Tables(0).TableName = "WorkLoadPending"
    '    ds.Tables(1).TableName = "Dic"
    '    ds.Relations.Add("PK", ds.Tables(0).Columns(0), ds.Tables(1).Columns(1), False)
    '    Me.dgDailyWorkloadPending.DataSource = ds
    '    If ds.Tables(0).Rows.Count <> 0 Then
    '        dgDailyWorkloadPending.Visible = True
    '        Label2.Visible = True
    '        Me.dgDailyWorkloadPending.DataMember = "WorkLoadPending"
    '        getPNODDaily(ds.Tables(0))
    '        getPNOMDaily(ds.Tables(0))
    '        getPNOODaily(ds.Tables(0))
    '        Me.dgDailyWorkloadPending.DataBind()
    '    Else
    '        dgDailyWorkloadPending.Visible = False
    '        Label2.Visible = False
    '    End If
    'End Sub

    'Protected Sub dgDailyWorkloadPending_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDailyWorkloadPending.ItemDataBound
    '    If e.Item.Cells(1).Text <> "" And e.Item.Cells(1).Text <> "#" And e.Item.Cells(1).Text <> "&nbsp;" Then

    '        e.Item.Cells(1).Text = "ali"
    '    End If

    'End Sub
    'Protected Sub dgDailyWorkloadPending_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles dgDailyWorkloadPending.TemplateSelection
    '    e.TemplateFilename = "dailydictationdetail.ascx"
    'End Sub
    'Private Function GetFOID(ByVal strName As String) As String
    '    Dim Con As New DBTaskBO
    '    Dim Qry As String = "Select foID From boFO where foName='" + strName + "'"
    '    Dim ds As DataSet
    '    Dim strID As String = Nothing
    '    ds = Con.getDataSet(Qry)
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        strID = ds.Tables(0).Rows(0).Item(0).ToString
    '        Return strID
    '    End If
    '    Return strID
    'End Function

    'Protected Function getCounterDaily() As String
    '    Dim intCountDaily As Integer = Session("cintDaily")
    '    intCountDaily += 1
    '    Session("cintDaily") = intCountDaily
    '    Return intCountDaily.ToString
    'End Function

    'Protected Function getCounterPending() As String
    '    Dim intCountPending As Integer = Session("cintPending")
    '    intCountPending += 1
    '    Session("cintPending") = intCountPending
    '    Return intCountPending.ToString
    'End Function

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        loadDailyworkload()

    End Sub
End Class
