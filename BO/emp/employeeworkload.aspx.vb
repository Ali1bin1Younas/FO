Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL
Partial Class BO_employeeworkload
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
            Me.CPTo.VisibleDate = Now.Date
            Dim query As String = "SELECT * FROM boEmployee WHERE empID = '" & Session("empID") & "'"
            Dim ds As New DataSet
            Dim Con As New DBTaskBO
            ds = Con.getDataSet(query)
            
            Session("CompletePrefix") = ds.Tables(0).Rows(0)("empPrefix")
            Session("CompleteFirstNAme") = ds.Tables(0).Rows(0)("empFirstName")
            Session("CompleteLastName") = ds.Tables(0).Rows(0)("empLastName")
            lblCompleteName.Text = Session("CompletePrefix") + "  " + Session("CompleteFirstNAme") + "   " + Session("CompleteLastName")

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
        Query = "SELECT dicL.rolID, rolDescription, empID, " _
            & "COUNT(DISTINCT dic.foID + dic.drID) AS Dictators, " _
            & "COUNT(dic.dicID) AS Dictations, SUM(dic.dicLength)AS Minutes, " _
            & "IsNull((SELECT COUNT(doneDic.dicID) " _
            & "FROM dbo.boDictation doneDic INNER JOIN " _
            & "boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE(doneDicL.rolID = dicl.rolID And doneDicL.empID = dicl.empID) " _
            & "AND (doneDicL.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yy") & "') AND doneDicl.diclStatus = 3" _
            & "GROUP BY doneDicL.empID, doneDicl.rolID),0) AS doneDictations,IsNull((SELECT SUM(doneDic.dicLength) " _
            & "FROM dbo.boDictation doneDic INNER JOIN " _
            & "boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE(doneDicL.rolID = dicl.rolID And doneDicL.empID = dicl.empID) " _
            & "AND (doneDicL.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(CPTo.SelectedDate, "MM/dd/yy") & "') AND doneDicl.diclStatus = 3 " _
            & "GROUP BY doneDicL.empID, doneDicl.rolID),0) AS doneMinutes, " _
            & "IsNull((SELECT COUNT(doneDic.dicID) " _
            & "FROM dbo.boDictation doneDic INNER JOIN " _
            & "boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE(doneDicL.rolID = dicl.rolID And doneDicL.empID = dicl.empID) " _
            & "AND (doneDicL.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yy") & "') AND doneDicl.diclStatus IN(1,2) " _
            & "GROUP BY doneDicL.empID, doneDicl.rolID),0) AS availDictations,IsNull((SELECT SUM(doneDic.dicLength) " _
            & "FROM dbo.boDictation doneDic INNER JOIN " _
            & "boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE(doneDicL.rolID = dicl.rolID And doneDicL.empID = dicl.empID) " _
            & "AND (doneDicL.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yy") & "') AND doneDicl.diclStatus IN(1,2) " _
            & "GROUP BY doneDicL.empID, doneDicl.rolID),0) AS availMinutes, " _
            & "IsNull((SELECT COUNT(doneDic.dicID) " _
            & "FROM dbo.boDictation doneDic INNER JOIN " _
            & "boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE(doneDicL.rolID = dicl.rolID And doneDicL.empID = dicl.empID) " _
            & "AND (doneDicL.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yy") & "') AND doneDicl.diclStatus < 3 " _
            & "GROUP BY doneDicL.empID, doneDicl.rolID),0) AS outDictations,IsNull((SELECT SUM(doneDic.dicLength) " _
            & "FROM dbo.boDictation doneDic INNER JOIN " _
            & "boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
            & "WHERE(doneDicL.rolID = dicl.rolID And doneDicL.empID = dicl.empID) " _
            & "AND (doneDicL.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yy") & "') AND doneDicl.diclStatus < 3 " _
            & "GROUP BY doneDicL.empID, doneDicl.rolID),0) AS outMinutes FROM dbo.boDictation dic INNER JOIN " _
            & "boDictationLayers dicL ON dic.dicID = dicL.dicID INNER JOIN " _
            & "boRoles Rol ON dicL.rolID = Rol.rolID " _
            & "WHERE dicL.empID = '" & Session("empID") & "' AND (dicL.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yy") & "') " _
            & "GROUP BY dicL.rolID, rolDescription, dicL.empID, rol.rolOrder " _
            & "ORDER BY rolOrder;"
        Query &= "SELECT DicL.rolID,DicL.empID, bDic.foID, bDic.drID, boDictator.drFirstName, boDictator.drLastName, " _
            & "boDictator.drMiddleName, " _
            & "(SELECT Count(boDictation.dicId) FROM boDictation " _
            & "INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
            & "WHERE (boDictationLayers.empID = '" & Session("empID") & "') AND (boDictationLayers.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yy") & "') " _
            & "AND boDictationLayers.empId=DicL.empId AND " _
            & "boDictation.drId=BDic.drId AND boDictation.foId=BDic.foID) as DicTations," _
            & "IsNull((SELECT Sum(boDictation.dicLength)FROM boDictation " _
            & "INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
            & "WHERE (boDictationLayers.empID = '" & Session("empID") & "') AND (boDictationLayers.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yy") & "') " _
            & "And boDictationLayers.empId = DicL.empId " _
            & "AND boDictation.drId = bDic.drId And boDictation.foId = bDic.foID),0) as dicLength, " _
            & "(SELECT Count(boDictation.dicId) FROM boDictation " _
            & "INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
            & "WHERE (boDictationLayers.empID = '" & Session("empID") & "') AND (boDictationLayers.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yy") & "') " _
            & "AND boDictationLayers.empId=DicL.empId AND " _
            & "boDictation.drId=BDic.drId AND boDictation.foId=BDic.foID AND boDictationLayers.diclStatus = 3) as DoneDictations, " _
            & "IsNull((SELECT Sum(boDictation.dicLength)FROM boDictation " _
            & "INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
            & "WHERE (boDictationLayers.empID = '" & Session("empID") & "') AND (boDictationLayers.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yy") & "') " _
            & "And boDictationLayers.empId = DicL.empId " _
            & " AND boDictation.drId = bDic.drId And boDictation.foId = bDic.foID AND boDictationLayers.diclStatus = 3),0) as DonedicLength, " _
            & "(SELECT Count(boDictation.dicId) FROM boDictation " _
            & "INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
            & "WHERE (boDictationLayers.empID = '" & Session("empID") & "') AND (boDictationLayers.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yy") & "') " _
            & "AND boDictationLayers.empId=DicL.empId AND " _
            & "boDictation.drId=BDic.drId AND boDictation.foId=BDic.foID AND boDictationLayers.diclStatus IN(1,2)) as availDictations, " _
            & "IsNull((SELECT Sum(boDictation.dicLength)FROM boDictation " _
            & "INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
            & "WHERE (boDictationLayers.empID = '" & Session("empID") & "') AND (boDictationLayers.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yy") & "') " _
            & "And boDictationLayers.empId = DicL.empId " _
            & " AND boDictation.drId = bDic.drId And boDictation.foId = bDic.foID AND boDictationLayers.diclStatus IN(1,2)),0) as availdicLength, " _
            & "(SELECT Count(boDictation.dicId) FROM boDictation " _
            & "INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID WHERE (boDictationLayers.empID = '" & Session("empID") & "') " _
            & "AND boDictationLayers.diclStatus < 3 AND (boDictationLayers.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yy") & "') " _
            & "AND boDictationLayers.empId=DicL.empId AND boDictation.drId=BDic.drId AND boDictation.foId=BDic.foID) as OutDicTations, " _
            & "IsNull((SELECT Sum(boDictation.dicLength)FROM boDictation INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
            & "WHERE (boDictationLayers.empID = '" & Session("empID") & "') AND boDictationLayers.diclStatus < 3 AND (boDictationLayers.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yy") & "') " _
            & "And boDictationLayers.empId=DicL.empId AND boDictation.drId = bDic.drId And boDictation.foId = bDic.foID),0) as OutdicLength " _
            & "FROM boDictation bDic INNER JOIN boDictationLayers DicL ON bDic.dicID = DicL.dicID " _
            & "INNER JOIN boDictator ON bDic.drID = boDictator.drID AND bDic.foID = boDictator.foID " _
            & "WHERE (DicL.empID = '" & Session("empID") & "') AND (DicL.diclWorkloadDate BETWEEN '" & Format(Me.CPDate.SelectedDate, "MM/dd/yy") & "' AND '" & Format(Me.CPTo.SelectedDate, "MM/dd/yy") & "') " _
            & "group by dicl.rolID, dicl.empid, bDic.foID, bDic.drID,boDictator.drFirstName, boDictator.drLastName, boDictator.drMiddleName"

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
        e.TemplateFilename = "employeeworkloaddetail.ascx"
    End Sub
End Class
