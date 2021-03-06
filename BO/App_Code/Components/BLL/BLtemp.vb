Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Imports System.IO
Imports System.Web

Public Class BLtemp
    Inherits System.Web.UI.Page
    Private m_sNext_Layer As String
    Private m_sPrevious_Layer As String
    Private Const m_sRouteSC As String = "SC"
    Private Const m_sRouteCS As String = "CS"
    Private _oFile As FileUpload
    Dim m_stempType As String
    Dim m_stempExtension As String

    Private Open_Transcription_Name, _Generate_Transcription, TranscriptionCount_MT As String
    Private _DicID As Long
    Private _TempID As Long
    Private _PFname, _PLname, _PatientNo, _NHSNo, _RolID, _DicFName, _FileName, _ServerFile As String
    Private _empID, _TraName, _Remarks As String
    Private _Tag As Boolean
    Private _Urgent As Boolean
    Private _drID As String
    Private _foID As String
    Private Qry As String
    Private con As New DBTaskBO
    Private ds As New DataSet
    Private _RemoteAddress As String
    Private traNameFile, tempNameFile As String
    Private _dicActualName As String
    Private _dicDate As Date
    Dim flag As Boolean
    Private _TraId As Long

    Private _traSubject As String
    Private _traDear As String
    Private _traClinicDate As Date
    Private _traDOB As Date
    Private _traClinicReference As String
    Private _traNTS As String
    Private _traNTD As String
    Private _traRecipientAddress As String
    Private _traFooterBlock As String

    Public Property traFooterBlock() As String
        Get
            Return _traFooterBlock
        End Get
        Set(ByVal value As String)
            _traFooterBlock = value
        End Set
    End Property

    Public Property traRecipientAddress() As String
        Get
            Return _traRecipientAddress
        End Get
        Set(ByVal value As String)
            _traRecipientAddress = value
        End Set
    End Property

    Public Property traNTD() As String
        Get
            Return _traNTD
        End Get
        Set(ByVal value As String)
            _traNTD = value
        End Set
    End Property

    Public Property traNTS() As String
        Get
            Return _traNTS
        End Get
        Set(ByVal value As String)
            _traNTS = value
        End Set
    End Property

    Public Property traClinicReference() As String
        Get
            Return _traClinicReference
        End Get
        Set(ByVal value As String)
            _traClinicReference = value
        End Set
    End Property

    Public Property traDOB() As Date
        Get
            Return _traDOB
        End Get
        Set(ByVal value As Date)
            _traDOB = value
        End Set
    End Property

    Public Property traClinicDate() As Date
        Get
            Return _traClinicDate
        End Get
        Set(ByVal value As Date)
            _traClinicDate = value
        End Set
    End Property

    Public Property traDear() As String
        Get
            Return _traDear
        End Get
        Set(ByVal value As String)
            _traDear = value
        End Set
    End Property

    Public Property traSubject() As String
        Get
            Return _traSubject
        End Get
        Set(ByVal value As String)
            _traSubject = value
        End Set
    End Property

    Public Property TraId() As Long
        Get
            Return _TraId
        End Get
        Set(ByVal value As Long)
            _TraId = value
        End Set
    End Property

    Public Property dicActualName() As String
        Get
            Return _dicActualName
        End Get
        Set(ByVal value As String)
            _dicActualName = value
        End Set
    End Property

    Public Property dicDate() As Date
        Get
            Return _dicDate
        End Get
        Set(ByVal value As Date)
            _dicDate = value
        End Set
    End Property

    Public Property TraName() As String
        Get
            Return _TraName
        End Get
        Set(ByVal value As String)
            _TraName = value
        End Set
    End Property

    Public Property ServerFile() As String
        Get
            Return _ServerFile
        End Get
        Set(ByVal value As String)
            _ServerFile = value
        End Set
    End Property

    Public Property DicID() As Long
        Get
            Return _DicID
        End Get
        Set(ByVal value As Long)
            _DicID = value
        End Set
    End Property

    Public Property TempID() As Long
        Get
            Return _TempID
        End Get
        Set(ByVal value As Long)
            _TempID = value
        End Set
    End Property

    Public Property PFname() As String
        Get
            Return _PFname
        End Get
        Set(ByVal value As String)
            _PFname = value
        End Set
    End Property

    Public Property PLname() As String
        Get
            Return _PLname
        End Get
        Set(ByVal value As String)
            _PLname = value
        End Set
    End Property

    Public Property PatientNo() As String
        Get
            Return _PatientNo
        End Get
        Set(ByVal value As String)
            _PatientNo = value
        End Set
    End Property

    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property

    Public Property NHSNo() As String
        Get
            Return _NHSNo
        End Get
        Set(ByVal value As String)
            _NHSNo = value
        End Set
    End Property

    Public Property Urgent() As Boolean
        Get
            Return _Urgent
        End Get
        Set(ByVal value As Boolean)
            _Urgent = value
        End Set
    End Property

    Public Property drID() As String
        Get
            Return _drID
        End Get
        Set(ByVal value As String)
            _drID = value
        End Set
    End Property

    Public Property foID() As String
        Get
            Return _foID
        End Get
        Set(ByVal value As String)
            _foID = value
        End Set
    End Property

    Public Property empID() As String
        Get
            Return _empID
        End Get
        Set(ByVal value As String)
            _empID = value
        End Set
    End Property

    Public Property RolID() As String
        Get
            Return _RolID
        End Get
        Set(ByVal value As String)
            _RolID = value
        End Set
    End Property

    Public Property RemoteAddres() As String
        Get
            Return _RemoteAddress
        End Get
        Set(ByVal value As String)
            _RemoteAddress = value
        End Set
    End Property

    Public Property DicFName() As String
        Get
            Return _DicFName
        End Get
        Set(ByVal value As String)
            _DicFName = value
        End Set
    End Property

    Public Property FileName() As String
        Get
            Return _FileName
        End Get
        Set(ByVal value As String)
            _FileName = value
        End Set
    End Property

    Public Property Tag() As Boolean
        Get
            Return _Tag
        End Get
        Set(ByVal value As Boolean)
            _Tag = value
        End Set
    End Property

    Public WriteOnly Property BrowseFile() As FileUpload
        Set(ByVal value As FileUpload)
            Me._oFile = value
        End Set
    End Property

    Public Function Generate_Transcription() As String

        Qry = "SELECT temTempName, temType, temExtension FROM boTemplates WHERE temID = " & _TempID
        ds = con.getDataSet(Qry)
        Dim tempName As String = ds.Tables(0).Rows(0).Item("temTempName")
        m_stempType = ds.Tables(0).Rows(0).Item("temType")
        m_stempExtension = ds.Tables(0).Rows(0).Item("temExtension")

        Dim traName As String = Transcription_Name()
        If Not _oFile Is Nothing Then
            If Copy_File(m_sRouteSC, tempName, traName, "Yes") = True Then
                If Open_TranscriptionDB(traName) = True Then
                    _Generate_Transcription = traName
                    DicFName = traName
                Else
                    _Generate_Transcription = ""
                End If
            Else
                _Generate_Transcription = ""
            End If
        Else
            If Copy_File(m_sRouteSC, tempName, traName) = True Then
                If Open_TranscriptionDB(traName) = True Then
                    _Generate_Transcription = traName
                    DicFName = traName
                Else
                    _Generate_Transcription = ""
                End If
            Else
                _Generate_Transcription = ""
            End If
        End If

        Return _Generate_Transcription
    End Function

    Public Function Open_Transcription() As String
        If Copy_File(m_sRouteSC, _TraName, _TraName) = True Then
            If Open_TranscriptionDB(TraName) = True Then
                Open_Transcription_Name = TraName
                DicFName = TraName
            Else
                Open_Transcription_Name = ""
            End If
        Else
            Open_Transcription_Name = ""
        End If
        Return Open_Transcription_Name
    End Function

    Public Function Transcription_Name() As String
        Qry = "SELECT foId, drId, dicActualName, dicDate FROM boDictation " _
              & "WHERE dicId = " & _DicID
        ds = con.getDataSet(Qry)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim str As String = ds.Tables(0).Rows(0).Item("dicActualName").ToString
            str = str.Substring(0, str.IndexOf("."))
            Transcription_Name = ds.Tables(0).Rows(0).Item("foId") & ds.Tables(0).Rows(0).Item("drId") & "_" _
                                 & str & "_" & _PLname & "-" _
                                 & _PFname & "_" & Format(ds.Tables(0).Rows(0).Item("dicDate"), ("MMddyy")) & "-" _
                                 & Format(System.DateTime.Now, ("ssff")) & ".doc"
        Else
            Transcription_Name = ""
        End If
        Return Transcription_Name
    End Function

    Private Function Copy_File(ByVal vsRoute As String, ByVal sourceFile As String, ByVal destinationFile As String, Optional ByVal bFileName As String = Nothing) As Boolean
        If bFileName = Nothing Then
            If sourceFile = "" Or destinationFile = "" Then Return False
            Dim sFolderName As String
            Dim sourcePath, destinationPath As String
            Try
                If vsRoute = m_sRouteSC Then
                    Select Case _RolID
                        Case "MT"
                            sFolderName = "Templates\"
                        Case "QC"
                            sFolderName = "MT\"
                        Case "PR"
                            If _Tag Then
                                sFolderName = "QC\"
                            Else
                                Qry = "SELECT tralName FROM boTranscriptionLayers " _
                                      & "WHERE traID = " & _TraId & " AND rolID = 'QC'"
                                ds = con.getDataSet(Qry)
                                If ds.Tables(0).Rows.Count > 0 Then
                                    sFolderName = "QC\"
                                Else
                                    sFolderName = "MT\"
                                End If
                            End If
                        Case "FR"
                            If _Tag Then
                                sFolderName = "PR\"
                            Else
                                Qry = "SELECT tralName FROM boTranscriptionLayers " _
                                      & "WHERE traID = " & _TraId & " AND  rolID = 'PR'"
                                ds = con.getDataSet(Qry)
                                If ds.Tables(0).Rows.Count > 0 Then
                                    sFolderName = "PR\"
                                Else
                                    Qry = "SELECT tralName FROM boTranscriptionLayers " _
                                          & "WHERE traID = " & _TraId & " AND rolID = 'QC'"
                                    ds = con.getDataSet(Qry)
                                    If ds.Tables(0).Rows.Count > 0 Then
                                        sFolderName = "QC\"
                                    Else
                                        sFolderName = "MT\"
                                    End If
                                End If
                            End If
                    End Select
                    If sFolderName = "Templates\" Then
                        sourcePath = Server.MapPath("..\Data\" + _foID + _drID + "\" + sFolderName + sourceFile)
                    Else
                        sourcePath = Server.MapPath("..\Data\" + sFolderName + sourceFile)
                    End If
                    destinationPath = "\\" + _RemoteAddress + "\" + "D$\System\" + _empID + "\" + destinationFile.Substring(destinationFile.Length - 15, 6).ToString
                    FileName = destinationPath & "\"
                ElseIf vsRoute = m_sRouteCS Then
                    sourcePath = "\\" & _RemoteAddress & "\" & "D$\System\" & _empID & "\" & sourceFile.Substring(sourceFile.Length - 15, 6).ToString & "\" & sourceFile
                    destinationPath = Server.MapPath("..\Data\" & _RolID)
                End If
                System.IO.Directory.CreateDirectory(destinationPath)
                'System.IO.File.Copy(sourcePath, destinationPath & "\" & destinationFile, True)
                My.Computer.FileSystem.CopyFile(sourcePath, destinationPath & "\" & destinationFile, True)
                Return True
            Catch ex As Exception
                Throw New Exception("Unable to create directory:")
            End Try

        Else
            Try
                Dim destinationPath As String = "\\" + _RemoteAddress + "\" + "D$\System\" + _empID + "\" + destinationFile.Substring(destinationFile.Length - 15, 6).ToString
                System.IO.Directory.CreateDirectory(destinationPath)
                _oFile.SaveAs(destinationPath & "\" & destinationFile)
                Return True
            Catch ex As Exception
                Throw New Exception("Unable to create directory:")
            End Try
        End If
    End Function

    Public Function Open_TranscriptionDB(ByVal traName As String) As String 'Return True or False When Transcription is Open
        Dim SQLCon As New SqlConnection(Me.ConnectionString())
        Dim Cmd As SqlCommand
        SQLCon.Open()
        Dim MyTran As SqlTransaction = SQLCon.BeginTransaction()

        Dim returnID As Long = 0

        Try
            If _RolID = "MT" Then
                Qry = "INSERT INTO boTranscription (dicID, traName, traPatFirstName, traPatLastName,traPatientNo, traCharacters, traTag,traStatus,traRemarks,traType,traExtension) " _
                      & " VALUES (" & _DicID & " ,'" & traName & "','" & _PFname & "','" & _PLname & "','" & _PatientNo & "','-1','0','0','','R','doc');  SELECT @@IDENTITY AS 'traID';"

                Cmd = New SqlCommand(Qry, SQLCon, MyTran)
                returnID = Cmd.ExecuteScalar()

                Qry = "INSERT INTO boTranscriptionLayers (dicID,traID,empID,rolID,tralName,tralDownDateTime,traTag,tralStatus) " _
                      & "VALUES (" & _DicID & ", @@Identity ,'" & _empID & "','" & _RolID & "','" & traName & "','" & Format(System.DateTime.Now, "MM/dd/yyyy HH:mm:ss") & "','0','1');"
                Cmd = New SqlCommand(Qry, SQLCon, MyTran)
                Cmd.ExecuteNonQuery()

                Qry = "UPDATE boDictation SET dicStatus = 1, dicTranscriptions = dicTranscriptions + 1 WHERE dicID=" & _DicID & ";"
                Cmd = New SqlCommand(Qry, SQLCon, MyTran)
                Cmd.ExecuteNonQuery()
            Else
                Qry = "SELECT diclTranscriptions From boDictationLayers WHERE dicId = '" & _DicID & "' " _
                      & "AND rolId = 'MT' AND diclStatus = 3"
                Cmd = New SqlCommand(Qry, SQLCon, MyTran)
                Dim MT_Transcriptions As String = Cmd.ExecuteScalar()
                If Not MT_Transcriptions = "" Then
                    If _RolID = "PR" Then
                        Dim QC_Transcriptions As String = Count_Transcriptions("QC")
                        If MT_Transcriptions = QC_Transcriptions Then
                            Qry = "UPDATE boDictationLayers SET diclStatus=3 WHERE RolId='QC' " _
                                  & "AND dicId='" & _DicID & "' AND empID='" & _empID & "';"
                            Cmd = New SqlCommand(Qry, SQLCon, MyTran)
                            Cmd.ExecuteNonQuery()
                        End If
                    ElseIf _RolID = "FR" Then
                        Dim PR_Transcriptions As String = Count_Transcriptions("PR")
                        If MT_Transcriptions = PR_Transcriptions Then
                            Qry = "UPDATE boDictationLayers SET diclStatus=3 Where RolId IN('PR','QC') " _
                                  & "AND dicId='" & _DicID & "' AND empID='" & _empID & "';"
                            Cmd = New SqlCommand(Qry, SQLCon, MyTran)
                            Cmd.ExecuteNonQuery()
                        End If
                    End If
                End If

                Qry = "UPDATE boTranscriptionLayers SET tralDownDateTime = '" & Format(System.DateTime.Now, "MM/dd/yyyy HH:mm:ss") & "', " _
                       & "tralStatus=1 WHERE traId=" & _TraId & " AND empId= '" & _empID & "' AND rolId='" & _RolID & "';"
                Cmd = New SqlCommand(Qry, SQLCon, MyTran)
                Cmd.ExecuteNonQuery()
            End If

            Dim diclStart As String
            Qry = "SELECT diclStatus FROM boDictationLayers WHERE dicId=" & _DicID & " AND rolId='" & _RolID & "'"
            Cmd = New SqlCommand(Qry, SQLCon, MyTran)
            If Cmd.ExecuteScalar() = 1 Then
                diclStart = ", diclStart = '" & Format(System.DateTime.Now, "MM/dd/yyyy HH:mm:ss") & "'"
            Else
                diclStart = ""
            End If

            Qry = "UPDATE boDictationLayers SET diclStatus = 2 " & diclStart _
                   & " WHERE dicID=" & _DicID & " AND empID='" & _empID & "' AND rolID='" & _RolID & "'"
            Cmd = New SqlCommand(Qry, SQLCon, MyTran)
            Cmd.ExecuteNonQuery()

            If _RolID <> "MT" AndAlso _RolID <> "QC" Then
                If _RolID = "FR" Then
                    Qry = "UPDATE boDictationLayers SET diclStatus = 3 WHERE dicId=" & _DicID & " AND rolID='QC' AND diclSkip = 1 AND diclStatus = 1"
                    Cmd = New SqlCommand(Qry, SQLCon, MyTran)
                    Cmd.ExecuteNonQuery()

                    Qry = "UPDATE boDictationLayers SET diclStatus = 3 WHERE dicId=" & _DicID & " AND rolID='PR' AND diclSkip = 1 AND diclStatus = 1"
                    Cmd = New SqlCommand(Qry, SQLCon, MyTran)
                    Cmd.ExecuteNonQuery()
                ElseIf _RolID = "PR" Then
                    Qry = "UPDATE boDictationLayers SET diclStatus = 3 WHERE dicId=" & _DicID & " AND rolID='QC' AND diclSkip = 1 AND diclStatus = 1"
                    Cmd = New SqlCommand(Qry, SQLCon, MyTran)
                    Cmd.ExecuteNonQuery()
                End If

                MyTran.Commit()
                Open_TranscriptionDB = returnID
            Else
                MyTran.Commit()
                Open_TranscriptionDB = returnID
            End If
        Catch ex As Exception
            MyTran.Rollback()
            Open_TranscriptionDB = -1 'ex.Message & " " & sStep
        Finally
            SQLCon.Close()
        End Try
    End Function

    Private Function Count_Transcriptions(ByVal rol_Id As String) As String
        Qry = "SELECT diclTranscriptions from boDictationLayers Where rolID='" & rol_Id & "' " _
            & "and dicId=" & _DicID & " AND empID='" & _empID & "'"
        Return con.getScalar(Qry)
    End Function

    Public Function Return_Transcriptions() As DataSet ' Return DataSet To Load a Grid
        Qry = "SELECT bT.traId,bT.traPatFirstName, bT.traPatLastName, bT.traPatientNo, isnull(bT.traNHSNo,'') AS traNHSNo, bT.traName, bT.traTag, bT.traIncomplete, isnull(bTL.tralRemarks,'') AS tralRemarks, bTL.tralDownDateTime, bTL.tralStatus " _
            & "FROM boTranscription bT " _
            & "INNER JOIN  boTranscriptionLayers bTL ON bT.traID = bTL.traID " _
            & "WHERE bT.dicID = " & _DicID & " AND bTL.empID = '" & _empID & "' and bTL.rolID='" & _RolID & "'"

        ds = con.getDataSet(Qry)
        Return ds
    End Function

    Public Function Remove_Transcriptions() As Boolean
        Qry = "UPDATE boDictation SET dicTranscriptions=dicTranscriptions-1   WHERE dicid=" & _DicID & ";"
        Qry += "UPDATE boDictation SET dicStatus=0  WHERE dicid='" & _DicID & "' and dicTranscriptions='0';"
        Qry += "DELETE FROM boTranscriptionLayers WHERE dicID=" & _DicID & " AND traID='" & _TraId & "' AND rolID='" & _RolID & "';"
        Qry += "DELETE FROM boTranscription WHERE dicID=" & _DicID & " and traID='" & _TraId & "'"
        If con.update(Qry) = True Then
            If con.getScalar("SELECT dicTranscriptions FROM boDictation WHERE dicID=" & _DicID) = 0 Then
                'If con.getScalar("SELECT diclTranscriptions FROM boDictationLayers WHERE dicID=" & _DicID) > 0 Then
                Qry = "UPDATE boDictationLayers SET diclTranscriptions = 0, diclStatus=1 WHERE dicID=" & _DicID & " and rolID='" & _RolID & "';"
                'End If
                If con.update(Qry) = True Then
                    Return True
                End If
            End If
            Return True
        Else
            Return False
        End If
    End Function

    'Public Function Submit_Transcription() As Boolean
    '    Dim SQLCon As New SqlConnection(Me.ConnectionString())
    '    Dim Cmd As SqlCommand
    '    SQLCon.Open()
    '    'Dim MyTran As SqlTransaction = SQLCon.BeginTransaction()

    '    Dim sNotIN As String = ""

    '    Qry = "UPDATE boTranscriptionLayers SET tralName='" & _TraName & "', " _
    '          & "tralUpDateTime='" & Format(System.DateTime.Now, "MM/dd/yyyy HH:mm:ss") & "',tralStatus=2,traTag=" & IIf(_Tag, 1, 0) & ", " _
    '          & "tralRemarks='" & Remarks & "' where traId=" & _TraId & " and rolID='" & _RolID & "';"

    '    Dim tag_ As String
    '    If _Tag Then
    '        tag_ = ", dicLTag = 1"
    '    Else
    '        tag_ = ""
    '    End If
    '    Qry += "UPDATE boDictationLayers SET diclTranscriptions=diclTranscriptions+1 " _
    '                & tag_ & " WHERE dicID=" & _DicID _
    '                & "AND rolID='" & _RolID & "';"
    '    Cmd = New SqlCommand(Qry, SQLCon)
    '    Cmd.ExecuteNonQuery()

    '    Qry = "SELECT diclTranscriptions From boDictationLayers WHERE dicId = '" & _DicID & "' AND rolId = 'MT' AND diclStatus = 3"
    '    Cmd = New SqlCommand(Qry, SQLCon)
    '    Dim MT_Transcriptions As String = Cmd.ExecuteScalar()
    '    Dim bDictationComplete As Boolean = False

    '    If Not MT_Transcriptions = "" Then
    '        Dim Check_Transcriptions As String = Count_Transcriptions(_RolID)

    '        If MT_Transcriptions = Check_Transcriptions Then
    '            Qry = "UPDATE boDictationLayers SET diclStatus=3 WHERE RolId='" & _RolID & "' " _
    '                  & "AND dicId='" & _DicID & "' AND empID='" & _empID & "';"
    '            Cmd = New SqlCommand(Qry, SQLCon)
    '            Cmd.ExecuteNonQuery()

    '            bDictationComplete = True
    '        End If
    '    End If

    '    Dim traStatus As String

    '    If Not Assign_To_Next_Layer(_RolID) Then
    '        System.IO.Directory.CreateDirectory(Server.MapPath("../" & "Data\" & _foID & _drID & "\" & "Transcriptions"))
    '        System.IO.File.Copy(Source_Address() & _TraName, Server.MapPath("../" & "Data\" & _foID & _drID & "\" + "Transcriptions\" & _ServerFile), True)

    '        If bDictationComplete Then
    '            Qry = "UPDATE boDictation SET boDictation.dicStatus = 2 WHERE dicID=" & _DicID
    '            Cmd = New SqlCommand(Qry, SQLCon)
    '            Cmd.ExecuteNonQuery()
    '        End If

    '        traStatus = 1
    '    Else
    '        traStatus = 0
    '    End If

    '    Qry = "update boTranscription set traName='" & _TraName & "',traPatFirstName='" & _PFname & "',traPatLastName='" & _PLname & "',traPatientNo='" & _PatientNo & "',traNHSNo='" & _NHSNo & "',traSubject='" & _traSubject & "',traDear='" & _traDear & "',traClinicDate='" & Format(_traClinicDate, "MM/dd/yyyy") & "',traDOB='" & Format(_traDOB, "MM/dd/yyyy") & "',traClinicReference='" & _traClinicReference & "',traNTS='" & _traNTS & "',traNTD='" & _traNTD & "',traRecipientAddress='" & _traRecipientAddress & "',traFooterBlock='" & _traFooterBlock & "',traTag=" & IIf(_Tag, 1, 0) & ",traIncomplete=" & IIf(_Urgent, 1, 0) & ",traRemarks='" & _Remarks & "',traStatus='" & traStatus & "' where traId=" & _TraId
    '    If con.update(Qry) <> 0 Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    'Public Function Assign_To_Next_Layer(ByVal rolID As String) As Boolean
    '    Dim EmpID As String
    '    If rolID = "MT" Then
    '        m_sNext_Layer = "QC"
    '    ElseIf rolID = "QC" Then
    '        m_sNext_Layer = "PR"
    '    ElseIf rolID = "PR" Then
    '        m_sNext_Layer = "FR"
    '    Else
    '        Return False
    '        Exit Function
    '    End If
    '    Qry = "Select diclSkip,empID from boDictationLayers  where dicID=" & _DicID & " and rolID='" & m_sNext_Layer & "'"
    '    ds = con.getDataSet(Qry)
    '    Dim diclSkip As Long = ds.Tables(0).Rows(0)("diclSkip")
    '    EmpID = ds.Tables(0).Rows(0)("empId")

    '    If _Tag Then
    '        If diclSkip = 0 Then
    '            Qry = "Update boDictationLayers set diclStatus=1,diclTag=1 where dicID=" & _DicID & " and rolID='" & m_sNext_Layer & "'"
    '            con.update(Qry)
    '        Else
    '            Qry = "select empID from boDictatorLayers where drID='" & _drID & "' and foID='" & _foID & "' and rolID='" & m_sNext_Layer & "'"
    '            EmpID = con.getScalar(Qry)
    '            If EmpID.Trim = "0" Then
    '                Qry = "select teamParent from boTeamPlayers where empID='" & _empID & "' and rolID='" & _RolID & "'"
    '                EmpID = con.getScalar(Qry)
    '                If EmpID.Trim <> "0" Then
    '                    Qry = "update boDictationLayers set empID='" & EmpID & "',diclStatus=1 ,diclTag=1 where dicID=" & _DicID & " and rolID='" & m_sNext_Layer & "'"
    '                    con.update(Qry)
    '                End If
    '            Else
    '                Qry = "update boDictationLayers set empID='" & EmpID & "',diclStatus=1 ,diclTag=1 where dicID=" & _DicID & " and rolID='" & m_sNext_Layer & "'"
    '                con.update(Qry)
    '            End If
    '        End If
    '        Qry = "INSERT INTO boTranscriptionLayers (dicID,traID,empID,rolID,tralName,tralRemarks,traTag,tralStatus) VALUES (" & _DicID & "," & _TraId & ",'" & EmpID & "','" & m_sNext_Layer & "','" & _TraName & "','" & _Remarks & "',1,0)"
    '        con.update(Qry)
    '        flag = True
    '    Else
    '        If diclSkip = 0 Then
    '            flag = True
    '            Qry = "UPDATE boDictationLayers set diclStatus=1 where dicID=" & _DicID & " and rolID='" & m_sNext_Layer & "';"
    '            Qry += "INSERT INTO boTranscriptionLayers (dicID,traID,empID,rolID,tralName,tralRemarks,traTag,tralStatus) " _
    '                & "VALUES (" & _DicID & "," & _TraId & ",'" & EmpID & "','" & m_sNext_Layer & "','" & _TraName & "','" & _Remarks & "',0,0)"
    '            con.update(Qry)

    '        Else
    '            flag = False
    '            Qry = "SELECT diclStatus from boDictationLayers WHERE dicID=" & _DicID & " AND rolID='" & m_sNext_Layer & "'"
    '            Dim diclStatus_ As String
    '            If con.getScalar(Qry) = 0 Then
    '                diclStatus_ = " diclStatus=1, "
    '            Else
    '                diclStatus_ = ""
    '            End If
    '            Qry = "UPDATE boDictationLayers SET " & diclStatus_ & "diclTranscriptions=diclTranscriptions+1,diclTag=0" _
    '                  & " WHERE dicID=" & _DicID & " AND rolID='" & m_sNext_Layer & "'"
    '            con.update(Qry)
    '        End If
    '    End If
    '    If flag = False AndAlso m_sNext_Layer <> "FR" Then
    '        Assign_To_Next_Layer(m_sNext_Layer)
    '    End If
    '    Return flag
    'End Function

    Public Function Submit_Transcription(ByVal remarks As String, _
                                         ByVal locID As String, _
                                         ByVal cbxincstatus As String, _
                                         ByVal traClinicDateDay As String, _
                                         ByVal traClinicDateMonth As String, _
                                         ByVal traClinicDateYear As String, _
                                         ByVal traDOBDay As String, _
                                         ByVal traDOBMonth As String, _
                                         ByVal traDOBYear As String) As Boolean
        'Dim NowDateTime As Date
        Dim sNotIN As String
        'NowDateTime = Now.Date
        'NowDateTime += Now.TimeOfDay

        Qry = "UPDATE boTranscriptionLayers SET tralName='" & _TraName & "', locID='" & locID & "' , " _
              & "tralUpDateTime='" & Format(System.DateTime.Now, "MM/dd/yyyy HH:mm:ss") & "',tralStatus=2,traTag='" & IIf(_Tag, 1, 0) & "', " _
              & "tralRemarks='" & remarks & "' where traId=" & _TraId & " and rolID='" & _RolID & "';"

        Dim tag_ As String = ""

        If _Tag Then
            tag_ = ", dicLTag = 1"
        Else
            tag_ = ""
        End If
        Qry += "UPDATE boDictationLayers SET diclTranscriptions=diclTranscriptions+1 " _
                    & tag_ & " WHERE dicID=" & _DicID _
                    & "AND rolID='" & _RolID & "';"

        Dim Query As String = Qry
        Dim StatusTra As String

        If Not Assign_To_Next_Layer(_RolID, locid, remarks) Then
            System.IO.Directory.CreateDirectory(Server.MapPath("../" & "Data\" & _foID & _drID & "\" & "Transcriptions"))
            System.IO.File.Copy(Server.MapPath("../" & "Data\" & _RolID & "\" & _TraName), Server.MapPath("../" & "Data\" & _foID & _drID & "\" + "Transcriptions\" & _TraName), True)

            If _RolID <> "FR" Then
                Select Case _RolID
                    Case "MT"
                        sNotIN = "NOT IN ('MT')"
                    Case "QC"
                        sNotIN = "NOT IN ('MT','QC')"
                    Case "PR"
                        sNotIN = "NOT IN ('MT','QC','PR')"
                End Select

                con.update("UPDATE boDictationLayers SET diclStatus = 2 " _
                         & " WHERE dicID = " & _DicID _
                         & "AND rolID " & sNotIN)
            End If

            StatusTra = 1
        Else
            StatusTra = 0
        End If

        Qry = "update boTranscription set traName='" & _TraName & "',traPatFirstName='" & _PFname & "',traPatLastName='" & _PLname & "',traPatientNo='" _
                & _PatientNo & "',traNHSNo='" & _NHSNo & "',traSubject='" & _traSubject & "',traDear='" & _traDear & "',traClinicDate='" _
                & Format(_traClinicDate, "MM/dd/yyyy") & "',traDOB='" & Format(_traDOB, "MM/dd/yyyy") & "',traClinicReference='" & _traClinicReference _
                & "',traNTS='" & _traNTS & "',traNTD='" & _traNTD & "',traRecipientAddress='" & _traRecipientAddress & "',traFooterBlock='" & _traFooterBlock _
                & "',traTag=" & IIf(_Tag, 1, 0) & ",traIncomplete=" & IIf(_Urgent, 1, 0) & ",traRemarks='" & _Remarks & "',traStatus='" & StatusTra _
                & "',traClinicDateDay='" & traClinicDateDay & "',traClinicDateMonth='" & traClinicDateMonth & "',traClinicDateYear='" & traClinicDateYear _
                & "',traDOBDay='" & traDOBDay & "',traDOBMonth='" & traDOBMonth & "',traDOBYear='" & traDOBYear _
                & "' where traId=" & _TraId

        Qry = Query + Qry

        If con.update(Qry) <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Assign_To_Next_Layer(ByVal Rol_Id As String, ByVal slocID As String, ByVal sRemarks As String) As Boolean
        Dim EmpID As String
        If Rol_Id = "MT" Then
            m_sNext_Layer = "QC"
        ElseIf Rol_Id = "QC" Then
            m_sNext_Layer = "PR"
        ElseIf Rol_Id = "PR" Then
            m_sNext_Layer = "FR"
        Else
            Return False
            Exit Function
        End If
        Qry = "Select diclSkip,empID from boDictationLayers  where dicID=" & _DicID & " and rolID='" & m_sNext_Layer & "'"
        ds = con.getDataSet(Qry)
        Dim diclSkip As Long = ds.Tables(0).Rows(0)("diclSkip")
        EmpID = ds.Tables(0).Rows(0)("empId")
        If _Tag Then
            If diclSkip = 0 Then
                Qry = "Update boDictationLayers set diclStatus=1,diclTag=1 where dicID=" & _DicID & " and rolID='" & m_sNext_Layer & "'"
                con.update(Qry)
            Else
                Qry = "select empID from boDictatorLayers where drID='" & _drID & "' and foID='" & _foID & "' and rolID='" & m_sNext_Layer & "'"
                EmpID = con.getScalar(Qry)
                If EmpID.Trim = "0" Then
                    Qry = "select teamParent from boTeamPlayers where empID='" & _empID & "' and rolID='" & _RolID & "'"
                    EmpID = con.getScalar(Qry)
                    If EmpID.Trim <> "0" Then
                        Qry = "update boDictationLayers set empID='" & EmpID & "',diclStatus=1 ,diclTag=1 where dicID=" & _DicID & " and rolID='" & m_sNext_Layer & "'"
                        con.update(Qry)
                    End If
                Else
                    Qry = "update boDictationLayers set empID='" & EmpID & "',diclStatus=1 ,diclTag=1 where dicID=" & _DicID & " and rolID='" & m_sNext_Layer & "'"
                    con.update(Qry)
                End If
            End If
            Qry = "INSERT INTO boTranscriptionLayers (dicID,traID,empID,rolID,locID,tralName,tralRemarks,traTag,tralStatus) VALUES (" & _DicID & "," & _TraId & ",'" & EmpID & "','" & m_sNext_Layer & "','" & slocID & "','" & _ServerFile & "','" & sRemarks & "',1,0)"
            con.update(Qry)
            flag = True
        Else
            If diclSkip = 0 Then
                flag = True
                Qry = "UPDATE boDictationLayers set diclStatus=1 where dicID=" & _DicID & " and rolID='" & m_sNext_Layer & "';"
                Qry += "INSERT INTO boTranscriptionLayers (dicID,traID,empID,rolID,locID,tralName,tralRemarks,traTag,tralStatus) " _
                    & "VALUES (" & _DicID & "," & _TraId & ",'" & EmpID & "','" & m_sNext_Layer & "','" & slocID & "','" & _TraName & "','" & sRemarks & "',0,0)"
                con.update(Qry)

            Else
                flag = False
                Qry = "SELECT diclStatus from boDictationLayers WHERE dicID=" & _DicID & " AND rolID='" & m_sNext_Layer & "'"
                Dim diclStatus_ As String
                If con.getScalar(Qry) = 0 Then
                    diclStatus_ = " diclStatus =1, "
                Else
                    diclStatus_ = ""
                End If
                Qry = "UPDATE boDictationLayers SET " & diclStatus_ & "diclTranscriptions=diclTranscriptions+1,diclTag=0" _
                      & " WHERE dicID=" & _DicID & " AND rolID='" & m_sNext_Layer & "'"
                con.update(Qry)
            End If
        End If
        If flag = False AndAlso m_sNext_Layer <> "FR" Then
            Assign_To_Next_Layer(m_sNext_Layer, slocID, sRemarks)
        End If
        Return flag
    End Function

    Public Function Source_Address() As String
        Source_Address = "\\" + _RemoteAddress + "\" + "D$\System\" + _empID + "\" + _TraName.Substring(_TraName.Length - 15, 6).ToString + "\"
        Return Source_Address
    End Function

    Public Function Get_Tral_Status(ByVal traID As Long) As Long
        Qry = "SELECT tralStatus FROM boTranscriptionLayers WHERE dicId=" _
               & _DicID & " AND empId = '" & _empID & "' AND rolID= '" & _RolID & "' AND traId=" & traID
        Dim TralStatus As Long = con.getScalar(Qry)
        Return TralStatus
    End Function

    Public Function CopyFileName() As String
        Dim dicActualName_ As String
        If _RolID = "MT" Then
            dicActualName_ = _dicActualName
        Else
            dicActualName_ = _dicActualName.Substring(0, _dicActualName.IndexOf("."))
        End If

        ServerFile = _foID & _drID & "_" _
                                         & dicActualName_ & "_" & _PLname & "-" _
                                         & _PFname & "_" & Format(_dicDate, ("MMddyy")) & "-" _
                                         & Format(System.DateTime.Now, ("MMss")) & ".doc"
        Return ServerFile
    End Function

    Public Function Complete_Dictation() As Boolean
        Dim iMTTranscriptions As Long
        Dim bDictationFinal As Boolean

        Try

            If _RolID = "MT" Then
                Qry = "UPDATE boDictationLayers SET boDictationLayers.diclStatus= 3, " _
                      & "diclEnd = '" + Format(System.DateTime.Now, "MM/dd/yyyy HH:mm:ss") + "' WHERE boDictationLayers.dicID = " & _DicID & " " _
                      & "AND rolID = 'MT';"
                con.update(Qry)
            End If

            Qry = "SELECT diclTranscriptions FROM  boDictationLayers WHERE dicID=" & _DicID & " " _
                  & "AND rolID= 'MT'"
            iMTTranscriptions = con.getScalar(Qry)

            If iMTTranscriptions > 0 Then
                Qry = "SELECT rolID FROM boDictationLayers WHERE dicID = " & _DicID & " " _
                      & "AND diclTranscriptions <> " & iMTTranscriptions

                If con.getDataSet(Qry).Tables(0).Rows.Count > 0 Then
                    Qry = "UPDATE boDictationLayers SET boDictationLayers.diclStatus = 3, " _
                          & "diclEnd = '" + Format(System.DateTime.Now, "MM/dd/yyyy HH:mm:ss") + "' WHERE boDictationLayers.dicID = " & _DicID & " " _
                          & "AND rolID = '" & _RolID & "' AND rolID <> 'MT' AND diclTranscriptions = " & iMTTranscriptions

                    If con.update(Qry) > 0 Then
                        If _RolID = "PR" Then
                            Qry = "UPDATE boDictationLayers SET boDictationLayers.diclStatus= 3, " _
                                  & "diclEnd = '" + Format(System.DateTime.Now, "MM/dd/yyyy HH:mm:ss") + "' WHERE boDictationLayers.dicID = " & _DicID & " " _
                                  & "AND rolID = 'QC' AND diclTranscriptions = " & iMTTranscriptions & " " _
                                  & "AND diclStatus < 3"
                            con.update(Qry)
                        ElseIf _RolID = "FR" Then
                            Qry = "UPDATE boDictationLayers SET boDictationLayers.diclStatus= 3, " _
                                  & "diclEnd = '" + Format(System.DateTime.Now, "MM/dd/yyyy HH:mm:ss") + "' WHERE boDictationLayers.dicID = " & _DicID & " " _
                                  & "AND rolID = 'PR' AND diclTranscriptions = " & iMTTranscriptions & " " _
                                  & "AND diclStatus < 3"
                            If con.update(Qry) > 0 Then
                                Qry = "UPDATE boDictationLayers SET boDictationLayers.diclStatus= 3, " _
                                      & "diclEnd = '" + Format(System.DateTime.Now, "MM/dd/yyyy HH:mm:ss") + "' WHERE boDictationLayers.dicID = " & _DicID & " " _
                                      & "AND rolID = 'QC' AND diclTranscriptions = " & iMTTranscriptions & " " _
                                      & "AND diclStatus < 3"
                                con.update(Qry)

                                bDictationFinal = True
                            End If
                        End If
                    End If
                Else
                    Qry = "UPDATE boDictationLayers SET boDictationLayers.diclStatus= 3, " _
                          & "diclEnd = '" + Format(System.DateTime.Now, "MM/dd/yyyy HH:mm:ss") + "' WHERE boDictationLayers.dicID = " & _DicID & ";"
                    con.update(Qry)

                    bDictationFinal = True
                End If

                If bDictationFinal Then
                    Qry += "UPDATE boDictation SET boDictation.dicStatus = 2 WHERE dicID=" & _DicID
                    con.update(Qry)
                End If
            End If

            Complete_Dictation = True
        Catch ex As Exception
            Complete_Dictation = False
        End Try
    End Function

    Public Function Open_Reopen_Transcription(ByVal m_sPervious_Layer As String) As String
        Qry = "SELECT boEmployee.empFirstName, boEmployee.empLastName, boTranscriptionLayers.locID,  " _
                & " boTranscriptionLayers.tralUpDateTime, boTranscriptionLayers.tralRemarks,boTranscriptionLayers.traTag " _
                & " FROM         boTranscriptionLayers INNER JOIN " _
                & " boEmployee ON boTranscriptionLayers.empID = boEmployee.empID " _
                & " WHERE     boTranscriptionLayers.traId = " & _TraId & " and boTranscriptionLayers.rolID='" & m_sPervious_Layer & "' "
        Return Qry
    End Function

    Public Function Find_Pervious_Layer(ByVal p_layer As String, ByVal tra_id As Long) As String
        Dim Qry_Result As String
        If p_layer = "FR" Then
            p_layer = "PR"
        ElseIf p_layer = "PR" Then
            p_layer = "QC"
        ElseIf p_layer = "QC" Then
            p_layer = "MT"
        Else
            Return Nothing
            Exit Function
        End If

        Qry = "SELECT boTranscriptionLayers.rolID, boTranscriptionLayers.empID, boEmployee.empPrefix, " _
              & "boEmployee.empFirstName, boEmployee.empLastName,IsNull(tralRemarks,'-') as tralRemarks, " _
              & "tralUpDateTime,traTag,IsNull(locId,'-') as locId FROM boTranscriptionLayers INNER JOIN boEmployee " _
              & "ON boTranscriptionLayers.empID = boEmployee.empID " _
              & "WHERE boTranscriptionLayers.traID = " & tra_id & " " _
              & "AND boTranscriptionLayers.rolID = '" & p_layer & "'"

        'Qry = "SELECT rolId FROM boTranscriptionLayers WHERE traId=" & tra_id & " AND rolId='" & P_Layer & "' AND empId='" & emp_id & "'"
        ds = con.getDataSet(Qry)
        If ds.Tables(0).Rows.Count > 0 Then
            Qry_Result = Qry
        Else
            Qry_Result = Find_Pervious_Layer(p_layer, tra_id)
        End If
        Return Qry_Result
    End Function

    Public Function Load_Employee_Work_Area_Grid(ByVal rol_id As String, ByVal empId As String) As String
        Dim SQry As String
        If rol_id = "MT" Then
            SQry = "SELECT boDictation.drID, boDictation.foID,boDictation.dicAccountName, boDictation.dicActualName,  boDictation.dicTempName, boDictation.dicLength, boDictation.dicStatus, boDictationLayers.diclStatus, " _
                    & " boDictation.dicDate,boDictation.dicID,boDictation.dicTime, " _
                    & "boDictation.dicStatus,boDictation.dicID, boDictationLayers.diclStatus FROM boDictation " _
                    & "INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
                    & "WHERE(boDictationlayers.diclstatus < 3) " _
                    & "and bodictationlayers.rolid = '" & rol_id & "' " _
                    & "and bodictationlayers.empid = '" & empId & "' " _
                    & "GROUP BY boDictation.dicActualName,boDictation.dictempName,boDictation.dicAccountName ,boDictation.dicLength, boDictation.foID, " _
                    & "boDictation.drID, boDictation.dicDate,boDictation.dicID, " _
                    & "boDictation.dicStatus, dbo.boDictation.dicTime, boDictation.dicStatus, boDictationLayers.diclStatus " _
                    & " ORDER BY boDictation.foID, boDictation.drID, boDictation.dicDate Desc, boDictation.dicActualName"
        Else
            SQry = "SELECT boDictation.dicID, boDictation.drID, boDictation.dicAccountName, boDictation.foID, boDictation.dicActualName,  boDictation.dicTempName, boDictation.dicDate, boDictation.dicLength, boDictation.dicStatus, boDictationLayers.diclStatus, " _
                        & "IsNull(boTranscription.traID,0) as traId ,  boTranscription.locID,  boTranscription.traName,  boTranscription.traPatFirstName, " _
                        & "boTranscription.traPatLastName,boTranscription.traPatientNo, IsNull(boTranscription.traIncomplete,0) as traIncomplete ,  IsNull(boTranscription.traTag,0) as traTag,  boTranscription.traRemarks, " _
                        & "boTranscriptionLayers.tralStatus FROM boTranscriptionLayers INNER JOIN " _
                        & "boTranscription ON  boTranscriptionLayers.traID =  boTranscription.traID RIGHT OUTER JOIN " _
                        & " boDictation INNER JOIN boDictationLayers ON  boDictation.dicID =  boDictationLayers.dicID ON  boTranscriptionLayers.rolID =  boDictationLayers.rolID AND " _
                        & "boTranscriptionLayers.empID = boDictationLayers.empID And boTranscription.dicID = boDictation.dicID " _
                        & "WHERE( boDictationLayers.rolID = '" & rol_id & "') AND (boDictationLayers.empID = '" & empId & "') " _
                        & "AND boDictationLayers.diclStatus < 3 AND IsNull(boTranscription.traId,0) <> 0 AND IsNull(boTranscriptionLayers.tralStatus,0) < 2 " _
                        & " ORDER BY boDictation.foID, boDictation.drID, boDictation.dicDate Desc, boDictation.dicActualName"
        End If


        Qry = "SELECT boDictation.drID, boDictation.foID, isnull ((select sum(c.dicLength) FROM  boDictation c " _
                & "INNER JOIN boDictationLayers ON c.dicID = boDictationLayers.dicID " _
                & "WHERE boDictationLayers.empID = '" & empId & "' AND boDictationLayers.rolID = '" & rol_id & "' " _
                & "AND boDictationLayers.diclStatus IN(1,2) AND c.drID = boDictation.drID and c.foID = boDictation.foID),0) AS avlMinutes, " _
                & "isnull ((SELECT Count(c.dicID) FROM  boDictation c INNER JOIN boDictationLayers ON c.dicID = boDictationLayers.dicID " _
                & "WHERE boDictationLayers.empID = '" & empId & "' AND boDictationLayers.rolID = '" & rol_id & "' AND boDictationLayers.diclStatus IN(1,2) " _
                & "AND c.drID = boDictation.drID and c.foID = boDictation.foID),0)  AS avlCount, " _
                & "(select sum(c.dicLength) FROM  boDictation c INNER JOIN boDictationLayers ON c.dicID = boDictationLayers.dicID " _
                & "WHERE boDictationLayers.empID = '" & empId & "' AND boDictationLayers.rolID = '" & rol_id & "' AND boDictationLayers.diclStatus < 3  " _
                & "AND c.drID = boDictation.drID and c.foID = boDictation.foID) as outMinutes, " _
                & "(SELECT Count(c.dicID) FROM  boDictation c INNER JOIN boDictationLayers ON c.dicID = boDictationLayers.dicID " _
                & "WHERE boDictationLayers.empID = '" & empId & "' AND boDictationLayers.rolID = '" & rol_id & "' AND boDictationLayers.diclStatus < 3 " _
                & "AND c.drID = boDictation.drID and c.foID = boDictation.foID) as outCount, " _
                & "(SELECT A.drFirstName + ' ' + A.drLastName FROM boDictator A WHERE A.foID = boDictation.foID and A.drID = boDictation.drID) AS drName " _
                & "FROM boDictationLayers INNER JOIN boDictation ON boDictationLayers.dicID = boDictation.dicID " _
                & "INNER JOIN boDictator ON boDictation.drID = boDictator.drID AND boDictation.foID = boDictator.foID " _
                & "WHERE boDictationLayers.rolID = '" & rol_id & "' AND boDictationLayers.empID = '" & empId & "' AND boDictationLayers.diclStatus < 3 " _
                & "GROUP BY dbo.boDictation.drID, dbo.boDictation.foID ORDER BY dbo.boDictation.foID, dbo.boDictation.drID; "
        Return Qry & SQry
    End Function

    Public Function Get_PreviouseEmployee(ByVal dicId As Long, ByVal rol_Id As String, ByVal tra_Id As Long) As String
        Dim Qry As String
        Dim sPreRolID As String

        If rol_Id = "FR" Then
            sPreRolID = "PR"
        ElseIf rol_Id = "PR" Then
            sPreRolID = "QC"
        ElseIf rol_Id = "QC" Then
            sPreRolID = "MT"
        ElseIf rol_Id = "MT" Then
            Return Nothing
        End If

        If tra_Id = 0 Then
            Qry = "SELECT boDictationLayers.empID, boEmployee.empFirstName + ' ' +  boEmployee.empLastName AS empName " _
                  & "FROM boDictationLayers INNER JOIN boEmployee ON boDictationLayers.empID =  boEmployee.empID " _
                  & "WHERE rolID = '" & sPreRolID & "' and dicID = " & dicId
        Else
            Qry = "SELECT boTranscriptionLayers.empID, boEmployee.empFirstName + ' ' +  boEmployee.empLastName AS empName " _
                  & "FROM boTranscriptionLayers INNER JOIN boEmployee ON boTranscriptionLayers.empID =  boEmployee.empID " _
                  & "WHERE rolID = '" & sPreRolID & "' and traID = " & tra_Id
        End If

        ds = con.getDataSet(Qry)
        If ds.Tables(0).Rows.Count = 0 Then
            Get_PreviouseEmployee = "-"
        ElseIf ds.Tables(0).Rows(0)("empID").ToString.Trim = "0" Then
            Get_PreviouseEmployee = "-"
        Else
            Get_PreviouseEmployee = ds.Tables(0).Rows(0)("empName")
        End If
    End Function

    Public Function Get_LastEmployee(ByVal dicId As Long, ByVal rol_Id As String, ByVal tra_Id As Long) As String
        Dim Qry As String
        Dim sPreRolID As String
        If rol_Id = "FR" Then
            sPreRolID = "PR"
        ElseIf rol_Id = "PR" Then
            sPreRolID = "QC"
        ElseIf rol_Id = "QC" Then
            sPreRolID = "MT"
        Else
            Return Nothing
            Exit Function
        End If

        If tra_Id = 0 Then
            Qry = "SELECT boDictationLayers.empID, boEmployee.empFirstName + ' ' +  boEmployee.empLastName AS empName " _
                  & "FROM boDictationLayers INNER JOIN boEmployee ON boDictationLayers.empID =  boEmployee.empID " _
                  & "WHERE rolID = '" & sPreRolID & "' and dicID = " & dicId
        Else
            Qry = "SELECT boTranscriptionLayers.empID, boEmployee.empFirstName + ' ' +  boEmployee.empLastName AS empName " _
                  & "FROM boTranscriptionLayers INNER JOIN boEmployee ON boTranscriptionLayers.empID =  boEmployee.empID " _
                  & "WHERE rolID = '" & sPreRolID & "' and traID = " & tra_Id
        End If

        ds = con.getDataSet(Qry)
        If ds.Tables(0).Rows.Count = 0 Then
            Get_LastEmployee = Get_LastEmployee(dicId, sPreRolID, tra_Id)
        ElseIf ds.Tables(0).Rows(0)("empID").ToString.Trim = "0" Then
            Get_LastEmployee = Get_LastEmployee(dicId, sPreRolID, tra_Id)
        Else
            Get_LastEmployee = ds.Tables(0).Rows(0)("empName") & " [" & sPreRolID & "]"
        End If
    End Function

    Private Function ConnectionString() As String
        Dim obj As New DBTaskBO
        Return obj.ConnectionString
        'Dim SQLCon As New SqlConnectionStringBuilder
        'SQLCon.DataSource = "BALI"
        'SQLCon.InitialCatalog = "MTBMS-BO"
        'SQLCon.UserID = "sa"
        'Return SQLCon.ToString()
    End Function

    Public Function File_Submit_or_Not() As Boolean
        Dim Qry = "SELECT tralStatus from boTranscriptionLayers WHERE traID=" & Me._TraId & " AND rolID='" & Me._RolID & "'"
        If con.getScalar(Qry) = 1 Then Return True
    End Function

    Public Function File_Open_Or_Not() As Boolean
        Dim Qry = "SELECT tralStatus from boTranscriptionLayers WHERE traID=" & Me._TraId & " AND rolID='" & Me._RolID & "'"
        If con.getScalar(Qry) = 0 Then Return True
    End Function

    Public Function Load_Comparisons(ByVal empId As String) As String
        Dim SQry As String
        SQry = "SELECT boDictation.dicID, boDictation.drID, boDictation.dicDate, boDictation.dicStatus, " _
             & "boDictationLayers.rolID, boDictationLayers.empID, " _
             & " IsNull(boTranscription.traID,0) as traId , boTranscription.traName, " _
             & " boTranscriptionLayers.tralStatus FROM boTranscriptionLayers " _
             & " INNER JOIN boTranscription ON  boTranscriptionLayers.traID =  boTranscription.traID " _
             & " RIGHT OUTER JOIN  boDictation INNER JOIN boDictationLayers ON  boDictation.dicID =  boDictationLayers.dicID " _
             & " ON  boTranscriptionLayers.rolID =  boDictationLayers.rolID AND " _
             & " boTranscriptionLayers.empID = boDictationLayers.empID And boTranscription.dicID = boDictation.dicID " _
             & " WHERE (boDictationLayers.empID = '" & empId & "') AND boDictationLayers.diclStatus = 3 AND " _
             & " boDictationLayers.diclComparison = 1 AND IsNull(boTranscription.traId,0) <> 0  " _
             & " ORDER BY boDictation.foID, boDictation.drID, boDictation.dicDate Desc, " _
             & " boDictation.dicActualName "
        Return SQry
    End Function

    Public Function Load_DicSearch(ByVal dic As String, ByVal dr2 As String, ByVal dateFrom As String, ByVal dateTo As String, ByVal empID As String, ByVal chkAll As Boolean, ByVal btnAll As Boolean, ByVal btnSearch As Boolean) As String
        Dim drID, foID As String
        If btnAll = True Then
            Qry = "SELECT  boDictation.foID+boDictation.drID as Uid,boDictation.dicActualName, " _
                    & "boTranscription.traName,boDictation.dicDate,boDictationLayers.empID, boDictationLayers.rolID,boTranscription.traPatFirstName+', '+" _
                    & "boTranscription.traPatLastName as PatientName ,boTranscription.traStatus, boTranscription.traPatientNo, " _
                    & "boDictation.dicID, boTranscription.traID, boTranscriptionLayers.traID, boTranscriptionLayers.tralID, boTranscriptionLayers.rolID, boTranscriptionLayers.tralComparison " _
                    & "FROM boDictation INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
                    & "INNER JOIN boTranscription ON boDictation.dicID = boTranscription.dicID " _
                    & "INNER JOIN boTranscriptionLayers ON boTranscription.traID = boTranscriptionLayers.traID AND boDictationLayers.rolID = boTranscriptionLayers.rolID " _
                    & "WHERE boTranscriptionLayers.empID = '" & empID & "' AND boTranscriptionLayers.tralComparison = '1' " _
                    & "ORDER BY Uid"
        Else

            If btnSearch = True Then
                If chkAll = True Then
                    If dr2 <> Nothing Or dr2 <> "" Then
                        drID = dr2.Substring(dr2.Length - 4, 4)
                        foID = dr2.Remove(dr2.Length - 4)

                        Qry = "SELECT  boDictation.foID+boDictation.drID as Uid,boDictation.dicActualName, " _
                            & "boTranscription.traID,boTranscription.traName,boDictation.dicDate,boDictationLayers.empID,boDictationLayers.rolID,boTranscription.traPatFirstName+', '+" _
                            & "boTranscription.traPatLastName as PatientName ,boTranscription.traStatus, boTranscription.traPatientNo, " _
                            & "boDictation.dicID, boTranscription.traID, boTranscriptionLayers.traID, boTranscriptionLayers.tralID, boTranscriptionLayers.rolID " _
                            & "FROM boDictation INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
                            & "INNER JOIN boTranscription ON boDictation.dicID = boTranscription.dicID " _
                            & "INNER JOIN boTranscriptionLayers ON boTranscription.traID = boTranscriptionLayers.traID AND boDictationLayers.rolID = boTranscriptionLayers.rolID " _
                            & "WHERE  boDictationLayers.empID = '" & empID & "' AND boTranscriptionLayers.tralComparison > '0' AND boDictation.dicDate BETWEEN '" & dateFrom & "' AND '" & dateTo & "' AND boDictation.drID = '" & drID & "' " _
                            & "AND boDictation.foID = '" & foID & "' AND boDictation.dicActualName Like '%" & dic & "%'" _
                            & "ORDER BY Uid"
                    Else
                        Qry = "SELECT  boDictation.foID+boDictation.drID as Uid,boDictation.dicActualName, " _
                            & "boTranscription.traID,boTranscription.traName,boDictation.dicDate,boDictationLayers.empID, boDictationLayers.rolID,boTranscription.traPatFirstName+', '+" _
                            & "boTranscription.traPatLastName as PatientName ,boTranscription.traStatus, boTranscription.traPatientNo, " _
                            & "boDictation.dicID, boTranscription.traID, boTranscriptionLayers.traID, boTranscriptionLayers.tralID, boTranscriptionLayers.rolID " _
                            & "FROM boDictation INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
                            & "INNER JOIN boTranscription ON boDictation.dicID = boTranscription.dicID " _
                            & "INNER JOIN boTranscriptionLayers ON boTranscription.traID = boTranscriptionLayers.traID AND boDictationLayers.rolID = boTranscriptionLayers.rolID " _
                            & "WHERE boDictationLayers.empID = '" & empID & "' AND boTranscriptionLayers.tralComparison > '0' AND  boDictation.dicDate BETWEEN '" & dateFrom & "' AND '" & dateTo & "' AND boDictation.dicActualName Like '%" & dic & "%'" _
                            & "ORDER BY Uid"

                    End If
                Else
                    Qry = "SELECT  boDictation.foID+boDictation.drID as Uid,boDictation.dicActualName, " _
                        & "boTranscription.traID,boTranscription.traName,boDictation.dicDate,boDictationLayers.empID, boDictationLayers.rolID,boTranscription.traPatFirstName+', '+" _
                        & "boTranscription.traPatLastName as PatientName ,boTranscription.traStatus, boTranscription.traPatientNo, " _
                        & "boDictation.dicID, boTranscription.traID, boTranscriptionLayers.traID, boTranscriptionLayers.tralID, boTranscriptionLayers.rolID " _
                        & "FROM boDictation INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
                        & "INNER JOIN boTranscription ON boDictation.dicID = boTranscription.dicID " _
                        & "INNER JOIN boTranscriptionLayers ON boTranscription.traID = boTranscriptionLayers.traID AND boDictationLayers.rolID = boTranscriptionLayers.rolID " _
                        & "WHERE boDictationLayers.empID = '" & empID & "' AND boTranscriptionLayers.tralComparison = '1' AND  boDictation.dicDate BETWEEN '" & dateFrom & "' AND '" & dateTo & "'" _
                        & "ORDER BY Uid"

                End If
            End If
        End If
        Return Qry
    End Function

    Public Function Load_Dictators(ByVal empID As String) As String
        Qry = "SELECT DISTINCT(dic.foID+dic.drID) AS Uid," _
            & " dic.foID +'-'+dic.drID +'  '+ dr.drLastName +', '+ ISNULL(dr.drMiddleName, '') +' '+ dr.drFirstName as DictatorName" _
            & " FROM  boDictation dic INNER JOIN boDictationLayers dicL ON dic.dicID = dicL.dicID " _
            & " INNER JOIN boDictator dr ON dic.drID = dr.drID where dicL.empID = '" & empID & "' order by Uid "
        Return Qry
    End Function
End Class
