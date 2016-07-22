Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL

Partial Class BO_popviewtranscription
    Inherits System.Web.UI.Page
    Protected Qry As String
    Protected Shared Flag As Boolean = False
    Protected foID As String
    Protected drID As String
    Protected traName As String
    Dim Con As New DBTaskBO
    Dim ds As New DataSet
    Dim RollFolder As String
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call getTranscriptionDetails()
    End Sub

    Public Sub getTranscriptionDetails()
        Qry = "SELECT * FROM boTranscription WHERE traID = " & Request.QueryString("traID").ToString
        ds = Con.getDataSet(Qry)

        traName = ds.Tables(0).Rows(0)("traName")
       

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

            docLink.HRef = "../data/" & Request.QueryString("foID").ToString & Request.QueryString("drID").ToString & "/transcriptions/" & dr("traName")
        Next
    End Sub

    'Protected Function getfoID_drID() As String
    '    foID = Request.QueryString("foID").ToString
    '    drID = Request.QueryString("drID").ToString
    '    Return foID + drID
    'End Function

    'Protected Function gettraName() As String
    '    Qry = "SELECT * FROM boTranscription WHERE traID = " & Request.QueryString("traID").ToString
    '    ds = Con.getDataSet(Qry)
    '    traName = ds.Tables(0).Rows(0)("traName")

    '    Return traName
    'End Function
End Class
