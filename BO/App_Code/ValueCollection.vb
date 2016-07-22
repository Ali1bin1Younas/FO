Imports Microsoft.VisualBasic

Public Class ValueCollection
    Public _foid As String
    Public _dicid As String
    Public _drid As String
    Public _ddate As String
    Public _name As String
    Public _ext As String
    Public _loctation As String
    Public _lastLayer As String
    Public _empName As String
    Public _remarks As String
    Public _datetime As String
    Public _layer As String
    Public _tag As String


    Sub New(ByVal foid As String, ByVal dicid As String, ByVal drid As String, ByVal ddate As String, ByVal name As String, ByVal ext As String, ByVal loctation As String, ByVal lastLayer As String, ByVal empName As String, ByVal remarks As String, ByVal datetime As String, ByVal layer As String, ByVal tag As String)

        _foid = foid
        _dicid = dicid
        _ddate = ddate
        _name = name
        _drid = drid
        _ext = ext
        _loctation = loctation
        _lastLayer = lastLayer
        _empName = empName
        _remarks = remarks
        _datetime = datetime
        _layer = layer
        _tag = tag
    End Sub
End Class
