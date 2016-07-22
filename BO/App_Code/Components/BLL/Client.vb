Imports Microsoft.VisualBasic
Imports MTBMS.DAL
Imports System.Data
Imports System.Data.SqlClient
Namespace MTBMS.BLL
    Public Class Client
        Public Function getFieldValues(ByVal colName As String, ByVal tblName As String) As SqlDataReader
            Dim ConString As New DataAccessLayer
            Dim Con As New SqlConnection(ConString.ConnectionString)
            Dim Cmd As New SqlCommand("Select " + colName + " From " + tblName + "", Con)
            Dim dr As SqlDataReader
            Con.Open()
            dr = Cmd.ExecuteReader
            Return dr
            Con.Close()
        End Function

        Public Function Query(ByVal drId As String, ByVal fDate As Date, ByVal tDate As Date, ByVal line As String) As String
            If drId = "0" Then
                drId = ""
            Else
                drId = " AND bd.foId+bd.drId='" & drId & "' "
            End If
            Dim sql As String = ""
            sql = "SELECT dicDate,Sum(dicLength) as dicLength, sum(Lines) as Lines," _
                & "Sum(TotalDIc) as TotalDic,Sum(TotalTra) as TotalTra FROM " _
                & "(SELECT bd.foId + bd.drId as drId," _
                & "Sum(boDictation.dicLength) as dicLength,Sum(bt.traCharacters)/'" & line & "' as Lines," _
                & "Count(boDictation.dicId) as TotalDIc,Sum(dicTranscriptions) as TotalTra,dicDate " _
                & "FROM boDictator bd INNER JOIN boDictation ON   bd.drID =  boDictation.drID AND   bd.foID =  boDictation.foID " _
                & "INNER JOIN boTranscription bt ON  boDictation.dicID =  bt.dicID " _
                & "Where dicDate Between '" & fDate & "' AND '" & tDate & "' AND dicStatus >=2 AND bt.traStatus >=1" & drId _
                & "Group by bd.foId+bd.drId,bt.traCharacters,dicDate) ABC Group by dicDate Order by dicDate Asc; "

            sql += "SELECT drId,drName,Sum(dicLength) as dicLength, Sum(Dictations) as Dictations, dicDate, Sum(Lines) as Lines,Sum(Transcriptions) as Transcriptions FROM " _
                & "(Select bd.foId+bd.drId as drId, bdo.drLastName + ', ' + bdo.drFirstName as drName, Sum(dicTranscriptions) as Transcriptions," _
                & "Sum(dicLength) as dicLength ,Count(bd.dicID) as Dictations,dicDate,Sum(boTranscription.traCharacters)/'" & line & "' as Lines " _
                & "FROM boDictation bd INNER JOIN boDictator bdo ON bdo.foId+bdo.drId = bd.foId+bd.drid " _
                & "INNER JOIN boTranscription On boTranscription.dicId=bd.dicId " _
                & "WHERE dicDate Between '" & fDate & "' AND '" & tDate & "' AND dicStatus >=2 AND boTranscription.traStatus>=1 " & drId _
                & "group by bd.foId,bd.drId,dicLength,dicDate,bd.dicId,bdo.drLastName,bdo.drFirstName)ABC " _
                & "group by drId,drName,dicDate Order By dicDate Asc; "

            sql += "SELECT bd.foID+ bd.drID as drId, dicDate,dicActualName as traName,dicLength,traCharacters/'" & line & "' as Lines, dicTranscriptions as Transcriptions FROM boDictation bd " _
                & "INNER JOIN boTranscription bt ON bt.dicId=bd.dicId " _
                & "WHERE dicStatus >=2 AND bt.traStatus>=1 AND dicDate Between '" & fDate & "' AND '" & tDate & "'" & drId

            Return sql
        End Function
    End Class
End Namespace