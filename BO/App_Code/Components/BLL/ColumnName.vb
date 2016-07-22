Imports Microsoft.VisualBasic

Public Class ColumnName
    Private _colName As String
    Private _colValue As String
    Private _colType As String
    Sub New(ByVal colName As String, ByVal colValue As String, ByVal colType As String)
        _colName = colName
        _colValue = colValue
        _colType = colType
    End Sub
    Public ReadOnly Property colName()
        Get
            Return _colName
        End Get
    End Property
    Public ReadOnly Property colValue()
        Get
            Return _colValue
        End Get
    End Property
    Public ReadOnly Property colType()
        Get
            Return _colType
        End Get
    End Property
End Class
