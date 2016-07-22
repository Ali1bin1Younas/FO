Imports System.Data
Partial Class drstatusbacklog
    Inherits System.Web.UI.UserControl
    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        'if an InvalidCastException occurs in either of the next two lines, 
        'please make sure that you've set the TemplateDataMode to Table (because you want nested grids)
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        If (Not (TypeOf dgi.DataItem Is Data.DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If
        Dim ds As Data.DataSet = CType(dgi.DataItem, Data.DataSet)

        If ds.Tables("DR1").Rows.Count <> 0 Then
            Me.grdAssigned.DataSource = ds
            Me.grdAssigned.DataMember = "DR1"
            Me.grdAssigned.DataBind()
            Me.grdAssigned.Visible = True
        Else
            Me.grdAssigned.Visible = False
        End If
        Me.grdAssigned.RowExpanded.ExpandAll()
    End Sub
    Protected Sub grdAssigned_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles grdAssigned.TemplateSelection
        e.TemplateFilename = "dicstatusbacklog.ascx"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
    End Sub
    Protected Function getmin(ByVal seconds As String) As String
        Return GF.GetMin(seconds)
    End Function
End Class
