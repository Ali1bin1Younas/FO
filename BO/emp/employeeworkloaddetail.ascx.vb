Imports System.Data
Imports MTBMS.DAL

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
    Protected Sub gvDictator_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDictator.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim drView As DataRowView = e.Row.DataItem

            Dim ddlTemplate As DropDownList = CType(e.Row.FindControl("ddlTem"), DropDownList)
            LoadTemplates(ddlTemplate, drView("drID"), drView("foID"))
        End If

    End Sub

    Private Sub LoadTemplates(ByVal ddlTemp As DropDownList, ByVal drID As String, ByVal foID As String)
        Dim qryTem As String = "Select temID, (CONVERT(varchar(10), temID) + ', ' + drId) as templateID ,drID, temActualName, isNull(temDefault, '0') as temDefault From boTemplates where temEnable = '1' And foID = '" & foID & "' And drID ='" & drID & "'"
        Dim con As New DBTaskBO
        Dim ds As New DataSet
        ds = con.getDataSet(qryTem)
        If ds.Tables(0).Rows.Count > 0 Then
            ddlTemp.DataSource = ds

            ddlTemp.DataTextField = "temActualName"
            ddlTemp.DataValueField = "templateID"
            ddlTemp.DataBind()
        End If
        ddlTemp.Items.Insert(0, "Templates")
        ddlTemp.Items(0).Value = ""

        For Each dr As DataRow In ds.Tables(0).Rows
            If Not dr("temDefault") Is Nothing Then
                If dr("temDefault") Then
                    ddlTemp.SelectedValue = dr("templateID")
                End If

            End If
        Next

    End Sub
End Class
