Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class dailydictationprogressdetail

    Inherits System.Web.UI.UserControl

    Protected m_sLayerEmployee As String
    Protected conStatus As SqlConnection
    Public rIndex As String = 0

    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        If (Not (TypeOf dgi.DataItem Is Data.DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If
        ViewState("ccint1") = 0
        Dim ds As Data.DataSet = CType(dgi.DataItem, Data.DataSet)
        Me.grdDailyProgress.DataSource = ds
        Me.grdDailyProgress.DataMember = "Dics"
        Me.grdDailyProgress.DataBind()
        inc(ds.Tables(2))
    End Sub

    Protected Function getImage(ByVal urg As String) As String

        If urg.ToString = "True" Then
            Return "../Icon/urgent.png".Trim
        Else
            Return "../Images/dummy.jpg"
        End If

    End Function
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

    Protected Function getLayerDetail(ByVal strdicID As Integer, ByVal vsrolID As String) As String
        Dim sStatusImage As String
        'Dim drStatus As SqlDataReader

        'Try
        'Dim conStatus As New DBTaskBO

        Dim qryMT As String = "SELECT boDictationLayers.empID, empLastName+', '+Left(empFirstName,1) AS empName, diclStatus FROM boDictationLayers " _
                              & "INNER JOIN boEmployee ON boDictationLayers.empID = boEmployee.empID " _
                              & "WHERE dicID = " & strdicID & " AND rolID = '" & vsrolID & "' "


        'drStatus = getDataReader(qryMT)

        Dim Con As New DBTaskBO
        Dim ds As DataSet
        ds = Con.getDataSet(qryMT)

        'If drStatus.Read Then
        '    If drStatus("empID").ToString.Trim = "0" Then
        '        m_sLayerEmployee = "-"
        '    Else
        '        m_sLayerEmployee = drStatus("empName")
        '    End If

        '    Select Case drStatus("diclStatus")
        '        Case 0
        '            sStatusImage = "../images/NotAvailable.gif"
        '        Case 1
        '            sStatusImage = "../images/Available.gif"
        '        Case 2
        '            sStatusImage = "../images/Processing.gif"
        '        Case 3
        '            sStatusImage = "../images/Complete.gif"
        '        Case Else
        '            sStatusImage = "../images/Error.gif"
        '    End Select
        'Else
        '    m_sLayerEmployee = "Error"
        '    sStatusImage = "../images/Error.gif"
        'End If

        'drStatus.Close()
        'drStatus = Nothing

        If ds.tables(0).rows.count > 0 Then
            If ds.tables(0).rows(0).item("empID").ToString.Trim = "0" Then
                m_sLayerEmployee = "-"
            Else
                m_sLayerEmployee = ds.tables(0).rows(0).item("empName")
            End If

            Select Case ds.tables(0).rows(0).item("diclStatus")
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


        'conStatus.Close()
        'conStatus = Nothing

        'conStatus.objConnection.Dispose()
        'conStatus = Nothing
        'drStatus.Close()
        Return sStatusImage
        'Catch

        'Finally

        'End Try
    End Function
   
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

    Protected Function getmin(ByVal seconds As String) As String
        Return GF.GetMin(seconds)
    End Function
End Class
