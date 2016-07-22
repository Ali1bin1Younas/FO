Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class fo_search
    Inherits System.Web.UI.Page
    Protected strCliID As String
    Dim ds As DataSet
    Dim Con As New DBTaskBO

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        Try
            'lblCompleteName.Text = Session("CompletePrefix") + "  " + Session("CompleteFirstNAme") + "   " + Session("CompleteLastName")

            Session("cint") = 0
            Session("cint1") = 0
            If Not Page.IsPostBack Then
                loadLocation()
                loaddictator()
            End If

        Catch ex As Exception
            ' Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub loaddictator()
        Dim Query As String = "SELECT  drID, foID, drFirstName, drLastName, drMiddleName FROM boDictator order BY foID, drID"
        'Dim dr As SqlDataReader
        ds = Con.getDataSet(Query)
        Me.cmbdictaror.Items.Add("Select Dictator")

        If ds.Tables(0).Rows.Count > 0 Then
            'While dr.Read
            For Each dr As DataRow In ds.Tables(0).Rows
                Query = dr("drID") + " " + dr("drLastName") + ", " + dr("drFirstName") + " " + dr("drMiddleName")
                Me.cmbdictaror.Items.Add(Query)
            Next
        End If
        ds.Dispose()
        ds = Nothing
    End Sub

    Private Sub loadLocation()
        Dim Query As String = "SELECT distinct locDescription,locID FROM  boLocation order BY locID"
        ds = Con.getDataSet(Query)
        Me.cmbserLocation.Items.Add("Select Location")
        If ds.Tables(0).Rows.Count <> False Then

            'While dr.Read
            For Each dr As DataRow In ds.Tables(0).Rows
                Me.cmbserLocation.Items.Add(dr("locID") + " - " + dr("locDescription"))
            Next
            Me.btnSearch.Attributes("onclick") = " return checkvalueloc(" + Me.txtserPatientName.ClientID + "," + Me.CPFrom.ClientID + "," + Me.CPTo.ClientID + "," + Me.cmbserLocation.ClientID + "," + Me.cmbdictaror.ClientID + ");"
        End If
        ds.Dispose()
        ds = Nothing
        Con.objConnection.Close()
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        'lblMessage.Text = ""
        Dim Query As String
        Query = ""
        Query = Query + "SELECT boDictation.foID, boDictation.drID,boDictation.dicActualName,boDictation.dicDate, " _
                        & "boTranscription.traName, boTranscription.traPatFirstName, boTranscription.locID, " _
                        & "boTranscription.traPatLastName,boTranscription.traStatus, boTranscription.traTag, boTranscription.traIncomplete, " _
                        & "isnull(boLocation.locDescription,'')as locDescription,boTranscription.traID, " _
                        & "boDictation.dicID FROM   boDictation " _
                        & "INNER JOIN boTranscription ON boDictation.dicID = boTranscription.dicID " _
                        & "Left OUTER JOIN boLocation ON boTranscription.locID = boLocation.locID " _
                        & "WHERE  boTranscription.traStatus>'1' "


        If Me.txtserPatientName.Text <> "" Then
            Query = Query + "And (boTranscription.traPatFirstName LIKE '%" + Me.txtserPatientName.Text + "%' " _
                    & "OR boTranscription.traPatLastName LIKE '%" + Me.txtserPatientName.Text + "%') "
        End If

        If Me.cmbdictaror.SelectedValue.ToString <> "Select Dictator" Then
            Dim str() As String = Split(Me.cmbdictaror.Text.ToString, " ")
            Query = Query + "And" + " " + "boDictation.drID ='" + str(0) + "'"
        End If
        If Me.cmbserLocation.SelectedValue.ToString <> "" And Me.cmbserLocation.SelectedValue.ToString <> "Select Location" Then
            Dim str() As String = Split(cmbserLocation.SelectedValue.ToString, "-")

            Query = Query + "And" + " " + "boLocation.locID LIKE '%" + str(0) + "%'"
        End If
        If Me.CPFrom.SelectedDate.ToString <> "1/1/0001 12:00:00 AM" And Me.CPTo.SelectedDate.ToString = "1/1/0001 12:00:00 AM" Then
            Query = Query + "And " + "boDictation.dicDate='" + CPFrom.SelectedDate + "'"
        End If
        If Me.CPTo.SelectedDate.ToString <> "1/1/0001 12:00:00 AM" Then
            Query = Query + "And " + " boDictation.dicDate between" + " " + "'" + Me.CPFrom.SelectedDate + "'" + " " + "And" + "'" + Me.CPTo.SelectedDate + "'"
        End If
        If Me.chkTag.checked Then
            Query = Query + "And " + " traTag = 1 "
        End If
        If Me.chkIncomplete.checked Then
            Query = Query + "And " + " traIncomplete = 1 "
        End If
        Session("searchquery") = Query & " ORDER BY boDictation.foID, boDictation.drId, boDictation.dicDate DESC"

        Response.Redirect("searchrecord.aspx")

        'Dim Con As New DBTaskBO
        'Dim ds As DataSet
        'ds = Con.getDataSet(Query)
        'Dim strNOFiles As String = "Records Found: " + ds.Tables(0).Rows.Count.ToString
        'lblMessage.Text = strNOFiles
        'If strNOFiles.Trim = "" Or strNOFiles.Trim = "Records Found: 0" Then
        '    btnResend.Visible = False
        'Else
        '    btnResend.Visible = True
        'End If
        'Me.grdMain.DataSource = ds
        'Me.grdMain.DataBind()

        ' End If
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.txtserPatientName.Text = ""
        Me.CPFrom.SelectedDate = "1/1/0001 12:00:00 AM"
        Me.CPTo.SelectedDate = "1/1/0001 12:00:00 AM"
    End Sub
    Protected Function getDicName(ByVal strDicID As String) As String
        Dim strDicName As String = Nothing
        Dim Query As String = "Select dicActualName From boDictation where dicID='" & strDicID & "'"
        ds = Con.getDataSet(Query)
        If ds.Tables(0).Rows.Count > 0 Then
            strDicName = ds.Tables(0).Rows(0).Item("dicActualName")
        End If
        ds.Dispose()
        ds = Nothing
        Return strDicName
    End Function

    Protected Function getLocName(ByVal strLocID As String) As String
        Dim strlocName As String = Nothing
        Dim Query As String = "Select locDescription From boLocation where locID='" & strLocID & "'"
        ds = Con.getDataSet(Query)
        If ds.Tables(0).Rows.Count > 0 Then
            strlocName = ds.Tables(0).Rows(0).Item("locName")
        End If
        'Con.objConnection.Close()
        ds.Dispose()
        ds = Nothing
        Return strlocName
    End Function
    Protected Function getCounter() As String
        Dim intCount As Integer = Session("cint")
        intCount += 1
        Session("cint") = intCount
        Return intCount.ToString
    End Function
    'Protected Function getStatus(ByVal str As String) As String
    '    Select Case str
    '        Case "1"
    '            Return "Processing"
    '        Case "2"
    '            Return "Processing"
    '        Case "3"
    '            Return "Complete"
    '        Case "4"
    '            Return "Available"
    '    End Select
    '    Return Nothing
    'End Function

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'lblMessage.Text = ""
    End Sub
    Private Sub CreateTable()
        Dim filesTable As New DataTable
        filesTable.Columns.Add("Location", Type.GetType("System.String"))
        filesTable.Columns.Add("ReDirectTo", Type.GetType("System.String"))
        filesTable.Columns.Add("Email", Type.GetType("System.String"))
        filesTable.Columns.Add("Enable", Type.GetType("System.String"))
    End Sub

    'Protected Sub btnResend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResend.Click
    '    Dim filesTable As New DataTable
    '    Dim myDataRow As DataRow
    '    filesTable.Columns.Add("ID", Type.GetType("System.String"))
    '    filesTable.Columns.Add("traName", Type.GetType("System.String"))
    '    filesTable.Columns.Add("traPatFirstName", Type.GetType("System.String"))
    '    filesTable.Columns.Add("locName", Type.GetType("System.String"))
    '    filesTable.Columns.Add("datDateTime", Type.GetType("System.DateTime"))
    '    filesTable.Columns.Add("TID", Type.GetType("System.String"))
    '    filesTable.Columns.Add("DID", Type.GetType("System.String"))
    '    For Each item4 As GridViewRow In grdMain.Rows
    '        Dim chk2 As CheckBox = item4.FindControl("chk1")
    '        If chk2.Checked Then
    '            myDataRow = filesTable.NewRow()
    '            myDataRow("ID") = getCounter1()
    '            myDataRow("traName") = item4.Cells(1).Text.ToString.Trim
    '            'myDataRow("traPatFirstName") = item4.Cells(2).Text.ToString.Trim

    '            Dim lblName As System.Web.UI.DataBoundLiteralControl = CType(item4.Cells(2).Controls(0), System.Web.UI.DataBoundLiteralControl)
    '            myDataRow("traPatFirstName") = lblName.Text


    '            myDataRow("locName") = item4.Cells(3).Text.ToString.Trim
    '            Dim lblDate As Label = item4.Cells(4).Controls(1)
    '            myDataRow("datDateTime") = CDate(lblDate.Text)
    '            myDataRow("TID") = item4.Cells(7).Text.ToString.Trim
    '            myDataRow("DID") = item4.Cells(8).Text.ToString.Trim
    '            filesTable.Rows.Add(myDataRow)
    '        End If
    '    Next
    '    Session("dt") = filesTable
    '    Response.Redirect("searchresponse.aspx")
    'End Sub
    Protected Function getCounter1() As String
        Dim intCount1 As Integer = Session("cint1")
        intCount1 += 1
        Session("cint1") = intCount1
        Return intCount1.ToString
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class


