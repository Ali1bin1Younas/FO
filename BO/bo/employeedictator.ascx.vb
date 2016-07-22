Partial Class BO_employeedictator
    Inherits System.Web.UI.UserControl
    Protected iCounter As Int16
    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        If (Not (TypeOf dgi.DataItem Is Data.DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If
        Dim ds As Data.DataSet = CType(dgi.DataItem, Data.DataSet)
        If ds.Tables("Dictator").Rows.Count > 0 Then
            Me.gvDictator.DataSource = ds
            Me.gvDictator.DataMember = "Dictator"
            Me.gvDictator.DataBind()
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        iCounter = 0
    End Sub

    Protected Sub gvDictator_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDictator.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            iCounter = 0
        Else
            iCounter += 1
        End If
    End Sub
End Class
