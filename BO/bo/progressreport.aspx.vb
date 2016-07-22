Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Imports System.Collections.Generic

Partial Class dailyprogress
    Inherits System.Web.UI.Page
    Dim DicId, dicStatus As String


    Protected intTDictations As Integer
    Protected intTMinutes As Integer
    Protected intTOutstandingDictations As Integer
    Protected intTOutstandingMinutes, intTDoneDictation, IntTDoneMinutes As Integer

    Protected intTBDictations As Integer
    Protected intTBMinutes As Integer
    Protected intTBOutstandingDictations As Integer
    Protected intTBOutstandingMinutes As Integer

    Protected DoneDictation, OutDictation, doneMinutes, outMinutes As String
    Protected List As New List(Of String)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empID") = "" Then Response.Redirect(GF.Home)
        ViewState("ccint1") = 0
        ViewState("ccint") = 0
        If Not Page.IsPostBack Then
            Me.lblBacklog.Visible = False

            Me.cpFrom.SelectedDate = Now.Date.Date
            Me.cpFrom.VisibleDate = Now.Date.Date
            Me.cpTo.SelectedDate = Now.Date.Date
            Me.cpTo.VisibleDate = Now.Date.Date

            Me.LoadAccounts()
        End If
    End Sub

    Protected Sub LoadAccounts()
        Dim Qry As String
        Dim Con As New DBTaskBO
        Dim ds As DataSet
        Qry = "SELECT distinct(dicAccountName) FROM boDictation WHERE dicEnable=1 ORDER BY dicAccountName"
        ds = Con.getDataSet(Qry)
        Dim dt As DataTable
        dt = ds.Tables(0)
        Dim dr As DataRow = dt.NewRow

        dr("dicAccountName") = "All"
        dt.Rows.InsertAt(dr, 0)
        Me.ddlAccount.DataSource = dt
        Me.ddlAccount.DataBind()
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

    Private Sub loadDailyProgress()
        Dim AccountSearch As String
        If ddlAccount.SelectedValue = "All" Then
            AccountSearch = " "
        Else
            AccountSearch = "dicAccountName = '" & ddlAccount.SelectedItem.Text & "' AND "
        End If
        Dim Qry As String
        Dim Con As New DBTaskBO
        Dim ds As DataSet
        Qry = "SELECT tD.dicAccountName, tD.foID, COUNT(DISTINCT tD.drID) AS Dictators " _
            & " ,(SELECT Count(dicID) FROM boDictation dIn WHERE dIn.dicEnable= 1 AND dIn.dicStatus < 2 AND dIn.foID = tD.foID AND dIn.dicAccountName = tD.dicAccountName " _
            & " AND dIn.dicDate BETWEEN '" & Format(cpFrom.SelectedDate, "MM/dd/yyy") & "' AND '" & Format(cpTo.SelectedDate, "MM/dd/yyy") & "') as OutStanding " _
            & " ,IsNull((SELECT Sum(IsNull(dicLength,0)) FROM boDictation dIn WHERE dIn.dicEnable= 1 AND dIn.dicStatus < 2 AND dIn.foID = tD.foID AND dIn.dicAccountName = tD.dicAccountName" _
            & " AND dIn.dicDate BETWEEN '" & Format(cpFrom.SelectedDate, "MM/dd/yyy") & "' AND '" & Format(cpTo.SelectedDate, "MM/dd/yyy") & "'),0) as OutStandingMinute " _
            & " ,Count(dicId) as TotalDictations,Sum(tD.dicLength) as TotalMinutes " _
            & " FROM boDictation AS tD " _
            & " INNER JOIN boDictator C ON tD.drID = c.drID AND tD.foID = c.foID " _
            & " WHERE " & AccountSearch & " tD.dicEnable=1 " _
            & " AND (tD.dicDate BETWEEN '" & Format(cpFrom.SelectedDate, "MM/dd/yyy") & "' AND '" & Format(cpTo.SelectedDate, "MM/dd/yyy") & "') " & dicStatus & " " _
            & " GROUP BY tD.dicAccountName, tD.foID " _
            & " ORDER BY tD.dicAccountName;"

        Qry += "SELECT b.dicAccountName, b.foID, b.drID, c.drFirstName, COUNT(b.dicActualName) AS TotalDictation, " _
              & "SUM(b.dicLength) AS TotalMinutes, " _
              & OutDictation & " As OutstandingDictations, " _
              & DoneDictation & " As DoneDictations, " _
              & doneMinutes & " As DoneMinutes, " _
              & outMinutes & " As OutstandingMinutes, c.drLastname, c.drMiddleName " _
              & " FROM boDictation b " _
              & " INNER JOIN boDictator C ON b.drID = c.drID AND b.foID = c.foID " _
              & " WHERE " & AccountSearch & " (b.dicEnable = 1) " _
              & " AND (b.dicDate BETWEEN '" & Format(cpFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(cpTo.SelectedDate, "MM/dd/yyyy") & "' ) " & dicStatus & " " _
              & " GROUP BY b.dicAccountName, b.foID, b.drID,c.drFirstName,c.drLastName,c.drMiddleName " _
              & " ORDER BY b.foID, b.drID;"

        Qry += "Select dicID, drID, dicAccountName, dicDate, dicActualName, dicUrgent, dicLength, dicStatus From boDictation b " _
               & "where (dicEnable=1 AND dicDate BETWEEN '" & Format(cpFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(cpTo.SelectedDate, "MM/dd/yyyy") & "' ) " & dicStatus & "  " _
               & "order by drID, dicDate Desc, dicActualName"

        ds = Con.getDataSet(Qry)
        ds.Tables(0).TableName = "Accounts"
        ds.Tables(1).TableName = "Dictators"
        ds.Tables(2).TableName = "Dics"

        Dim objFirstDataColumn() As DataColumn = {ds.Tables(0).Columns(0), ds.Tables(0).Columns(1)}
        Dim objSecondDataColumn() As DataColumn = {ds.Tables(1).Columns(0), ds.Tables(1).Columns(1)}
        ds.Relations.Add("PK", objFirstDataColumn, objSecondDataColumn, False)

        Dim objFirstColumn() As DataColumn = {ds.Tables(1).Columns("drID"), ds.Tables(1).Columns("dicAccountName")}
        Dim objSecondColumn() As DataColumn = {ds.Tables(2).Columns("drID"), ds.Tables(2).Columns("dicAccountName")}
        ds.Relations.Add("PK1", objFirstColumn, objSecondColumn, False)



        Me.dgDailyWorkLoad.DataSource = ds

        If ds.Tables(0).Rows.Count <> 0 Then
            dgDailyWorkLoad.Visible = True
            Label1.Visible = True
            Me.dgDailyWorkLoad.DataMember = "Accounts"
            getTotals(ds.Tables(0), "C")

            Me.dgDailyWorkLoad.DataBind()
        Else
            dgDailyWorkLoad.Visible = False
        End If

        ds.Dispose()
        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Private Sub loadProgressBacklog()
        Dim Qry As String
        Dim Con As New DBTaskBO
        Dim ds As DataSet

        Qry = "SELECT b.drID, b.foID, c.drFirstName,COUNT(b.dicActualName) AS TotalDictation, " _
              & "SUM(b.dicLength) AS TotalMinutes, " _
              & OutDictation & " as OutstandingDictations, " _
              & outMinutes & " as OutstandingMinutes ,c.drLastname, c.drMiddleName " _
              & "FROM boDictation B INNER JOIN boDictator C ON b.drID = c.drID " _
              & "AND b.foID = c.foID WHERE b.dicStatus < 4 AND b.dicEnable = 1 " _
              & "AND (b.dicDate < '" & Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") & "')" & dicStatus & "" _
              & "GROUP BY b.foID, b.drID,c.drFirstName,c.drLastName,c.drMiddleName " _
              & "ORDER BY b.foID, b.drID;"
        Qry += "Select * From boDictation b where dicStatus < 4 AND dicEnable = 1 " _
               & "AND dicDate < '" + Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") + "'" & dicStatus & " " _
               & "ORDER BY dicDate Desc, dicActualName"

        ds = Con.getDataSet(Qry)
        ds.Tables(0).TableName = "WorkLoadPending"
        ds.Tables(1).TableName = "Dic"

        Dim objFirstDataColumn() As DataColumn = {ds.Tables(0).Columns(0), ds.Tables(0).Columns(1)}
        Dim objSecondDataColumn() As DataColumn = {ds.Tables(1).Columns(1), ds.Tables(1).Columns(2)}
        ds.Relations.Add("PK1", objFirstDataColumn, objSecondDataColumn, False)

        Me.dgDailyWorkloadPending.DataSource = ds
        If ds.Tables(0).Rows.Count <> 0 Then
            dgDailyWorkloadPending.Visible = True
            Me.dgDailyWorkloadPending.DataMember = "WorkLoadPending"

            getTotals(ds.Tables(0), "B")

            Me.dgDailyWorkloadPending.DataBind()
            Me.lblBacklog.Visible = True
        Else
            dgDailyWorkloadPending.Visible = False
            Label1.Visible = False
            Me.lblBacklog.Visible = False
        End If

        ds.Dispose()
        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Protected Function getmin(ByVal second As String) As String
        Return GF.GetMin(second)
    End Function

    Protected Sub dgDailyWorkLoad_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles dgDailyWorkLoad.TemplateSelection
        e.TemplateFilename = "dailydictatorprogressdetail.ascx"
    End Sub

    'Protected Sub dgDailyWorkloadPending_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles dgDailyWorkloadPending.TemplateSelection
    '    e.TemplateFilename = "dailydictatorprogressdetail.ascx"
    'End Sub

    Protected Sub getTotals(ByVal dt As DataTable, ByVal vsType As String)
        intTDictations = 0
        intTMinutes = 0
        intTOutstandingDictations = 0
        intTOutstandingMinutes = 0

        intTBDictations = 0
        intTBMinutes = 0
        intTBOutstandingDictations = 0
        intTBOutstandingMinutes = 0

        For Each itemRow As DataRow In dt.Rows
            If vsType = "C" Then
                intTDictations += CType(itemRow("totalDictations"), Integer)
                intTMinutes += CType(itemRow("TotalMinutes"), Integer)
                intTOutstandingDictations += CType(itemRow("Outstanding"), Integer)
                intTOutstandingMinutes += CType(itemRow("OutstandingMinute"), Integer)
                'intTDoneDictation += CType(itemRow("DoneDictations"), Integer)
                'IntTDoneMinutes += CType(itemRow("DoneMinutes"), Integer)
            Else
                'intTBDictations += CType(itemRow("TotalDictation"), Integer)
                'intTBMinutes += CType(itemRow("TotalMinutes"), Integer)
                'intTBOutstandingDictations += CType(itemRow("OutstandingDictations"), Integer)
                'intTBOutstandingMinutes += CType(itemRow("OutstandingMinutes"), Integer)
            End If
        Next
    End Sub

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

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click

        If Me.ddlStatus.SelectedValue = "0" Then
            dicStatus = " AND dicStatus = 0"
        ElseIf Me.ddlStatus.SelectedValue = "1" Then
            dicStatus = " AND dicStatus = 1"
        ElseIf Me.ddlStatus.SelectedValue = "2" Then
            dicStatus = " AND dicStatus = 2"
        ElseIf Me.ddlStatus.SelectedValue = "3" Then
            dicStatus = " AND dicStatus = 3"
        ElseIf Me.ddlStatus.SelectedValue = "4" Then
            dicStatus = " AND dicStatus = 4"
        ElseIf Me.ddlStatus.SelectedValue = "5" Then
            dicStatus = " AND dicStatus < 2 "
        ElseIf Me.ddlStatus.SelectedValue = "6" Then
            Me.dgDailyWorkLoad.Visible = False
            Me.dgDailyWorkloadPending.Visible = False
            Exit Sub
        Else
            dicStatus = " AND dicStatus >=0"
        End If
        Try
            Dim objGF As New GF
            objGF.DateTo = Format(Me.cpTo.SelectedDate, "MM/dd/yyyy")
            objGF.DateFrom = Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy")

            List = objGF.Get_Query_Data(Me.ddlStatus.SelectedValue.ToString)
            DoneDictation = List(0)
            OutDictation = List(1)
            doneMinutes = List(2)
            outMinutes = List(3)
            List.TrimExcess()
        Catch ex As Exception

        End Try
        
        
        If Me.chkBaklog.Checked Then
            Me.loadProgressBacklog()
        Else
            Me.lblBacklog.Visible = False
            Me.dgDailyWorkloadPending.Visible = False
        End If
        Me.loadDailyProgress()
    End Sub
    
    
End Class
