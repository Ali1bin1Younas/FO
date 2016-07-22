Imports System.Data

Partial Class drstatus
    Inherits System.Web.UI.UserControl
    Protected Counter As Int32

    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        'if an InvalidCastException occurs in either of the next two lines, 
        'please make sure that you've set the TemplateDataMode to Table (because you want nested grids)
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        If (Not (TypeOf dgi.DataItem Is Data.DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If
        Dim ds As Data.DataSet = CType(dgi.DataItem, Data.DataSet)
        If ds.Tables("DR").Rows.Count <> 0 Then
            Me.grdCurrent.DataSource = ds
            Me.grdCurrent.DataMember = "DR"
            Me.grdCurrent.DataBind()
            Me.grdCurrent.RowExpanded.ExpandAll()

        End If
        
    End Sub

    Protected Sub grdCurrent_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdCurrent.ItemCreated
        If e.Item.ItemType = ListItemType.Header Then
            Counter = 0
        Else
            Counter += 1
        End If

    End Sub
   
    Protected Sub grdCurrent_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles grdCurrent.TemplateSelection
        e.TemplateFilename = "dicstatus.ascx"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        Counter = 0
    End Sub
    Protected Function getmin(ByVal seconds As String) As String
        Return GF.GetMin(seconds)
    End Function
End Class
