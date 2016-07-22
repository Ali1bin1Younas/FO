Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL
Partial Class BO_employeeworkloadFull_old
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
            Me.cpTo.SelectedDate = Now.Date
            Me.cpTo.VisibleDate = Now.Date
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

        Query = " SELECT case(dicL.empID) when '0' then '-' else dicl.empID end AS empID," _
              & " case(empFirstName) when 'Skip' then '-' else empFirstName end as empFirstName," _
              & " case(empLastName) when 'Skip' then '-' else empLastName end as empLastName," _
              & " COUNT(DISTINCT dic.foID + dic.drID) AS Dictators, COUNT(dic.dicID) AS Dictations, " _
              & " SUM(dic.dicLength)AS Minutes," _
              & " IsNull((SELECT COUNT(doneDic.dicID) FROM dbo.boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID WHERE(doneDicL.empID = dicl.empID) " _
              & " AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') AND doneDicl.diclStatus = 3 " _
              & " GROUP BY doneDicL.empID),0) AS doneDictations, " _
              & " IsNull((SELECT SUM(doneDic.dicLength) FROM dbo.boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID WHERE(doneDicL.empID = dicl.empID) AND " _
              & " (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') AND doneDicl.diclStatus = 3 " _
              & " GROUP BY doneDicL.empID),0) AS doneMinutes, " _
              & " IsNull((SELECT COUNT(doneDic.dicID) FROM dbo.boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID WHERE(doneDicL.empID = dicl.empID) " _
              & " AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') AND doneDicl.diclStatus IN(1,2) " _
              & " GROUP BY doneDicL.empID),0) AS availDictations, " _
              & " IsNull((SELECT SUM(doneDic.dicLength) FROM dbo.boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID WHERE(doneDicL.empID = dicl.empID) " _
              & " AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
              & " AND doneDicl.diclStatus IN(1,2) " _
              & " GROUP BY doneDicL.empID),0) AS availMinutes, " _
              & " IsNull((SELECT COUNT(doneDic.dicID) FROM dbo.boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID WHERE (doneDicL.empID = dicl.empID) " _
              & " AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') AND doneDicl.diclStatus < 3 " _
              & " GROUP BY doneDicL.empID),0) AS outDictations, " _
              & " IsNull((SELECT SUM(doneDic.dicLength) FROM dbo.boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID WHERE (doneDicL.empID = dicl.empID) " _
              & " AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') AND doneDicl.diclStatus < 3 " _
              & " GROUP BY doneDicL.empID),0) AS outMinutes " _
              & " FROM dbo.boDictation dic " _
              & " INNER JOIN boDictationLayers dicL ON dic.dicID = dicL.dicID INNER JOIN boEmployee Emp ON dicL.empID = Emp.empID " _
              & " WHERE (dic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') GROUP BY dicL.empID, Emp.empFirstName, Emp.empLastName " _
              & " ORDER BY empFirstName, empLastName;"
        Query &= " SELECT dicL.empID, dicL.rolID, " _
              & " case(empFirstName) when 'Skip' then '-' else empFirstName end as empFirstName, " _
              & " case(empLastName) when 'Skip' then '-' else empLastName end as empLastName, " _
              & " COUNT(DISTINCT dic.foID + dic.drID) AS Dictators, COUNT(dic.dicID) AS Dictations, SUM(dic.dicLength)AS Minutes, " _
              & " IsNull((SELECT COUNT(doneDic.dicID) FROM dbo.boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID WHERE (doneDicL.empID = dicl.empID) " _
              & " AND (doneDicL.rolID = dicl.rolID) AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') AND doneDicl.diclStatus = 3 " _
              & " GROUP BY doneDicL.empID),0) AS doneDictations, " _
              & " IsNull((SELECT SUM(doneDic.dicLength) FROM dbo.boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID WHERE (doneDicL.empID = dicl.empID) AND " _
              & " (doneDicL.rolID = dicl.rolID) AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') AND doneDicl.diclStatus = 3 " _
              & " GROUP BY doneDicL.empID),0) AS doneMinutes, " _
              & " IsNull((SELECT COUNT(doneDic.dicID) FROM dbo.boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID WHERE (doneDicL.empID = dicl.empID) " _
              & " AND (doneDicL.rolID = dicl.rolID) AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') AND doneDicl.diclStatus IN(1,2) " _
              & " GROUP BY doneDicL.empID),0) AS availDictations, " _
              & " isNull((SELECT SUM(doneDic.dicLength) FROM dbo.boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
              & " WHERE (doneDicL.empID = dicl.empID) AND (doneDicL.rolID = dicl.rolID) AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
              & " AND doneDicl.diclStatus IN(1,2) " _
              & " GROUP BY doneDicL.empID),0) AS availMinutes, " _
              & " IsNull((SELECT COUNT(doneDic.dicID) FROM dbo.boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
              & " WHERE(doneDicL.empID = dicl.empID) AND (doneDicL.rolID = dicl.rolID) AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
              & " And doneDicl.diclStatus < 3" _
              & " GROUP BY doneDicL.empID),0) AS outDictations, " _
              & " IsNull((SELECT SUM(doneDic.dicLength) FROM dbo.boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
              & " WHERE(doneDicL.empID = dicl.empID) AND (doneDicL.rolID = dicl.rolID) AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
              & " And doneDicl.diclStatus < 3 " _
              & " GROUP BY doneDicL.empID),0) AS outMinutes FROM dbo.boDictation dic  " _
              & " INNER JOIN boDictationLayers dicL ON dic.dicID = dicL.dicID " _
              & " INNER JOIN boEmployee Emp ON dicL.empID = Emp.empID " _
              & " INNER JOIN boRoles rol ON dicL.rolID = rol.rolID " _
              & " WHERE (Dic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
              & " GROUP BY dicL.rolID, dicL.empID, Emp.empFirstName, Emp.empLastName, rol.rolOrder" _
              & " ORDER BY dicL.empID, rol.rolOrder;"
        Query &= " SELECT DicL.empID, DicL.rolID, Dic.drID, Dic.foID, boDictator.drFirstName, " _
              & " boDictator.drLastName, boDictator.drMiddleName, " _
              & " (SELECT Count(doneDic.dicId) FROM boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
              & " WHERE(doneDicL.rolID = DicL.rolID) AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
              & " And doneDicL.empId = DicL.empId And doneDic.drId = Dic.drId " _
              & " AND doneDic.foId = Dic.foID) as DicTations, " _
              & " IsNull((SELECT Sum(doneDic.dicLength) FROM boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
              & " WHERE(doneDicL.rolID = DicL.rolID) AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
              & " And doneDicL.empId = DicL.empId AND doneDic.drId = Dic.drId " _
              & " And doneDic.foId = Dic.foID),0) as dicLength, " _
              & " (SELECT Count(doneDic.dicId) FROM boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
              & " WHERE(doneDicL.rolID = DicL.rolID) " _
              & " AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
              & " And doneDicL.empId = DicL.empId And doneDic.drId = Dic.drId " _
              & " And doneDic.foId = Dic.foID AND doneDicL.diclStatus = 3) as DoneDictations , " _
              & " IsNull((SELECT Sum(doneDic.dicLength) FROM boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
              & " WHERE (doneDicL.rolID = DicL.rolID) AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
              & " And doneDicL.empId = DicL.empId AND doneDic.drId = Dic.drId " _
              & " And doneDic.foId = Dic.foID AND doneDicL.diclStatus = 3),0) as DonedicLength, " _
              & " (SELECT Count(doneDic.dicId) FROM boDictation doneDic" _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
              & " WHERE (doneDicL.rolID = DicL.rolID) AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
              & " And doneDicL.empId = DicL.empId AND doneDic.drId = Dic.drId " _
              & " And doneDic.foId = Dic.foID AND doneDicL.diclStatus IN(1,2)) as availDictations, " _
              & " IsNull((SELECT Sum(doneDic.dicLength) FROM boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
              & " WHERE(doneDicL.rolID = DicL.rolID) AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
              & " And doneDicL.empId = DicL.empId AND doneDic.drId = Dic.drId " _
              & " And doneDic.foId = Dic.foID AND doneDicL.diclStatus IN(1,2)),0) as availdicLength, " _
              & " (SELECT Count(doneDic.dicId) FROM boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
              & " WHERE (doneDicL.rolID = DicL.rolID) AND doneDicL.diclStatus < 3 " _
              & " AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
              & " And doneDicL.empId = DicL.empId AND doneDic.drId = Dic.drId AND doneDic.foId = Dic.foID) as OutDicTations, " _
              & " IsNull((SELECT Sum(doneDic.dicLength) FROM boDictation doneDic " _
              & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
              & " WHERE (doneDicL.rolID = DicL.rolID) AND doneDicL.diclStatus < 3 " _
              & " AND (doneDic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') And doneDicL.empId=DicL.empId AND doneDic.drId = Dic.drId " _
              & " And doneDic.foId = Dic.foID),0) as OutdicLength " _
              & " FROM boDictation Dic " _
              & " INNER JOIN boDictationLayers DicL ON Dic.dicID = DicL.dicID " _
              & " INNER JOIN boDictator ON Dic.drID = boDictator.drID " _
              & " And Dic.foID = boDictator.foID " _
              & " WHERE (Dic.dicDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "')  " _
              & " group by dicL.empid, DicL.rolID, Dic.foID, Dic.drID,boDictator.drFirstName, " _
              & " boDictator.drLastName, boDictator.drMiddleName "

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
        If e.Item.ItemType = ListItemType.Header Then
            iCounter = 0
        Else
            iCounter += 1
        End If
    End Sub
    Protected Sub EmpWorkload_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles EmpWorkload.ItemDataBound

    End Sub

    Protected Sub EmpWorkload_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles EmpWorkload.TemplateSelection
        e.TemplateFilename = "employeesworkloadFullDetail.ascx"
    End Sub
End Class
