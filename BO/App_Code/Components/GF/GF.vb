Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Data

Public Class GF 'General Funcation Class
    Inherits System.Web.UI.Page
    Shared _Refresh As Int16 = 1
    Private _DoneDictation, _OutDictation, _OutMinutes, _DoneMinutes As String
    Private _DateTo As String
    Private _DateFrom As String
    Private Total_Data As New List(Of String)

    Public Shared Home As String = "../index.aspx"
    Public Sub New()

    End Sub

    Public Shared Property Refresh() As Int16
        Get
            Return _Refresh
        End Get
        Set(ByVal value As Int16)
            _Refresh = value
        End Set
    End Property
    Public Property DateTo() As String
        Get
            Return _DateTo
        End Get
        Set(ByVal value As String)
            _DateTo = value
        End Set
    End Property

    Public Property DateFrom() As String
        Get
            Return _DateFrom
        End Get
        Set(ByVal value As String)
            _DateFrom = value
        End Set
    End Property

    Public Shared Function GetMin(ByVal Seconds As String) As String
        Dim min, min2 As String
        min = Seconds / 60
        min2 = Seconds Mod 60
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

    Public Shared Function getEverage(ByVal viMinutes As Int32, ByVal viCounter As Int16) As String
        Dim min As Int32 = viMinutes
        min = Math.Round(min / viCounter, 0)
        Return GetMin(min)
    End Function

    Public Function Line_Per_Minutes(ByVal min As String, ByVal line As String) As String
        If min = "0" Then
            Return "-"
        Else
            min = min / 60
            min = System.Math.Round(line / min, 2)
            Return min
        End If
    End Function

    Public Function Line_Per_Transcriptions(ByVal Trans As String, ByVal line As String) As String
        If Trans = "0" Then
            Return "-"
        Else
            Trans = System.Math.Round(line / Trans, 2)
            Return Trans
        End If
    End Function

    Protected Function DoneDictation(ByVal Status As String) As String
        If Status = "0" Or Status = "1" Or Status = "5" Then
            _DoneDictation = "'0'"
        ElseIf Status = "2" Or Status = "3" Or Status = "4" Then
            _DoneDictation = "COUNT(b.dicActualName)"
        Else
            _DoneDictation = "(Select Count(dicID) from boDictation where dicStatus >=2 AND foID+drID=b.foID+b.drID " _
                             & "AND dicDate BETWEEN '" + _DateFrom + "' AND '" + _DateTo + "')"
        End If
        Return _DoneDictation
    End Function
    Protected Function OutDictation(ByVal Status As String) As String
        If Status = "0" Or Status = "1" Or Status = "5" Then
            _OutDictation = "COUNT(b.dicActualName)"
        ElseIf Status = "2" Or Status = "3" Or Status = "4" Then
            _OutDictation = "'0'"
        Else
            _OutDictation = "(Select Count(dicActualName) From boDictation where dicEnable = 1 AND dicStatus < 2 " _
                                        & "and dicDate BETWEEN '" + _DateFrom + "' AND '" + _DateTo + "' " _
                                        & "and foID+drID=b.foID+b.drID)"
        End If
        Return _OutDictation
    End Function

    Protected Function DoneMinutes(ByVal Status As String) As String
        If Status = "0" Or Status = "1" Or Status = "5" Then
            _DoneMinutes = "'0'"
        ElseIf Status = "2" Or Status = "3" Or Status = "4" Then
            _DoneMinutes = "SUM(b.dicLength)"
        Else
            _DoneMinutes = "(SELECT Isnull(sum(dicLength),'') From boDictation Where foID+drID = b.foID+b.drID " _
                                        & "AND dicStatus >=2 And dicDate BETWEEN '" + _DateFrom + "' AND '" + _DateTo + "' )"
        End If
        Return _DoneMinutes
    End Function

    Protected Function OutMinutes(ByVal Status As String) As String
        If Status = "0" Or Status = "1" Or Status = "5" Then
            _OutMinutes = "'0'"
        ElseIf Status = "2" Or Status = "3" Or Status = "4" Then
            _OutMinutes = "SUM(b.dicLength)"
        Else
            _OutMinutes = "(Select isnull(Sum(boDictation.dicLength),'') as TotalMinute " _
                                      & "From boDictation where dicStatus < 2 AND dicEnable = 1 " _
                                      & "and dicDate BETWEEN '" + _DateFrom + "' AND '" + _DateTo + "' " _
                                      & "and foID+drID=b.foID+b.drID)"
        End If
        Return _OutMinutes
    End Function

    Public Function Get_Query_Data(ByVal status As String) As List(Of String)
        Try
            Total_Data.Add(Me.DoneDictation(status))
            Total_Data.Add(Me.OutDictation(status))
            Total_Data.Add(Me.DoneMinutes(status))
            Total_Data.Add(Me.OutMinutes(status))
            Total_Data.TrimExcess()
        Catch ex As Exception

        End Try
        Return Total_Data
    End Function
End Class
