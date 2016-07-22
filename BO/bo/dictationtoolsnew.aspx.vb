Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Imports System.Web.Services
Imports System.Collections.Generic
Partial Class BO_dictationtools
    Inherits System.Web.UI.Page
    Dim Qry As String
    Dim Con As New DBTaskBO
    Dim ds As New DataSet
    Protected dic_Status As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        If Not Page.IsPostBack Then
            CPFrom.SelectedDate = Now.AddDays(-1)
            CPFrom.VisibleDate = Now.AddDays(-1)

            CpTo.SelectedDate = Now
            CpTo.VisibleDate = Now
        End If

        If Not Me.IsPostBack Then
            Call Me.Load_ddl_Dictator()
            Call Me.Load_ddl_Location()
            Call Me.Load_ddl_Employee()

            With ddlStatus
                .Items.Insert(0, "Active")
                .Items.Insert(1, "Deleted")
                .Items.Insert(2, "All")
            End With

            With ddlSorting
                .Items.Insert(0, "Dictator, Dictation Name")
                .Items.Insert(1, "Date, Dictation Name")
                .Items.Insert(2, "Dictation Name, Date")
            End With
        End If
    End Sub

    <WebMethod()> _
    Public Shared Function Load_Transcriptions(ByVal _selected_Dictator As String, ByVal _selected_Account As String, ByVal _selected_Employee As String, ByVal sort As String, ByVal _selected_date_from As String, ByVal _selected_date_to As String, ByVal searchtxtbox As String, ByVal status As String) As UserDetails()
        Dim sDictator, sAccount, sEmployee, sDate, sStatus, sSort As String
        If _selected_Dictator = "-1" Then
            sDictator = ""
        Else
            sDictator = " AND RTRIM(foID)+RTRIM(drId) = '" & _selected_Dictator.Trim() & "' "
        End If
        If _selected_Account = "All Accounts" Then
            sAccount = ""
        Else
            sAccount = " AND td.dicAccountName = '" & _selected_Account.Trim() & "'"
        End If

        If Not _selected_Employee = Nothing AndAlso Not _selected_Employee = Nothing Then
            sEmployee = " AND tdl.empID = '" & _selected_Employee.Trim() & "'"
        Else
            sEmployee = ""
        End If

        If _selected_date_from = Nothing And _selected_date_to = Nothing Then
            sDate = ""
        ElseIf _selected_date_from <> Nothing And _selected_date_to = Nothing Then
            sDate = " AND dicDate= '" & _selected_date_from & "'"
        ElseIf _selected_date_to <> Nothing And _selected_date_from = Nothing Then
            sDate = " AND dicDate= '" & _selected_date_to & "'"
        Else
            sDate = " AND dicDate BETWEEN '" & _selected_date_from & "' AND '" & _selected_date_to & "' "
        End If
        If status = "Active" Then
            sStatus = " AND dicEnable = 1"
        ElseIf status = "Deleted" Then
            sStatus = " AND dicEnable = 0"
        Else
            sStatus = ""
        End If

        If sort = "Dictator, Dictation Name" Then
            sSort = " ,drID,dicActualName "
        ElseIf sort = "Date, Dictation Name" Then
            sSort = " ,dicDate,dicActualName "
        ElseIf sort = "Dictation Name, Date" Then
            sSort = " ,dicActualName,dicDate "
        End If

        Dim dt As New DataSet()
        Dim dbc As New DBTaskBO()
        Dim dictation_tools As String = ""
        Dim dictation_tools_db As String = ""
        Dim Details As New List(Of UserDetails)()

        dictation_tools_db = "Select distinct(td.dicId) as dicID,foId,drId,dicActualName,dicDate,dicAccountName, dicStatus,dicLength,dicEnable,dicDuplicateCheck, " _
        & "isNull((Select empFirstName +' '+substring(empLastName,1,1)+':'+Convert(varchar,diclStatus)+':'+bE.empID  as empName from boDictationLayers bDL " _
        & "Inner join boEmployee bE on bDL.empID = bE.empID Inner join boDictation bD on bDL.dicId = bD.dicId " _
        & "where bDL.dicId= td.dicId AND bDl.rolID='MT' And bD.dicStatus >= 0), '-') as MT," _
        & "isNull((Select empFirstName +' '+substring(empLastName,1,1)+':'+ Convert(varchar,diclStatus)+':'+bE.empID  as empName from boDictationLayers bDL " _
        & "Inner join boEmployee bE on bDL.empID = bE.empID Inner join boDictation bD on bDL.dicId = bD.dicId " _
        & "where bDL.dicId= td.dicId AND bDl.rolID='PR' And bD.dicStatus >= 0), '-') as PR," _
        & "isNull((Select empFirstName +' '+substring(empLastName,1,1)+':'+ Convert(varchar,diclStatus)+':'+bE.empID  as  empName from boDictationLayers bDL " _
        & "Inner join boEmployee bE on bDL.empID = bE.empID  Inner join boDictation bD on bDL.dicId = bD.dicId " _
        & "where bDL.dicId= td.dicId AND bDl.rolID='QC' And bD.dicStatus >= 0), '-') as QC," _
        & "isNull((Select empFirstName +' '+substring(empLastName,1,1)+':'+ Convert(varchar,diclStatus)+':'+bE.empID  as empName from boDictationLayers bDL " _
        & "Inner join boEmployee bE on bDL.empID = bE.empID  Inner join boDictation bD on bDL.dicId = bD.dicId " _
        & "where bDL.dicId= td.dicId AND bDl.rolID='PR' And bD.dicStatus >= 0), '-') as FR " _
        & "from boDictation td " _
        & "left outer join boDictationLayers tdl on tdl.dicID = td.dicID " _
        & " where dicTempName like '%" & searchtxtbox & "%' " _
        & sDictator & sEmployee & sAccount & sDate & sStatus & " ORDER BY foID " & sSort


        dt = dbc.getDataSet(dictation_tools_db)
        For Each dtrow As DataRow In dt.Tables(0).Rows

            Dim user As New UserDetails()
            user.drId = dtrow("drId").ToString()
            user.foId = dtrow("foId").ToString()
            user.dicActualName = dtrow("dicActualName").ToString()
            user.dicAccountName = dtrow("dicAccountName").ToString()
            user.dicDate = String.Format(dtrow("dicDate"), "dd/MM/yy")
            user.status = dtrow("dicStatus").ToString()
            user.dicLength = CDbl(dtrow("dicLength").ToString())
            user.dicEnable = dtrow("dicEnable").ToString()
            user.dicDuplicateCheck = CBool(dtrow("dicDuplicateCheck").ToString())
            user.dicId = dtrow("dicId").ToString()
            user.mt = dtrow("MT").ToString()
            user.qc = dtrow("QC").ToString()
            user.pr = dtrow("PR").ToString()
            user.fr = dtrow("FR").ToString()

            Details.Add(user)
        Next
        Return Details.ToArray()


    End Function

    

    Public Sub Load_ddl_Dictator()
        Qry = "SELECT LTRIM(RTRIM(foID))+LTRIM(RTRIM(drID)) As UId ,drID + '  ' + drLastName + ', ' + drFirstName+ ' '+ ISNULL(drMiddleName,'') As DictatorName " _
                & "FROM  boDictator where drEnable = 1 Order by foID, drID"
        ds = Con.getDataSet(Qry)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow = dt.NewRow
        dr("UId") = "-1"
        dr("DictatorName") = "All Dictators"
        dt.Rows.InsertAt(dr, 0)
        Me.ddlDictator.DataSource = dt
        Me.ddlDictator.DataBind()
    End Sub

    Protected Sub Load_ddl_Location()
        Qry = "SELECT Distinct dicAccountName FROM boDictation Order by dicAccountName"
        ds = Con.getDataSet(Qry)
        Dim dt As DataTable = ds.Tables(0)

        Me.ddlLocation.DataTextField = "dicAccountName"
        Me.ddlLocation.DataSource = dt
        Me.ddlLocation.DataBind()

        Me.ddlLocation.Items.Insert(0, "All Accounts")
    End Sub

    Protected Sub Load_ddl_Employee()
        Qry = "SELECT empID, (empFirstName +' '+ empLastName) as empName from boEmployee where empEnable = '1' order by empName"
        ds = Con.getDataSet(Qry)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow = dt.NewRow
        dr("empID") = ""
        dr("empName") = "All Employees"
        dt.Rows.InsertAt(dr, 0)

        Me.ddlEmployee.DataTextField = "empName"
        Me.ddlEmployee.DataValueField = "empID"
        Me.ddlEmployee.DataSource = dt
        Me.ddlEmployee.DataBind()
    End Sub
    Protected Function Status(ByVal dicStatus As Int32) As String
        Select Case dicStatus
            Case 0
                dic_Status = "New"
                Exit Select
            Case 1
                dic_Status = "Processing"
                Exit Select
            Case 2
                dic_Status = "Complete"
                Exit Select
            Case 3
                dic_Status = "Gathered"
                Exit Select
            Case 4
                dic_Status = "Uploaded"
                Exit Select
            Case Else
                dic_Status = "Error"
                Exit Select
        End Select

        Return dic_Status

    End Function

    <WebMethod()> _
    Public Shared Function restore_dictations(ByVal dicIDs As String) As Boolean
        Dim dbt As New DBTaskBO()
        If dicIDs.Length > 0 Then
            Dim Qry As String = "UPDATE boDictation SET dicEnable = 1 WHERE dicID in (" & dicIDs & ");"
            dbt.saveData(Qry)
            Return True

        Else
            Return False
        End If
    End Function
    <WebMethod()> _
    Public Shared Function purge_dictations(ByVal dicIDs As String) As Boolean
        Dim dbt As New DBTaskBO()
        If dicIDs.Length > 0 Then
            Dim Qry As String = "DELETE boTranscriptionLayers where dicID in (" & dicIDs & ");"
            Qry += "DELETE boTranscription where dicID in (" & dicIDs & ");"
            Qry &= "DELETE boDictationLayers where dicID in (" & dicIDs & ");"
            Qry &= "DELETE boDictation where dicID in (" & dicIDs & ");"
            dbt.saveData(Qry)
            Return True

        Else
            Return False
        End If
    End Function
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        ds.Dispose()
        ds = Nothing
        Con = Nothing
    End Sub

    Public Class UserDetails

        Private _drId As String
        Private _foId As String
        Private _dicActualName As String
        Private _dicAccountName As String
        Private _dicDate As Object
        Private _dicLength As Double
        Private _status As String
        Private _dicEnable As String
        Private _dicDuplicateCheck As Boolean
        Private _dicId As String
        Private _mt As String
        Private _qc As String
        Private _pr As String
        Private _fr As String

        Property drId As String
            Get
                Return _drId
            End Get
            Set(value As String)
                _drId = value
            End Set
        End Property

        Property foId As String
            Get
                Return _foId
            End Get
            Set(value As String)
                _foId = value
            End Set
        End Property

        Property dicActualName As String
            Get
                Return _dicActualName
            End Get
            Set(value As String)
                _dicActualName = value
            End Set
        End Property

        Property dicAccountName As String
            Get
                Return _dicAccountName
            End Get
            Set(value As String)
                _dicAccountName = value
            End Set
        End Property

        Property dicDate As Object
            Get
                Return _dicDate
            End Get
            Set(value As Object)
                _dicDate = value
            End Set
        End Property

        Property dicLength As Double
            Get
                Return _dicLength
            End Get
            Set(value As Double)
                _dicLength = value
            End Set
        End Property

        Property status As String
            Get
                Return _status
            End Get
            Set(value As String)
                _status = value
            End Set
        End Property

        Property dicEnable As String
            Get
                Return _dicEnable
            End Get
            Set(value As String)
                _dicEnable = value
            End Set
        End Property

        Property dicDuplicateCheck As Boolean
            Get
                Return _dicDuplicateCheck
            End Get
            Set(value As Boolean)
                _dicDuplicateCheck = value
            End Set
        End Property

        Property dicId As String
            Get
                Return _dicId
            End Get
            Set(value As String)
                _dicId = value
            End Set
        End Property

        Property mt As String
            Get
                Return _mt
            End Get
            Set(value As String)
                _mt = value
            End Set
        End Property

        Property qc As String
            Get
                Return _qc
            End Get
            Set(value As String)
                _qc = value
            End Set
        End Property

        Property pr As String
            Get
                Return _pr
            End Get
            Set(value As String)
                _pr = value
            End Set
        End Property

        Property fr As String
            Get
                Return _fr
            End Get
            Set(value As String)
                _fr = value
            End Set
        End Property

            
    End Class
    
    
End Class
