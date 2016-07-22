Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL

Partial Class BO_popviewtranscription
    Inherits System.Web.UI.Page
    Protected Qry As String
    Protected Shared Flag As Boolean = False

    Dim Con As New DBTaskBO
    Dim ds As New DataSet
    Dim RollFolder As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call getTranscriptionDetails()
        Call getTranscriptionDocuments()

        'If Not Me.IsPostBack Then

        '    Me.View_Status_Emp(Request.QueryString("traID").ToString, Request.QueryString("dicID").ToString)

        '    Qry = "Select dicStatus from boDictation where dicID =" & Request.QueryString("dicID").ToString
        '    Con = New DBTaskBO
        '    Dim dicStatus As Int32 = Con.getScalar(Qry)

        '    If Flag = True Then
        '        Me.btnOk.Enabled = False
        '    Else
        '        Me.btnOk.Enabled = True
        '    End If
        'End If

    End Sub

    Private Sub getTranscriptionDetails()
        Qry = "SELECT * FROM boTranscription WHERE traID = " & Request.QueryString("traID").ToString
        ds = Con.getDataSet(Qry)

        For Each dr As DataRow In ds.Tables(0).Rows
            traID.InnerHtml = "<b>Document #: </b>" & dr("traID")
            traUrgent.InnerHtml = "<b>Urgent: </b>" & IIf(dr("traIncomplete"), "Urgent", "")

            traSubject.InnerHtml = "<b>Subject: </b>" & dr("traSubject")
            traDear.InnerHtml = "<b>Dear: </b>" & dr("traDear")

            traPatientNo.InnerHtml = "<b>Patient #: </b>" & dr("traPatientNo")
            traNHSNo.InnerHtml = "<b>NHS #: </b>" & dr("traNHSNo")

            traClinicDate.InnerHtml = "<b>ClinicDate: </b>" & IIf(dr("traClinicDate") = "1/1/1900", "", dr("traClinicDate"))
            traDOB.InnerHtml = "<b>Date of Birth: </b>" & IIf(dr("traDOB") = "1/1/1900", "", dr("traDOB"))

            traNTS.InnerHtml = "<b>Notes to Secretary: </b>" & dr("traNTS")
            traNTD.InnerHtml = "<b>Notes to Dictator: </b>" & dr("traNTD")

            traRecipientAddress.InnerHtml = "<b>Recipient Address: </b>" & dr("traRecipientAddress")
            traFooterBlock.InnerHtml = "<b>Footer Block: </b>" & dr("traFooterBlock")
        Next
    End Sub

    Private Sub getTranscriptionDocuments()
        Qry = "SELECT * FROM boTranscriptionLayers WHERE traID = " & Request.QueryString("traID").ToString
        ds = Con.getDataSet(Qry)

        Dim docMT As String = "#"
        Dim docQC As String = "#"
        Dim docPR As String = "#"
        Dim docFR As String = "#"

        For Each dr As DataRow In ds.Tables(0).Rows
            If dr("rolID") = "MT" Then
                docMT = dr("tralName")
            ElseIf dr("rolID") = "QC" Then
                docQC = dr("tralName")
            ElseIf dr("rolID") = "PR" Then
                docPR = dr("tralName")
            ElseIf dr("rolID") = "FR" Then
                docFR = dr("tralName")
            End If
        Next

        If docMT <> "#" Then
            hrMT.HRef = "../data/mt/" & docMT
        Else
            hrMT.HRef = "#"
            hrMT.InnerText = "-"
            hrMT.Target = "_self"
        End If

        If docQC <> "#" Then
            hrQC.HRef = "../data/qc/" & docQC
        Else
            hrQC.HRef = "#"
            hrQC.InnerText = "-"
            hrQC.Target = "_self"
        End If

        If docPR <> "#" Then
            hrPR.HRef = "../data/pr/" & docPR
        Else
            hrPR.HRef = "#"
            hrPR.InnerText = "-"
            hrPR.Target = "_self"
        End If

        If docFR <> "#" Then
            hrFR.HRef = "../data/fr/" & docFR
        Else
            hrFR.HRef = "#"
            hrFR.InnerText = "-"
            hrFR.Target = "_self"
        End If



    End Sub
End Class
