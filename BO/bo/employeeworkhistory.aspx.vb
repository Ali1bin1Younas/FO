Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class BO_employeeworkhistory
    Inherits System.Web.UI.Page
    Dim str As String = "page"
    Dim eempID As String
    Dim Query As String
    Protected intTMinutes, RowCounter, iCount As Integer
    Protected intTDictations As Integer
    Protected intTTranscriptions As Integer
    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        iCount = 0
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        If Not Me.IsPostBack Then
            Me.cpFrom.SelectedDate = Now.Date
            Me.cpFrom.VisibleDate = Now.Date

            Me.cpTo.SelectedDate = Now.Date
            Me.cpTo.VisibleDate = Now.Date
            load_dropdownlist_Emp()
            loadRole()
        End If
    End Sub

    Protected Sub load_dropdownlist_Emp()
        Query = "SELECT empID, empID + '-' + empFirstName + ' ' +  empLastName AS EmployeeName FROM boEmployee " _
                & "WHERE empId <> '0' and empEnable = 1"
        Dim con As New DBTaskBO
        Dim ds As New DataSet
        ds = con.getDataSet(Query)
        Me.ddlEmployee.DataSource = ds
        Me.ddlEmployee.DataBind()
        ds.Dispose()
    End Sub

    Protected Sub loadRole()
        Query = "SELECT rolDescription , rolID from boRoles " _
                & "where rolID <> 'AD' AND rolEnable = 1 " _
                & "GROUP By rolDescription ,rolID, rolOrder " _
                & "Order by rolOrder"
        Dim con As New DBTaskBO
        Dim ds As New DataSet
        ds = con.getDataSet(Query)
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

    Protected Function getmin(ByVal second As String) As String
        Return GF.GetMin(second)
    End Function

    Protected Sub getTotals(ByVal dt As DataTable)
        For Each item1 As DataRow In dt.Rows
            intTMinutes += CType(item1(3), Integer)
            intTDictations += CType(item1(2), Integer)
            intTTranscriptions += CType(item1(4), Integer)
            RowCounter += 1
        Next
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim con As New DBTaskBO
        If Me.ddlInfo.SelectedValue = "DD" Then
            Query = "SELECT convert(char(12),dic.dicDate,3) as dicDate,count(distinct(foID+drID)) AS Dictators," _
                    & "COUNT(dic.dicID) AS Dictations, SUM(dic.dicLength) AS Minutes," _
                    & "SUM(dic.dicTranscriptions) AS Transcriptions " _
                    & "FROM boDictation dic INNER JOIN " _
                    & "boDictationLayers dicL ON dic.dicID = dicL.dicID " _
                    & "WHERE (dicL.empID = '" & Me.ddlEmployee.SelectedValue & "') AND (dicL.rolID = '" & Me.ddlEmployeeRole.SelectedValue & "') AND (dicL.diclStatus = 3) AND " _
                    & "(dic.dicDate BETWEEN '" & Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") & "')" _
                    & "GROUP BY dic.dicDate " _
                    & "ORDER BY dic.dicDate"
        ElseIf Me.ddlInfo.SelectedValue = "TD" Then
            Query = "SELECT  Convert(char(12),dicL.diclEnd,3) as dicDate,count(distinct(foID+drID)) AS Dictators," _
                     & "COUNT(dic.dicID) AS Dictations, SUM(dic.dicLength) AS Minutes," _
                     & "SUM(dic.dicTranscriptions) AS Transcriptions " _
                     & "FROM boDictation dic INNER JOIN " _
                     & "boDictationLayers dicL ON dic.dicID = dicL.dicID " _
                     & "WHERE (dicL.empID = '" & Me.ddlEmployee.SelectedValue & "') AND (dicL.rolID = '" & Me.ddlEmployeeRole.SelectedValue & "') AND (dicL.diclStatus = 3) AND " _
                     & "(dicL.diclEnd BETWEEN '" & Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") & "') " _
                     & "GROUP BY dicL.diclEnd " _
                     & "ORDER BY dicL.diclEnd"
        End If

        Dim ds As New DataSet
        ds = con.getDataSet(Query)
        If ds.Tables(0).Rows.Count <> 0 Then
            getTotals(ds.Tables(0))
        End If
        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()

        ds.Dispose()
        con.objConnection.Close()
        con = Nothing
    End Sub

    Protected Sub GridRowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowIndex >= 0 Then iCount += 1
    End Sub
    
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowIndex = RowCounter - 1 Then
            Me.lblHeading.Text = "Average"
            Me.LblData.Text = GF.getEverage(intTMinutes, RowCounter)
        End If
    End Sub
End Class
