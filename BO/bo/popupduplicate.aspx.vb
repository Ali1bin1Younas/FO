Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL
Partial Class BO_popupchangeminutes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim con As New DBTaskBO
        Dim ds As New DataSet
        Dim Qry As String

        Qry = "SELECT dicID, dicDate, drID, dicActualName, dicLength from boDictation WHERE dicActualName = (SELECT dicActualName FROM boDictation WHERE dicID = " & Request.QueryString("dicID") & ") AND dicLength = (SELECT dicLength FROM boDictation WHERE dicID = " & Request.QueryString("dicID") & ")"

        ds = con.getDataSet(Qry)
        Me.gvDictation.DataSource = ds
        Me.gvDictation.DataBind()

        Qry = "UPDATE boDictation SET dicDuplicateCheck = 1 WHERE dicID = " & Request.QueryString("dicID")
        con.update(Qry)

        ds.Clear()
        ds = Nothing
        con = Nothing
    End Sub

    'Protected Sub btnCancle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancle.Click
    '    Dim str As String = "<script>window.close('popreplacetranscription.aspx');</script>"
    '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "CloseWindow", str)
    'End Sub

    Protected Function getMin(ByVal second As String) As String
        Return GF.GetMin(second)
    End Function

    Protected Sub gvDictation_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDictation.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dicID As Int32 = Me.gvDictation.DataKeys(e.Row.RowIndex).Values.Item(0)

            If dicID = Request.QueryString("dicID") Then
                e.Row.ForeColor = Drawing.Color.Green
            End If
        End If
    End Sub
End Class
