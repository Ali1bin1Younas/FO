Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class BO_dictatorlinecount
    Inherits System.Web.UI.Page
    Dim Qry As String
    Dim Con As New DBTaskBO
    Dim Ds As New DataSet
    Protected RowCounter As Int16
    Protected T_dictations, T_transcription, T_minutes as Integer
    Protected T_lines as Double

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        RowCounter = 0
        If Not Me.IsPostBack Then
            Call Me.Load_Dictatior()
            Me.cpFrom.VisibleDate = Now.Date
            Me.cpFrom.SelectedDate = Now.Date
            Me.cpTo.VisibleDate = Now.Date
            Me.cpTo.SelectedDate = Now.Date
        End If
    End Sub

    Protected Sub Load_Dictatior()
        Qry = "Select foId+drId as drId, foId+drId + ' ' + drLastName + ', ' + drFirstName as drName " _
              & "from boDictator where drEnable=1 order by foId+drId"
        Ds = Con.getDataSet(Qry)
        Dim dr As DataRow = Ds.Tables(0).NewRow
        dr("drId") = "-1"
        dr("drName") = "All Dictators"
        Ds.Tables(0).Rows.InsertAt(dr, 0)
        Me.ddlDictator.DataSource = Ds
        Me.ddlDictator.DataBind()
    End Sub


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim drID As String
        If Me.ddlDictator.SelectedValue = "-1" Then
            drID = ""
        Else
            drID = "AND boDictator.foId+boDictator.drId = '" & Me.ddlDictator.SelectedValue & "'"
        End If
        Qry = "SELECT boDictation.foId+boDictation.drId as drID, " _
                & "boDictator.drLastName + ', ' + boDictator.drFirstName as drName, " _
                & "COUNT(boDictation.dicID) AS Dictations, Sum(boDictation.dicLength) as Minutes, " _
                & "SUM(boDictation.dicTranscriptions) AS Transcriptions, " _
                & "SUM(boTranscription.traCharacters) / " & Me.txtChar.Text & " AS Lines " _
                & "FROM boDictation INNER JOIN boTranscription ON boDictation.dicID = boTranscription.dicID " _
                & "Inner join boDictator on boDictator.foId+boDictator.drId = boDictation.foId + boDictation.drId " _
                & "WHERE (boDictation.dicDate " _
                & " BETWEEN '" & Format(Me.cpFrom.SelectedDate.Date, "MM/dd/yyyy") & "' AND '" & Format(Me.cpTo.SelectedDate.Date, "MM/dd/yyyy") & "') " & drID _
                & "GROUP BY boDictation.foId+boDictation.drId ,boDictator.drLastName,boDictator.drFirstName " _
                & "ORDER BY boDictation.foId+boDictation.drId;"

        Qry += "SELECT boDictation.foId+boDictation.drId as drID,Convert(char(12),boDictation.dicDate,3) as DicDate, " _
                & "COUNT(boDictation.dicID) AS Dictations, Sum(boDictation.dicLength) as Minutes, " _
                & "SUM(boDictation.dicTranscriptions) AS Transcriptions, " _
                & "SUM(boTranscription.traCharacters) / " & Me.txtChar.Text & " AS Lines " _
                & "FROM boDictation INNER JOIN boTranscription ON boDictation.dicID = boTranscription.dicID " _
                & "Inner join boDictator on boDictator.foId+boDictator.drId = boDictation.foId + boDictation.drId " _
                & "WHERE  (boDictation.dicDate " _
                & "BETWEEN '" & Format(Me.cpFrom.SelectedDate.Date, "MM/dd/yyyy") & "' AND '" & Format(Me.cpTo.SelectedDate.Date, "MM/dd/yyyy") & "') " & drID _
                & "GROUP BY boDictation.foId+boDictation.drId ,boDictation.dicDate " _
                & "ORDER BY boDictation.foId+boDictation.drID,boDictation.dicDate;"

        Qry += "SELECT boDictation.foId+boDictation.drId as drID,Convert(char(12),boDictation.dicDate,3) as DicDate,boDictation.dicActualName as traName, " _
                & "boTranscription.traCharacters / " & Me.txtChar.Text & " AS Lines,dicTranscriptions as Transcriptions, dicLength  FROM boDictation " _
                & "INNER JOIN boTranscription ON boDictation.dicID = boTranscription.dicID " _
                & "INNER join boDictator on boDictation.foId+boDictation.drId = boDictator.foId+boDictator.drID " _
                & "WHERE  (boDictation.dicDate " _
                & "BETWEEN '" & Format(Me.cpFrom.SelectedDate.Date, "MM/dd/yyyy") & "' AND '" & Format(Me.cpTo.SelectedDate.Date, "MM/dd/yyyy") & "') " & drID _
                & "ORDER BY boDictation.dicActualName,boDictation.foId+boDictation.drID,boDictation.dicDate"

        Ds = Con.getDataSet(Qry)
        Ds.Tables(0).TableName = "Dictators"
        Ds.Tables(1).TableName = "Date"
        Ds.Tables(2).TableName = "Transcriptions"
        Ds.Relations.Add("PK", Ds.Tables(0).Columns(0), Ds.Tables(1).Columns(0), False)
        Dim FCRelation() As DataColumn = {Ds.Tables(1).Columns("drId"), Ds.Tables(1).Columns("DicDate")}
        Dim SCRelation() As DataColumn = {Ds.Tables(2).Columns("drId"), Ds.Tables(2).Columns("DicDate")}
        Ds.Relations.Add("PK1", FCRelation, SCRelation, False)

        If Ds.Tables(0).Rows.Count <> 0 Then
            Me.gridDictator.DataSource = Ds
            Me.GrandTotal(Ds.Tables(0))
            Me.gridDictator.DataMember = "Dictators"
        End If
        Me.gridDictator.DataBind()
    End Sub

    Protected Sub gridDictator_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gridDictator.ItemCreated
        If e.Item.ItemIndex = 0 Then
            RowCounter = 1
        Else
            RowCounter += 1
        End If
    End Sub
    Protected Sub GrandTotal(ByVal dt As DataTable)
        For Each dr As DataRow In dt.Rows
            T_dictations += CType(dr.Item("Dictations"), Integer)
            T_transcription += CType(dr.Item("Transcriptions"), Integer)
            T_lines += CType(dr.Item("Lines"), Double)
            T_minutes += CType(dr.Item("Minutes"), Integer)
        Next
    End Sub

    
    Protected Sub gridDictator_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles gridDictator.TemplateSelection
        e.TemplateFilename = "dictatorlinecountdatewise.ascx"
    End Sub


    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Ds.Dispose()
        Ds = Nothing
        Con = Nothing
    End Sub
    Protected Function Line_Per_Minutes(ByVal min As String, ByVal line As String) As String
        Dim obj As New GF
        Return obj.Line_Per_Minutes(min, line)
    End Function

    Protected Function Line_Per_Transcriptions(ByVal Trans As String, ByVal line As String) As String
        Dim obj As New GF
        Return obj.Line_Per_Transcriptions(Trans, line)
    End Function
    'Protected Function GetMin(ByVal seconds As String) As String
    '    Return GF.GetMin(seconds)
    'End Function
End Class
