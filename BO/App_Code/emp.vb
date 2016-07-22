Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Imports MTBMS.BLL
Imports MTBMS.DAL

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
'<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://bo.xstek.net/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class emp
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function Login(ByVal vsUser As String, ByVal vsPassword As String) As String
        Dim Query As String
        Dim ds As DataSet
        Dim Con As New DBTaskBO

        Try
            Query = "Select empID, empEnable From boEmployee where empLoginID ='" _
                    & vsUser & "' AND empPassword COLLATE Latin1_General_BIN = '" & vsPassword & "'"

            ds = Con.getDataSet(Query)

            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0)("empEnable") = "1" Then
                    Login = Trim(ds.Tables(0).Rows(0)("empID"))
                Else
                    Login = "1"
                End If
            Else
                Login = "0"
            End If
        Catch ex As Exception
            Login = "-1"
        Finally
            ds.Dispose()
            ds = Nothing

            Con = Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function Roles(ByVal empID As String) As DataSet
        Dim sQuery As String
        Dim con As New DBTaskBO

        sQuery = "SELECT boEmployee.empID, boEmployee.empPrefix + ' ' + boEmployee.empFirstName + ' ' + boEmployee.empLastName AS empName, boEmployeeRoles.rolID, " _
                 & "(SELECT Count(dD.dicID) FROM boDictationLayers dL INNER JOIN boDictation dD ON dl.dicID=dD.dicID where diclStatus < 3 AND rolID=boEmployeeRoles.rolID AND empID='" & empID & "') AS empDictations " _
                 & "FROM boEmployeeRoles " _
                 & "INNER JOIN boEmployee ON boEmployeeRoles.empID = boEmployee.empID " _
                 & "INNER JOIN boRoles ON boEmployeeRoles.rolID = boRoles.rolID " _
                 & "WHERE  boEmployee.empID = '" & empID & "' AND boEmployeeRoles.empEnable = 1 " _
                 & "ORDER BY boRoles.rolOrder"

        Roles = con.getDataSet(sQuery)

        con = Nothing
    End Function

    <WebMethod()> _
    Public Function Templates(ByVal foID As String, ByVal drID As String) As DataSet
        Dim sQuery As String
        Dim con As New DBTaskBO

        sQuery = "SELECT temID, temActualName, temTempName, temDefault " _
                 & "FROM boTemplates " _
                 & "WHERE  foID = '" & foID & "' AND drID = '" & drID & "' AND temEnable = 1 " _
                 & "ORDER BY temActualName"

        Templates = con.getDataSet(sQuery)

        con = Nothing
    End Function

    <WebMethod()> _
    Public Function Workload(ByVal empID As String, ByVal rolID As String) As DataSet
        Dim con As New DBTaskBO
        Dim objBL As New BL

        Workload = con.getDataSet(objBL.Load_Employee_Work_Area_Grid(rolID, empID))

        con = Nothing
    End Function

    <WebMethod()> _
    Public Function Transcriptions(ByVal empID As String, ByVal rolID As String, ByVal dicID As Long) As DataSet
        Dim objBL As New BL

        objBL.empID = empID
        objBL.DicID = dicID
        objBL.RolID = rolID

        Transcriptions = objBL.Return_Transcriptions()

        objBL = Nothing
    End Function

    <WebMethod()> _
    Public Function GenerateTranscription(ByVal foID As String, ByVal drID As String, ByVal dicID As String, ByVal patFirstName As String, ByVal patLastName As String, ByVal patNo As String, ByVal traName As String, ByVal empID As String) As Long
        Dim objBL As New BL
        Try
            objBL.foID = foID
            objBL.drID = drID
            objBL.DicID = dicID
            objBL.PLname = patFirstName
            objBL.PFname = patLastName
            objBL.PatientNo = patNo
            objBL.TraName = traName
            objBL.empID = empID
            objBL.RolID = "MT"

            GenerateTranscription = objBL.Open_TranscriptionDB(traName)
        Catch ex As Exception
            GenerateTranscription = 0
        End Try
    End Function

    <WebMethod()> _
    Public Function OpenTranscription(ByVal foID As String, ByVal dicID As String, ByVal traID As String, ByVal traName As String, ByVal empID As String, ByVal rolID As String) As DataSet
        Dim objBL As New BL

        objBL.foID = foID
        objBL.DicID = dicID
        objBL.TraId = traID
        objBL.TraName = traName
        objBL.empID = empID
        objBL.RolID = rolID

        If objBL.Open_TranscriptionDB(traName) >= 0 Then
            OpenTranscription = getFields(traID)
        End If
    End Function

    <WebMethod()> _
    Public Function getFieldsXML(ByVal traID As String) As DataSet
        getFieldsXML = getFields(traID)
    End Function

    Private Function getFields(ByVal traID As String) As DataSet
        Dim sQuery As String
        Dim con As New DBTaskBO

        sQuery = "SELECT traID, isnull(traPatFirstName,'') AS traPatFirstName, isnull(traPatLastName,'') AS traPatLastName, isnull(traSubject,'') AS traSubject, " _
                 & "isnull(traPatientNo,'') AS traPatientNo, isnull(traNHSNo,'') as traNHSNo, isnull(traDear,'') AS traDear, isnull(traClinicDate,'1/1/1900') AS traClinicDate, " _
                 & "isnull(traClinicReference,'') AS traClinicReference, isnull(traDOB,'1/1/1900') AS traDOB, isnull(traNTS,'') AS traNTS, isnull(traNTD,'') AS traNTD, " _
                 & "isnull(traRecipientAddress,'') AS traRecipientAddress, isnull(traFooterBlock,'') AS traFooterBlock, traIncomplete, traTag, " _
                 & "isnull(traRemarks,'') AS traRemarks, isnull(traClinicDateDay,'') AS traClinicDateDay,isnull(traClinicDateMonth,'') AS traClinicDateMonth, " _
                 & "isnull(traClinicDateYear,'') AS traClinicDateYear, isnull(traDOBDay,'') AS traDOBDay,isnull(traDOBMonth,'') AS traDOBMonth,isnull(traDOBYear,'') AS traDOBYear " _
                 & "FROM boTranscription " _
                 & "WHERE  traID = " & traID

        getFields = con.getDataSet(sQuery)

        con = Nothing
    End Function

    <WebMethod()> _
    Public Function CancelTranscription(ByVal dicID As String, ByVal traName As String) As Boolean
        Dim objBL As New BL
        Try
            objBL.DicID = dicID
            objBL.TraId = getTranscriptionID(traName)
            objBL.RolID = "MT"

            CancelTranscription = objBL.Remove_Transcriptions()
        Catch ex As Exception
            CancelTranscription = False
        End Try
    End Function

    <WebMethod()> _
    Public Function SubmitTranscription(ByVal foID As String, _
                                        ByVal drID As String, _
                                        ByVal dicID As String, _
                                        ByVal empID As String, _
                                        ByVal rolID As String, _
                                        ByVal traId As String, _
                                        ByVal traName As String, _
                                        ByVal patFirstName As String, _
                                        ByVal patLastName As String, _
                                        ByVal patNo As String, _
                                        ByVal patNHSNo As String, _
                                        ByVal traSubject As String, _
                                        ByVal traDear As String, _
                                        ByVal traClinicDate As Date, _
                                        ByVal traDOB As Date, _
                                        ByVal traClinicReference As String, _
                                        ByVal traNTS As String, _
                                        ByVal traNTD As String, _
                                        ByVal traRecipientAddress As String, _
                                        ByVal traFooterBlock As String, _
                                        ByVal traTag As Boolean, _
                                        ByVal traUrgent As Boolean, _
                                        ByVal tralRemarks As String, _
                                        ByVal traClinicDateDay As String, _
                                        ByVal traClinicDateMonth As String, _
                                        ByVal traClinicDateYear As String, _
                                        ByVal traDOBDay As String, _
                                        ByVal traDOBMonth As String, _
                                        ByVal traDOBYear As String) As String
        Dim objBL As New BL
        'objBL.empID = Session("empId")
        Try
            With objBL
                .foID = foID
                .drID = drID
                .DicID = dicID
                .RolID = rolID
                .empID = empID
                .TraId = traId
                .TraName = traName
                .PFname = patFirstName
                .PLname = patLastName
                .PatientNo = patNo
                .NHSNo = patNHSNo

                .traSubject = Replace(traSubject, "'", "''")
                .traDear = Replace(traDear, "'", "''")

                If traClinicDateYear = Nothing Or traClinicDateYear = "" Then traClinicDateYear = "1900"
                If traClinicDateMonth = Nothing Or traClinicDateMonth = "" Then traClinicDateMonth = "1"
                If traClinicDateDay = Nothing Or traClinicDateDay = "" Then traClinicDateDay = "1"
                .traClinicDate = New Date(traClinicDateYear, traClinicDateMonth, traClinicDateDay)

                If traDOBYear = Nothing Or traDOBYear = "" Then traDOBYear = "1900"
                If traDOBMonth = Nothing Or traDOBMonth = "" Then traDOBMonth = "1"
                If traDOBDay = Nothing Or traDOBDay = "" Then traDOBDay = "1"
                .traDOB = New Date(traDOBYear, traDOBMonth, traDOBDay)

                .traClinicReference = Replace(traClinicReference, "'", "''")
                .traNTS = Replace(traNTS, "'", "''")
                .traNTD = Replace(traNTD, "'", "''")
                .traRecipientAddress = Replace(traRecipientAddress, "'", "''")
                .traFooterBlock = Replace(traFooterBlock, "'", "''")

                .Tag = traTag
                .Urgent = traUrgent
                .Remarks = Replace(tralRemarks, "'", "''")

                If .Submit_Transcription(tralRemarks, 0, traUrgent, traClinicDateDay, traClinicDateMonth, traClinicDateYear, traDOBDay, traDOBMonth, traDOBYear) Then
                    If rolID <> "MT" Then
                        SubmitTranscription = .Complete_Dictation()
                    Else
                        SubmitTranscription = True
                    End If
                End If
            End With
        Catch ex As Exception
            SubmitTranscription = ex.Message
        Finally
            objBL.Dispose()
            objBL = Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function CompleteDictation(ByVal dicID As String) As Boolean
        Dim objBL As New BL
        Try
            objBL.DicID = dicID
            objBL.RolID = "MT"

            CompleteDictation = objBL.Complete_Dictation()
        Catch ex As Exception
            CompleteDictation = False
        Finally
            objBL.Dispose()
            objBL = Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function DownloadTranscription(ByVal rolID As String, ByVal traName As String, ByVal drID As String) As Byte()
        Try
            Dim docFolder As String = ""
            Dim docPath As String = ""

            If rolID = "MT" Then
                docPath = Server.MapPath("..\Data\") & drID & "\Templates\" & traName
            ElseIf rolID = "QC" Then
                docPath = Server.MapPath("..\Data\MT\") & traName
            ElseIf rolID = "PR" Then
                docPath = Server.MapPath("..\Data\QC\") & traName
                If IO.File.Exists(docPath) = False Then
                    docPath = Server.MapPath("..\Data\MT\") & traName
                End If
            ElseIf rolID = "FR" Then
                docPath = Server.MapPath("..\Data\PR\") & traName
                If IO.File.Exists(docPath) = False Then
                    docPath = Server.MapPath("..\Data\QC\") & traName

                    If IO.File.Exists(docPath) = False Then
                        docPath = Server.MapPath("..\Data\MT\") & traName
                    End If
                End If
            End If

            Dim fStream As New FileStream(docPath, FileMode.Open, FileAccess.Read)
            Dim br As New BinaryReader(fStream)
            Dim data As Byte() = br.ReadBytes(Convert.ToInt32(fStream.Length))


            br.Close()
            fStream.Close()
            fStream.Dispose()

            DownloadTranscription = data
        Catch ex As Exception
            'DownloadTranscription = ""
        End Try
    End Function

    <WebMethod()> _
    Public Function UploadTranscription(ByVal rolID As String, ByVal traName As String, ByVal f As Byte()) As Boolean
        Try
            Dim ms As New MemoryStream(f)
            Dim destinationFolder As String = Server.MapPath("..\Data\") & rolID

            System.IO.Directory.CreateDirectory(destinationFolder)

            Dim fs As New FileStream(destinationFolder & "\" & traName, FileMode.Create)

            ms.WriteTo(fs)
            ms.Close()
            fs.Close()
            fs.Dispose()

            UploadTranscription = True
        Catch ex As Exception
            UploadTranscription = False
        End Try
    End Function

    Private Function getTranscriptionID(ByVal traName As String) As Long
        Dim Con As New DBTaskBO
        getTranscriptionID = Con.getScalar("SELECT traID FROM boTranscription WHERE traName = '" & traName & "'")
        Con = Nothing
    End Function

    <WebMethod()> _
    Public Function DownloadSearchedTrans(ByVal traName As String, ByVal rolID As String, ByVal empID As String, ByVal dicDate As String, ByVal tralID As Integer) As Byte()
        Try

            Dim docPath As String = Server.MapPath("..\Data\comparisons\" & dicDate & "\") & traName & "_" & rolID & "_" & empID & ".doc"
            If IO.File.Exists(docPath) Then

                Dim con As New DBTaskBO
                Dim Qry As String = "UPDATE  boTranscriptionLayers SET tralComparison = '2' WHERE tralID ='" & tralID & "'"
                con.saveData(Qry)

                Dim fStream As New FileStream(docPath, FileMode.Open, FileAccess.Read)
                Dim br As New BinaryReader(fStream)
                Dim data As Byte() = br.ReadBytes(Convert.ToInt32(fStream.Length))



                br.Close()
                fStream.Close()
                fStream.Dispose()

                DownloadSearchedTrans = data
            End If

        Catch ex As Exception
            DownloadSearchedTrans = System.Text.Encoding.Unicode.GetBytes("0")
        End Try
    End Function

    <WebMethod()> _
    Public Function downloadedComparisonsUpdate(ByVal empID As String, ByVal tralIDs As String, ByVal bTrue As Boolean) As Boolean
        Dim con As New DBTaskBO
        Dim Qry As String

        If bTrue Then
            Qry = "UPDATE boTranscriptionLayers SET tralComparison = 4 WHERE tralID IN(" & tralIDs & ")"
        Else
            Qry = "UPDATE boTranscriptionLayers SET tralComparison = 2 WHERE tralID IN(" & tralIDs & ")"
        End If

        If con.saveData(Qry) Then
            downloadedComparisonsUpdate = True
        Else
            downloadedComparisonsUpdate = False
        End If

        con = Nothing
    End Function

    <WebMethod()> _
    Public Function Comparisons(ByVal empID As String) As DataSet
        Dim con As New DBTaskBO
        Dim objBL As New BL
        Comparisons = con.getDataSet(objBL.Load_Comparisons(empID))

        con = Nothing
    End Function

    <WebMethod()> _
    Public Function DicSearch(ByVal dic As String, ByVal dr2 As String, ByVal dateFrom As String, ByVal dateTo As String, ByVal empID As String, ByVal chkAll As Boolean, ByVal btnAll As Boolean, ByVal btnSearch As Boolean) As DataSet
        Dim con As New DBTaskBO
        Dim objBL As New BL
        DicSearch = con.getDataSet(objBL.Load_DicSearch(dic, dr2, dateFrom, dateTo, empID, chkAll, btnAll, btnSearch))
        con = Nothing
    End Function

    <WebMethod()> _
    Public Function Dictators(ByVal empID As String) As DataSet
        Dim con As New DBTaskBO
        Dim objBL As New BL
        Dictators = con.getDataSet(objBL.Load_Dictators(empID))
        con = Nothing
    End Function

    <WebMethod()> _
    Public Function Dictators_by_comparison_dates(ByVal empID As String, ByVal dateFrom As String, ByVal dateTo As String) As DataSet
        Dim con As New DBTaskBO
        Try
            Dim objBL As New BL
            Dim Qry As String = " SELECT distinct(RTRIM(boDictation.foID)+boDictation.drID) as Uid, " _
                            & " RTRIM(boDictation.foID) +'-'+boDictation.drID +' '+ boDictator.drLastName +', '+ ISNULL(boDictator.drMiddleName, '') +' '+ boDictator.drFirstName as DictatorName " _
                            & " FROM boDictation " _
                            & " inner join boDictator on boDictation.drID = boDictator.drID and boDictator.foID = boDictation.foID " _
                            & " INNER JOIN boDictationLayers ON boDictation.dicID = boDictationLayers.dicID " _
                            & " INNER JOIN boTranscription ON boDictation.dicID = boTranscription.dicID " _
                            & " INNER JOIN boTranscriptionLayers ON boTranscription.traID = boTranscriptionLayers.traID " _
                            & " AND boDictationLayers.rolID = boTranscriptionLayers.rolID " _
                            & " WHERE boTranscriptionLayers.empID = '" & empID & "' and boDictation.foID = '1111' " _
                            & " and boDictation.dicDate between '" & dateFrom & "' and '" & dateTo & "' " _
                            & " ORDER BY Uid"
            Dictators_by_comparison_dates = con.getDataSet(Qry)

        Catch ex As Exception
            Dictators_by_comparison_dates = Nothing
        Finally
            con = Nothing
        End Try

    End Function

    <WebMethod()> _
    Public Function getMacroInfo() As DataSet
        Try
            Dim objDB As New DBTaskBO
            Dim qry As String = "select Max(mcID) as mcID, mcVersion, mcName from boMacros where mcType = '1' and mcDefault = '1' group by mcVersion, mcName"
            getMacroInfo = objDB.getDataSet(qry)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
