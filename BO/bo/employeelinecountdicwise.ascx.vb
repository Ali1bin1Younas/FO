
Partial Class BO_employeelinecountdicwise
    Inherits System.Web.UI.UserControl
    Protected RowCounter As Int32

    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        'if an InvalidCastException occurs in either of the next two lines, 
        'please make sure that you've set the TemplateDataMode to Table (because you want nested grids)
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        If (Not (TypeOf dgi.DataItem Is Data.DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If
        Dim ds As Data.DataSet = CType(dgi.DataItem, Data.DataSet)
        Me.gridDicWise.DataSource = ds
        Me.gridDicWise.DataMember = "Dictators"
        Me.gridDicWise.DataBind()
    End Sub


    Protected Function getmin(ByVal second As String) As String
        Return GF.GetMin(second)
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        RowCounter = 0
    End Sub

    Protected Sub gridDicWise_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridDicWise.RowCreated
        If e.Row.RowIndex = 0 Then
            RowCounter = 1
        Else
            RowCounter += 1
        End If
    End Sub

    Protected Function Line_Per_Minutes(ByVal min As String, ByVal line As String) As String
        
        Dim obj As New GF
        Return obj.Line_Per_Minutes(min, line)

    End Function

    Protected Function Line_Per_Transcriptions(ByVal Trans As String, ByVal line As String) As String 

        Dim obj As New GF
        Return obj.Line_Per_Transcriptions(Trans, line)

    End Function

End Class
