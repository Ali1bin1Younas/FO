
Partial Class BO_dictatorlinecountdatewise
    Inherits System.Web.UI.UserControl
    Protected RowCount As Int16

    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        If (Not (TypeOf dgi.DataItem Is Data.DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If
        Dim ds As Data.DataSet = CType(dgi.DataItem, Data.DataSet)
        Me.gridDictator.DataSource = ds
        Me.gridDictator.DataMember = "Date"
        Me.gridDictator.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RowCount = 0
    End Sub

    Protected Sub gridDictator_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gridDictator.ItemCreated
        If e.Item.ItemIndex = 0 Then
            RowCount = 1
        Else
            RowCount += 1
        End If
    End Sub

    Protected Sub gridDictator_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles gridDictator.TemplateSelection
        e.TemplateFilename = "dictatorlinecounttranscriptionswise.ascx"
    End Sub

    Protected Function Line_Per_Minutes(ByVal seconds As String, ByVal lines As String) As String
        Dim objGF As New GF
        Return objGF.Line_Per_Minutes(seconds, lines)
    End Function
    Protected Function Line_Per_Transcriptions(ByVal transcriptions As String, ByVal lines As String) As String
        Dim objGF As New GF
        Return objGF.Line_Per_Transcriptions(transcriptions, lines)
    End Function
End Class
