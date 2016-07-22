Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class BO_employeelinecount_check
    Inherits System.Web.UI.Page

    Dim Qry As String
    Dim ds As DataSet
    Dim con As New DBTaskBO
    Protected T_dictations, T_transcription, T_lines, T_minutes

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)

        Session("RowCounter") = 0
        If Not Me.IsPostBack Then
            Me.cpFrom.SelectedDate = Now
            Me.cpFrom.VisibleDate = Now
            Me.cpTo.SelectedDate = Now
            Me.cpTo.VisibleDate = Now
            LoadEmployDDL()
            loadEmpRole()
        End If
    End Sub

    Public Sub LoadEmployDDL()
        Qry = "select empId, empID + '-' + empFirstName + ' ' + empLastName as EmpName " _
                & "from boEmployee  where empEnable=1 and empID <> '0' " _
                & "Order by empId"
        ds = con.getDataSet(Qry)
        ds = con.getDataSet(Qry)
        Dim dt As DataTable
        dt = ds.Tables(0)
        Dim dr As DataRow = dt.NewRow
        dr("empId") = "-1"
        dr("EmpName") = "ALL"
        dt.Rows.InsertAt(dr, 0)
        Me.ddlEmployee.DataSource = dt
        Me.ddlEmployee.DataBind()
        ds.Dispose()
        ds = Nothing
    End Sub

    Protected Sub loadEmpRole()
        Qry = "SELECT rolDescription , rolID from boRoles " _
                & "where rolID <> 'AD' AND rolEnable = 1 " _
                & "GROUP By rolDescription ,rolID, rolOrder " _
                & "Order by rolOrder"
        Dim con As New DBTaskBO
        Dim ds As New DataSet
        ds = con.getDataSet(Qry)
        Dim dt As DataTable
        dt = ds.Tables(0)
        Dim i As Integer

        For Each item1 As DataRow In dt.Rows
            dt.Rows(i).Item(0) = item1.Item(1) & " - " & item1.Item(0)
            i = i + 1
        Next

        Me.ddlEmployeeRole.DataSource = dt
        Me.ddlEmployeeRole.DataBind()

        ds.Dispose()
        con.objConnection.Close()
        con = Nothing
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click


        If Me.txtChar.Text = "" Then Exit Sub
        Dim empId As String
        If Me.ddlEmployee.SelectedValue = "-1" Then
            empId = ""
        Else
            empId = "AND (boEmployee.empId='" & Me.ddlEmployee.SelectedValue & "')"
        End If
        Qry = "SELECT case(boDictationLayers.empID) when '0' then '-' else boDictationLayers.empID end as empID, " _
                & "Case(boEmployee.empFirstName) when 'Skip' then '-' else boEmployee.empFirstName end as empFirst , " _
                & "Case(boEmployee.empLastName) when 'Skip' then '-' else boEmployee.empLastName end as empLast , " _
                & "COUNT(boDictation.dicID) AS Dictations, Sum(boDictation.dicLength) as Minutes, " _
                & "SUM(boDictation.dicTranscriptions) AS Transcriptions, " _
                & "ROUND(SUM(boTranscription.traCharacters) / '" & Me.txtChar.Text & "' , 0) AS Lines " _
                & "FROM boDictation INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
                & "INNER JOIN boTranscription ON boDictation.dicID = boTranscription.dicID " _
                & "INNER JOIN boEmployee ON boDictationLayers.empID = boEmployee.empID " _
                & "WHERE (boDictation.dicStatus >= 2) AND (boDictationLayers.rolID = '" & Me.ddlEmployeeRole.SelectedValue & "')" & empId _
                & "AND (boDictation.dicDate BETWEEN '" & Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") & "') " _
                & "GROUP BY boDictationLayers.empID, boEmployee.empFirstName, boEmployee.empLastName " _
                & "ORDER BY boDictationLayers.empID; " _
                & "SELECT case(boDictationLayers.empID) when '0' then '-' else boDictationLayers.empID end as empID, " _
                & "Convert(char(12),boDictation.dicDate,3) as DicDate, COUNT(boDictation.dicID) AS Dictations,Sum(boDictation.dicLength) as Minutes, " _
                & "SUM(boDictation.dicTranscriptions) AS Transcriptions, ROUND(SUM(boTranscription.traCharacters) / '" & Me.txtChar.Text & "', 0) AS Lines " _
                & "FROM boDictation INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
                & "INNER JOIN boTranscription ON boDictation.dicID = boTranscription.dicID " _
                & "INNER JOIN boEmployee ON boDictationLayers.empID = boEmployee.empID " _
                & "WHERE (boDictation.dicStatus >= 2) AND (boDictationLayers.rolID = '" & Me.ddlEmployeeRole.SelectedValue & "') AND (boDictation.dicDate BETWEEN '" & Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") & "')" & empId _
                & "GROUP BY boDictationLayers.empID, boDictation.dicDate " _
                & "ORDER BY boDictationLayers.empID, boDictation.dicDate; " _
                & "SELECT boDictationLayers.empID,Convert(char(12), " _
                & "boDictation.dicDate,3) as DicDate, boDictation.foID, boDictation.drID, drFirstName, drLastName, " _
                & "COUNT(boDictation.dicID) AS Dictations,Sum(boDictation.dicLength) as Minutes, SUM(boDictation.dicTranscriptions) AS Transcriptions, ROUND(SUM(boTranscription.traCharacters) / '" & Me.txtChar.Text & "', 0) AS Lines " _
                & "FROM boDictation INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
                & "INNER JOIN boTranscription ON boDictation.dicID = boTranscription.dicID " _
                & "INNER JOIN boEmployee ON boDictationLayers.empID = boEmployee.empID " _
                & "INNER JOIN boDictator ON boDictation.drID = boDictator.drID AND boDictation.foID = boDictator.foID " _
                & "WHERE  (boDictation.dicStatus >= 2) AND (boDictationLayers.rolID = '" & Me.ddlEmployeeRole.SelectedValue & "')" & empId _
                & "AND (boDictation.dicDate BETWEEN '" & Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") & "') " _
                & "GROUP BY boDictationLayers.empID, boDictation.dicDate, boDictation.foID, boDictation.drID, drFirstName, drLastName " _
                & "ORDER BY boDictationLayers.empID, boDictation.dicDate, boDictation.foID, boDictation.drID"

        ds = con.getDataSet(Qry)
        ds.Tables(0).TableName = "Employees"
        ds.Tables(1).TableName = "Date"
        ds.Tables(2).TableName = "Dictators"
        ds.Relations.Add("PK", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
        Dim FCRelation() As DataColumn = {ds.Tables(1).Columns("empId"), ds.Tables(1).Columns("DicDate")}
        Dim SCRelation() As DataColumn = {ds.Tables(2).Columns("empId"), ds.Tables(2).Columns("DicDate")}
        ds.Relations.Add("PK1", FCRelation, SCRelation, False)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.gridEmployee.DataSource = ds
            Me.GrandTotal(ds.Tables(0))
            Me.gridEmployee.DataMember = "Employees"
        End If
        Me.gridEmployee.DataBind()
        ds.Dispose()
        ds = Nothing
    End Sub

    'Protected Sub gridEmployee_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gridEmployee.ItemCreated
    '    iCounter += 1
    'End Sub

    Protected Function getCounterDaily() As String
        Dim intCountDaily As Integer = Session("RowCounter")
        intCountDaily += 1
        Session("RowCounter") = intCountDaily
        Return intCountDaily.ToString
    End Function

    Protected Sub gridEmployee_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles gridEmployee.TemplateSelection
        e.TemplateFilename = "employeelinecountdatewise.ascx"
    End Sub

    Protected Sub GrandTotal(ByVal dt As DataTable)
        For Each dr As DataRow In dt.Rows
            T_dictations += CType(dr.Item("Dictations"), Integer)
            T_transcription += CType(dr.Item("Transcriptions"), Integer)
            T_lines += CType(dr.Item("Lines"), Integer)
            T_minutes += CType(dr.Item("Minutes"), Integer)
        Next
    End Sub

    Protected Function getmin(ByVal second As String) As String
        Return GF.GetMin(second)
    End Function

    Protected Function Line_Per_Minutes(ByVal min As String, ByVal line As String) As String
        Dim obj As New GF
        Return obj.Line_Per_Minutes(min, line)
    End Function

    Protected Function Line_Per_Transcriptions(ByVal Trans As String, ByVal line As String) As String
        Dim obj As New GF
        Return obj.Line_Per_Transcriptions(Trans, line)
    End Function
End Class

