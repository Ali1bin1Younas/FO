Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL

Partial Class BO_deletetranscription

    Inherits System.Web.UI.Page
    Dim flag As Boolean
    Dim Qry As String
    Dim Con As New DBTaskBO
    Dim ds As New DataSet
    Dim str As String = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
                            + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                            + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                            + "<td align=center width=80><img src='../images/error.ico'></td><td align=left width=370><font style='font-size:8pt;'>File in Process or Upload that's why can't Delete..</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr>" _
                            + "<tr><td height=15></td></tr></table>"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' If Session("empID") = "" Then Response.Redirect(GF.Home)
        Qry = "Select tralStatus from boTranscriptionLayers where traID=" & Request.QueryString("traID")
        Con = New DBTaskBO
        ds = New DataSet
        ds = Con.getDataSet(Qry)
        Qry = "Select dicStatus from boDictation where dicID =" & Request.QueryString("dicID").ToString
        Dim dicStatus As Int16 = Con.getScalar(Qry)

        For Each dr As DataRow In ds.Tables(0).Rows
            If dr("tralStatus") = 1 Then flag = True
        Next

        Qry = "SELECT bD.dicID,dicActualName,traName,Convert(char(12),dicDate,3) as dicDate from boDictation bD " _
              & "inner join boTranscription bT on bD.dicID = bT.dicID where bD.dicID=" & Request.QueryString("dicID")
        ds = Con.getDataSet(Qry)
        Me.id.Text = ds.Tables(0).Rows(0).Item("dicID").ToString
        Me.DName.Text = ds.Tables(0).Rows(0).Item("dicActualName").ToString
        Me.TName.Text = ds.Tables(0).Rows(0).Item("traName").ToString
        Me.lDate.Text = ds.Tables(0).Rows(0).Item("dicDate").ToString

        If Not Me.IsPostBack Then
            If flag Or dicStatus > 2 Then
                Me.lblError.Text = str
                Me.btnDelete.Enabled = False
            Else
                Me.lblError.Text = ""
                Me.btnDelete.Enabled = True
            End If
        End If

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            Qry = "SELECT dicTranscriptions FROM boDictation WHERE dicID = " & Request.QueryString("dicID")
            Dim iTranscriptions As Int16 = Con.getScalar(Qry)

            If iTranscriptions = 1 Then
                Qry = "DELETE FROM boTranscriptionLayers WHERE traID = " & Request.QueryString("traID") & ";"
                Qry += "DELETE FROM boTranscription WHERE traID = " & Request.QueryString("traID") & ";"
                Qry += "Update boDictationLayers set diclStatus=0, diclTranscriptions = 0, diclTag = 0 " _
                       & "where dicId=" & Request.QueryString("dicID") & ";"
                Qry += "Update boDictationLayers set diclStatus=1 " _
                       & "where dicId=" & Request.QueryString("dicID") & " AND rolID='MT';"
                Qry += "Update boDictationLayers set empID = '0' " _
                       & "where dicId=" & Request.QueryString("dicID") & " AND diclSkip = 1;"
                Qry += "Update boDictation set dicStatus=1, dicTranscriptions=0 " _
                       & "WHERE dicID=" & Request.QueryString("dicID") & ";"
            Else
                Call deleteTranscriptionLayer("FR")
                Call deleteTranscriptionLayer("PR")
                Call deleteTranscriptionLayer("QC")
                Call deleteTranscriptionLayer("MT")

                Qry = "DELETE FROM boTranscription WHERE traID = " & Request.QueryString("traID") & ";"
                Qry += "Update boDictation set dicTranscriptions=dicTranscriptions-1 " _
                       & "WHERE dicID=" & Request.QueryString("dicID") & ";"
            End If
            Call Con.saveData(Qry)
            GF.Refresh = 2
            str = "<script> window.close('popup.aspx');opener.location.reload();</script>"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "CloseWindo", str)

        Catch ex As Exception
            GF.Refresh = 1
            Me.lblError.Text = "Unable to delete transcription record. Please try agian."
        Finally
            Con.objConnection.ConnectionString = Nothing
        End Try
    End Sub

    Protected Sub deleteTranscriptionLayer(ByVal vsrolID As String)
        Qry = "DELETE FROM boTranscriptionLayers WHERE traID = " & Request.QueryString("traID") & " " _
                              & "AND rolID = '" & vsrolID & "' AND tralStatus = 2;"
        If Con.saveData(Qry) > 0 Then
            Qry = "Update boDictationLayers set diclTranscriptions = diclTranscriptions-1 " _
                   & "where dicId=" & Request.QueryString("dicID") & " AND rolID = '" & vsrolID & "'"
            Call Con.saveData(Qry)
        Else
            Qry = "DELETE FROM boTranscriptionLayers WHERE traID = " & Request.QueryString("traID") & " " _
                  & "AND rolID = '" & vsrolID & "' AND tralStatus = 0;"
            If Con.saveData(Qry) = 0 Then
                Qry = "Update boDictationLayers set diclTranscriptions = diclTranscriptions - 1 " _
                      & "where dicId=" & Request.QueryString("dicID") & " AND rolID = '" & vsrolID & "' " _
                      & "AND diclStatus > 0"
                Call Con.saveData(Qry)
            End If
        End If
        Qry = "SELECT COUNT(traID) FROM boTranscriptionLayers " _
              & "WHERE dicID = " & Request.QueryString("dicID") & " AND tralTag = 1 AND rolID = '" & vsrolID & "'"
        If Con.saveData(Qry) = 0 Then
            Qry = "Update boDictationLayers set diclTag = 0 " _
                  & "where dicId=" & Request.QueryString("dicID") & " AND rolID = '" & vsrolID & "';"
            Qry += "Update boDictationLayers set empID = '0' " _
                  & "where dicId=" & Request.QueryString("dicID") & " AND rolID = '" & vsrolID & "' AND diclSkip = 1;"
            Call Con.saveData(Qry)
        End If
    End Sub

    Protected Sub btnCancle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancle.Click

        str = "<script>window.close('deletetranscription.aspx');</script>"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "CloseWindow", str)
    End Sub
End Class
