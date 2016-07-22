Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL
Partial Class BO_popupchangeminutes
    Inherits System.Web.UI.Page
    Dim con As New DBTaskBO
    Dim ds As New DataSet
    Dim Qry As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Qry = "SELECT dicLength from boDictation where dicId=" & Request.QueryString("dicID")
            lblMinutes.Text = GF.GetMin(con.getScalar(Qry))
        End If
    End Sub
    Protected Function Update_Minutes(ByVal Seconds As String) As Boolean
        If Seconds = "" Then
            Return False
        End If
        Qry = "UPDATE boDictation set dicLength='" & Seconds & "' where dicId=" & Request.QueryString("dicID")
        con.saveData(Qry)
        Return True
    End Function

    Protected Sub btnChange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChange.Click
        If Me.Update_Minutes(Me.txtSeconds.Text) Then
            GF.Refresh = 2
            Dim str As String = "<script>window.close('popreplacetranscription.aspx');opener.location.reload();</script>"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "CloseWindow", str)
        Else
            Me.lblError.Text = "Unable to Update......Sorry! try Again"
        End If
    End Sub

    Protected Sub btnCancle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancle.Click
        Dim str As String = "<script>window.close('popreplacetranscription.aspx');</script>"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "CloseWindow", str)
    End Sub
End Class
