Imports System.Data
Partial Class dictatorworkloaddetail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        'if an InvalidCastException occurs in either of the next two lines, 
        'please make sure that you've set the TemplateDataMode to Table (because you want nested grids)
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        If (Not (TypeOf dgi.DataItem Is Data.DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If
        Dim ds As Data.DataSet = CType(dgi.DataItem, Data.DataSet)
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

            rtnDt.Rows.Add(dr1)
        Next
        Return rtnDt
    End Function

    Protected Function getmin(ByVal second As String) As String
        Return GF.GetMin(second)
    End Function

    Private Function CreateDataTable() As Data.DataTable
        Dim dt As New DataTable
        dt.Columns.Add("#")
        dt.Columns.Add("dicActualName")
        dt.Columns.Add("dicDate")
        dt.Columns.Add("dicLength")

        Return dt
    End Function

    Protected Function getCounterDaily() As String
        Dim intCountDaily As Integer = Session("sccintDaily")
        intCountDaily += 1
        Session("sccintDaily") = intCountDaily
        Return intCountDaily.ToString
    End Function

    Protected Function getStatusBO(ByVal str As String) As String
        Select Case str
            Case "0"
                Return "Pending"
            Case "1"
                Return "Pending"
            Case "2"
                Return ("Complete")
            Case "3"
                Return "Complete"
        End Select
        Return Nothing
    End Function

    Protected Function getStatusPR(ByVal str As String) As String
        Select Case str
            Case "0"
                Return "Pending"
            Case "1"

                Return "Pending"
            Case "2"
                Return "Pending"
            Case "3"
                Return "Complete"
        End Select
        Return Nothing
    End Function

    Protected Function getStatusClient(ByVal str As String) As String
        Select Case str
            Case "0"
                Return "Pending"
            Case "1"

                Return "Pending"
            Case "2"
                Return "Pending"
            Case "3"
                Return "Available"
        End Select
        Return Nothing
    End Function

    Protected Function getCounter() As String
        Dim intCount As Integer = ViewState("ccint1")
        intCount += 1
        ViewState("ccint1") = intCount
        Return intCount.ToString
    End Function

    Private Sub ddd()
        For Each item As GridViewRow In Me.grdDailyProgress.Rows
            Dim chk As CheckBox = item.FindControl("chk")
            If chk.Checked Then
                My.Computer.FileSystem.DeleteFile(Server.MapPath("../Data\" & Session("scliID") & "\Temp\" + item.Cells(1).Text.ToString))
            End If
        Next
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
    End Sub

End Class
