Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Imports System.Web.Services
Imports System.Collections.Generic

Partial Class BO_transcriptiontools2
    Inherits System.Web.UI.Page
    Dim Qry As String
    Dim Con As New DBTaskBO
    Dim ds As New DataSet
    Protected iCounter As Int16
    Protected Flag As Boolean
    Private Shared _doc_MT As String
    Private Shared _doc_QC As String
    Private Shared _doc_PR As String
    Private Shared _doc_FR As String

    Private Shared Property Doc_MT As String
        Get
            Return _doc_MT
        End Get
        Set(value As String)
            _doc_MT = value
        End Set
    End Property

    Private Shared Property Doc_QC As String
        Get
            Return _doc_QC
        End Get
        Set(value As String)
            _doc_QC = value
        End Set
    End Property

    Private Shared Property Doc_PR As String
        Get
            Return _doc_PR
        End Get
        Set(value As String)
            _doc_PR = value
        End Set
    End Property

    Private Shared Property Doc_FR As String
        Get
            Return _doc_FR
        End Get
        Set(value As String)
            _doc_FR = value
        End Set
    End Property



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empID") = "" Then Response.Redirect(GF.Home)
        iCounter = 0
        If Not Me.IsPostBack Then
            Flag = True
            Load_ddl_Dictator()
            Load_ddl_Location()
            CPFrom.SelectedDate = Now.AddDays(-1)
            CPFrom.VisibleDate = Now.AddDays(-1)
            CpTo.SelectedDate = Now
            CpTo.VisibleDate = Now

            With ddlSorting
                .Items.Insert(0, "Dictator, Dictation Name")
                .Items.Insert(1, "Date, Dictation Name")
                .Items.Insert(2, "Dictation Name, Date")
            End With
        Else
            Flag = False
        End If
    End Sub

    Public Sub Load_ddl_Dictator()
        Qry = "SELECT (RTRIM(foID)+RTRIM(drID)) As UId ,drID + ' ' + drLastName + ', ' + drFirstName+ ' '+ ISNULL(drMiddleName,'') As DictatorName " _
                & "FROM  boDictator Order by foID, drID"
        ds = Con.getDataSet(Qry)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow = dt.NewRow
        dr("UId") = -1
        dr("DictatorName") = "All Dictators"
        dt.Rows.InsertAt(dr, 0)
        Me.ddlDictator.DataSource = dt
        Me.ddlDictator.DataBind()
    End Sub

    Protected Sub Load_ddl_Location()
        Qry = "SELECT Distinct RTRIM(dicAccountName) as dicAccountName FROM boDictation Order by dicAccountName"
        ds = Con.getDataSet(Qry)
        Dim dt As DataTable = ds.Tables(0)

        Me.ddlLocation.DataTextField = "dicAccountName"
        Me.ddlLocation.DataSource = dt
        Me.ddlLocation.DataBind()

        Me.ddlLocation.Items.Insert(0, "All Accounts")
    End Sub

    'Protected Shared Sub getTranscriptionDetail(ByVal vidicID As Int32, ByVal vitraID As Int32)
    '    Dim Con As New DBTaskBO
    '    Dim ds As DataSet
    '    Dim tran As New BO_transcriptiontools2
    '    Dim Qry As String = "SELECT boDictationLayers.empID, boDictationLayers.rolID, empFirstName +' '+ substring(empLastName,1,1) as empName, diclStatus " _
    '                        & "FROM boDictationLayers INNER JOIN boEmployee " _
    '                        & "ON boDictationLayers.empID = boEmployee.empID " _
    '                        & "INNER JOIN boDictation ON boDictationLayers.dicID = boDictation.dicID " _
    '                        & "WHERE boDictationLayers.dicID = " & vidicID & " AND dicStatus >= 0"

    '    ds = Con.getDataSet(Qry)
    '    For Each dr As DataRow In ds.Tables(0).Rows
    '        Select Case dr("rolID").trim()
    '            Case "MT"
    '                If dr("empID").ToString.Trim <> "0" Then
    '                    m_sMTName = dr("empName")
    '                Else
    '                    m_sMTName = "-"
    '                End If
    '                If dr("diclStatus") > 0 Then
    '                    m_iMTStatus = tran.getTranscritionStatus(vitraID, "MT")
    '                Else
    '                    m_iMTStatus = -1
    '                End If
    '                Select Case m_iMTStatus
    '                    Case -1
    '                        m_cMTColor = "#808080"
    '                    Case 0
    '                        m_cMTColor = "#F4BA00"
    '                    Case 1
    '                        m_cMTColor = "#7627FC"
    '                    Case 2
    '                        m_cMTColor = "#00804F"
    '                    Case Else
    '                        m_cMTColor = "#F64244"
    '                End Select
    '            Case "QC"
    '                If dr("empID").ToString.Trim <> "0" Then
    '                    m_sQCName = dr("empName")
    '                Else
    '                    m_sQCName = "-"
    '                End If
    '                If dr("diclStatus") > 0 Then
    '                    m_iQCStatus = tran.getTranscritionStatus(vitraID, "QC")
    '                Else
    '                    m_iQCStatus = -1
    '                End If
    '                Select Case m_iQCStatus
    '                    Case -1
    '                        m_cQCColor = "#808080"
    '                    Case 0
    '                        m_cQCColor = "#F4BA00"
    '                    Case 1
    '                        m_cQCColor = "#7627FC"
    '                    Case 2
    '                        m_cQCColor = "#00804F"
    '                    Case Else
    '                        m_cQCColor = "#F64244"
    '                End Select
    '            Case "PR"
    '                If dr("empID").ToString.Trim <> "0" Then
    '                    m_sPRName = dr("empName")
    '                Else
    '                    m_sPRName = "-"
    '                End If
    '                If dr("diclStatus") > 0 Then
    '                    m_iPRStatus = tran.getTranscritionStatus(vitraID, "PR")
    '                Else
    '                    m_iPRStatus = -1
    '                End If
    '                Select Case m_iPRStatus
    '                    Case -1
    '                        m_cPRColor = "#808080"
    '                    Case 0
    '                        m_cPRColor = "#F4BA00"
    '                    Case 1
    '                        m_cPRColor = "#7627FC"
    '                    Case 2
    '                        m_cPRColor = "#00804F"
    '                    Case Else
    '                        m_cPRColor = "#F64244"
    '                End Select
    '            Case "FR"
    '                If dr("empID").ToString.Trim <> "0" Then
    '                    m_sFRName = dr("empName")
    '                Else
    '                    m_sFRName = "-"
    '                End If
    '                If dr("diclStatus") > 0 Then
    '                    m_iFRStatus = tran.getTranscritionStatus(vitraID, "FR")
    '                Else
    '                    m_iFRStatus = -1
    '                End If
    '                Select Case m_iFRStatus
    '                    Case -1
    '                        m_cFRColor = "#808080"
    '                    Case 0
    '                        m_cFRColor = "#F4BA00"
    '                    Case 1
    '                        m_cFRColor = "#7627FC"
    '                    Case 2
    '                        m_cFRColor = "#00804F"
    '                    Case Else
    '                        m_cFRColor = "#F64244"
    '                End Select
    '        End Select
    '    Next
    '    ds.Dispose()
    '    ds = Nothing

    '    Con.objConnection.Close()
    '    Con = Nothing
    'End Sub

    Protected Function getTranscritionStatus(ByVal vitraID As Int32, ByVal vsrolID As String) As Int16
        Dim Con As New DBTaskBO
        Dim ds As DataSet
        Dim Qry As String = "SELECT tralStatus " _
                            & "FROM boTranscriptionLayers " _
                            & "WHERE rolID = '" & vsrolID & "' AND traID = " & vitraID

        ds = Con.getDataSet(Qry)
        If ds.Tables(0).Rows.Count > 0 Then
            getTranscritionStatus = ds.Tables(0).Rows(0).Item("tralStatus")
        Else
            getTranscritionStatus = -1
        End If

        ds.Dispose()
        ds = Nothing
        Con.objConnection.Close()
        Con = Nothing

        Return getTranscritionStatus
    End Function

    <WebMethod()> _
    Public Shared Function get_trans_details(ByVal traID As String) As String
        Try
            Dim Qry As String
            Dim Con As New MTBMS.DAL.DBTaskBO
            Dim docMT As String = "#"
            Dim docQC As String = "#"
            Dim docPR As String = "#"
            Dim docFR As String = "#"
            Qry = "SELECT * FROM boTranscription WHERE traID = '" & traID & "';SELECT * FROM boTranscriptionLayers WHERE traID = '" & traID & "'"
            Dim ds As DataSet = Con.getDataSet(Qry)

            For Each dr As DataRow In ds.Tables(1).Rows
                If dr("rolID") = "MT" Then
                    docMT = dr("tralName")
                ElseIf dr("rolID") = "QC" Then
                    docQC = dr("tralName")
                ElseIf dr("rolID") = "PR" Then
                    docPR = dr("tralName")
                ElseIf dr("rolID") = "FR" Then
                    docFR = dr("tralName")
                End If
            Next

            If docMT <> "#" Then
                Doc_MT = "<a href='../data/mt/" + docMT + "' target='_blank'>MT</a>"
            Else
                Doc_MT = "-"
            End If

            If docQC <> "#" Then
                Doc_QC = "<a href='../data/qc/" + docQC + "' target='_blank'>QC</a>"
            Else
                Doc_QC = "-"
            End If

            If docPR <> "#" Then
                Doc_PR = "<a href='../data/pr/" + docPR + "' target='_blank'>PR</a>"
            Else
                Doc_PR = "-"
            End If

            If docFR <> "#" Then
                Doc_FR = "<a href='../data/fr/" + docFR + "' target='_blank'>FR</a>"
            Else
                Doc_FR = "-"
            End If

            ds.Tables(0).TableName = "trans"
            Dim dRow As DataRow
            ds.Tables(0).Columns.Add("traCDate", Type.GetType("System.String"))
            ds.Tables(0).Columns.Add("traDoc_mt_qc_pr_fr", Type.GetType("System.String"))
            For Each dRow In ds.Tables(0).Rows

                dRow("traCDate") = Format(dRow("traClinicDate"), "dd/MM/yyyy")
                dRow("traDoc_mt_qc_pr_fr") = "<span>" + Doc_MT + " </span> | <span> " + Doc_QC + " </span> | <span>" + Doc_PR + "</span> | <span>" + Doc_FR + " </span> "


            Next
            Return ds.GetXml()
        Catch ex As Exception
            Return ex.Message().ToString()
        End Try
    End Function


    <WebMethod()> _
    Public Shared Function Load_grid_Transcription(ByVal _selected_dictator As String, ByVal _selected_account As String, ByVal sort As String, ByVal _selected_date_from As String, ByVal _selected_date_to As String, ByVal searchdication As String) As UserDetails()
        Dim Search_Dictation, L_Id, D_Id, D_Date, sSort As String

        If searchdication <> "" Then
            Search_Dictation = " AND traName like '%" & searchdication & "%' "
        Else
            Search_Dictation = ""
        End If

        If _selected_account <> "All Accounts" Then
            L_Id = " AND bo.dicAccountName = '" & _selected_account.Trim() & "'"
        Else
            L_Id = ""
        End If

        If _selected_dictator <> "-1" Then
            D_Id = " AND RTRIM(bo.foId)+RTRIM(bo.drId) ='" & _selected_dictator.Trim() & "'"
        Else
            D_Id = ""
        End If

        If _selected_date_from = Nothing And _selected_date_to = Nothing Then
            D_Date = ""
        ElseIf _selected_date_from <> Nothing And _selected_date_to = Nothing Then
            D_Date = " AND bo.dicDate= '" & _selected_date_from & "'"
        ElseIf _selected_date_to <> Nothing And _selected_date_from = Nothing Then
            D_Date = " AND bo.dicDate= '" & _selected_date_to & "'"
        Else
            D_Date = " AND bo.dicDate BETWEEN '" & Format(CDate(_selected_date_from), "MM/dd/yyyy") & "' AND '" & Format(CDate(_selected_date_to), "MM/dd/yyyy") & "'"
        End If

        If sort = "Dictator, Dictation Name" Then
            sSort = ",bo.drID,bo.dicActualName"
        ElseIf sort = "Date, Dictation Name" Then
            sSort = ",bo.dicDate,bo.dicActualName"
        ElseIf sort = "Dictation Name, Date" Then
            sSort = ",bo.dicActualName,bo.dicDate"
        End If
        Dim dt As New DataSet()
        Dim dbc As New DBTaskBO()
        Dim trans_tools As String = ""
        Dim Details As New List(Of UserDetails)()
        trans_tools = "SELECT  RTRIM(bo.drID) as drID,RTRIM(bo.foID) as foID,bo.dicActualName, bo.dicAccountName, " _
                    & " boT.traName,bo.dicDate,boT.traPatFirstName as fName " _
                    & " ,boT.traPatLastName as lName,boT.traPatientNo,boT.traStatus, bo.dicID, boT.traID ," _
                    & " ISNULL((SELECT empFirstName +' '+ substring(empLastName,1,1)+':'+Convert(varchar,diclStatus) as empName " _
                    & " FROM boDictationLayers bDL INNER JOIN boEmployee ON bDL.empID = boEmployee.empID " _
                    & " WHERE bDL.dicID = bo.dicID AND bDl.rolID='MT'),'-') as MT , " _
                    & " ISNULL((SELECT empFirstName +' '+ substring(empLastName,1,1)+':'+Convert(varchar,diclStatus) as empName " _
                    & " FROM boDictationLayers bDL INNER JOIN boEmployee ON bDL.empID = boEmployee.empID " _
                    & " WHERE bDL.dicID = bo.dicID AND bDl.rolID='QC'),'-') as QC , " _
                    & " ISNULL((SELECT empFirstName +' '+ substring(empLastName,1,1)+':'+Convert(varchar,diclStatus) as empName " _
                    & " FROM boDictationLayers bDL INNER JOIN boEmployee ON bDL.empID = boEmployee.empID " _
                    & " WHERE bDL.dicID = bo.dicID AND bDl.rolID='PR'),'-') as PR , " _
                    & " ISNULL((SELECT empFirstName +' '+ substring(empLastName,1,1)+':'+Convert(varchar,diclStatus) as empName " _
                    & " FROM boDictationLayers bDL INNER JOIN boEmployee ON bDL.empID = boEmployee.empID " _
                    & " WHERE bDL.dicID = bo.dicID AND bDl.rolID='FR'),'-') as FR " _
                    & " FROM boTranscription boT " _
                    & " INNER JOIN boDictation bo ON boT.dicID = bo.dicID and bo.dicStatus >= 0 " _
                    & " Where bo.dicEnable = '1' " & Search_Dictation & D_Id & L_Id & D_Date & " ORDER BY bo.foID " & sSort
        'trans_tools = "SELECT  boDictation.drID,boDictation.foID,boDictation.dicActualName, " _
        '        & "boTranscription.traName,boDictation.dicDate,boTranscription.traPatFirstName as fName, " _
        '        & "boTranscription.traPatLastName as lName,boTranscription.traPatientNo,boTranscription.traStatus, " _
        '        & "boDictation.dicID, boTranscription.traID " _
        '        & "FROM boTranscription INNER JOIN boDictation ON boTranscription.dicID = boDictation.dicID " _
        '        & "Left Outer JOIN dbo.boLocation ON dbo.boTranscription.locID = dbo.boLocation.locID " _
        '        
        dt = dbc.getDataSet(trans_tools)
        For Each dtrow As DataRow In dt.Tables(0).Rows
            Dim user As New UserDetails()
            user.drID = dtrow("drID").ToString()
            user.foID = dtrow("foID").ToString()
            user.dicActualName = dtrow("dicActualName").ToString()
            user.dicAccountName = dtrow("dicAccountName").ToString()
            user.traName = dtrow("traName").ToString()
            user.dicDate = String.Format(dtrow("dicDate"), "dd/MM/yy")
            user.fName = dtrow("fName").ToString()
            user.lName = dtrow("lName").ToString()
            user.traPatientNo = dtrow("traPatientNo").ToString()
            user.traStatus = CBool(dtrow("traStatus").ToString())
            user.dicID = dtrow("dicID").ToString()
            user.traID = dtrow("traID").ToString()
            user.mt = dtrow("MT").ToString()
            user.qc = dtrow("QC").ToString()
            user.pr = dtrow("PR").ToString()
            user.fr = dtrow("FR").ToString()

            Details.Add(user)
        Next
        Return Details.ToArray()

    End Function
    Protected Function getPatientName(ByVal patFirstName As String, ByVal patLastName As String) As String
        If patFirstName = "" And patLastName = "" Then
            getPatientName = ""
        ElseIf patLastName = "" Then
            getPatientName = patFirstName
        ElseIf patFirstName = "" Then
            getPatientName = patLastName
        Else
            getPatientName = patLastName & ", " & patFirstName
        End If
    End Function
    Public Class UserDetails

        Private _mt As String
        Private _qc As String
        Private _pr As String
        Private _fr As String

        Public Property drID() As String
            Get
                Return trans_drID
            End Get
            Set(ByVal value As String)
                trans_drID = value
            End Set
        End Property
        Private trans_drID As String
        Public Property foID() As String
            Get
                Return trans_foID
            End Get
            Set(ByVal value As String)
                trans_foID = value
            End Set
        End Property
        Private trans_foID As String
        Public Property dicActualName() As String
            Get
                Return trans_dicActualName
            End Get
            Set(ByVal value As String)
                trans_dicActualName = value
            End Set
        End Property
        Private trans_dicActualName As String

        Public Property dicAccountName() As String
            Get
                Return trans_dicAccountName
            End Get
            Set(ByVal value As String)
                trans_dicAccountName = value
            End Set
        End Property
        Private trans_dicAccountName As String

        Public Property traName() As String
            Get
                Return trans_traName
            End Get
            Set(ByVal value As String)
                trans_traName = value
            End Set
        End Property
        Private trans_traName As String
        Public Property dicDate() As String
            Get
                Return trans_dicDate
            End Get
            Set(ByVal value As String)
                trans_dicDate = value
            End Set
        End Property
        Private trans_dicDate As String
        Public Property fName() As String
            Get
                Return trans_fName
            End Get
            Set(ByVal value As String)
                trans_fName = value
            End Set
        End Property
        Private trans_fName As String
        Public Property lName() As String
            Get
                Return trans_lName
            End Get
            Set(ByVal value As String)
                trans_lName = value
            End Set
        End Property
        Private trans_lName As String
        Public Property traPatientNo() As String
            Get
                Return trans_traPatientNo
            End Get
            Set(ByVal value As String)
                trans_traPatientNo = value
            End Set
        End Property
        Private trans_traPatientNo As String
        Public Property traStatus() As Boolean
            Get
                Return trans_traStatus
            End Get
            Set(ByVal value As Boolean)
                trans_traStatus = value
            End Set
        End Property
        Private trans_traStatus As Boolean
        Public Property dicID() As String
            Get
                Return trans_dicID
            End Get
            Set(ByVal value As String)
                trans_dicID = value
            End Set
        End Property
        Private trans_dicID As String
        Public Property traID() As String
            Get
                Return trans_traID
            End Get
            Set(ByVal value As String)
                trans_traID = value
            End Set
        End Property
        Private trans_traID As String

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
