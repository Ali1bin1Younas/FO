Imports System.Data

Partial Class BO_employeesworkloadFullDetail
    Inherits System.Web.UI.UserControl
    Protected iCounter As Int16
    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        If (Not (TypeOf dgi.DataItem Is Data.DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If
        Dim ds As Data.DataSet = CType(dgi.DataItem, Data.DataSet)
        If ds.Tables("workloadrolwise").Rows.Count > 0 Then
            Me.gvDictator.DataSource = ds
            Me.gvDictator.DataMember = "workloadrolwise"
            Me.gvDictator.DataBind()
        End If
    End Sub
    Protected Sub gvDictator_TemplateSelection(ByVal sender As Object, ByVal e As DBauer.Web.UI.WebControls.HierarGridTemplateSelectionEventArgs) Handles gvDictator.TemplateSelection
        e.TemplateFilename = "employeesworkloadFullDetail2.ascx"
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        iCounter = 0
    End Sub
    Protected Sub gvDictator_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gvDictator.ItemCreated
        Try
            If e.Item.ItemIndex = 0 Then
                iCounter = 1
            Else
                iCounter += 1
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
