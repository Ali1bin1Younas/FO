Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Namespace MTBMS.DAL
    Public Class DBTaskBO

        Public Function ConnectionString() As String
            Dim ConnString As String
            'ConnString = "Server=.;database=MTBMS-BO;user=sa;pwd=eL2GKvk7"
            ConnString = "Data Source=ALIBinYounas-PC\SQLEXPRESS;Initial Catalog=MTBMS-BO;Integrated Security=True"

            Return ConnString
        End Function

        Public Function getScalar(ByVal Qry As String) As Object
            Dim Con As New SqlConnection(ConnectionString)
            Dim Cmd As New SqlCommand(Qry, Con)
            Con.Open()
            Dim i = Cmd.ExecuteScalar
            Con.Close()
            Return i
        End Function

        Public Function saveData(ByVal Qry As String) As Integer
            Dim Con As New SqlConnection(ConnectionString)
            Dim Cmd As New SqlCommand(Qry, Con)
            Con.Open()
            Dim i = Cmd.ExecuteNonQuery()
            Con.Close()
            Return i
        End Function

        Public Function saveData(ByVal cmd As SqlCommand) As Integer
            Dim Con As New SqlConnection(ConnectionString)
            cmd.Connection = Con
            Con.Open()
            Dim i = cmd.ExecuteNonQuery()
            Con.Close()
            Return i
        End Function

        Public objConnection As New SqlConnection(ConnectionString)
        'Public objDataReader As SqlDataReader = Nothing

        Public Function getDataReader(ByVal Qry As String) As SqlDataReader
            ' Dim Con As New SqlConnection(ConnectionString)

            Dim Cmd As New SqlCommand(Qry, objConnection)
            Dim dr As SqlDataReader
            objConnection.Open()
            dr = Cmd.ExecuteReader
            getDataReader = dr


            Return dr

        End Function

        Public Function getDataReader1(ByVal Qry As String) As SqlDataReader
            Dim Con As New SqlConnection(ConnectionString)
            Dim Cmd As New SqlCommand(Qry, Con)
            Dim dr As SqlDataReader
            Con.Open()
            dr = Cmd.ExecuteReader
            Return dr
            Con.Close()
        End Function

        Public Function getDataSet(ByVal Qry As String) As DataSet
            Dim da As New SqlDataAdapter(Qry, ConnectionString)
            Dim ds As New DataSet
            da.Fill(ds)
            da.Dispose()
            getDataSet = ds
            'Return (ds)
            ds.dispose()
        End Function

        Public Function InsertDataValues(ByVal hash As Hashtable, ByVal tblName As String) As Integer
            'Try
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
            saveData(cmd)
            'Catch ex As Exception
            'End Try

        End Function

        Private Function getParam(ByVal paramName As String, ByVal value As String, ByVal type As String) As Data.SqlClient.SqlParameter
            Dim dbParam As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter
            dbParam.ParameterName = paramName
            dbParam.Value = value
            If type = "int" Then
                dbParam.DbType = System.Data.DbType.Int32
            ElseIf type = "dat" Then
                dbParam.DbType = System.Data.DbType.DateTime
            ElseIf type = "dec" Then
                dbParam.DbType = System.Data.DbType.Double
            ElseIf type = "bln" Then
                dbParam.DbType = System.Data.DbType.Boolean
            Else
                dbParam.DbType = System.Data.DbType.String
            End If
            Return dbParam
        End Function

        Public Function update(ByVal query As String) As String

            Dim Con As New SqlConnection(ConnectionString)
            Dim Cmd As New SqlCommand(query, Con)
            Con.Open()
            Dim i = Cmd.ExecuteNonQuery()
            Con.Close()
            Return i
            Return True

        End Function

        Public Function updateDataValues(ByVal hash As System.Collections.Hashtable, ByVal tblName As String) As Integer

            Dim query As String = "Update " + tblName + " set "

            Dim values As ColumnName = Nothing
            Dim colls As System.Collections.IDictionaryEnumerator = hash.GetEnumerator
            While colls.MoveNext

                If colls.Key = "wheres" Then
                    Continue While
                End If
                values = colls.Value
                query += values.colName + "=@" + values.colName + ","

            End While
            query = query.Substring(0, query.Length - 1)
            Dim col1 As ColumnName = hash("wheres")
            query += " where" + " " + col1.colName + "=@" + col1.colName

            Dim cmd As New Data.SqlClient.SqlCommand()
            cmd.CommandText = query
            For Each col As ColumnName In hash.Values
                cmd.Parameters.Add(Me.getParam("@" + col.colName, col.colValue, col.colType))
            Next
            saveData(cmd)
        End Function

        Public Function deleteDataValues(ByVal Qry As String) As Integer
            Dim Con As New SqlConnection(ConnectionString)
            Dim Cmd As New SqlCommand(Qry, Con)
            Con.Open()
            Dim i = Cmd.ExecuteNonQuery()
            Con.Close()
            Return i
        End Function

        Public Function saveDataValues(ByVal Qry As String) As Integer
            Dim Con As New SqlConnection(ConnectionString)
            Dim Cmd As New SqlCommand(Qry, Con)
            Con.Open()
            Dim i = Cmd.ExecuteNonQuery()
            Con.Close()
            Return i
        End Function

        Public Function deleteDataValues1(ByVal Qry As String) As Integer
            Dim Con As New SqlConnection(ConnectionString)
            Dim Cmd As New SqlCommand(Qry, Con)
            Con.Open()
            Dim i As Integer = Cmd.ExecuteScalar()
            Con.Close()
            Return i
        End Function

        ''Testing for Status

        Public Function getDataReaderMT(ByVal Qry As String) As SqlDataReader
            Dim Con As New SqlConnection(ConnectionString)
            Dim Cmd As New SqlCommand(Qry, Con)
            Dim dr As SqlDataReader
            Con.Open()
            dr = Cmd.ExecuteReader
            Return dr
            Con.Close()
        End Function

        Public Function getDataReaderQC(ByVal Qry As String) As SqlDataReader
            Dim Con As New SqlConnection(ConnectionString)
            Dim Cmd As New SqlCommand(Qry, Con)
            Dim dr As SqlDataReader
            Con.Open()
            dr = Cmd.ExecuteReader
            Return dr
            Con.Close()
        End Function

        Public Function getDataReaderPR(ByVal Qry As String) As SqlDataReader
            Dim Con As New SqlConnection(ConnectionString)
            Dim Cmd As New SqlCommand(Qry, Con)
            Dim dr As SqlDataReader
            Con.Open()
            dr = Cmd.ExecuteReader
            Return dr
            Con.Close()
        End Function

        Public Function getDataReaderFR(ByVal Qry As String) As SqlDataReader
            Dim Con As New SqlConnection(ConnectionString)
            Dim Cmd As New SqlCommand(Qry, Con)
            Dim dr As SqlDataReader
            Con.Open()
            dr = Cmd.ExecuteReader
            Return dr
            Con.Close()
        End Function




















    End Class
End Namespace

