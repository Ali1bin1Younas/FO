Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Imports System.Web.Services
Imports System.Collections.Generic

Partial Class dailyworkload_new
    Inherits System.Web.UI.Page
    Protected intNODDaily As Integer
    Protected intNOMDaily As Integer
    Protected intPNODDaily As Integer
    Protected intPNOMDaily As Integer
    Protected intNOODaily As Integer
    Protected intPNOODaily As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empID") = "" Then Response.Redirect(GF.Home)

        ViewState("ccint1") = 0
        ViewState("ccint") = 0

        If Not Page.IsPostBack Then
            chkBaklog.Checked = True
            Me.CPMain.SelectedDate = Now.Date.Date
            Me.CPMain.VisibleDate = Now.Date.Date
        End If

        If chkBaklog.Checked = True Then
            Label2.Visible = True
        Else
            Label2.Visible = False
        End If
    End Sub

    Protected Function getCounter() As String
        Dim intCount As Integer = ViewState("ccint1")
        intCount += 1
        ViewState("ccint1") = intCount
        Return intCount.ToString
    End Function
    Protected Function getCounter1() As String
        Dim intCount As Integer = ViewState("ccint")
        intCount += 1
        ViewState("ccint") = intCount
        Return intCount.ToString
    End Function

    Protected Function getMin(ByVal second As String) As String
        Return GF.GetMin(second)
    End Function

    Protected Sub getNOODaily(ByVal dt As DataTable)
        For Each item1 As DataRow In dt.Rows
            intNOODaily += CType(item1("Outstanding"), Integer)
        Next
    End Sub
    Protected Sub getPNOODaily(ByVal dt As DataTable)
        For Each item1 As DataRow In dt.Rows
            intPNOODaily += CType(item1("Outstanding"), Integer)
        Next
    End Sub

    Protected Sub getPNODDaily(ByVal dt As DataTable)
        For Each item1 As DataRow In dt.Rows
            intPNODDaily += CType(item1("TotalDictation"), Integer)
        Next
    End Sub
    Protected Sub getPNOMDaily(ByVal dt As DataTable)
        For Each item1 As DataRow In dt.Rows
            intPNOMDaily += CType(item1("TotalMinutes"), Integer)
        Next
    End Sub
    Protected Sub getNODDaily(ByVal dt As DataTable)
        For Each item1 As DataRow In dt.Rows
            intNODDaily += CType(item1("TotalDictation"), Integer)
        Next
    End Sub
    Protected Sub getNOMDaily(ByVal dt As DataTable)
        For Each item1 As DataRow In dt.Rows
            intNOMDaily += CType(item1("TotalMinutes"), Integer)

        Next
    End Sub

    Private Function GetFOID(ByVal strName As String) As String
        Dim Con As New DBTaskBO
        Dim Qry As String = "Select foID From boFO where foName='" + strName + "'"
        Dim ds As DataSet
        Dim strID As String = Nothing
        ds = Con.getDataSet(Qry)
        If ds.Tables(0).Rows.Count > 0 Then
            strID = ds.Tables(0).Rows(0).Item(0).ToString
            Return strID
        End If
        Return strID
    End Function
    Protected Function getCounterDaily() As String
        Dim intCountDaily As Integer = Session("cintDaily")
        intCountDaily += 1
        Session("cintDaily") = intCountDaily
        Return intCountDaily.ToString
    End Function
    Protected Function getCounterPending() As String
        Dim intCountPending As Integer = Session("cintPending")
        intCountPending += 1
        Session("cintPending") = intCountPending
        Return intCountPending.ToString
    End Function

    <WebMethod> _
    Public Shared Function loadDailyworkload(ByVal selectedDate As String) As List(Of DictatorList)
        Dim drList As New List(Of DictatorList)
        Dim dt As String
        Dim dts() As String
        Dim dtDate As Date
        Try
            dts = selectedDate.Split("/")
            dt = dts(0) & "/" & dts(1) & "/" & dts(2)
            dtDate = DateTime.Parse(dt)

            Dim Qry As String
            Dim Con As New DBTaskBO
            Dim ds As DataSet
            Qry = "SELECT b.foId, b.drId, b.foID + '-' + b.drID as drID,c.drFirstName,c.drLastname,c.drMiddleName,COUNT(b.dicActualName) AS TotalDictation, " _
            & " SUM(b.dicLength) AS TotalMinutes, " _
            & " ISNULL(C.drDifficulty,'') as drDifficulty,(Select Count(dicActualName) From boDictation where dicStatus < 4 and dicDate= '" + Format(dtDate, "MM/dd/yyyy") + "' and drID=b.drID ) As Outstanding, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate= '" + Format(dtDate, "MM/dd/yyyy") + "' and drID=b.drID and tDL.rolID= 'MT'), 0) As MTdoneMins, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate= '" + Format(dtDate, "MM/dd/yyyy") + "' and drID=b.drID and tDL.rolID= 'QC'), 0) As QCdoneMins, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate= '" + Format(dtDate, "MM/dd/yyyy") + "' and drID=b.drID and tDL.rolID= 'PR'), 0) As PRdoneMins, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate= '" + Format(dtDate, "MM/dd/yyyy") + "' and drID=b.drID and tDL.rolID= 'FR'), 0) As FRdoneMins " _
            & " FROM boDictation B INNER JOIN boDictator C ON b.drID = c.drID AND b.foID = c.foID " _
            & " WHERE (b.dicEnable = 1) AND (b.dicDate = '" + Format(dtDate, "MM/dd/yyyy") + "') " _
            & " GROUP BY b.foID,b.drID,c.drFirstName,c.drLastName,c.drMiddleName,C.drDifficulty; "
            Qry &= " Select dicID,drID,foID,dicDate,dicActualName,dicTempName,dicAccountName,dicLength From boDictation where (dicEnable = 1 AND dicDate= '" + Format(dtDate, "MM/dd/yyyy") + "') order by dicDate Desc, dicActualName"
            ds = Con.getDataSet(Qry)

            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Dim drObj As New DictatorList
                    drObj.drID = dr("drID").ToString()
                    drObj.foID = dr("foID").ToString()
                    drObj.drFirstName = dr("drFirstName").ToString()
                    drObj.drLastName = dr("drLastName").ToString()
                    drObj.drMiddleName = dr("drMiddleName").ToString()
                    drObj.drDifficulty = dr("drDifficulty").ToString()
                    drObj.totalDictations = Convert.ToInt64(dr("TotalDictation"))
                    drObj.totalMinutes = Convert.ToInt64(dr("TotalMinutes").ToString())
                    drObj.outStanding = Convert.ToInt64(dr("Outstanding").ToString())
                    drObj.MTdoneMins = Convert.ToInt64(dr("MTdoneMins").ToString())
                    drObj.QCdoneMins = Convert.ToInt64(dr("QCdoneMins").ToString())
                    drObj.PRdoneMins = Convert.ToInt64(dr("PRdoneMins").ToString())
                    drObj.FRdoneMins = Convert.ToInt64(dr("FRdoneMins").ToString())

                    Dim dicList As New List(Of DictationList)
                    If ds.Tables(1).Rows.Count > 0 Then
                        For Each dic As DataRow In ds.Tables(1).Rows

                            Dim dics As New DictationList
                            If dr("drID").ToString.Trim() = dic("drID").ToString().Trim() Then

                                dics.drID = dic("drID").ToString().Trim()
                                dics.dicID = dic("dicID").ToString().Trim()
                                dics.foID = dr("foID").ToString().Trim()
                                dics.dicActualName = dic("dicActualName").ToString().Trim()
                                dics.dicTempName = dic("dicTempName").ToString().Trim()
                                dics.dicAccountName = dic("dicAccountName").ToString().Trim()
                                dics.dicLength = dic("dicLength").ToString().Trim()
                                dics.dicDate = Format(CType(dic("dicDate"), DateTime), "dd/MM/yyyy")

                                dicList.Add(dics)
                                drObj.listDications = dicList
                            End If
                        Next
                    End If

                    drList.Add(drObj)
                Next
                loadDailyworkload = drList
            Else
                loadDailyworkload = Nothing
            End If
        Catch ex As Exception
            loadDailyworkload = Nothing
        End Try
    End Function

    <WebMethod> _
    Public Shared Function loadPendingWorkload(ByVal selectedDate As String) As List(Of DictatorList)
        Dim drList As New List(Of DictatorList)
        Dim dt As String
        Dim dts() As String
        Dim dtDate As Date
        Try
            dts = selectedDate.Split("/")
            dt = dts(0) & "/" & dts(1) & "/" & dts(2)
            dtDate = DateTime.Parse(dt)

            Dim Qry As String
            Dim Con As New DBTaskBO
            Dim ds As DataSet

            Qry = "SELECT b.foId,C.drId, b.foID+ '-' + C.drID As drID,c.drFirstName,COUNT(b.dicActualName) AS TotalDictation,ISNULL(C.drDifficulty,'') as drDifficulty, " _
            & " SUM(b.dicLength) AS TotalMinutes,(Select Count(dicActualName) From boDictation where dicStatus < 3 and dicDate < '" & Format(dtDate, "MM/dd/yyyy") & "' and drID=C.drID ) As Outstanding,c.drLastname,c.drMiddleName, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate < '" + Format(dtDate, "MM/dd/yyyy") + "' and drID=C.drID and tD.foID = B.foID and tDL.rolID= 'MT' and tD.dicEnable = 1 and tD.dicID IN (" _
            & " select tDD.dicID from boDictation tDD where dicStatus < 3 and drID = C.drID and dicDate < '" & Format(dtDate, "MM/dd/yyyy") & "' and dicEnable = 1)), 0) As MTdoneMins, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate < '" + Format(dtDate, "MM/dd/yyyy") + "' and drID=C.drID and tD.foID = B.foID and tDL.rolID= 'QC' and tD.dicEnable = 1 and tD.dicID IN (" _
            & " select tDD.dicID from boDictation tDD where dicStatus < 3 and drID = C.drID and dicDate < '" & Format(dtDate, "MM/dd/yyyy") & "' and dicEnable = 1)), 0) As QCdoneMins, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate < '" + Format(dtDate, "MM/dd/yyyy") + "' and drID=C.drID and tD.foID = B.foID and tDL.rolID= 'PR' and tD.dicEnable = 1 and tD.dicID IN (" _
            & " select tDD.dicID from boDictation tDD where dicStatus < 3 and drID = C.drID and dicDate < '" & Format(dtDate, "MM/dd/yyyy") & "' and dicEnable = 1)), 0) As PRdoneMins, " _
            & " IsNull((Select Sum(dicLength) From boDictation tD inner join boDictationLayers tDL on tD.dicID = tDL.dicID " _
            & " where diclStatus = 3 and dicDate < '" + Format(dtDate, "MM/dd/yyyy") + "' and drID=C.drID and tD.foID = B.foID and tDL.rolID= 'FR' and tD.dicEnable = 1 and tD.dicID IN (" _
            & " select tDD.dicID from boDictation tDD where dicStatus < 3 and drID = C.drID and dicDate < '" & Format(dtDate, "MM/dd/yyyy") & "' and dicEnable = 1)), 0) As FRdoneMins " _
            & " FROM boDictation B INNER JOIN boDictator C ON b.drID = c.drID AND b.foID = c.foID WHERE (b.dicEnable = 1) " _
            & " AND b.dicStatus < 3 AND (b.dicDate < '" & Format(dtDate, "MM/dd/yyyy") & "') " _
            & " GROUP BY b.foID,C.drID,c.drFirstName,c.drLastName,c.drMiddleName,C.drDifficulty; "

            Qry &= " Select dicID,drID,foID,dicDate,dicActualName,dicTempName,dicAccountName,dicLength From boDictation where (dicEnable = 1 AND dicStatus < 4 AND dicDate<'" + Format(dtDate, "MM/dd/yyyy") + "') order by dicDate Desc, dicActualName"
            ds = Con.getDataSet(Qry)

            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Dim drObj As New DictatorList
                    drObj.drID = dr("drID").ToString().Trim()
                    drObj.foID = dr("foID").ToString().Trim()
                    drObj.drFirstName = dr("drFirstName").ToString().Trim()
                    drObj.drLastName = dr("drLastName").ToString().Trim()
                    drObj.drMiddleName = dr("drMiddleName").ToString().Trim()
                    drObj.drDifficulty = dr("drDifficulty").ToString().Trim()
                    drObj.totalDictations = Convert.ToInt64(dr("TotalDictation"))
                    drObj.totalMinutes = Convert.ToInt64(dr("TotalMinutes").ToString().Trim())
                    drObj.outStanding = Convert.ToInt64(dr("Outstanding").ToString().Trim())
                    drObj.MTdoneMins = Convert.ToInt64(dr("MTdoneMins").ToString().Trim())
                    drObj.QCdoneMins = Convert.ToInt64(dr("QCdoneMins").ToString().Trim())
                    drObj.PRdoneMins = Convert.ToInt64(dr("PRdoneMins").ToString().Trim())
                    drObj.FRdoneMins = Convert.ToInt64(dr("FRdoneMins").ToString().Trim())

                    Dim dicList As New List(Of DictationList)
                    If ds.Tables(1).Rows.Count > 0 Then
                        For Each dic As DataRow In ds.Tables(1).Rows

                            Dim dics As New DictationList
                            If dr("drID").ToString.Trim() = dic("drID").ToString().Trim() Then

                                dics.drID = dic("drID").ToString().Trim()
                                dics.dicID = dic("dicID").ToString().Trim()
                                dics.foID = dr("foID").ToString().Trim()
                                dics.dicActualName = dic("dicActualName").ToString().Trim()
                                dics.dicTempName = dic("dicTempName").ToString().Trim()
                                dics.dicAccountName = dic("dicAccountName").ToString().Trim()
                                dics.dicLength = dic("dicLength").ToString().Trim()
                                dics.dicDate = Format(CType(dic("dicDate"), DateTime), "dd/MM/yyyy")

                                dicList.Add(dics)
                                drObj.listDications = dicList
                                End If
                        Next
                        End If

                    drList.Add(drObj)
                Next
                loadPendingWorkload = drList
            Else
                loadPendingWorkload = Nothing
                End If
        Catch ex As Exception
            loadPendingWorkload = Nothing
        End Try
    End Function

    <WebMethod> _
    Public Shared Function getDictator_dictations(ByVal drID As String, ByVal foID As String, ByVal selectedDate As String, ByVal isPending As Boolean) As List(Of DictationList)
        Dim dicList As New List(Of DictationList)
        Dim dt As String
        Dim dts() As String
        Dim dtDate As Date
        Try
            dts = selectedDate.Split("/")
            dt = dts(0) & "/" & dts(1) & "/" & dts(2)
            dtDate = DateTime.Parse(dt)

            Dim Qry As String
            Dim Con As New DBTaskBO
            Dim ds As DataSet
            If isPending Then
                Qry = "Select dicID,drID,foID,dicDate,dicActualName,dicTempName,dicAccountName,dicLength From boDictation where (dicEnable = 1 AND dicStatus < 4 AND dicDate<'" + Format(dtDate, "MM/dd/yyyy") + "' and drID = '" & drID & "' and foID = '" & foID & "') order by dicDate Desc, dicActualName"
            Else
                Qry = "Select dicID,drID,foID,dicDate,dicActualName,dicTempName,dicAccountName,dicLength From boDictation where (dicEnable = 1 AND dicDate= '" + Format(dtDate, "MM/dd/yyyy") + "' and drID = '" & drID & "' and foID = '" & foID & "') order by dicDate Desc, dicActualName"
            End If

            ds = Con.getDataSet(Qry)

            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Dim dicObj As New DictationList
                    dicObj.drID = dr("drID").ToString().Trim()
                    dicObj.dicID = dr("dicID").ToString().Trim()
                    dicObj.dicActualName = dr("dicActualName").ToString().Trim()
                    dicObj.dicTempName = dr("dicTempName").ToString().Trim()
                    dicObj.dicAccountName = dr("dicAccountName").ToString().Trim()
                    dicObj.dicDate = Format(CType(dr("dicDate"), DateTime), "dd/MM/yyyy")
                    dicObj.dicLength = dr("dicLength").ToString()

                    dicList.Add(dicObj)
                Next
                getDictator_dictations = dicList
            Else
                getDictator_dictations = Nothing
            End If
        Catch ex As Exception
            getDictator_dictations = Nothing
        End Try
    End Function
    <WebMethod> _
    Public Shared Function btnDownloadAll_Click(ByVal dicIDs As String) As String
        Dim qry As String = ""
        Dim objDB As New DBTaskBO
        Dim ds As New DataSet
        Dim zIcon As New Ionic.Zip.ZipFile()
        Dim isAnySelected As Boolean = False
        Dim listOfDoc As New Generic.List(Of String)
        Try
            qry = "select dicID, drID, foID, dicTempName from boDictation where dicID IN(" & dicIDs & ")"
            ds = objDB.getDataSet(qry)

            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows

                    If IO.Directory.Exists(HttpContext.Current.Server.MapPath("~/data/dictationsZips")) Then
                        IO.Directory.Delete(HttpContext.Current.Server.MapPath("~/data/dictationsZips"), True)
                    End If

                    If Not IO.Directory.Exists(HttpContext.Current.Server.MapPath("..\Data\dictationsZips")) Then
                        IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("..\Data\dictationsZips"))
                    End If

                    Dim fFullName As String = HttpContext.Current.Server.MapPath("..\Data\") & dr("foID").ToString().Trim() & dr("drID").ToString().Trim() & "\Dictations\" & dr("dicTempName").ToString().Trim()
                    If IO.File.Exists(fFullName) Then
                        isAnySelected = True
                        listOfDoc.Add(fFullName)
                    End If
                Next

                If isAnySelected Then
                    Dim archiveName As String = String.Format("Dictations-{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"))

                    Using zIcon
                        zIcon.AddFiles(listOfDoc, DateTime.Now.ToString("yyyy-MM-dd"))
                        zIcon.Save(HttpContext.Current.Server.MapPath("~/data/dictationsZips/" & archiveName))
                    End Using
                    Return archiveName
                Else
                    Return "0"
                End If
            Else
                Return "0"
            End If

        Catch ex As Exception
            Return "-1"
        End Try
    End Function

    <WebMethod> _
    Public Shared Function deleteDictationsZip(ByVal drID As String, ByVal foID As String, ByVal fileName As String) As String

        Try
            Dim fFullName As String = HttpContext.Current.Server.MapPath("..\Data\dictationsZips\") & fileName.Trim()
            If IO.File.Exists(fFullName) Then
                IO.File.Delete(fFullName)
                Return "1"
            Else
                Return "0"
            End If
        Catch ex As Exception
            Return "-1"
        End Try
    End Function
End Class

Public Class DictatorList
    Private _drID As String
    Private _foID As String
    Private _drFirstName As String
    Private _drLastName As String
    Private _drDifficulty As String
    Private _drMiddleName As String
    Private _totalDictations As Integer
    Private _totalMinutes As Integer
    Private _outStanding As Integer
    Private _MTdoneMins As Integer
    Private _QCdoneMins As Integer
    Private _PRdoneMins As Integer
    Private _FRdoneMins As Integer
    Private _listDications As List(Of DictationList)

    Public Property drID() As String
        Get
            Return _drID
        End Get
        Set(value As String)
            _drID = value
        End Set
    End Property

    Public Property foID() As String
        Get
            Return _foID
        End Get
        Set(value As String)
            _foID = value
        End Set
    End Property

    Public Property drFirstName() As String
        Get
            Return _drFirstName
        End Get
        Set(value As String)
            _drFirstName = value
        End Set
    End Property

    Public Property drLastName() As String
        Get
            Return _drLastName
        End Get
        Set(value As String)
            _drLastName = value
        End Set
    End Property

    Public Property drMiddleName() As String
        Get
            Return _drMiddleName
        End Get
        Set(value As String)
            _drMiddleName = value
        End Set
    End Property

    Public Property drDifficulty() As String
        Get
            Return _drDifficulty
        End Get
        Set(value As String)
            _drDifficulty = value
        End Set
    End Property

    Public Property totalDictations() As Integer
        Get
            Return _totalDictations
        End Get
        Set(value As Integer)
            _totalDictations = value
        End Set
    End Property

    Public Property totalMinutes() As String
        Get
            Return _totalMinutes
        End Get
        Set(value As String)
            _totalMinutes = value
        End Set
    End Property

    Public Property outStanding() As Integer
        Get
            Return _outStanding
        End Get
        Set(value As Integer)
            _outStanding = value
        End Set
    End Property

    Public Property MTdoneMins() As Integer
        Get
            Return _MTdoneMins
        End Get
        Set(value As Integer)
            _MTdoneMins = value
        End Set
    End Property

    Public Property QCdoneMins() As Integer
        Get
            Return _QCdoneMins
        End Get
        Set(value As Integer)
            _QCdoneMins = value
        End Set
    End Property

    Public Property PRdoneMins() As Integer
        Get
            Return _PRdoneMins
        End Get
        Set(value As Integer)
            _PRdoneMins = value
        End Set
    End Property

    Public Property FRdoneMins() As Integer
        Get
            Return _FRdoneMins
        End Get
        Set(value As Integer)
            _FRdoneMins = value
        End Set
    End Property

    Public Property listDications() As List(Of DictationList)
        Get
            Return _listDications
        End Get
        Set(value As List(Of DictationList))
            _listDications = value
        End Set
    End Property
End Class

Public Class DictationList
    Private _dicID As String
    Private _drID As String
    Private _foID As String
    Private _dicActualName As String
    Private _dicTempName As String
    Private _dicAccountName As String
    Private _dicDate As String
    Private _dicLength As Integer

    Public Property dicID() As String
        Get
            Return _dicID
        End Get
        Set(value As String)
            _dicID = value
        End Set
    End Property

    Public Property drID() As String
        Get
            Return _drID
        End Get
        Set(value As String)
            _drID = value
        End Set
    End Property

    Public Property foID() As String
        Get
            Return _foID
        End Get
        Set(value As String)
            _foID = value
        End Set
    End Property

    Public Property dicActualName() As String
        Get
            Return _dicActualName
        End Get
        Set(value As String)
            _dicActualName = value
        End Set
    End Property

    Public Property dicTempName() As String
        Get
            Return _dicTempName
        End Get
        Set(value As String)
            _dicTempName = value
        End Set
    End Property

    Public Property dicAccountName() As String
        Get
            Return _dicAccountName
        End Get
        Set(value As String)
            _dicAccountName = value
        End Set
    End Property

    Public Property dicDate() As String
        Get
            Return _dicDate
        End Get
        Set(value As String)
            _dicDate = value
        End Set
    End Property

    Public Property dicLength() As String
        Get
            Return _dicLength
        End Get
        Set(value As String)
            _dicLength = value
        End Set
    End Property

End Class