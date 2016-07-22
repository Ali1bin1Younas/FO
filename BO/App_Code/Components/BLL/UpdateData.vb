Imports Microsoft.VisualBasic

Public Class UpdateData

    Public Function UpdateRecord(ByVal hash As System.Collections.Hashtable, ByVal tblName As String) As Integer
        Dim qry As String = "Update tblName set "
        For Each col As ColumnName In hash.Values
            qry += col.colName + "="
            If col.colType = "str" Then
                qry += "'" + col.colValue + "',"
            Else
                qry += col.colValue + ","
            End If
        Next
        Return 0
    End Function
End Class
