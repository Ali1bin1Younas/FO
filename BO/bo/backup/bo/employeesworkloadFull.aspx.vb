Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL
Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Class BO_employeeworkloadFull
    Inherits System.Web.UI.Page
    Protected iCounter As Int16
    Protected Query, eempID As String
    Protected intPNOMDaily As Integer
    Protected intTDictationD As Integer
    Protected done As Integer
    Protected doneM As Integer
    Protected avail As Integer
    Protected availM As Integer
    Protected out As Integer
    Protected outM As Integer

    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        iCounter = 0
        If Not Me.IsPostBack Then
            'loadRole(eempID)
            Me.CPDate.SelectedDate = Now.Date
            Me.CPDate.VisibleDate = Now.Date
            Me.CPTo.SelectedDate = Now.Date
            Me.CPTo.VisibleDate = Now.Date
        Else
            Session("CPDateFrom") = String.Format(Me.CPDate.SelectedDate, "MM/dd/yyyy")
            Session("CPDateTo") = String.Format(Me.CPTo.SelectedDate, "MM/dd/yyyy")
            If ddlDateType.SelectedValue <> 1 Then
                Session("ddlDataType") = "Dictation Date"
            Else
                Session("ddlDateType") = "Workload Date"
            End If
        End If
    End Sub

    'Protected Sub loadRole(ByVal empId As String)
    '    Query = "select r.rolDescription, r.rolID " _
    '             & "from  boRoles r " _
    '             & "where rolEnable='1' and r.rolID !='AD' " _
    '             & "order by r.rolOrder"
    '    Dim con As New DBTaskBO
    '    Dim ds As New DataSet
    '    ds = con.getDataSet(Query)
    '    Dim dt As DataTable
    '    dt = ds.Tables(0)
    '    Dim i As Integer = 0
    '    For Each item1 As DataRow In dt.Rows
    '        dt.Rows(i).Item(0) = item1.Item("rolID") & "-" & item1.Item("rolDescription")
    '        i = i + 1
    '    Next
    '    Me.ddlEmp.DataSource = dt
    '    Me.ddlEmp.DataBind()
    '    ds.Dispose()
    '    dt.Dispose()
    '    con.objConnection.Close()
    '    con = Nothing
    '    ds = Nothing
    '    dt = Nothing
    'End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim QueryClause As String = ""
        Dim QueryClause2 As String = ""
        If ddlDateType.SelectedIndex = 0 Then
            QueryClause = " doneDic.dicDate "
            QueryClause2 = " dic.dicDate "
        Else
            QueryClause = " doneDicL.diclWorkloadDate "
            QueryClause2 = " dicL.diclWorkloadDate "
        End If
        Query = " SELECT case(dicL.empID) when '0' then '-' else dicl.empID end AS empID," _
              & " case(empFirstName) when 'Skip' then '-' else empFirstName end as empFirstName," _
              & " case(empLastName) when 'Skip' then '-' else empLastName end as empLastName," _
              & " COUNT(DISTINCT dic.foID + dic.drID) AS Dictators, COUNT(dic.dicID) AS Dictations, " _
              & " SUM(dic.dicLength)AS Minutes," _
              & " IsNull(COUNT(case(dicL.diclStatus) when 3 then 1 else null end), 0) as doneDictations, " _
              & " IsNull(Sum(case(dicL.diclStatus) when 3 then dic.dicLength else null end), 0) as doneMinutes, " _
              & " IsNull(COUNT(case(dicL.diclStatus) when 1 then 1 when 2 then 1 else null end), 0) as availDictations, " _
              & " IsNull(Sum(case(dicL.diclStatus) when 1 then dic.dicLength when 2 then dic.dicLength else null end), 0) as availMinutes, " _
              & " IsNull(COUNT(case(dicL.diclStatus) when 1 then 1 when 2 then 1 when 0 then 1 else null end ), 0) as outDictations, " _
              & " IsNull(Sum(case(dicL.diclStatus) when 1 then dic.dicLength when 2 then dic.dicLength when 0 then dic.dicLength else null end), 0) as outMinutes, " _
              & " IsNull((select Sum(CONVERT(int,er.empRolCapacity)) from boEmployeeRoles er where empID = dicL.empID), 0) as rolCapacity " _
              & " FROM dbo.boDictation dic " _
              & " INNER JOIN boDictationLayers dicL ON dic.dicID = dicL.dicID INNER JOIN boEmployee Emp ON dicL.empID = Emp.empID " _
              & " WHERE (" & QueryClause2 & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') GROUP BY dicL.empID, Emp.empFirstName, Emp.empLastName " _
              & " ORDER BY empFirstName, empLastName;"
        Query &= " SELECT dicL.empID, dicL.rolID, " _
              & " case(empFirstName) when 'Skip' then '-' else empFirstName end as empFirstName, " _
              & " case(empLastName) when 'Skip' then '-' else empLastName end as empLastName, " _
              & " COUNT(DISTINCT dic.foID + dic.drID) AS Dictators, COUNT(dic.dicID) AS Dictations, SUM(dic.dicLength)AS Minutes, " _
              & " IsNull(COUNT(case(dicL.diclStatus) when 3 then 1 else null end), 0) as doneDictations, " _
              & " IsNull(Sum(case(dicL.diclStatus) when 3 then dic.dicLength else null end), 0) as doneMinutes, " _
              & " IsNull(COUNT(case(dicL.diclStatus) when 1 then 1 when 2 then 1 else null end), 0) as availDictations, " _
              & " IsNull(Sum(case(dicL.diclStatus) when 1 then dic.dicLength when 2 then dic.dicLength else null end), 0) as availMinutes, " _
              & " IsNull(COUNT(case(dicL.diclStatus) when 1 then 1 when 2 then 1 when 0 then 1 else null end ), 0) as outDictations, " _
              & " IsNull(Sum(case(dicL.diclStatus) when 1 then dic.dicLength when 2 then dic.dicLength when 0 then dic.dicLength else null end), 0) as outMinutes, " _
              & " IsNull((select CONVERT(int,er.empRolCapacity) from boEmployeeRoles er where empID = dicL.empID and rolID = dicL.rolID), 0) as rolCapacity " _
              & " FROM dbo.boDictation dic  " _
              & " INNER JOIN boDictationLayers dicL ON dic.dicID = dicL.dicID " _
              & " INNER JOIN boEmployee Emp ON dicL.empID = Emp.empID " _
              & " INNER JOIN boRoles rol ON dicL.rolID = rol.rolID " _
              & " WHERE (" & QueryClause2 & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
              & " GROUP BY dicL.rolID, dicL.empID, Emp.empFirstName, Emp.empLastName, rol.rolOrder" _
              & " ORDER BY dicL.empID, rol.rolOrder;"
        Query &= " SELECT DicL.empID, DicL.rolID, Dic.drID, Dic.foID, boDictator.drFirstName,boDictator.drSpecialty, " _
              & " boDictator.drLastName, boDictator.drMiddleName, isNull(boDictator.drDifficulty, '') as drDifficulty , " _
              & " IsNull(COUNT(dic.dicID), 0) as DicTations, " _
              & " ISNULL(SUM(dic.dicLength),0) as dicLength, " _
              & " IsNull(COUNT(case(dicL.diclStatus) when 3 then 1 else null end), 0) as doneDictations,  " _
              & " IsNull(Sum(case(dicL.diclStatus) when 3 then dic.dicLength else null end), 0) as DonedicLength, " _
              & " IsNull(COUNT(case(dicL.diclStatus) when 1 then 1 when 2 then 1 else null end), 0) as availDictations, " _
              & " IsNull(Sum(case(dicL.diclStatus) when 1 then dic.dicLength when 2 then dic.dicLength else null end), 0) as availdicLength, " _
              & " COUNT(case(dicL.diclStatus) when 1 then 1 when 2 then 1 when 0 then 1 else null end ) as OutDicTations,  " _
              & " IsNull(Sum(case(dicL.diclStatus) when 1 then dic.dicLength when 2 then dic.dicLength when 0 then dic.dicLength else null end), 0) as OutdicLength " _
              & " FROM boDictation Dic " _
              & " INNER JOIN boDictationLayers DicL ON Dic.dicID = DicL.dicID " _
              & " INNER JOIN boDictator ON Dic.drID = boDictator.drID " _
              & " And Dic.foID = boDictator.foID " _
              & " WHERE (" & QueryClause2 & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "')  " _
              & " group by dicL.empid, DicL.rolID, Dic.foID, Dic.drID,boDictator.drFirstName, " _
              & " boDictator.drLastName, boDictator.drMiddleName,boDictator.drDifficulty,boDictator.drSpecialty "

        Dim con As New DBTaskBO
        Dim ds As New DataSet
        ds = con.getDataSet(Query)
        ds.Tables(0).TableName = "workload"
        ds.Tables(1).TableName = "workloadrolwise"
        ds.Tables(2).TableName = "workloaddictator"
        If ds.Tables(0).Rows.Count > 0 Then
            GetGrandTotal(ds.Tables(0))
        End If
        'Bind the data source with grid
        ds.Relations.Add("PK", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)

        Dim FCRelation() As DataColumn = {ds.Tables(1).Columns(0), ds.Tables(1).Columns(1)}
        Dim SCRelation() As DataColumn = {ds.Tables(2).Columns(0), ds.Tables(2).Columns(1)}
        ds.Relations.Add("PK1", FCRelation, SCRelation, False)

        Me.EmpWorkload.DataSource = ds
        Me.EmpWorkload.DataMember = "workload"
        Me.EmpWorkload.DataBind()
        Me.EmpWorkload.RowExpanded.ExpandAll()
        ds.Dispose()
        ds = Nothing
        con.objConnection.Close()
        con = Nothing
    End Sub

    Protected Sub GetGrandTotal(ByVal dt As DataTable)
        For Each item1 As DataRow In dt.Rows
            intPNOMDaily += CType(item1("Minutes"), Integer)
            intTDictationD += CType(item1("Dictations"), Integer)

            doneM += CType(item1("doneMinutes"), Integer)
            done += CType(item1("doneDictations"), Integer)

            availM += CType(item1("availMinutes"), Integer)
            avail += CType(item1("availDictations"), Integer)

            outM += CType(item1("outMinutes"), Integer)
            out += CType(item1("outDictations"), Integer)
        Next
    End Sub

    Protected Sub EmpWorkload_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles EmpWorkload.ItemCreated
        Try
            If e.Item.ItemType = ListItemType.Header Then
                iCounter = 0
            Else
                iCounter += 1
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub EmpWorkload_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles EmpWorkload.ItemDataBound
    End Sub

    Protected Sub EmpWorkload_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles EmpWorkload.TemplateSelection
        e.TemplateFilename = "employeesworkloadFullDetail.ascx"
    End Sub

    Protected Function getPerDone(ByVal mins As Double, ByVal done As Double) As String
        Try
            Dim donePer As String
            donePer = Math.Round(((done / mins) * 100), 0, MidpointRounding.AwayFromZero)
            If donePer = "100" Then
                Return "<span style='color:green !important;'>" & donePer & "%</span>"
            Else
                Return "<span>" & donePer & "%</span>"
            End If
        Catch ex As Exception
            Return "<span>-%</span>"
        End Try
    End Function

    Protected Function check_availability(ByVal availMins As String, ByVal outMins As String) As String
        Try
            If Not (availMins Is Nothing) AndAlso Not outMins Is Nothing Then
                If Convert.ToInt32(availMins) < 600 AndAlso Convert.ToInt32(outMins) > 600 Then
                    Return "<span style='color:red !important;'>" & GF.GetMin(availMins) & "</span>"
                Else
                    Return "<span style='color:black !important;'>" & GF.GetMin(availMins) & "</span>"
                End If
            End If
        Catch ex As Exception
            Return "<span>" & GF.GetMin(availMins) & "</span>"
        End Try
    End Function
End Class
