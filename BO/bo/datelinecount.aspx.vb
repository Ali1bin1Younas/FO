Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class BO_datelinecount
    Inherits System.Web.UI.Page
    Protected rCount As Int16
    Protected tDictations, tMinutes, tTranscriptions, tLines As Double

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        rCount = 0
        If Not Me.IsPostBack Then
            Me.cpFrom.SelectedDate = Now.Date
            Me.cpFrom.VisibleDate = Now.Date
            Me.cpTo.SelectedDate = Now.Date
            Me.cpTo.VisibleDate = Now.Date
            Dim sql As String = "SELECT foId+drId as drId, foId+drId + '-' + drLastName + ', ' + drFirstName as drName " _
                                & "FROM boDictator Where drEnable = 1"
            Dim obj As New DBTaskBO
            Me.ddlDictator.DataSource = obj.getDataSet(sql)
            Me.ddlDictator.DataTextField = "drName"
            Me.ddlDictator.DataValueField = "drId"
            Me.ddlDictator.DataBind()
            Me.ddlDictator.Items.Insert(0, "ALL")
            Me.ddlDictator.Items(0).Value = "0"
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        Dim obj As New Client
        Dim objDb As New DBTaskBO
        Dim ds As DataSet
        Try
            Convert.ToInt32(Me.txtLine.Text)
            If Me.cpFrom.SelectedDate > Me.cpTo.SelectedDate Then
                Me.lblError.Text = "Invalid date range: Please select the valid date range:"
                Me.lblError.ForeColor = Drawing.Color.Red
                Me.lblError.Visible = True
                Exit Sub
            End If
        Catch ex As Exception
            Me.lblError.Text = ex.Message & " Please enter the Number value"
            Me.lblError.ForeColor = Drawing.Color.Red
            Me.lblError.Visible = True
            Exit Sub
        End Try
        Me.lblError.Visible = False
        ds = objDb.getDataSet(obj.Query(Me.ddlDictator.SelectedValue, Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy"), Format(Me.cpTo.SelectedDate, "MM/dd/yyyy"), Me.txtLine.Text))
        ds.Tables(0).TableName = "First"
        ds.Tables(1).TableName = "Second"
        ds.Tables(2).TableName = "Third"
        Dim _1st() As DataColumn = {ds.Tables(0).Columns("dicDate")}
        Dim _2nd() As DataColumn = {ds.Tables(1).Columns("dicDate")}
        ds.Relations.Add("PK", _1st, _2nd, False)
        Dim _3rd() As DataColumn = {ds.Tables(1).Columns("drId"), ds.Tables(1).Columns("dicDate")}
        Dim _4th() As DataColumn = {ds.Tables(2).Columns("drId"), ds.Tables(2).Columns("dicDate")}
        ds.Relations.Add("PK1", _3rd, _4th, False)
        Me.GridDate.DataSource = ds
        If ds.Tables(0).Rows.Count > 0 Then
            Me.GridDate.Visible = True
            Call Me.GetTotal(ds.Tables(0))
            Me.GridDate.DataMember = "First"
            Me.GridDate.DataBind()
        Else
            Me.GridDate.Visible = False
        End If
       
    End Sub

    Protected Sub GridDate_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles GridDate.ItemCreated
        If e.Item.ItemType = ListItemType.Header Then
            rCount = 0
        Else
            rCount += 1
        End If
    End Sub

    Protected Sub GridDate_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles GridDate.TemplateSelection
        e.TemplateFilename = "datelinecount.ascx"
    End Sub

    Protected Function Line_Per_Minutes(ByVal seconds As String, ByVal lines As String) As String
        Dim obj As New GF
        Return obj.Line_Per_Minutes(seconds, lines)
    End Function

    Protected Function Lines_Per_Transcriptions(ByVal trans As String, ByVal line As String) As String
        Dim obj As New GF
        Return obj.Line_Per_Transcriptions(trans, line)
    End Function

    Protected Sub GetTotal(ByVal dt As DataTable)
        For Each row As DataRow In dt.Rows
            Me.tDictations += System.Convert.ToDouble(row.Item("TotalDic"))
            Me.tTranscriptions += System.Convert.ToDouble(row.Item("TotalTra"))
            Me.tMinutes += System.Convert.ToDouble(row.Item("dicLength"))
            Me.tLines += System.Convert.ToDouble(row.Item("Lines"))
        Next
    End Sub
End Class
