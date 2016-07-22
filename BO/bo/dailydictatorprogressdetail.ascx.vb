Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class dailydictatorprogressdetail

    Inherits System.Web.UI.UserControl

    Public rCount As Integer
    Protected m_sLayerEmployee As String
    Protected conStatus As SqlConnection
    Public rIndex As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empID") = "" Then Response.Redirect(GF.Home)
    End Sub

    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        If (Not (TypeOf dgi.DataItem Is Data.DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If
        Dim ds As Data.DataSet = CType(dgi.DataItem, Data.DataSet)
        Me.grdDailyProgress.DataSource = ds
        Me.grdDailyProgress.DataMember = "Dictators"
        Me.grdDailyProgress.DataBind()
        inc(ds.Tables(1))
    End Sub

    Protected Sub grdDailyProgress_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles grdDailyProgress.TemplateSelection
        e.TemplateFilename = "dailydictationprogressdetail.ascx"
    End Sub

    'Protected Sub dgDailyWorkloadPending_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles dgDailyWorkloadPending.TemplateSelection
    '    e.TemplateFilename = "dailydictationprogressdetail.ascx"
    'End Sub

    Protected Sub grdDailyProgress_RowDataBound(ByVal sender As Object, ByVal e As Web.UI.WebControls.DataGridItemEventArgs) Handles grdDailyProgress.ItemDataBound
        Try
            rIndex = e.Item.ItemIndex + 2
        Catch ex As Exception
            rIndex = 0
        End Try

    End Sub

    Protected Function inc(ByVal dt As DataTable) As Integer
        For Each itemRow As DataRow In dt.Rows
            Return rIndex = rIndex + 1
        Next
    End Function

    Protected Function getImage(ByVal urg As String) As String

        If urg.ToString = "True" Then
            Return "../Icon/urgent.png".Trim
        Else
            Return "../Images/dummy.jpg"
        End If

    End Function

    'Private Function AddCounterInDataTable(ByVal dt As DataTable)
    '    Dim rtnDt As DataTable = CreateDataTable()
    '    Dim cnt As Integer = 0
    '    For Each dr As DataRow In dt.Rows
    '        Dim dr1 As DataRow = rtnDt.NewRow
    '        cnt += 1
    '        dr1(0) = cnt
    '        dr1(1) = dr("dicActualName")
    '        dr1(2) = dr("dicDate")
    '        dr1(3) = dr("dicLength")
    '        dr1(4) = dr("dicStatus")
    '        dr1(5) = dr("dicID")
    '        dr1(6) = dr("dicUrgent")
    '        rtnDt.Rows.Add(dr1)
    '    Next
    '    Return rtnDt
    'End Function

    'Private Function CreateDataTable() As Data.DataTable
    '    Dim dt As New DataTable

    '    dt.Columns.Add("#")
    '    dt.Columns.Add("dicActualName")
    '    dt.Columns.Add("dicDate")
    '    dt.Columns.Add("dicLength")
    '    dt.Columns.Add("dicStatus")
    '    dt.Columns.Add("dicID")
    '    dt.Columns.Add("dicUrgent")

    '    Return dt
    'End Function

    Protected Function getCounterDaily() As String
        Dim intCountDaily As Integer = Session("sccintDaily")
        intCountDaily += 1
        Session("sccintDaily") = intCountDaily
        Return intCountDaily.ToString
    End Function

    'Public Function getDataReader(ByVal Qry As String) As SqlDataReader
    '    conStatus = New SqlConnection("Server=data;database=MTBMS-BO;user=sa")
    '    conStatus.Open()

    '    Dim Cmd As New SqlCommand(Qry, conStatus)
    '    Dim dr As SqlDataReader

    '    'objConnection.Open()
    '    dr = Cmd.ExecuteReader
    '    getDataReader = dr

    '    'dr.Close()
    '    'dr = Nothing


    'End Function

    Protected Function getStatus(ByVal viStatus As Int16) As String
        Select Case viStatus
            Case -1
                Return "Unassigned"
            Case 0
                Return "New"
            Case 1
                Return "Processing"
            Case 2
                Return "Complete"
            Case 3
                Return "Gathered"
            Case 4
                Return "Uploaded"
            Case Else
                Return "Error"
        End Select
    End Function

    Protected Function getCounter() As String
        Dim intCount As Integer = ViewState("ccint1")
        intCount += 1
        ViewState("ccint1") = intCount
        Return intCount.ToString
    End Function

    Protected Sub grdDailyProgress_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdDailyProgress.ItemDataBound
        'If e.Item.Cells(8).Text <> "" And e.Item.Cells(8).Text <> "Status" And e.Item.Cells(8).Text <> "&nbsp;" Then
        '    Dim a As String = e.Item.Cells(4).Text

        '    If a = "C" Then
        '        e.Item.Cells(4).ForeColor = Drawing.Color.Green
        '    End If
        'End If
    End Sub

    Protected Function getmin(ByVal seconds As String) As String
        Return GF.GetMin(seconds)
    End Function
End Class
