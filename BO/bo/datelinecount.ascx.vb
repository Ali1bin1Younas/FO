
Partial Class BO_datelinecount
    Inherits System.Web.UI.UserControl
    Protected rCount As Int16

    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        If (Not (TypeOf dgi.DataItem Is Data.DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If
        Dim ds As Data.DataSet = CType(dgi.DataItem, Data.DataSet)
        Me.GridDr.DataSource = ds
        Me.GridDr.DataMember = "Second"
        Me.GridDr.DataBind()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        rCount = 0
    End Sub

    Protected Sub GridDr_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles GridDr.ItemCreated
        If e.Item.ItemType = ListItemType.Header Then
            rCount = 0
        Else
            rCount += 1
        End If
    End Sub

    Protected Sub GridDr_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles GridDr.TemplateSelection
        e.TemplateFilename = "datelinecountdate.ascx"
    End Sub

    Protected Function Line_Per_Minutes(ByVal seconds As String, ByVal lines As String) As String
        Dim obj As New GF
        Return obj.Line_Per_Minutes(seconds, lines)
    End Function

    Protected Function Lines_Per_Transcriptions(ByVal trans As String, ByVal line As String) As String
        Dim obj As New GF
        Return obj.Line_Per_Transcriptions(trans, line)
    End Function
End Class
