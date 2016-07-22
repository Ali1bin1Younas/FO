Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL
Partial Class BO_popupdeletedictation
    Inherits System.Web.UI.Page
    Protected Qry As String
    Dim Con As New DBTaskBO
    Dim ds As New DataSet
    Protected dicId As Int16

    Dim str As String = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
                           + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; color:#343434; letter-spacing:0.9px;'><strong>Information &nbsp;</strong></font></legend>" _
                           + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                           + "<td align=center width=80><img src='../images/info.ico'></td><td align=left width=370><font style='font-size:8pt;'>File In Process so that's why can't Delete </font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr>" _
                           + "<tr><td height=15></td></tr></table>"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            dicId = Request.QueryString("dicID")
            Qry = "Select dicStatus from boDictation where dicID=" & dicId
            Con = New DBTaskBO
            Dim checkStatus As Int16 = Con.getScalar(Qry)
            Qry = "Select foId+drId as Uid , dicActualName,dicTempName,convert(char(12),dicDate,7) as dicDate " _
            & " from boDictation where dicID=" & dicId
            ds = New DataSet
            ds = Con.getDataSet(Qry)
            Me.lblId.Text = ds.Tables(0).Rows(0).Item("Uid")
            Me.lblName.Text = ds.Tables(0).Rows(0).Item("dicActualName")
            Me.lblTemp.Text = ds.Tables(0).Rows(0).Item("dicTempName")
            Me.lblDate.Text = ds.Tables(0).Rows(0).Item("dicDate")
            If checkStatus = 0 Then
                Me.btnDelete.Enabled = True
                Me.lblInformation.Text = ""
            Else
                Me.btnDelete.Enabled = False
                Me.lblInformation.Text = str
            End If
        End If
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            Qry = "UPDATE boDictation set dicEnable=0 where dicId=" & dicId
            Con.saveData(Qry)
            GF.Refresh = 2
            Dim str As String
            str = "<script>window.close('popdeletedictation.aspx');opener.location.reload();</script>"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "CloseWindow", str)
        Catch ex As Exception
            Me.lblInformation.Text = ex.ToString()
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub

    Protected Sub btnCancle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancle.Click
        Dim str As String
        str = "<script>window.close('popdeletedictation.aspx')</script>"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "CloseWindow", str)
    End Sub
End Class
