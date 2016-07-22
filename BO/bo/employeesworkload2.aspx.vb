Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL
Partial Class BO_employeeworkload2
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
            loadRole(eempID)
            Me.CPDate.SelectedDate = Now.Date
            Me.CPDate.VisibleDate = Now.Date
            Me.CPTo.SelectedDate = Now.Date
            Me.CPTo.VisibleDate = Now.Date
        End If
    End Sub

    Protected Sub loadRole(ByVal empId As String)
        Query = "select r.rolDescription, r.rolID " _
                 & "from  boRoles r " _
                 & "where rolEnable='1' and r.rolID !='AD' " _
                 & "order by r.rolOrder"
        Dim con As New DBTaskBO
        Dim ds As New DataSet
        ds = con.getDataSet(Query)
        Dim dt As DataTable
        dt = ds.Tables(0)
        Dim i As Integer = 0
        For Each item1 As DataRow In dt.Rows
            dt.Rows(i).Item(0) = item1.Item("rolID") & "-" & item1.Item("rolDescription")
            i = i + 1
        Next
        Me.ddlEmp.DataSource = dt
        Me.ddlEmp.DataBind()
        ds.Dispose()
        dt.Dispose()
        con.objConnection.Close()
        con = Nothing
        ds = Nothing
        dt = Nothing
    End Sub

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

        Query = "SELECT case(dicL.empID) " _
            & "when '0' then '-' else dicl.empID end AS empID," _
            & "case(empFirstName) " _
            & "when 'Skip' then '-' else empFirstName end as empFirstName," _
            & "case(empLastName) when 'Skip' then '-' else empLastName end as empLastName, " _
            & "COUNT(DISTINCT dic.foID + dic.drID) AS Dictators, " _
            & "COUNT(dic.dicID) AS Dictations, SUM(dic.dicLength)AS Minutes, " _
            & "IsNull((SELECT COUNT(doneDic.dicID) " _
            & "FROM dbo.boDictation doneDic INNER JOIN " _
            & "boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE(doneDicL.rolID = dicl.rolID And doneDicL.empID = dicl.empID) " _
            & "AND (" & QueryClause & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') AND doneDicl.diclStatus = 3" _
            & "GROUP BY doneDicL.empID, doneDicl.rolID),0) AS doneDictations,IsNull((SELECT SUM(doneDic.dicLength) " _
            & "FROM dbo.boDictation doneDic INNER JOIN " _
            & "boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE(doneDicL.rolID = dicl.rolID And doneDicL.empID = dicl.empID) " _
            & "AND (" & QueryClause & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') AND doneDicl.diclStatus = 3 " _
            & "GROUP BY doneDicL.empID, doneDicl.rolID),0) AS doneMinutes, " _
            & "IsNull((SELECT COUNT(doneDic.dicID) " _
            & "FROM dbo.boDictation doneDic INNER JOIN " _
            & "boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE(doneDicL.rolID = dicl.rolID And doneDicL.empID = dicl.empID) " _
            & "AND (" & QueryClause & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') AND doneDicl.diclStatus IN(1,2) " _
            & "GROUP BY doneDicL.empID, doneDicl.rolID),0) AS availDictations,IsNull((SELECT SUM(doneDic.dicLength) " _
            & "FROM dbo.boDictation doneDic INNER JOIN " _
            & "boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE(doneDicL.rolID = dicl.rolID And doneDicL.empID = dicl.empID) " _
            & "AND (" & QueryClause & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') AND doneDicl.diclStatus IN(1,2) " _
            & "GROUP BY doneDicL.empID, doneDicl.rolID),0) AS availMinutes, " _
            & "IsNull((SELECT COUNT(doneDic.dicID) " _
            & "FROM dbo.boDictation doneDic INNER JOIN " _
            & "boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE(doneDicL.rolID = dicl.rolID And doneDicL.empID = dicl.empID) " _
            & "AND (" & QueryClause & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') AND doneDicl.diclStatus < 3 " _
            & "GROUP BY doneDicL.empID, doneDicl.rolID),0) AS outDictations,IsNull((SELECT SUM(doneDic.dicLength) " _
            & "FROM dbo.boDictation doneDic INNER JOIN " _
            & "boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE(doneDicL.rolID = dicl.rolID And doneDicL.empID = dicl.empID) " _
            & "AND (" & QueryClause & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') AND doneDicl.diclStatus < 3 " _
            & "GROUP BY doneDicL.empID, doneDicl.rolID),0) AS outMinutes FROM dbo.boDictation dic INNER JOIN " _
            & "boDictationLayers dicL ON dic.dicID = dicL.dicID INNER JOIN " _
            & "boEmployee Emp ON dicL.empID = Emp.empID " _
            & "WHERE dicL.rolID = '" & Me.ddlEmp.SelectedValue & "' AND (" & QueryClause2 & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
            & "GROUP BY dicL.rolID, dicL.empID, Emp.empFirstName, Emp.empLastName Order by Emp.empFirstName, Emp.empLastName;"
        Query &= "SELECT DicL.empID, Dic.foID, Dic.drID, boDictator.drFirstName, boDictator.drLastName, " _
            & "boDictator.drMiddleName, " _
            & "(SELECT Count(doneDic.dicId) FROM boDictation doneDic " _
            & "INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE (doneDicL.rolID = '" & Me.ddlEmp.SelectedValue & "') AND (" & QueryClause & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
            & "AND doneDicL.empId = DicL.empId AND " _
            & "doneDic.drId = Dic.drId AND doneDic.foId = Dic.foID) as DicTations," _
            & "IsNull((SELECT Sum(doneDic.dicLength)FROM boDictation doneDic " _
            & "INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE (doneDicL.rolID = '" & Me.ddlEmp.SelectedValue & "') AND (" & QueryClause & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
            & "And doneDicL.empId = DicL.empId " _
            & "AND doneDic.drId = Dic.drId And doneDic.foId = Dic.foID),0) as dicLength, " _
            & "(SELECT Count(doneDic.dicId) FROM boDictation doneDic " _
            & "INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE (doneDicL.rolID = '" & Me.ddlEmp.SelectedValue & "') AND (" & QueryClause & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
            & "AND doneDicL.empId = DicL.empId AND " _
            & "doneDic.drId = Dic.drId AND doneDic.foId = Dic.foID AND doneDicL.diclStatus = 3) as DoneDictations, " _
            & "IsNull((SELECT Sum(doneDic.dicLength)FROM boDictation doneDic " _
            & "INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE (doneDicL.rolID = '" & Me.ddlEmp.SelectedValue & "') AND (" & QueryClause & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
            & "And doneDicL.empId = DicL.empId " _
            & " AND doneDic.drId = Dic.drId And doneDic.foId = Dic.foID AND doneDicL.diclStatus = 3),0) as DonedicLength, " _
            & "(SELECT Count(doneDic.dicId) FROM boDictation doneDic " _
            & "INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE (doneDicL.rolID = '" & Me.ddlEmp.SelectedValue & "') AND (" & QueryClause & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
            & "AND doneDicL.empId = DicL.empId AND " _
            & "doneDic.drId = Dic.drId AND doneDic.foId = Dic.foID AND doneDicL.diclStatus IN(1,2)) as availDictations, " _
            & "IsNull((SELECT Sum(doneDic.dicLength)FROM boDictation doneDic " _
            & "INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE (doneDicL.rolID = '" & Me.ddlEmp.SelectedValue & "') AND (" & QueryClause & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
            & "And doneDicL.empId = DicL.empId " _
            & " AND doneDic.drId = Dic.drId And doneDic.foId = Dic.foID AND doneDicL.diclStatus IN(1,2)),0) as availdicLength, " _
            & "(SELECT Count(doneDic.dicId) FROM boDictation doneDic " _
            & "INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID WHERE (doneDicL.rolID = '" & Me.ddlEmp.SelectedValue & "') " _
            & "AND doneDicL.diclStatus < 3 AND (" & QueryClause & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
            & "AND doneDicL.empId = DicL.empId AND doneDic.drId = Dic.drId AND doneDic.foId = Dic.foID) as OutDicTations, " _
            & "IsNull((SELECT Sum(doneDic.dicLength)FROM boDictation doneDic INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE (doneDicL.rolID = '" & Me.ddlEmp.SelectedValue & "') AND doneDicL.diclStatus < 3 AND (" & QueryClause & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
            & "And doneDicL.empId = DicL.empId AND doneDic.drId = Dic.drId And doneDic.foId = Dic.foID),0) as OutdicLength " _
            & "FROM boDictation Dic INNER JOIN boDictationLayers DicL ON Dic.dicID = DicL.dicID " _
            & "INNER JOIN boDictator ON Dic.drID = boDictator.drID AND Dic.foID = boDictator.foID " _
            & "WHERE (DicL.rolID = '" & Me.ddlEmp.SelectedValue & "') AND (" & QueryClause2 & " BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yyyy") & "') " _
            & "group by dicl.empid, Dic.foID, Dic.drID,boDictator.drFirstName, boDictator.drLastName, boDictator.drMiddleName"

        Dim con As New DBTaskBO
        Dim ds As New DataSet
        ds = con.getDataSet(Query)
        ds.Tables(0).TableName = "Employee"
        ds.Tables(1).TableName = "Dictator"
        If ds.Tables(0).Rows.Count > 0 Then
            GetGrandTotal(ds.Tables(0))
        End If
        'Bind the data source with grid
        ds.Relations.Add("PK", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
        Me.EmpWorkload.DataSource = ds
        Me.EmpWorkload.DataMember = "Employee"
        Me.EmpWorkload.DataBind()
        Me.EmpWorkload.RowExpanded.ExpandAll()
        ds.Dispose()
        ds = Nothing
        con.objConnection.Close()
        con = Nothing
    End Sub

    Protected Sub GetGrandTotal(ByVal dt As DataTable)
        For Each item1 As DataRow In dt.Rows
            intTDictationD += CType(item1("Dictations"), Integer)
            intPNOMDaily += CType(item1("Minutes"), Integer)
            done += CType(item1("doneDictations"), Integer)
            doneM += CType(item1("doneMinutes"), Integer)

            avail += CType(item1("availDictations"), Integer)
            availM += CType(item1("availMinutes"), Integer)

            out += CType(item1("outDictations"), Integer)
            outM += CType(item1("outMinutes"), Integer)
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
        e.TemplateFilename = "employeedictator.ascx"
    End Sub
End Class
