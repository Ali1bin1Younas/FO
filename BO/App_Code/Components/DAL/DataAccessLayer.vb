Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Namespace MTBMS.DAL
    Public Class DataAccessLayer
        Public Function ConnectionString() As String
            Dim ConnString As String
            'ConnString = "Data Source=Data;Initial Catalog=MTBMS;Integrated Security=True"
            'ConnString = "Data Source=DATA;Initial Catalog=MTBMS;User ID=sa"
            ' ConnString = "Data Source=Data;Initial Catalog=MTBMS;Integrated Security=True"
            ConnString = "Data Source=ALIBinYounas-PC\SQLEXPRESS;Initial Catalog=MTBMS-BO;Integrated Security=True"
            'ConnString = "Server=172.0.0.9;Database=MTBMS;user id=sa"
            Return ConnString
        End Function

        Public Function InsertData(ByVal Qry As String) As Integer
            Dim Con As New SqlConnection(ConnectionString)
            Dim Cmd As New SqlCommand(Qry, Con)
            Con.Open()
            Dim i = Cmd.ExecuteNonQuery()
            Con.Close()
            Return i
        End Function
        Public Function InsertData(ByVal cmd As SqlCommand) As Integer
            Dim Con As New SqlConnection(ConnectionString)
            cmd.Connection = Con
            Con.Open()
            Dim i = cmd.ExecuteNonQuery()
            Con.Close()
            Return i
        End Function
        Public Function SelectReader(ByVal Qry As String) As SqlDataReader
            Dim Con As New SqlConnection(ConnectionString)
            Dim Cmd As New SqlCommand(Qry, Con)
            Dim dr As SqlDataReader
            Con.Open()
            dr = Cmd.ExecuteReader
            Return dr
            Con.Close()
        End Function
        Public Function SelectData(ByVal Qry As String) As DataSet
            Dim da As New SqlDataAdapter(Qry, ConnectionString)
            Dim ds As New DataSet
            da.Fill(ds)
            Return (ds)
        End Function
        Public Function Save(ByVal ds1 As DataSet, ByVal tbl As String) As Integer
            Dim myConnection As SqlConnection
            Dim mySqlDataAdapter As SqlDataAdapter
            myConnection = New SqlConnection(ConnectionString)
            mySqlDataAdapter = New SqlDataAdapter("Select * from " + tbl.ToString, myConnection)
            Dim myDataRowsCommandBuilder As SqlCommandBuilder = New SqlCommandBuilder(mySqlDataAdapter)
            mySqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
            mySqlDataAdapter.Update(ds1, tbl)
        End Function
    End Class
End Namespace

