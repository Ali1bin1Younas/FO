Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Imports System.IO
Imports System.Collections.Generic


Partial Public Class dicstatusbacklog
    Inherits System.Web.UI.UserControl
    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding

        ViewState("Counter") = 0
        'Me.btnAssign.Attributes("onclick") = "return AssignSessionValues()"

        'if an InvalidCastException occurs in either of the next two lines, 
        'please make sure that you've set the TemplateDataMode to Table (because you want nested grids)
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        If (Not (TypeOf dgi.DataItem Is Data.DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If
        Dim ds As Data.DataSet = CType(dgi.DataItem, Data.DataSet)
        Me.grdAssigned1.DataSource = AddCounterInDataTable(ds.Tables("DIC1"))
        Me.grdAssigned1.DataMember = "DIC1"
        Me.grdAssigned1.DataBind()
    End Sub

    Private Function AddCounterInDataTable(ByVal dt As DataTable)
        Dim rtnDt As DataTable = CreateDataTable()
        Dim cnt As Integer = 0
        For Each dr As DataRow In dt.Rows
            Dim dr1 As DataRow = rtnDt.NewRow
            cnt += 1
            dr1(0) = cnt
            dr1(1) = dr("empID")
            dr1(2) = dr("foID")
            dr1(3) = dr("dicID")
            dr1(4) = dr("dicActualName")
            dr1(5) = dr("dicDate")
            dr1(6) = dr("dicLength")
            dr1(7) = dr("dicStatus")
            dr1(8) = dr("drID")
            rtnDt.Rows.Add(dr1)
        Next
        Return rtnDt
    End Function

    Private Function CreateDataTable() As Data.DataTable
        Dim dt As New DataTable
        dt.Columns.Add("#")
        dt.Columns.Add("empID")
        dt.Columns.Add("foID")
        dt.Columns.Add("dicID")
        dt.Columns.Add("dicActualName")
        dt.Columns.Add("dicDate")
        dt.Columns.Add("dicLength")
        dt.Columns.Add("dicStatus")
        dt.Columns.Add("drID")
        Return dt
    End Function

    '<Ajax.AjaxMethod()> _
    ' Public Function AssignRights1(ByVal ckMT As Boolean, ByVal ckQC As Boolean, ByVal ckPR As Boolean, ByVal ckFR As Boolean, ByVal cmMT As String, ByVal cmQC As String, ByVal cmPR As String, ByVal cmFR As String) As String
    '    Return "hello"
    'End Function

    Private Sub setAssignedGrid()
        Dim hash As Hashtable = Session("AssignValue")
        Dim strEmpIDQC1 As String = hash("QC")
        Dim strEmpIDMT1 As String = hash("MT")
        Dim strEmpIDPR1 As String = hash("PR")
        Dim strEmpIDFR1 As String = hash("FR")

        For Each item1 As GridViewRow In Me.grdAssigned1.Rows
            Dim chkMT As CheckBox = item1.FindControl("AssChkMT")
            Dim chkQC As CheckBox = item1.FindControl("AssChkQC")
            Dim chkPR As CheckBox = item1.FindControl("AssChkPR")
            Dim chkFR As CheckBox = item1.FindControl("AssChkFR")

            Dim lngDicID As Long = item1.Cells(1).Text

            'for MT
            If chkMT.Checked Then
                Dim strEmpIDMT As String
                If strEmpIDMT1 <> "Skipped" Then
                    strEmpIDMT = strEmpIDMT1.ToString
                Else
                    strEmpIDMT = "0"
                End If

                'Save value one by one by one
                UpdateValuesMT(lngDicID, strEmpIDMT)
            End If

            'For QC
            If chkQC.Checked Then
                'Dim strdicID As String = item1.Cells(1).Text.ToString

                Dim strEmpIDQC As String
                If strEmpIDQC1 <> "Skipped" Then
                    strEmpIDQC = strEmpIDQC1.ToString
                Else
                    strEmpIDQC = "0"
                End If
                'Save value one by one by one
                UpdateValuesQC(lngDicID, strEmpIDQC)
            End If
            ''for PR
            If chkPR.Checked Then
                'Dim strdicID As String = item1.Cells(1).Text.ToString
                Dim strEmpIDPR As String
                If strEmpIDPR1 <> "Skipped" Then
                    strEmpIDPR = strEmpIDPR1.ToString
                Else
                    strEmpIDPR = "0"
                End If

                'Save value one by one by one
                UpdateValuesPR(lngDicID, strEmpIDPR)
            End If

            ''for FR
            If chkFR.Checked Then
                'Dim strdicID As String = item1.Cells(1).Text.ToString

                Dim strEmpIDFR As String
                If strEmpIDFR1.Trim <> "Skipped" Then
                    strEmpIDFR = strEmpIDFR1.ToString
                Else
                    strEmpIDFR = "0"
                End If
                'Save value one by one by one
                UpdateValuesFR(lngDicID, strEmpIDFR)
            End If
        Next
    End Sub

    Private Sub UpdateValuesMT(ByVal udicID As Long, ByVal uEmpID As String)
        Dim ConMT As New DBTaskBO
        ConMT.saveDataValues("Update boDictationLayers set empID='" & uEmpID & "' where dicID=" & udicID & " and rolID='MT'")
    End Sub

    Private Sub UpdateValuesQC(ByVal udicID As Long, ByVal uEmpID As String)
        Dim ConQC As New DBTaskBO
        Dim strQry As String

        If uEmpID = "0" Then
            strQry = "Update boDictationLayers set empID='" & uEmpID & "', diclSkip = 1 where dicID=" & udicID & " and rolID='QC'"
        Else
            strQry = "Update boDictationLayers set empID='" & uEmpID & "', diclSkip = 0 where dicID=" & udicID & " and rolID='QC'"
        End If

        ConQC.saveDataValues(strQry)
    End Sub

    Private Sub UpdateValuesPR(ByVal udicID As Long, ByVal uEmpID As String)
        Dim ConPR As New DBTaskBO
        If uEmpID = "0" Then
            ConPR.saveDataValues("Update boDictationLayers set empID='" & uEmpID & "', diclSkip = 1 where dicID=" & udicID & " and rolID='PR'")
        Else
            ConPR.saveDataValues("Update boDictationLayers set empID='" & uEmpID & "', diclSkip = 0 where dicID=" & udicID & " and rolID='PR'")
        End If
    End Sub

    Private Sub UpdateValuesFR(ByVal udicID As Long, ByVal uEmpID As String)
        Dim ConFR As New DBTaskBO
        If uEmpID = "0" Then
            ConFR.saveDataValues("Update boDictationLayers set empID='" & uEmpID & "', diclSkip = 1 where dicID=" & udicID & " and rolID='FR'")
        Else
            ConFR.saveDataValues("Update boDictationLayers set empID='" & uEmpID & "', diclSkip = 0 where dicID=" & udicID & " and rolID='FR'")
        End If
    End Sub

    Private Sub SaveValues(ByVal sdicID As String, ByVal sMT As String, ByVal sQC As String, ByVal sPR As String, ByVal sFR As String)
        Dim ConMT As New DBTaskBO
        ConMT.saveDataValues("Insert into boDictationLayers(dicID,empID,rolID,diclSkip,diclStatus) values('" + sdicID + "','" + sMT + "','MT',1,1) ")
        Dim ConQC As New DBTaskBO
        ConQC.saveDataValues("Insert into boDictationLayers(dicID,empID,rolID,diclSkip,diclStatus) values('" + sdicID + "','" + sQC + "','QC',1,1)")
        Dim ConPR As New DBTaskBO
        ConPR.saveDataValues("Insert into boDictationLayers(dicID,empID,rolID,diclSkip,diclStatus) values('" + sdicID + "','" + sPR + "','PR',1,1)")
        Dim ConFR As New DBTaskBO
        ConFR.saveDataValues("Insert into boDictationLayers(dicID,empID,rolID,diclSkip,diclStatus) values('" + sdicID + "','" + sFR + "','FR',1,1)")
    End Sub

    Protected Function getCounterDaily() As String
        Dim intCountDaily As Integer = Session("sccintDaily")
        intCountDaily += 1
        Session("sccintDaily") = intCountDaily
        Return intCountDaily.ToString
    End Function
    Protected Function getMTEmpID(ByVal strdicID As String) As String
        Dim Con As New DBTaskBO
        Dim Qry As String = "SELECT empID From boDictationLayers where dicID='" & strdicID & "' and rolID='MT'"
        Dim ds As DataSet
        Dim strName As String = Nothing
        ds = Con.getDataSet(Qry)
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim strID As String
            strID = ds.Tables(0).Rows(0)("empID")
            If strID.Trim <> "0" Then
                Dim ds1 As DataSet = Nothing
                Dim Qry1 As String
                Qry1 = "Select (empFirstName +', '+ substring(empLastName,1,1)) as Nam From boEmployee where empID='" & strID & "' "
                Dim Con1 As New DBTaskBO
                ds1 = Con1.getDataSet(Qry1)
                strName = ds1.Tables(0).Rows(0)("Nam")
            Else

                strName = "-"

            End If
        End If
        Return strName
    End Function
    Protected Function getQCEmpID(ByVal strdicID As String) As String
        Dim Con As New DBTaskBO
        Dim Qry As String = "SELECT empID From boDictationLayers where dicID='" & strdicID & "' and rolID='QC'"
        Dim ds As DataSet
        Dim strName As String = Nothing
        ds = Con.getDataSet(Qry)
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim strID As String
            strID = ds.Tables(0).Rows(0)("empID")
            If strID.Trim <> "0" Then
                Dim ds1 As DataSet = Nothing
                Dim Qry1 As String
                Qry1 = "Select (empFirstName +', '+ substring(empLastName,1,1)) as Nam From boEmployee where empID='" & strID & "' "
                Dim Con1 As New DBTaskBO
                ds1 = Con1.getDataSet(Qry1)
                strName = ds1.Tables(0).Rows(0)("Nam")
            Else

                strName = "-"

            End If
        End If
        Return strName
    End Function
    Protected Function getPREmpID(ByVal strdicID As String) As String
        Dim Con As New DBTaskBO
        Dim Qry As String = "SELECT empID From boDictationLayers where dicID='" & strdicID & "' and rolID='PR'"
        Dim ds As DataSet
        Dim strName As String = Nothing
        ds = Con.getDataSet(Qry)
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim strID As String
            strID = ds.Tables(0).Rows(0)("empID")
            If strID.Trim <> "0" Then
                Dim ds1 As DataSet = Nothing
                Dim Qry1 As String
                Qry1 = "Select (empFirstName +', '+ substring(empLastName,1,1)) as Nam From boEmployee where empID='" & strID & "' "
                Dim Con1 As New DBTaskBO
                ds1 = Con1.getDataSet(Qry1)
                strName = ds1.Tables(0).Rows(0)("Nam")
            Else

                strName = "-"

            End If
        End If
        Return strName
    End Function
    Protected Function getFREmpID(ByVal strdicID As String) As String
        Dim Con As New DBTaskBO
        Dim Qry As String = "SELECT empID From boDictationLayers where dicID='" & strdicID & "' and rolID='FR'"
        Dim ds As DataSet
        Dim strName As String = Nothing
        ds = Con.getDataSet(Qry)
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim strID As String
            strID = ds.Tables(0).Rows(0)("empID")
            If strID.Trim <> "0" Then
                Dim ds1 As DataSet = Nothing
                Dim Qry1 As String
                Qry1 = "Select (empFirstName +', '+ substring(empLastName,1,1)) as Nam From boEmployee where empID='" & strID & "' "
                Dim Con1 As New DBTaskBO
                ds1 = Con1.getDataSet(Qry1)
                strName = ds1.Tables(0).Rows(0)("Nam")
            Else

                strName = "-"

            End If
        End If
        Return strName
    End Function
    Protected Function getCounter() As String
        Dim intCount As Integer = Session("cint")
        intCount += 1
        Session("cint") = intCount
        Return intCount.ToString
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empID") = "" Then Response.Redirect(GF.Home)
        Session("cint") = 0

       
    End Sub
    'Protected Sub btnAssign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAssign.Click
    '    setAssignedGrid()
    '    Dim qStr As String = "PastBack"
    '    Response.Redirect("dictationassignment.aspx?qStr=" & qStr)

    'End Sub
    Protected Function getDate(ByVal dat As DateTime) As String
        Try

            Dim d As String = dat.ToShortDateString().ToString

            Return d

        Catch ex As Exception
            Return Nothing
        End Try
        
    End Function

    Protected Sub grdAssigned1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAssigned1.RowCreated
        
    End Sub

    Protected Sub grdAssigned1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAssigned1.RowDataBound


        If e.Row.Cells(13).Text.Trim <> "" And e.Row.Cells(13).Text.Trim <> "&nbsp;" And e.Row.Cells(13).Text.Trim <> "Status" Then
            Dim val123 As String = e.Row.Cells(13).Text.Trim
            Select Case val123
                Case "2"

                    e.Row.Cells(4).Enabled = False
                    e.Row.Cells(6).Enabled = False
                    e.Row.Cells(8).Enabled = False
                    e.Row.Cells(10).Enabled = False
                    e.Row.Cells(5).ForeColor = Drawing.Color.Gray
                    e.Row.Cells(7).ForeColor = Drawing.Color.Gray
                    e.Row.Cells(9).ForeColor = Drawing.Color.Gray
                    e.Row.Cells(11).ForeColor = Drawing.Color.Gray

                Case "3", "4"
                    e.Row.Cells(5).ForeColor = Drawing.Color.Blue
                    e.Row.Cells(7).ForeColor = Drawing.Color.Red
                    e.Row.Cells(9).ForeColor = Drawing.Color.Brown
                    e.Row.Cells(11).ForeColor = Drawing.Color.Green


                Case "0", "1"

                    e.Row.Cells(4).Enabled = True
                    e.Row.Cells(6).Enabled = True
                    e.Row.Cells(8).Enabled = True
                    e.Row.Cells(10).Enabled = True
                    e.Row.Cells(5).ForeColor = Drawing.Color.Black
                    e.Row.Cells(7).ForeColor = Drawing.Color.Black
                    e.Row.Cells(9).ForeColor = Drawing.Color.Black
                    e.Row.Cells(11).ForeColor = Drawing.Color.Black

            End Select
            e.Row.Cells(13).Visible = False
        End If
    End Sub

    Protected Function getMin(ByVal second As String) As String
        Return GF.GetMin(second)
    End Function
End Class
