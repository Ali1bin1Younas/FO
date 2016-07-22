Imports Microsoft.VisualBasic
Public Class AddData
    Public Function IsertData1(ByVal hash As Hashtable, ByVal tblName As String) As Integer
        Try
            Dim query As String = "Insert into " + tblName + "("
            Dim value As String = ""
            For Each col As ColumnName In hash.Values
                query += col.colName + ","

                If col.colType = "str" Then
                    value += "'" + col.colValue + "',"
                ElseIf col.colType = "int" Then
                    value += "" + col.colValue + ","
                End If
            Next
            query = query.Substring(0, query.Length - 1)
            value = value.Substring(0, value.Length - 1)
            query += ") values(" + value + ");"

            Dim dl As New MTBMS.DAL.DataAccessLayer
            dl.InsertData(query)

        Catch ex As Exception

        End Try

        
    End Function
    Public Function InsertDataValues(ByVal hash As Hashtable, ByVal tblName As String) As Integer
        Try
            Dim query As String = "Insert into " + tblName + "("
            Dim value As String = ""

            For Each col As ColumnName In hash.Values

                query += col.colName + ","


                value += "@" + col.colName + ","

            Next
            query = query.Substring(0, query.Length - 1)
            value = value.Substring(0, value.Length - 1)
            query += ") values(" + value + ");"
            Dim cmd As New Data.SqlClient.SqlCommand()
            cmd.CommandText = query

            For Each col As ColumnName In hash.Values
                cmd.Parameters.Add(Me.getParam("@" + col.colName, col.colValue, col.colType))
            Next
            Dim dl As New MTBMS.DAL.DataAccessLayer
            dl.InsertData(cmd)
        Catch ex As Exception

        End Try
        
    End Function
    Private Function getParam(ByVal paramName As String, ByVal value As String, ByVal type As String) As Data.SqlClient.SqlParameter
        Dim dbParam As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter
        dbParam.ParameterName = paramName
        dbParam.Value = value
        If type = "int" Then
            dbParam.DbType = System.Data.DbType.Int32
        ElseIf type = "date" Then
            dbParam.DbType = System.Data.DbType.DateTime
        ElseIf type = "dec" Then
            dbParam.DbType = System.Data.DbType.Double
        Else
            dbParam.DbType = System.Data.DbType.String
        End If
        Return dbParam
    End Function
    Public Function deleteData(ByVal hash1 As Hashtable, ByVal tbl As String) As Integer
        Try
            Dim Query As String = "Delete From " + tbl + " where "
            For Each col As ColumnName In hash1.Values
                Query += col.colName + "="
                Query += col.colValue
            Next
            Dim db As New MTBMS.DAL.DataAccessLayer
            db.InsertData(Query)
        Catch ex As Exception
        End Try

    End Function
    Public Function updateData(ByVal hash As System.Collections.Hashtable, ByVal tblName As String) As Integer
        Try
            Dim query As String = "Update " + tblName + " set "
            For Each col As ColumnName In hash.Values
                query += col.colName + "="
                If col.colType = "str" Then
                    query += "'" + col.colValue + "',"
                Else
                    query += col.colValue + ","
                End If
            Next
            query = query.Substring(0, query.Length - 1)
            query += "where cliID='675'"
            Dim cmd As New Data.SqlClient.SqlCommand()
            cmd.CommandText = query
            For Each col As ColumnName In hash.Values
                cmd.Parameters.Add(Me.getParam("@" + col.colName, col.colValue, col.colType))
            Next
            Dim dl As New MTBMS.DAL.DataAccessLayer
            dl.InsertData(cmd)
        Catch ex As Exception

        End Try
        
    End Function
End Class
