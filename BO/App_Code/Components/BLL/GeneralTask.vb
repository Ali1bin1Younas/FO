Imports Microsoft.VisualBasic
Imports MTBMS.DAL
Imports System.Data
Imports System.Data.SqlClient
Namespace MTBMS.BLL
    Public Class GeneralTask
        Public Function getFieldValues(ByVal colName As String, ByVal tblName As String) As SqlDataReader
            Dim ConString As New DBTaskBO
            Dim Con As New SqlConnection(ConString.ConnectionString)
            Dim Cmd As New SqlCommand("Select " + colName + " From " + tblName + "", Con)
            Dim dr As SqlDataReader
            Con.Open()
            dr = Cmd.ExecuteReader
            Return dr
        End Function
    End Class
End Namespace