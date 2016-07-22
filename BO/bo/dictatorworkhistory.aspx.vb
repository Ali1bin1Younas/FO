Imports System.Data.SqlClient
Imports System.Data
Imports MTBMS
Imports MTBMS.DAL
Imports MTBMS.BLL

Partial Class BO_dictatorworkhistory
    Inherits System.Web.UI.Page
    Dim Con As New DBTaskBO
    Dim ds As New DataSet
    Dim Query As String
    Protected IntDictator, IntDictation, IntMinutes, rowCount As Integer
    Protected LHeading, LData As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        ViewState("ccint") = 0
        If Not Me.IsPostBack Then
            Me.cpFrom.SelectedDate = Now.Date
            Me.cpFrom.VisibleDate = Now.Date

            Me.cpTo.SelectedDate = Now.Date
            Me.cpTo.VisibleDate = Now.Date

            Me.LoadDictator()
        End If
    End Sub

    Private Sub LoadDictator()
        Query = "select foId+drId as UId , foId+'-'+drId+ '  '+drLastName + ', ' + drFirstName as Name from boDictator where drEnable=1 order by foId+drId"
        ds = Con.getDataSet(Query)
        Me.ddlDictator.DataSource = ds
        Me.ddlDictator.DataBind()
    End Sub

    Private Sub FillGrid()
        Query = "SELECT foId,drId, dicDate, Count(foid+drid)as Dictators, " _
                & "COUNT(distinct(dicActualName)) AS TotalDictation, " _
                & "SUM(dicLength) AS TotalMinutes " _
                & "FROM  boDictation " _
                & "WHERE (dicEnable = 1) AND (dicDate BETWEEN '" & Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") & "')  " _
                & "AND foId+drId='" & Me.ddlDictator.SelectedValue & "' " _
                & "GROUP BY foId,drId,dicDate; " _
                & "Select * From boDictation where (dicEnable=1 AND dicDate BETWEEN '" & Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") & "') " _
                & "AND foId+drId='" & Me.ddlDictator.SelectedValue & "' " _
                & "order by dicDate Desc"

        ds = Con.getDataSet(Query)

        ds.Tables(0).TableName = "First"
        ds.Tables(1).TableName = "Dic"

        Dim FirstR() As DataColumn = {ds.Tables(0).Columns("foId"), ds.Tables(0).Columns("drId"), ds.Tables(0).Columns("dicDate")}
        Dim SecondR() As DataColumn = {ds.Tables(1).Columns("foId"), ds.Tables(1).Columns("drId"), ds.Tables(1).Columns("dicDate")}

        ds.Relations.Add("PK", FirstR, SecondR, False)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.GrandTotal(ds.Tables(0))
            gdDictatorWorkHistory.DataSource = ds
            Me.lblHeading.Text = "Daily Average"

        Else
            gdDictatorWorkHistory.DataSource = Nothing
            Me.lblHeading.Text = ""
            Me.LblData.Text = ""

        End If
        gdDictatorWorkHistory.DataBind()
    End Sub

    Protected Sub gdDictatorWorkHistory_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gdDictatorWorkHistory.ItemDataBound
        If e.Item.ItemIndex = rowCount - 1 Then
            Me.getval(rowCount)
        End If
    End Sub

    Protected Sub TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles gdDictatorWorkHistory.TemplateSelection
        e.TemplateFilename = "dictatorworkloaddetail.ascx"
    End Sub

    Private Sub GrandTotal(ByVal dt As DataTable)
        For Each dr As DataRow In dt.Rows
            IntDictator += CType(dr("Dictators"), Integer)
            IntMinutes += CType(dr("TotalMinutes"), Integer)
            IntDictation += CType(dr("TotalDictation"), Integer)
            rowCount += 1
        Next
    End Sub

    Protected Function getCounter() As String
        Dim intCount As Integer = ViewState("ccint")
        intCount += 1
        ViewState("ccint") = intCount
        Return intCount.ToString
    End Function

    Protected Function getMin(ByVal second As String) As String
        Return GF.GetMin(second)
    End Function

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        Me.FillGrid()
    End Sub

    Public Sub getval(ByVal Counter As String)
        Dim min As Integer = IntMinutes
        min = min / Counter
        'min = GF.GetMin(min)
        Me.LblData.Text = GF.GetMin(min)
    End Sub
End Class
