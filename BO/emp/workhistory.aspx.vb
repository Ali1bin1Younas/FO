Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class BO_workhistory
    Inherits System.Web.UI.Page
    Dim eempID As String
    Dim Query As String

    Protected intT_FR_min As Integer
    Protected intT_FR_dic As Integer
    Protected intT_PR_min As Integer
    Protected intT_PR_dic As Integer
    Protected intT_QC_min As Integer
    Protected intT_QC_dic As Integer
    Protected intT_MT_min As Integer
    Protected intT_MT_dic As Integer

    Protected intT_min As Integer
    Protected intT_dic As Integer
    Protected intTTranscriptions As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblCompleteName.Text = Session("CompletePrefix") + "  " + Session("CompleteFirstNAme") + "   " + Session("CompleteLastName")
        eempID = Session("empID")
        Session("cint") = 0
        If Not Me.IsPostBack Then
            Me.cpFrom.SelectedDate = Now.Date
            Me.cpFrom.VisibleDate = Now.Date

            Me.cpTo.SelectedDate = Now.Date
            Me.cpTo.VisibleDate = Now.Date

            'loadRole(eempID)
        End If

        'eempID = Session("empID")
        'Query = "select r.rolDescription from boEmployeeRoles E inner join boRoles r on r.rolID = E.rolID " _
        '        & "where empEnable='1' and empID='" & eempID & "'"
        'Dim con As New DBTaskBO
        'Dim ds As New DataSet
        'ds = con.getDataSet(Query)
        'Me.ddlEmployeeRole.DataSource = ds
        'Me.ddlEmployeeRole.DataBind()
    End Sub

    'Protected Sub loadRole(ByVal empId As String)
    '    Query = "select r.rolDescription, r.rolID from boEmployeeRoles E inner join boRoles r on r.rolID = E.rolID " _
    '           & "where empEnable=1 and empID='" & empId & "' and r.rolID !='AD' " _
    '           & "order by r.rolOrder"
    '    Dim con As New DBTaskBO
    '    Dim ds As New DataSet
    '    ds = con.getDataSet(Query)
    '    Dim dt As DataTable
    '    dt = ds.Tables(0)
    '    Dim i As Integer = 0
    '    Dim str As String

    '    For Each item1 As DataRow In dt.Rows
    '        'Dim str As String
    '        'str = item1.Item(0)
    '        dt.Rows(i).Item(0) = item1.Item(1) & " - " & item1.Item(0)
    '        i = i + 1
    '    Next

    '    Me.ddlEmployeeRole.DataSource = dt
    '    Me.ddlEmployeeRole.DataBind()

    '    ds.Dispose()
    '    con.objConnection.Close()
    '    con = Nothing
    'End Sub

    Protected Function getCounter() As String
        Dim intCount As Integer = Session("cint")
        intCount += 1
        Session("cint") = intCount
        Return intCount.ToString
    End Function

    'Protected Function GetName(ByVal name As String) As String
    '    If name = "Formator" Then
    '        name = "FR " & name & " Reader"
    '    ElseIf name = "Medical Transcriptionist" Then
    '        name = "MT " & name
    '    ElseIf name = "Quality Controller" Then
    '        name = "QC " & name
    '    ElseIf name = "Proof Reader" Then
    '        name = "PR " & name
    '    End If
    '    Return name
    'End Function

    Protected Function getmin(ByVal second As String) As String
        Dim min, min2 As String
        min = second / 60
        min2 = second Mod 60
        Dim arr() As String = Split(min, ".")
        If min2 < 10 And min2 <> 0 Then
            min2 = "0" + min2
        End If
        If min2 <> 0 Then
            If min < 10 Then
                min = "00" + arr(0) + ":" + min2
            ElseIf min < 99 Then
                min = "0" + arr(0) + ":" + min2
            Else
                min = arr(0) + ":" + min2
            End If
        Else
            If min < 10 Then
                min = "00" + arr(0) + ":" + "00"
            ElseIf min < 99 Then
                min = "0" + arr(0) + ":" + "00"
            Else
                min = arr(0) + ":" + "00"
            End If
        End If
        Return min
    End Function

    Protected Sub getTotals(ByVal dt As DataTable)
        intT_FR_min = 0
        intT_FR_dic = 0
        intT_PR_min = 0
        intT_PR_dic = 0
        intT_QC_min = 0
        intT_QC_dic = 0
        intT_MT_min = 0
        intT_MT_dic = 0

        intT_min = 0
        intT_dic = 0

        For Each item1 As DataRow In dt.Rows
            intT_FR_min += CType(item1("FR_doneMinutes"), Integer)
            intT_FR_dic += CType(item1("FR_doneDictations"), Integer)
            intT_PR_min += CType(item1("PR_doneMinutes"), Integer)
            intT_PR_dic += CType(item1("PR_doneDictations"), Integer)
            intT_QC_min += CType(item1("QC_doneMinutes"), Integer)
            intT_QC_dic += CType(item1("QC_doneDictations"), Integer)
            intT_MT_min += CType(item1("MT_doneMinutes"), Integer)
            intT_MT_dic += CType(item1("MT_doneDictations"), Integer)

            intT_min += CType(item1("Minutes"), Integer)
            intT_dic += CType(item1("Dictations"), Integer)
        Next
    End Sub

    'Protected Sub GetTotalDictation(ByVal dt As DataTable)
    '    For Each item1 As DataRow In dt.Rows
    '        intTDictationD += CType(item1(2), Integer)
    '    Next
    'End Sub

    'Protected Sub GetTotalTranscription(ByVal dt As DataTable)
    '    For Each item1 As DataRow In dt.Rows
    '        intTTranscriptionD += CType(item1(4), Integer)
    '    Next
    'End Sub

    'Protected Function TDictation(ByVal total As Integer) As Integer
    '    total = intTDictationD
    '    Return total
    'End Function

    'Protected Function TTranscription(ByVal total As Integer) As Integer
    '    total = intTTranscriptionD
    '    Return total
    'End Function

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim con As New DBTaskBO

        Query = "SELECT dic.dicDate, empID, COUNT(DISTINCT dic.foID + dic.drID) AS Dictators, " _
                & " COUNT(dic.dicID) AS Dictations, SUM(dic.dicLength)AS Minutes, " _
                & " IsNull((SELECT COUNT(doneDic.dicID) FROM dbo.boDictation doneDic " _
                & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
                & " WHERE(doneDicL.rolID = 'MT' And doneDicL.empID = '" & Session("empID") & "') " _
                & " And (doneDic.dicDate = dic.dicDate)AND doneDicl.diclStatus = 3 " _
                & " GROUP BY doneDicL.empID, doneDicl.rolID),'') AS MT_doneDictations, " _
                & " IsNull((SELECT SUM(doneDic.dicLength) FROM dbo.boDictation doneDic " _
                & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
                & " WHERE(doneDicL.rolID = 'MT' And doneDicL.empID = '" & Session("empID") & "' ) " _
                & " AND (doneDic.dicDate  = dic.dicDate) AND doneDicl.diclStatus = 3 " _
                & " GROUP BY doneDicL.empID, doneDicl.rolID),'') AS MT_doneMinutes, " _
                & " IsNull((SELECT COUNT(doneDic.dicID) FROM dbo.boDictation doneDic " _
                & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
                & " WHERE(doneDicL.rolID = 'FR' And doneDicL.empID = '" & Session("empID") & "' ) AND (doneDic.dicDate = dic.dicDate) " _
                & " AND doneDicl.diclStatus = 3 GROUP BY doneDicL.empID, doneDicl.rolID),0) AS FR_doneDictations, " _
                & " IsNull((SELECT SUM(doneDic.dicLength) FROM dbo.boDictation doneDic " _
                & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
                & " WHERE(doneDicL.rolID = 'FR' And doneDicL.empID = '" & Session("empID") & "')AND (doneDic.dicDate  = dic.dicDate) " _
                & " And doneDicl.diclStatus = 3 GROUP BY doneDicL.empID, doneDicl.rolID),0) AS FR_doneMinutes, " _
                & " IsNull((SELECT COUNT(doneDic.dicID) FROM dbo.boDictation doneDic " _
                & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
                & " WHERE(doneDicL.rolID = 'QC' And doneDicL.empID = '" & Session("empID") & "' ) " _
                & " And (doneDic.dicDate = dic.dicDate) AND doneDicl.diclStatus = 3 " _
                & " GROUP BY doneDicL.empID, doneDicl.rolID),0) AS QC_doneDictations, IsNull((SELECT SUM(doneDic.dicLength) " _
                & " FROM dbo.boDictation doneDic INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
                & " WHERE(doneDicL.rolID = 'QC' And doneDicL.empID = '" & Session("empID") & "' ) AND (doneDic.dicDate  = dic.dicDate) " _
                & " And doneDicl.diclStatus = 3 GROUP BY doneDicL.empID, doneDicl.rolID),0) AS QC_doneMinutes, " _
                & " IsNull((SELECT COUNT(doneDic.dicID) FROM dbo.boDictation doneDic " _
                & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
                & " WHERE(doneDicL.rolID = 'PR' And doneDicL.empID = '" & Session("empID") & "' ) AND (doneDic.dicDate  = dic.dicDate) " _
                & " And doneDicl.diclStatus = 3 GROUP BY doneDicL.empID, doneDicl.rolID),0) AS PR_doneDictations, " _
                & " IsNull((SELECT SUM(doneDic.dicLength) FROM dbo.boDictation doneDic " _
                & " INNER JOIN boDictationLayers doneDicL ON doneDic.dicID = doneDicL.dicID " _
                & " WHERE(doneDicL.rolID = 'PR' And doneDicL.empID = '" & Session("empID") & "' ) AND (doneDic.dicDate  = dic.dicDate) " _
                & " And doneDicl.diclStatus = 3 GROUP BY doneDicL.empID, doneDicl.rolID),0) AS PR_doneMinutes " _
                & " FROM dbo.boDictation dic INNER JOIN boDictationLayers dicL ON dic.dicID = dicL.dicID " _
                & " WHERE dicL.empID = '" & Session("empID") & "' AND (dic.dicDate BETWEEN '" & Format(Me.cpFrom.SelectedDate, "MM/dd/yyyy") & "' AND '" & Format(Me.cpTo.SelectedDate, "MM/dd/yyyy") & "') " _
                & " GROUP BY dicL.empID, dic.dicDate ORDER BY dic.dicDate"


        Dim ds As New DataSet
        ds = con.getDataSet(Query)
        If ds.Tables(0).Rows.Count <> 0 Then
            getTotals(ds.Tables(0))

            'getPNOMDaily(ds.Tables(0))
            'GetTotalDictation(ds.Tables(0))
            'GetTotalTranscription(ds.Tables(0))
        End If
        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()

        ds.Dispose()
        con.objConnection.Close()
        con = Nothing
    End Sub
End Class
