Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL
Partial Class BO_popreplacetranscription
    Inherits System.Web.UI.Page
    Protected Qry As String
    Dim Con As New DBTaskBO
    Dim ds As New DataSet

    Shared traID, dicID As Int32
    Dim str As String = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
                           + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                           + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                           + "<td align=center width=80><img src='../images/error.ico'></td><td align=left width=370><font style='font-size:8pt;'>File In Process so that's why can't Upload..</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr>" _
                           + "<tr><td height=15></td></tr></table>"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If Not Me.IsPostBack Then
            traID = Request.QueryString("traID")
            dicID = Request.QueryString("dicID")
            Qry = "SELECT traStatus from boTranscription where traID = " _
                                        & traID & " and dicID = " _
                                        & dicID
            Dim traStatus As Int16 = Con.getScalar(Qry)

            If traStatus < 1 Then
                Me.btnReplace.Enabled = False
                Me.lblError.Text = str
            Else
                Me.btnReplace.Enabled = True
                Me.lblError.Text = ""
            End If
        End If
    End Sub

    Protected Sub btnReplace_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReplace.Click
        Dim LineCount, ReUpload As String

        Qry = "SELECT foId+drId from boDictation where dicID=" & dicID
        Dim DicFolder As String = Con.getScalar(Qry)
        Qry = "SELECT traName from boTranscription where traId=" & traID
        Dim traName As String = Con.getScalar(Qry)
        LineCount = Request.QueryString("cbLine_Count")
        ReUpload = Request.QueryString("cbRe_Upload")

        If LineCount <> "" And ReUpload <> "" Then

            Qry = "Update boTranscription SET traStatus=1, traCharacters=-1 where traId= " _
                    & traID & " and dicId= " _
                    & dicID & ";"
            Qry += "Update boDictation SET dicStatus = 2 where dicId=" & dicID _
                   & " AND dicStatus > 2"
            Con.saveData(Qry)

        ElseIf ReUpload <> "" Then

            Qry = "Update boTranscription SET traStatus = 2 where " _
                    & traID & " and dicId= " _
                    & dicID & ";"

            Qry += "Update boDictation SET dicStatus=3 where dicId=" & dicID _
                   & " AND dicStatus > 2"

            Con.saveData(Qry)
        End If
        Dim path As String = Server.MapPath("../Data/" & DicFolder & "/Transcriptions/" & traName)
        fuReplace.SaveAs(path)
        GF.Refresh = 2
        str = "<script>window.close('popreplacetranscription.aspx');opener.location.reload();</script>"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "CloseWindow", str)
    End Sub

    Protected Sub btnCancle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancle.Click
        str = "<script>window.close('popreplacetranscription.aspx');</script>"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "CloseWindow", str)
    End Sub
End Class
