
Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Imports System.IO
Imports System.Web.Services

Partial Class DeleteUtilitySettings2
    Inherits System.Web.UI.Page
    Protected iCounter As Int16

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        iCounter = 0
        Try
            If Not Page.IsPostBack Then

            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Function getEnableDisable(ByVal ED As String) As String

        If ED.ToString = "True" Then
            Return "../Icon/Ngood.gif".Trim
        Else
            Return "../Icon/cancel.gif".Trim
        End If

    End Function

    'Protected Sub grdEmployee_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEmployee.RowCreated
    '    If e.Row.RowIndex > 0 Then iCounter += 1
    'End Sub

    <WebMethod> _
    Public Shared Function get_folder_structure() As String()
        Dim folder_structure_qry As String = ""
        Dim objDB As New DBTaskBO
        Dim folder_structure_ds As New DataSet
        Dim res_vals(1) As String
        Try
            folder_structure_qry = "Select fst.*, CASE schf.schtype " _
                                    & " WHEN 1 THEN 'Daily' + ', ' + schf.schtime + ' - O Clock' " _
                                    & " WHEN 2 THEN 'Weekly' + ', ' + LEFT(CONVERT(VARCHAR,schf.schdate, 106), 11) + ', ' + schf.schtime + ' - O Clock' " _
                                    & " WHEN 3 THEN 'Fortnight' + ', ' + LEFT(CONVERT(VARCHAR,schf.schdate, 106), 11) + ', ' + schf.schtime + ' - O Clock' " _
                                    & " WHEN 4 THEN 'Monthly' + ', ' + LEFT(CONVERT(VARCHAR,schf.schdate, 106), 11) + ', ' + schf.schtime + ' - O Clock' " _
                                    & " ELSE 'No Schedule' " _
                                    & " END as scheduleDetail from folderstructure fst left outer join schedulerfolders schf on schf.fid = fst.fid and schDefault = '1' "
            'folder_structure_qry = "Select * from folderstructure"
            folder_structure_ds = objDB.getDataSet(folder_structure_qry)
            folder_structure_ds.Tables(0).TableName = "tree"
            If folder_structure_ds.Tables(0).Rows.Count > 0 Then
                res_vals(0) = "1"
                res_vals(1) = folder_structure_ds.GetXml()
                Return res_vals
            Else
                res_vals(0) = "0"
                res_vals(1) = "No Record Found"
                Return res_vals
            End If
        Catch ex As Exception
            res_vals(0) = "-1"
            res_vals(1) = ex.Message.ToString()
            Return res_vals
        End Try
    End Function

    <WebMethod> _
    Public Shared Function get_folders_list() As String()
        Dim folder_structure_qry As String = ""
        Dim objDB As New DBTaskBO
        Dim folder_structure_ds As New DataSet
        Dim res_vals(1) As String
        Try
            folder_structure_qry = "Select * from folders where folEnable = '1' Order By folName"
            folder_structure_ds = objDB.getDataSet(folder_structure_qry)
            folder_structure_ds.Tables(0).TableName = "folders"
            If folder_structure_ds.Tables(0).Rows.Count > 0 Then
                Dim res_folders(folder_structure_ds.Tables(0).Rows.Count) As String
                Dim i As Integer = 1
                res_folders(0) = "1"
                For Each dr As DataRow In folder_structure_ds.Tables(0).Rows
                    res_folders(i) = dr("folName").ToString().Trim()
                    i = i + 1
                Next
                Return res_folders
            Else
                res_vals(0) = "0"
                res_vals(1) = "No Record Found"
                Return res_vals
            End If
        Catch ex As Exception
            res_vals(0) = "-1"
            res_vals(1) = ex.Message.ToString()
            Return res_vals
        End Try
    End Function

    <WebMethod> _
    Public Shared Function add_folder_name(ByVal folName As String) As String
        Dim add_folder_name_qry As String = ""
        Dim add_folder_name_chk_qry As String = ""
        Dim objDB As New DBTaskBO
        Try
            add_folder_name_chk_qry = "select * from folders where folName = '" & folName & "'"
            If objDB.getDataSet(add_folder_name_chk_qry).Tables(0).Rows.Count < 1 Then
                add_folder_name_qry = "Insert into folders(folname,folEnable) values('" & folName.Trim() & "', '1')"
                If objDB.saveData(add_folder_name_qry) Then
                    Return "1"
                Else
                    Return "0"
                End If
            Else
                Return "2"
            End If
        Catch ex As Exception
            Return "-1"
        End Try
    End Function

    <WebMethod> _
    Public Shared Function add_folder(ByVal folder As String, ByVal parentID As String, byval is_chk As Boolean) As String
        Dim add_folder_qry As String = ""
        Dim add_folder_chk_qry As String = ""
        Dim objDB As New DBTaskBO
        Try
            add_folder_chk_qry = "select * from folderstructure where foldername = '" & folder & "' and parentid = " & parentID
            If objDB.getDataSet(add_folder_chk_qry).Tables(0).Rows.Count < 1 Then
                add_folder_qry = "Insert into folderstructure(foldername,parentID,fEnable) values('" & folder.Trim() & "', '" & parentID.Trim() & "', '" & IIf(is_chk = True, 1, 0) & "')"
                If objDB.saveData(add_folder_qry) Then
                    Return "1"
                Else
                    Return "0"
                End If
            Else
                Return "2"
            End If
            
        Catch ex As Exception
            Return "-1"
        End Try
    End Function

    <WebMethod> _
    Public Shared Function enable_folder(ByVal fID As String, ByVal is_chk As Boolean) As String
        Dim enable_folder_qry As String = ""
        Dim objDB As New DBTaskBO
        Try
            enable_folder_qry = "Update folderstructure set fEnable = '" & IIf(is_chk = True, 1, 0) & "' where fID IN (" & fID & ")"
            If objDB.saveData(enable_folder_qry) Then
                Return "1"
            Else
                Return "0"
            End If
        Catch ex As Exception
            Return "-1"
        End Try
    End Function

    <WebMethod> _
    Public Shared Function remove_folder(ByVal fID As String) As String
        Dim enable_folder_qry As String = ""
        Dim objDB As New DBTaskBO
        Dim con As SqlConnection = New SqlConnection(objDB.ConnectionString)
        con.Open()

        Dim cmd As SqlCommand = con.CreateCommand()
        Dim transaction As SqlTransaction

        transaction = con.BeginTransaction()

        cmd.Connection = con
        cmd.Transaction = transaction

        Try
            cmd.CommandText = "delete schedulerfolders where fid IN(" & fID & ")"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "delete folderstructure where fid IN(" & fID & ")"
            cmd.ExecuteNonQuery()

            transaction.Commit()
            con.Close()

            Return "1"
        Catch ex As Exception
            transaction.Rollback()
            Return ex.Message.ToString()
        End Try
    End Function

    <WebMethod> _
    Public Shared Function get_schedule(ByVal fID As String) As String()
        Dim vals(8) As String
        Try
            Dim objDB As New DBTaskBO
            Dim dsVals As DataSet
            Dim qry As String = "select scheduleid, schtype, isNull(schday, '') schday, isNull(schdate, '1/1/1999') schdate, isNull(schtime,'0') schtime, " _
                                & " isNull(schDefault, '0') schDefault, isNull(schKeepFiles, 2) schKeepFiles, fid from schedulerfolders where schDefault='1' and fid='" & fID & "'"
            dsVals = objDB.getDataSet(qry)
            If dsVals.Tables(0).Rows.Count > 0 Then
                For Each dr As DataRow In dsVals.Tables(0).Rows
                    vals(0) = "1"
                    vals(1) = dr("scheduleid").ToString()
                    vals(2) = dr("schtype").ToString()
                    vals(3) = dr("schday").ToString()
                    vals(4) = dr("schdate").ToString()
                    vals(5) = dr("schtime").ToString()
                    vals(6) = dr("fid").ToString()
                    vals(7) = IIf(dr("schDefault") = True, 1, 0)
                    vals(8) = dr("schKeepFiles").ToString()
                Next
            Else
                vals(0) = "0"
                vals(1) = "No Schedule found"
            End If

            Return vals
        Catch ex As Exception
            vals(0) = "-1"
            vals(1) = ex.Message.ToString()
            Return vals
        End Try
    End Function

    <WebMethod> _
    Public Shared Function get_schedule_by_schType(ByVal fID As String, ByVal schType As Integer) As String()
        Dim vals(8) As String
        Try
            Dim objDB As New DBTaskBO
            Dim dsVals As DataSet
            Dim qry As String = "select scheduleid, schtype, isNull(schday, '') schday, isNull(schdate, '1/1/1999') schdate, isNull(schtime,'0') schtime, " _
                               & " isNull(schDefault, '0') schDefault, isNull(schKeepFiles, 2) schKeepFiles, fid from schedulerfolders where schType='" & schType & "' and fid='" & fID & "'"
            
            dsVals = objDB.getDataSet(qry)
            If dsVals.Tables(0).Rows.Count > 0 Then
                For Each dr As DataRow In dsVals.Tables(0).Rows
                    vals(0) = "1"
                    vals(1) = dr("scheduleid").ToString()
                    vals(2) = dr("schtype").ToString()
                    vals(3) = dr("schday").ToString()
                    vals(4) = dr("schdate").ToString()
                    vals(5) = dr("schtime").ToString()
                    vals(6) = dr("fid").ToString()
                    vals(7) = IIf(dr("schDefault") = True, 1, 0)
                    vals(8) = dr("schKeepFiles").ToString()
                Next
            Else
                vals(0) = "0"
                vals(1) = "No Schedule found"
            End If

            Return vals
        Catch ex As Exception
            vals(0) = "-1"
            vals(1) = ex.Message.ToString()
            Return vals
        End Try
    End Function

    <WebMethod> _
    Public Shared Function save_schedule(ByVal schID As String, ByVal schTime As String, ByVal schDate As Date, ByVal schType As String, ByVal fID As String, ByVal schKeepFiles As Integer) As String
        Dim sch_folder_qry As String = ""
        Dim objDB As New DBTaskBO
        Dim clause As String = ""
        Try
            If schID <> "0" Then
                If schType = "1" Then
                    clause = "schtime = '" & schTime & "'"
                Else
                    clause = "schtime = '" & schTime & "', schDate = '" & Format(schDate, "MM/dd/yyyy") & "'"
                End If
                sch_folder_qry = "Update schedulerfolders set " & clause & " where scheduleid = " & schID & ";" _
                    & " Update schedulerfolders set schKeepFiles=" & schKeepFiles & " where fid = " & fID & ";"
            Else
                Dim schDefault As Integer = 0
                sch_folder_qry = "select scheduleid from schedulerfolders where fid=" & fID
                If objDB.getDataSet(sch_folder_qry).Tables(0).Rows.Count < 1 Then
                    schDefault = 1
                End If
                If schType = "1" Then
                    clause = "(schtime,schType,schDefault,schKeepFiles,fID) values('" & schTime & "'," & schType & ",'" & schDefault & "', " & schKeepFiles & " ,'" & fID & "')"
                Else
                    clause = "(schtime,schDate,schType,schDefault,schKeepFiles,fID) Values('" & schTime & "','" & Format(schDate, "MM/dd/yyyy") & "','" & schType & "','" & schDefault & "', " & schKeepFiles & " ,'" & fID & "')"
                End If
                sch_folder_qry = "Insert into schedulerfolders " & clause
            End If

            If objDB.saveData(sch_folder_qry) Then
                Return "1"
            Else
                Return "0"
            End If
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    <WebMethod> _
    Public Shared Function set_schedule_default(ByVal schID As String, ByVal is_chk As Boolean, ByVal fID As String) As String
        Dim default_qry As String = ""
        Dim objDB As New DBTaskBO
        Try
            If is_chk Then
                default_qry = "Update schedulerfolders set schDefault = '0' where fid =" & fID
                objDB.saveData(default_qry)
            End If
            default_qry = "Update schedulerfolders set schDefault = '" & IIf(is_chk = True, 1, 0) & "' where scheduleid =" & schID
            If objDB.saveData(default_qry) Then
                Return "1"
            Else
                Return "0"
            End If
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function
End Class
