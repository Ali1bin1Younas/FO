Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class dailydictationdetailBacklog

    Inherits System.Web.UI.UserControl

    Protected m_sLayerEmployee As String

    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        'if an InvalidCastException occurs in either of the next two lines, 
        'please make sure that you've set the TemplateDataMode to Table (because you want nested grids)
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        Dim ds As Data.DataSet = CType(dgi.DataItem, Data.DataSet)

        If (Not (TypeOf dgi.DataItem Is Data.DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If

        ViewState("ccint1") = 0

        Me.grdDailyProgress.DataSource = AddCounterInDataTable(ds.Tables("Dic"))
        Me.grdDailyProgress.DataBind()
    End Sub

    Private Function AddCounterInDataTable(ByVal dt As DataTable)
        Dim rtnDt As DataTable = CreateDataTable()
        Dim cnt As Integer = 0
        For Each dr As DataRow In dt.Rows
            Dim dr1 As DataRow = rtnDt.NewRow
            cnt += 1
            dr1(0) = cnt
            dr1(1) = dr("dicActualName")
            dr1(2) = dr("dicDate")
            dr1(3) = dr("dicLength")
            dr1(4) = dr("dicStatus")
            dr1(5) = dr("dicID")
            rtnDt.Rows.Add(dr1)
        Next
        Return rtnDt
    End Function

    Private Function CreateDataTable() As Data.DataTable
        Dim dt As New DataTable

        dt.Columns.Add("#")
        dt.Columns.Add("dicActualName")
        dt.Columns.Add("dicDate")
        dt.Columns.Add("dicLength")
        dt.Columns.Add("dicStatus")
        dt.Columns.Add("dicID")

        Return dt
    End Function

    Protected Function getCounterDaily() As String
        Dim intCountDaily As Integer = Session("sccintDaily")
        intCountDaily += 1
        Session("sccintDaily") = intCountDaily
        Return intCountDaily.ToString
    End Function

    Protected Function getLayerDetail(ByVal strdicID As Integer, ByVal vsrolID As String) As String
        Dim sStatusImage As String
        Dim drStatus As SqlDataReader
        Dim conStatus As New DBTaskBO

        Dim qryMT As String = "SELECT boDictationLayers.empID, empLastName+', '+Left(empFirstName,1) AS empName, diclStatus FROM boDictationLayers " _
                              & "INNER JOIN boEmployee ON boDictationLayers.empID = boEmployee.empID " _
                              & "WHERE dicID = " & strdicID & " AND rolID = '" & vsrolID & "' "
        drStatus = conStatus.getDataReaderMT(qryMT)

        If drStatus.Read Then
            If drStatus("empID").ToString.Trim = "0" Then
                m_sLayerEmployee = "-"
            Else
                m_sLayerEmployee = drStatus("empName")
            End If

            Select Case drStatus("diclStatus")
                Case 0
                    sStatusImage = "../images/NotAvailable.gif"
                Case 1
                    sStatusImage = "../images/Available.gif"
                Case 2
                    sStatusImage = "../images/Processing.gif"
                Case 3
                    sStatusImage = "../images/Complete.gif"
                Case Else
                    sStatusImage = "../images/Error.gif"
            End Select
        Else
            m_sLayerEmployee = "Error"
            sStatusImage = "../images/Error.gif"
        End If

        drStatus.Close()
        drStatus = Nothing

        conStatus.objConnection.Close()
        conStatus = Nothing

        Return sStatusImage
    End Function

    'Protected Function getStatusImage(ByVal viStatus As Int16) As String
    '    Select Case viStatus
    '        Case 0
    '            Return "../images/NotAvaliable.gif"
    '        Case 1
    '            Return "../images/Avaliable.gif"
    '        Case 2
    '            Return "../images/Processing.gif"
    '        Case 3
    '            Return "../images/Complete.gif"
    '        Case Else
    '            Return "../images/Error.gif"
    '    End Select
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empID") = "" Then Response.Redirect(GF.Home)
    End Sub
End Class
