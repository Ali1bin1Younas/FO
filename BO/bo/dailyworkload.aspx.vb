Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class dailyworkload
    Inherits System.Web.UI.Page
    Protected intNODDaily As Integer
    Protected intNOMDaily As Integer
    Protected intPNODDaily As Integer
    Protected intPNOMDaily As Integer
    Protected intNOODaily As Integer
    Protected intPNOODaily As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empID") = "" Then Response.Redirect(GF.Home)

        ViewState("ccint1") = 0
        ViewState("ccint") = 0

        If Not Page.IsPostBack Then
            chkBaklog.Checked = True
            Me.CPMain.SelectedDate = Now.Date.Date
            Me.CPMain.VisibleDate = Now.Date.Date
        End If

        If chkBaklog.Checked = True Then
            Label2.Visible = True
            dgDailyWorkloadPending.Visible = True
            loadPendingWorkload()
        Else
            Label2.Visible = False
            dgDailyWorkloadPending.Visible = False
        End If
        loadDailyworkload()
    End Sub

    Protected Function getCounter() As String
        Dim intCount As Integer = ViewState("ccint1")
        intCount += 1
        ViewState("ccint1") = intCount
        Return intCount.ToString
    End Function
    Protected Function getCounter1() As String
        Dim intCount As Integer = ViewState("ccint")
        intCount += 1
        ViewState("ccint") = intCount
        Return intCount.ToString
    End Function

    Protected Function getMin(ByVal second As String) As String
        Return GF.GetMin(second)
    End Function

    Private Sub loadDailyworkload()
        'Try
        Dim Qry As String
        Dim Con As New DBTaskBO
        Dim ds As DataSet
        Qry = "SELECT b.foId, b.drId, b.foID + '-' + b.drID as drID,c.drFirstName,c.drLastname,c.drMiddleName,COUNT(b.dicActualName) AS TotalDictation, " _
            & " SUM(b.dicLength) AS TotalMinutes, " _
            & " ISNULL(C.drDifficulty,'') as drDifficulty,(Select Count(dicActualName) From boDictation where dicStatus < 4 and dicDate= '" + Format(Me.CPMain.SelectedDate, "MM/dd/yyyy") + "' and drID=b.drID ) As Outstanding, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate= '" + Format(Me.CPMain.SelectedDate, "MM/dd/yyyy") + "' and drID=b.drID and tDL.rolID= 'MT'), 0) As MTdoneMins, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate= '" + Format(Me.CPMain.SelectedDate, "MM/dd/yyyy") + "' and drID=b.drID and tDL.rolID= 'QC'), 0) As QCdoneMins, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate= '" + Format(Me.CPMain.SelectedDate, "MM/dd/yyyy") + "' and drID=b.drID and tDL.rolID= 'PR'), 0) As PRdoneMins, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate= '" + Format(Me.CPMain.SelectedDate, "MM/dd/yyyy") + "' and drID=b.drID and tDL.rolID= 'FR'), 0) As FRdoneMins " _
            & " FROM boDictation B INNER JOIN boDictator C ON b.drID = c.drID AND b.foID = c.foID " _
            & " WHERE (b.dicEnable = 1) AND (b.dicDate = '" + Format(Me.CPMain.SelectedDate, "MM/dd/yyyy") + "') " _
            & " GROUP BY b.foID,b.drID,c.drFirstName,c.drLastName,c.drMiddleName,C.drDifficulty; "
        Qry += "Select dicID,drID,foID,dicDate,dicActualName,dicAccountName,dicLength From boDictation where (dicEnable = 1 AND dicDate= '" + Format(Me.CPMain.SelectedDate, "MM/dd/yyyy") + "') order by dicDate Desc, dicActualName"

        ds = Con.getDataSet(Qry)
        ds.Tables(0).TableName = "WorkLoadDaily"
        ds.Tables(1).TableName = "Dic"
        Dim FirstColumns() As DataColumn = {ds.Tables(0).Columns("foId"), ds.Tables(0).Columns("drId")}
        Dim SecondColumns() As DataColumn = {ds.Tables(1).Columns("foId"), ds.Tables(1).Columns("drId")}
        ds.Relations.Add("PK", FirstColumns, SecondColumns, False)
        Me.dgDailyWorkLoad.DataSource = ds
        If ds.Tables(0).Rows.Count > 0 Then
            dgDailyWorkLoad.Visible = True
            Me.dgDailyWorkLoad.DataMember = "WorkLoadDaily"
            getNODDaily(ds.Tables(0))
            getNOMDaily(ds.Tables(0))
            getNOODaily(ds.Tables(0))
            Me.dgDailyWorkLoad.DataBind()
        Else
            dgDailyWorkLoad.Visible = False
        End If
        'Catch ex As Exception

        'End Try
    End Sub

    Protected Sub dgDailyWorkLoad_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDailyWorkLoad.ItemDataBound
        If e.Item.Cells(1).Text <> "" And e.Item.Cells(1).Text <> "#" And e.Item.Cells(1).Text <> "&nbsp;" Then
        End If
        If e.Item.ItemIndex Mod 2 = 0 Then
            e.Item.BackColor = System.Drawing.Color.FromName("#ffffff")
        End If

    End Sub

    Protected Sub dgDailyWorkLoad_TemplateDataModeSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateDataModeSelectionEventArgs) Handles dgDailyWorkLoad.TemplateDataModeSelection
        e.TemplateDataMode = DBauer.Web.UI.WebControls.TemplateDataModes.Table
    End Sub

    Protected Sub dgDailyWorkLoad_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles dgDailyWorkLoad.TemplateSelection
        e.TemplateFilename = "dailydictationdetail.ascx"
    End Sub

    Protected Sub getNOODaily(ByVal dt As DataTable)
        For Each item1 As DataRow In dt.Rows
            intNOODaily += CType(item1("Outstanding"), Integer)
        Next
    End Sub
    Protected Sub getPNOODaily(ByVal dt As DataTable)
        For Each item1 As DataRow In dt.Rows
            intPNOODaily += CType(item1("Outstanding"), Integer)
        Next
    End Sub

    Protected Sub getPNODDaily(ByVal dt As DataTable)
        For Each item1 As DataRow In dt.Rows
            intPNODDaily += CType(item1("TotalDictation"), Integer)
        Next
    End Sub
    Protected Sub getPNOMDaily(ByVal dt As DataTable)
        For Each item1 As DataRow In dt.Rows
            intPNOMDaily += CType(item1("TotalMinutes"), Integer)
        Next
    End Sub
    Protected Sub getNODDaily(ByVal dt As DataTable)
        For Each item1 As DataRow In dt.Rows
            intNODDaily += CType(item1("TotalDictation"), Integer)
        Next
    End Sub
    Protected Sub getNOMDaily(ByVal dt As DataTable)
        For Each item1 As DataRow In dt.Rows
            intNOMDaily += CType(item1("TotalMinutes"), Integer)

        Next
    End Sub

    Private Sub loadPendingWorkload()
        Dim Qry As String
        Dim Con As New DBTaskBO
        Dim ds As DataSet

        'Qry = "SELECT boDictation.drID,boDictator.drFirstName,COUNT(dbo.boDictation.dicActualName) AS TotalDictation, SUM(boDictation.dicLength) AS TotalMinutes FROM boDictation INNER JOIN boDictator ON boDictation.drID = boDictator.drID AND boDictation.foID = boDictator.foID WHERE (boDictation.dicEnable = 1) AND (boDictation.dicDate < '" & Me.CPMain.SelectedDate & "') GROUP BY dbo.boDictation.drID,boDictator.drFirstName;"
        Qry = "SELECT b.foId,b.drId, b.foID+ '-' + b.drID As drID,c.drFirstName,COUNT(b.dicActualName) AS TotalDictation,ISNULL(C.drDifficulty,'') as drDifficulty,SUM(b.dicLength) AS TotalMinutes,(Select Count(dicActualName) From boDictation where dicStatus<4 and dicDate<'" & Format(Me.CPMain.SelectedDate, "MM/dd/yyyy") & "' and drID=b.drID ) As Outstanding,c.drLastname,c.drMiddleName, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate= '" + Format(Me.CPMain.SelectedDate, "MM/dd/yyyy") + "' and drID=b.drID and tDL.rolID= 'MT'), 0) As MTdoneMins, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate= '" + Format(Me.CPMain.SelectedDate, "MM/dd/yyyy") + "' and drID=b.drID and tDL.rolID= 'QC'), 0) As QCdoneMins, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate= '" + Format(Me.CPMain.SelectedDate, "MM/dd/yyyy") + "' and drID=b.drID and tDL.rolID= 'PR'), 0) As PRdoneMins, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate= '" + Format(Me.CPMain.SelectedDate, "MM/dd/yyyy") + "' and drID=b.drID and tDL.rolID= 'FR'), 0) As FRdoneMins " _
            & " FROM boDictation B INNER JOIN boDictator C ON b.drID = c.drID AND b.foID = c.foID WHERE (b.dicEnable = 1) AND b.dicStatus < 4 AND (b.dicDate < '" & Format(Me.CPMain.SelectedDate, "MM/dd/yyyy") & "') GROUP BY b.foID,b.drID,c.drFirstName,c.drLastName,c.drMiddleName,C.drDifficulty;"
        Qry += "Select dicID,drID,foID,dicDate,dicActualName,dicAccountName,dicLength From boDictation where (dicEnable = 1 AND dicStatus < 4 AND dicDate<'" + Format(Me.CPMain.SelectedDate, "MM/dd/yyyy") + "') order by dicDate Desc, dicActualName"
        ds = Con.getDataSet(Qry)
        ds.Tables(0).TableName = "WorkLoadPending"
        ds.Tables(1).TableName = "Dic"
        Dim FirstColumns() As DataColumn = {ds.Tables(0).Columns("foId"), ds.Tables(0).Columns("drId")}
        Dim SecondColumns() As DataColumn = {ds.Tables(1).Columns("foId"), ds.Tables(1).Columns("drId")}
        ds.Relations.Add("PK", FirstColumns, SecondColumns, False)

        Me.dgDailyWorkloadPending.DataSource = ds
        If ds.Tables(0).Rows.Count > 0 Then
            dgDailyWorkloadPending.Visible = True
            Label2.Visible = True
            Me.dgDailyWorkloadPending.DataMember = "WorkLoadPending"
            getPNODDaily(ds.Tables(0))
            getPNOMDaily(ds.Tables(0))
            getPNOODaily(ds.Tables(0))
            Me.dgDailyWorkloadPending.DataBind()
        Else
            dgDailyWorkloadPending.Visible = False
            Label2.Visible = False
        End If
    End Sub

    Protected Sub dgDailyWorkloadPending_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDailyWorkloadPending.ItemDataBound
        If e.Item.Cells(1).Text <> "" And e.Item.Cells(1).Text <> "#" And e.Item.Cells(1).Text <> "&nbsp;" Then

            e.Item.Cells(1).Text = ""
        End If

        If e.Item.ItemIndex Mod 2 = 0 Then
            e.Item.BackColor = System.Drawing.Color.FromName("#ffffff")

        End If

    End Sub
    Private Function GetFOID(ByVal strName As String) As String
        Dim Con As New DBTaskBO
        Dim Qry As String = "Select foID From boFO where foName='" + strName + "'"
        Dim ds As DataSet
        Dim strID As String = Nothing
        ds = Con.getDataSet(Qry)
        If ds.Tables(0).Rows.Count > 0 Then
            strID = ds.Tables(0).Rows(0).Item(0).ToString
            Return strID
        End If
        Return strID
    End Function
    Protected Function getCounterDaily() As String
        Dim intCountDaily As Integer = Session("cintDaily")
        intCountDaily += 1
        Session("cintDaily") = intCountDaily
        Return intCountDaily.ToString
    End Function
    Protected Function getCounterPending() As String
        Dim intCountPending As Integer = Session("cintPending")
        intCountPending += 1
        Session("cintPending") = intCountPending
        Return intCountPending.ToString
    End Function

    Protected Sub dgDailyWorkloadPending_TemplateDataModeSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateDataModeSelectionEventArgs) Handles dgDailyWorkloadPending.TemplateDataModeSelection
        e.TemplateDataMode = DBauer.Web.UI.WebControls.TemplateDataModes.Table
    End Sub
    Protected Sub dgDailyWorkloadPending_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles dgDailyWorkloadPending.TemplateSelection
        e.TemplateFilename = "dailydictationdetail.ascx"
    End Sub
End Class
