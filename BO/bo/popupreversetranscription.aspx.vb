Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL
Partial Class BO_popup
    Inherits System.Web.UI.Page

    Protected Qry As String
    Protected Shared Flag As Boolean = False
    Dim Con As New DBTaskBO
    Dim ds As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.View_Status_Emp(Request.QueryString("traID").ToString, Request.QueryString("dicID").ToString)

            Qry = "Select dicStatus from boDictation where dicID =" & Request.QueryString("dicID").ToString
            Con = New DBTaskBO
            Dim dicStatus As Int32 = Con.getScalar(Qry)

            Me.lblError.Text = ""

            If dicStatus > 2 Then
                Me.lblError.Text = "The file has been uploaded."
                Me.btnOk.Enabled = False
                'ElseIf Flag Then
                '    Me.lblError.Text = "The file is in process."
                '    Me.btnOk.Enabled = False
            Else
                Me.lblError.Text = ""
                Me.btnOk.Enabled = True
            End If
        End If

    End Sub

    Public Sub View_Status_Emp(ByVal P_traid As Int32, ByVal P_dicId As Int32)
        Qry = "select bD.rolID,bD.empId,bE.empFirstName+ ' ' + bE.empLastName as empName, isNull(bT.tralStatus,-1) As tralStatus from boDictationLayers  bD " _
                & "Left Outer Join boTranscriptionLayers bT on bD.dicId = bT.dicID AND bD.rolID = bT.rolID " _
                & "inner join boEmployee bE on bD.empId = bE.empID " _
                & "where(bD.dicID = '" & P_dicId & "' AND traID= '" & P_traid & "')"
        ds = Con.getDataSet(Qry)

        For Each dr As DataRow In ds.Tables(0).Rows
            Select Case dr("rolID")
                Case "MT"
                    Me.rbMT.Checked = False
                    Me.rbMT.Enabled = False
                    Me.rbMT.ForeColor = Drawing.Color.Gray

                    If dr("empID").ToString.Trim <> "0" Then
                        Me.lblMT.Text = "MT: " & dr("empName")
                    Else
                        Me.lblMT.Text = "MT: " & "-"
                    End If

                    Select Case dr("tralStatus")
                        Case 1
                            Flag = True
                        Case 2
                            Me.rbMT.Enabled = True
                            Me.lblMT.ForeColor = Drawing.Color.Green
                    End Select
                Case "QC"
                    Me.rbQC.Checked = False
                    Me.rbQC.Enabled = False
                    Me.rbQC.ForeColor = Drawing.Color.Gray

                    If dr("empID").ToString.Trim <> "0" Then
                        Me.lblQC.Text = "QC: " & dr("empName")
                    Else
                        Me.lblQC.Text = "QC: " & "-"
                    End If

                    Select Case dr("tralStatus")
                        Case 1
                            Flag = True
                        Case 2
                            Me.rbQC.Enabled = True
                            Me.lblQC.ForeColor = Drawing.Color.Green
                    End Select
                Case "PR"
                    Me.rbPR.Checked = False
                    Me.rbPR.Enabled = False
                    Me.rbPR.ForeColor = Drawing.Color.Gray

                    If dr("empID").ToString.Trim <> "0" Then
                        Me.lblPR.Text = "PR: " & dr("empName")
                    Else
                        Me.lblPR.Text = "PR: " & "-"
                    End If

                    Select Case dr("tralStatus")
                        Case 1
                            Flag = True
                        Case 2
                            Me.rbPR.Enabled = True
                            Me.lblPR.ForeColor = Drawing.Color.Green
                    End Select
                Case "FR"
                    Me.rbFR.Checked = False
                    Me.rbFR.Enabled = False
                    Me.rbFR.ForeColor = Drawing.Color.Gray

                    If dr("empID").ToString.Trim <> "0" Then
                        Me.lblFR.Text = "FR: " & dr("empName")
                    Else
                        Me.lblFR.Text = "FR: " & "-"
                    End If

                    Select Case dr("tralStatus")
                        Case 1
                            Flag = True
                        Case 2
                            Me.rbFR.Enabled = True
                            Me.lblFR.ForeColor = Drawing.Color.Green
                    End Select
            End Select
        Next

        ds.Dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim sQry As String = ""
        Dim SelectedRole As String = ""

        If Me.rbMT.Checked Then
            SelectedRole = "MT"
        ElseIf Me.rbQC.Checked Then
            SelectedRole = "QC"
        ElseIf Me.rbPR.Checked Then
            SelectedRole = "PR"
        ElseIf Me.rbFR.Checked Then
            SelectedRole = "FR"
        End If

        Try
            'sQry = "SELECT rolID FROM boTranscriptionLayers WHERE traID = " & Request.QueryString("traID") & " AND rolID = '" & SelectedRole & "' AND tralStatus = 1;"
            'Dim sRolID As String = Con.getScalar(sQry)

            'If sRolID = "" Then
            sQry = "SELECT COUNT(traID) FROM boTranscription WHERE dicID = " & Request.QueryString("dicID")
            Dim iTranscriptions As Int16 = Con.getScalar(sQry)

            Qry = "Update boDictation set dicStatus=1 where dicId=" & Request.QueryString("dicID") & ";"
            Qry += "Update boTranscription set traStatus=0 where traId=" & Request.QueryString("traID") & ";"

            Qry += "UPDATE boTranscriptionLayers SET tralStatus = 1 " _
                & "WHERE traID = " & Request.QueryString("traID") & " AND rolID = '" & SelectedRole & "';"

            Qry += "UPDATE boDictationLayers SET diclTranscriptions=diclTranscriptions-1, diclStatus=2 " _
                & "WHERE dicID=" & Request.QueryString("dicID") & " AND rolID='" & SelectedRole & "';"

            If Me.rbMT.Checked Then
                If iTranscriptions = 1 Then
                    Qry += "Update boDictationLayers set diclStatus=0, diclTranscriptions=0, diclTag=0 " _
                        & "where dicId=" & Request.QueryString("dicID") & " AND rolID<>'MT';"

                    Qry += "DELETE FROM boTranscriptionLayers WHERE traID=" & Request.QueryString("traID") & " AND rolID IN ('QC','PR','FR')"
                Else
                    Call checkNextLayer("QC")
                    Call checkNextLayer("PR")
                    Call checkNextLayer("FR")
                End If


            ElseIf Me.rbQC.Checked Then
                If iTranscriptions = 1 Then
                    Qry += "UPDATE boDictationLayers SET diclStatus=0, diclTranscriptions=0, diclTag=0 " _
                        & "WHERE dicID=" & Request.QueryString("dicID") & " AND rolID IN ('PR','FR');"

                    Qry += "DELETE FROM boTranscriptionLayers WHERE traID=" & Request.QueryString("traID") & " AND rolID IN ('PR','FR')"
                Else
                    Call checkNextLayer("PR")
                    Call checkNextLayer("FR")
                End If


            ElseIf Me.rbPR.Checked Then
                If iTranscriptions = 1 Then
                    Qry += "UPDATE boDictationLayers SET diclStatus=0, diclTranscriptions=0, diclTag=0 " _
                        & "WHERE dicID=" & Request.QueryString("dicID") & " AND rolID IN ('FR');"

                    Qry += "DELETE FROM boTranscriptionLayers WHERE traID=" & Request.QueryString("traID") & " AND rolID IN ('FR')"
                Else
                    Call checkNextLayer("FR")
                End If
            ElseIf Me.rbFR.Checked Then

            Else
                Me.lblError.Text = "Error: Please select a layer to reverse the file."
                Me.lblError.ForeColor = Drawing.Color.Red
                Exit Sub
            End If

            Con.saveData(Qry)
            GF.Refresh = 2

            Dim str As String = ""
            str = "<script>opener.location.reload();window.close('popup.aspx');</script>"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "CloseWindo", str)
            'Else
            'Me.lblError.Text = "Alert: File is in process at " & sRolID & " layer."
            'Me.lblError.ForeColor = Drawing.Color.Red
            'Exit Sub
            'End If
        Catch ex As Exception
            GF.Refresh = 1
            Me.lblError.Text = "Error: Unable to process please try agian."
            Me.lblError.ForeColor = Drawing.Color.Red
        Finally
            Con.objConnection.ConnectionString = Nothing
        End Try

    End Sub

    Private Sub checkNextLayer(ByVal vRolID As String)
        Dim sQry As String = ""

        sQry = "SELECT tralStatus FROM boTranscriptionLayers WHERE traID = " & Request.QueryString("traID") & " AND rolID = '" & vRolID & "'"
        Dim tralStatus As Integer = Con.getScalar(sQry)

        If tralStatus = 2 Then
            Qry += "Update boDictationLayers set diclTranscriptions=diclTranscriptions-1 " _
                & "WHERE dicId=" & Request.QueryString("dicID") & " AND rolID = '" & vRolID & "';"
        End If

        sQry = "SELECT diclTranscriptions FROM boDictationLayers WHERE dicID = " & Request.QueryString("dicID") & " AND rolID = '" & vRolID & "'"
        Dim diclTranscriptions As Integer = Con.getScalar(sQry)

        If diclTranscriptions <= 1 Then
            Qry += "Update boDictationLayers set diclStatus = 0, diclTag = 0 " _
                & "WHERE dicId=" & Request.QueryString("dicID") & " AND rolID = '" & vRolID & "';"
        Else
            Qry += "Update boDictationLayers set diclStatus = 2 " _
                & "WHERE dicId=" & Request.QueryString("dicID") & " AND rolID = '" & vRolID & "' AND diclStatus = 3;"
        End If

        Qry += "DELETE FROM boTranscriptionLayers WHERE traID=" & Request.QueryString("traID") & " AND rolID = '" & vRolID & "';"
    End Sub

    Protected Sub btnCancle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancle.Click
        Dim str As String = ""
        Str = "<script>window.close('popup.aspx');</script>"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "CloseWindow", Str)
    End Sub
End Class
