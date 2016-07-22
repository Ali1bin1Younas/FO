Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL
Partial Class team
    Inherits System.Web.UI.Page
    Dim intCheckValue As Integer
    Dim strHospitalName As String
    Dim intTeamID As Integer
    Dim strEmployeeRemoveMT As String
    Dim strEmployeeRemoveQC As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        If Not Page.IsPostBack Then
            Me.chkEnable.Checked = True
            Session("strRemoveQC") = ""
            loadPR()
            loadFR()
            loadQCMain()
            loadMT()
            CreateUpperTable()
            Me.grdUpper.DataSource = Session("dt")
            Me.grdUpper.DataBind()
            CreateLowerTable()
            Me.grdLower.DataSource = Session("dt1")
            Me.grdLower.DataBind()
        End If
    End Sub

    Private Sub loadFR()
        Dim Con As New DBTaskBO
        Dim sqlText As New StringBuilder
        sqlText.Append("SELECT bE.empID, bE.empFirstName + ', ' + empLastName as empName from boEmployeeRoles bER ")
        sqlText.Append("INNER JOIN boEmployee bE on bER.empID = bE.empID ")
        sqlText.Append("WHERE bER.RolID='PR' and bER.empId <> '0' and bER.empEnable=1 AND bE.empEnable=1 ")
        sqlText.Append("AND bER.empID NOt IN(SELECT empID From boTeamPLayers where rolID='PR')")

        Dim ds As DataSet
        Dim strFR As String = Nothing
        ds = Con.getDataSet(sqlText.ToString())
        cmbFR.DataSource = ds.Tables(0)
        cmbFR.DataTextField = "empName"
        cmbFR.DataValueField = "empID"
        cmbFR.DataBind()
        ds.dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Private Sub loadPR()
        Dim Con As New DBTaskBO
        Dim Qry As String = "select  distinct(a.empID),c.empFirstName +', '+ c.empLastName as empName from boEmployeeRoles a INNER JOIN boEmployee c on a.empid=c.empID  where not a.rolID in(select rolID from boTeamPlayers b where b.empid=a.empid and a.rolID=b.rolID) and a.rolID='PR' and a.empID not in('0') AND a.empEnable=1 AND c.empEnable=1"
        Dim ds As DataSet
        Dim strPR As String = Nothing
        ds = Con.getDataSet(Qry)
        cmbPR.DataSource = ds.Tables(0)
        cmbPR.DataTextField = "empName"
        cmbPR.DataValueField = "empID"
        cmbPR.DataBind()
    End Sub
    Private Sub loadQCMain()
        Dim Qry As String
        Dim Con As New DBTaskBO

        If strEmployeeRemoveQC = "" Then
            Qry = "select  distinct(a.empID),c.empFirstName +', '+ c.empLastName as empName from boEmployeeRoles a INNER JOIN boEmployee c on a.empid=c.empID  where  not a.rolID in(select rolID from boTeamPlayers b where b.empid=a.empid and a.rolID=b.rolID) and a.rolID='QC' and a.empID not in('0') and a.empID not in ('" & strEmployeeRemoveQC & "') AND a.empEnable=1 AND c.empEnable=1"
        Else
            Qry = "select  distinct(a.empID),c.empFirstName +', '+ c.empLastName as empName from boEmployeeRoles a INNER JOIN boEmployee c on a.empid=c.empID  where  not a.rolID in(select rolID from boTeamPlayers b where b.empid=a.empid and a.rolID=b.rolID) and  a.rolID='FR' and a.empID not in('0') and a.empID not in (" & strEmployeeRemoveQC & ") AND a.empEnable=1 AND c.empEnable=1"
        End If
        Dim ds As DataSet
        Dim strQC As String = Nothing
        ds = Con.getDataSet(Qry)
        cmbQCMain.DataSource = ds.Tables(0)
        cmbQCMain.DataTextField = "empName"
        cmbQCMain.DataValueField = "empID"
        cmbQCMain.DataBind()
        ds.dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing
    End Sub
    Private Sub loadQC()
        cmbQC.DataSource = Session("dt")
        cmbQC.DataTextField = "empFirstName"
        cmbQC.DataValueField = "empID"
        cmbQC.DataBind()
    End Sub
    Private Sub loadMT()
        Dim Con As New DBTaskBO
        Dim Qry As String
        If strEmployeeRemoveMT = "" Then
            Qry = "select  distinct(a.empID),c.empLastName +', '+ c.empFirstName as empName from boEmployeeRoles a INNER JOIN boEmployee c on a.empid=c.empID  where  not a.rolID in(select rolID from boTeamPlayers b where b.empid=a.empid and a.rolID=b.rolID) and a.rolID='MT' and a.empID not in('0') and a.empID not in ('" & strEmployeeRemoveMT & "') AND a.empEnable=1 AND c.empEnable=1"
        Else
            Qry = "select  distinct(a.empID),c.empLastName +', '+ c.empFirstName as empName from boEmployeeRoles a INNER JOIN boEmployee c on a.empid=c.empID  where  not a.rolID in(select rolID from boTeamPlayers b where b.empid=a.empid and a.rolID=b.rolID) and  a.rolID='MT' and a.empID not in('0') and a.empID not in (" & strEmployeeRemoveMT & ") AND a.empEnable=1 AND c.empEnable=1"
        End If
        Dim ds As DataSet
        Dim strMT As String = Nothing
        ds = Con.getDataSet(Qry)
        cmbMT.DataSource = ds.Tables(0)
        cmbMT.DataTextField = "empName"
        cmbMT.DataValueField = "empID"
        cmbMT.DataBind()
    End Sub
    Private Sub CreateUpperTable()
        Dim dt As New DataTable
        dt.Columns.Add("ID", Type.GetType("System.Int16"))
        dt.Columns(0).AutoIncrement = True
        dt.Columns(0).AutoIncrementSeed = 1
        dt.Columns(0).AutoIncrementStep = 1
        dt.Columns(0).Unique = True
        dt.Columns.Add("empID", Type.GetType("System.String"))
        dt.Columns.Add("empFirstName", Type.GetType("System.String"))
        dt.Columns.Add("empLastName", Type.GetType("System.String"))
        dt.Columns.Add("dateAdded", Type.GetType("System.DateTime"))
        Session("dt") = dt
    End Sub
    Private Sub CreateLowerTable()
        Dim dt1 As New DataTable
        dt1.Columns.Add("ID", Type.GetType("System.Int16"))
        dt1.Columns(0).AutoIncrement = True
        dt1.Columns(0).AutoIncrementSeed = 1
        dt1.Columns(0).AutoIncrementStep = 1
        dt1.Columns(0).Unique = True
        dt1.Columns.Add("empID", Type.GetType("System.String"))
        dt1.Columns.Add("empFirstName", Type.GetType("System.String"))
        dt1.Columns.Add("empLastName", Type.GetType("System.String"))
        dt1.Columns.Add("QC", Type.GetType("System.String"))
        dt1.Columns.Add("dateAdded", Type.GetType("System.DateTime"))
        Session("dt1") = dt1
    End Sub
    Private Sub formatLowerGridAtLoad()
        Try
            Dim dt1 As DataTable = Session("dt1")
            Dim myDataRow As DataRow
            myDataRow = dt1.NewRow()
            myDataRow("empID") = Me.cmbMT.SelectedValue.ToString
            myDataRow("empFirstName") = GetEmpFirstName(Me.cmbMT.SelectedValue.ToString)
            myDataRow("empLastName") = GetEmpLastName(Me.cmbMT.SelectedValue.ToString)
            myDataRow("QC") = Me.cmbQC.SelectedValue.ToString
            myDataRow("dateAdded") = DateTime.Now
            Session("dt") = dt1
            dt1.Rows.Add(myDataRow)
            Me.grdLower.DataSource = dt1
            grdLower.DataBind()

        Catch ex As Exception

        End Try
        
    End Sub
    Private Sub formatUpperGridAtLoad()
        Try
            Dim dt As DataTable = Session("dt")
            Dim myDataRow As DataRow
            myDataRow = dt.NewRow()
            myDataRow("empID") = Me.cmbQCMain.SelectedValue.ToString
            myDataRow("empFirstName") = GetEmpFirstName(Me.cmbQCMain.SelectedValue.ToString)
            myDataRow("empLastName") = GetEmpLastName(Me.cmbQCMain.SelectedValue.ToString)
            myDataRow("dateAdded") = DateTime.Now
            Session("dt") = dt
            dt.Rows.Add(myDataRow)
            Me.grdUpper.DataSource = dt
            grdUpper.DataBind()

        Catch ex As Exception

        End Try
        
    End Sub
    Private Function GetEmpFirstName(ByVal id As String) As String
        Dim strFirstName As String = Nothing
        Dim Con As New DBTaskBO
        Dim Qry As String = "Select empFirstName from boEmployee where empID='" & id & "'"
        'Dim dr As SqlDataReader
        Dim ds As DataSet
        Dim strMT As String = Nothing
        'dr = Con.getDataReader(Qry)
        ds = Con.getDataSet(Qry)
        'If dr.Read Then
        '    strFirstName = dr("empFirstName").ToString
        'End If
        If ds.tables(0).rows.count > 0 Then
            strFirstName = ds.tables(0).rows(0).item("empFirstName").ToString
        End If
        ds.dispose()
        ds = Nothing
        con = Nothing
        Return strFirstName
    End Function
    Private Function GetEmpLastName(ByVal id As String) As String
        Dim strLastName As String = Nothing
        Dim Con As New DBTaskBO
        Dim Qry As String = "Select empLastName from boEmployee where empID='" & id & "'"
        'Dim dr As SqlDataReader
        Dim strMT As String = Nothing
        Dim ds As DataSet
        ds = Con.getDataSet(Qry)
        'dr = Con.getDataReader(Qry)
        'If dr.Read Then
        '    strLastName = dr("empLastName")
        'End If
        If ds.tables(0).rows.count > 0 Then
            strLastName = ds.tables(0).rows(0).item("empLastName").ToString
        End If
        ds.dispose()
        ds = Nothing
        con = Nothing
        Return strLastName
    End Function

    Protected Function GetQCName(ByVal id As String) As String
        Dim strName As String = Nothing
        Dim Con As New DBTaskBO
        Dim Qry As String = "Select empFirstName,empLastName from boEmployee where empID='" & id & "'"
        'Dim dr As SqlDataReader
        Dim strMT As String = Nothing
        'dr = Con.getDataReader(Qry)
        Dim ds As DataSet
        ds = Con.getDataSet(Qry)
        'If dr.Read Then
        '    strName = dr("empLastName") + ", " + dr("empFirstName")
        'End If
        If ds.tables(0).rows.count > 0 Then
            strName = ds.tables(0).rows(0).item("empLastName") + ", " + ds.tables(0).rows(0).item("empFirstName")
        End If
        ds.dispose()
        ds = Nothing
        con = Nothing
        Return strName
    End Function
    Protected Sub btnQCAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQCAdd.Click

       
        If Me.cmbPR.Text = "" Or Me.cmbQCMain.Text = "" Then

            If Me.cmbPR.Text = "" Then
                Me.lblSuccessMessage.Visible = True
                'Me.lblSuccessMessage.Text = "No Proof Reader Available"
                Me.lblSuccessMessage.Text = "<table width=520 border=0 cellpadding=0 cellspacing=0>" _
                + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                + "<table width=480 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                + "<td align=center width=90><img src='../images/error.ico'></td><td align=left width=390><font style='font-size:8pt;'>No Proof Reader Available.</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr>" _
                + "<tr><td height=15></td></tr></table>"
            Else
                Me.lblSuccessMessage.Visible = True
                'Me.lblSuccessMessage.Text = "No Quality Controller Available"
                Me.lblSuccessMessage.Text = "<table width=520 border=0 cellpadding=0 cellspacing=0>" _
                + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                + "<table width=480 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                + "<td align=center width=90><img src='../images/error.ico'></td><td align=left width=390><font style='font-size:8pt;'>No Quality Controller Available.</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr>" _
                + "<tr><td height=15></td></tr></table>"

            End If

        Else

            Me.lblSuccessMessage.Visible = False
            Me.lblSuccessMessage.Text = ""

            formatUpperGridAtLoad()
            Session("strRemoveQC") = ""
            RemoveValuesQC()
            loadQC()
            loadQCMain()
            lnkRemoveUpper.Visible = True
        End If



    End Sub
    Protected Sub btnMTAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMTAdd.Click
        Dim strMsg As String
        strMsg = "<table width=520 border=0 cellpadding=0 cellspacing=0>" _
                + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                + "<table width=480 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                + "<td align=center width=90><img src='../images/error.ico'></td><td align=left width=390><font style='font-size:8pt;'>No Medical Transcriptionist Available.</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr>" _
                + "<tr><td height=15></td></tr></table>"

        If Me.cmbMT.Text = "" Then

            Me.lblSuccessMessage.Visible = True
            Me.lblSuccessMessage.Text = strMsg
            'Me.lblSuccessMessage.Text = "No Medical Transcriptionist Available"

        Else
            Me.lblSuccessMessage.Visible = False
            Me.lblSuccessMessage.Text = ""

            formatLowerGridAtLoad()
            Session("strRemoveMT") = ""
            RemoveValuesMT()
            loadMT()
            lnkRemoveLower.Visible = True

        End If

    End Sub
    Protected Sub btnSaveTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveTeam.Click
        Dim Con As New DBTaskBO

        Dim Qry As String = "Select team from boTeam where team='" & Me.txtTeamName.Text & "'"
        'Dim dr As SqlDataReader
        Session("sTNam") = Me.txtTeamName.Text.Trim
        'dr = Con.getDataReader(Qry)
        Dim ds As DataSet
        ds = Con.getDataSet(Qry)
        'If dr.Read Then
        If ds.tables(0).rows.count > 0 Then
            Me.lblSuccessMessage.Visible = True
            'Me.lblSuccessMessage.Text = "Team Name Not Available..."
            Me.lblSuccessMessage.Text = "<table width=520 border=0 cellpadding=0 cellspacing=0>" _
                + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                + "<table width=480 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                + "<td align=center width=90><img src='../images/error.ico'></td><td align=left width=390><font style='font-size:8pt;'>Please fill all mandatory fields (*).</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr>" _
                + "<tr><td height=15></td></tr></table>"

        Else
            Me.lblSuccessMessage.Visible = False
            Me.lblSuccessMessage.Text = ""
            SaveTeam()
            SaveAllPR()
            SaveAllFR()
            SaveAllQCs()
            SaveAllMTs()
            Response.Redirect("teammain.aspx")
        End If


    End Sub
    Private Sub SaveAllPR()
        Dim intTID2 As Integer = intTeamID
        Dim strEmpID2 As String = Me.cmbPR.SelectedValue
        Dim strRollID2 As String = "PR"
        Dim intTeamLevel2 = 1
        Dim strTeamParent2 = " "
        SavePR(strEmpID2, strRollID2, intTeamLevel2, strTeamParent2)
    End Sub

    Private Sub SaveAllFR()
        Dim intTID3 As Integer = intTeamID
        Dim strEmpID3 As String = Me.cmbFR.SelectedValue
        Dim strRollID3 As String = "FR"
        Dim intTeamLevel3 = 4
        Dim strTeamParent3 = Me.cmbPR.SelectedValue
        SaveFR(strEmpID3, strRollID3, intTeamLevel3, strTeamParent3)
    End Sub
    Private Sub SaveFR(ByVal empid As String, ByVal rolid As String, ByVal level As Integer, ByVal tparent As String)
        Dim hash As New Hashtable
        Dim col As ColumnName = Nothing
        col = New ColumnName("team", Me.txtTeamName.Text.ToString, "str")
        hash.Add("1", col)
        col = New ColumnName("empID", empid, "str")
        hash.Add("2", col)
        col = New ColumnName("rolID", rolid, "str")
        hash.Add("3", col)
        col = New ColumnName("teamlevel", level, "int")
        hash.Add("4", col)
        col = New ColumnName("teamParent", tparent, "str")
        hash.Add("5", col)
        Dim ad As New DBTaskBO
        ad.InsertDataValues(hash, "boTeamPlayers")
    End Sub

    Private Sub SavePR(ByVal empid As String, ByVal rolid As String, ByVal level As Integer, ByVal tparent As String)
        Dim hash As New Hashtable
        Dim col As ColumnName = Nothing
        col = New ColumnName("team", Me.txtTeamName.Text.ToString, "str")
        hash.Add("1", col)
        col = New ColumnName("empID", empid, "str")
        hash.Add("2", col)
        col = New ColumnName("rolID", rolid, "str")
        hash.Add("3", col)
        col = New ColumnName("teamlevel", level, "int")
        hash.Add("4", col)
        col = New ColumnName("teamParent", tparent, "str")
        hash.Add("5", col)
        Dim ad As New DBTaskBO
        ad.InsertDataValues(hash, "boTeamPlayers")
    End Sub
    Private Sub SaveAllMTs()
        For Each dr As GridViewRow In grdLower.Rows
            Dim intTID1 As Integer = intTeamID
            Dim strEmpID1 As String = dr.Cells(1).Text.ToString
            Dim strRollID1 As String = "MT"
            Dim intTeamLevel1 = 3
            Dim strTeamParent1 = dr.Cells(4).Text.ToString
            SaveMTs(strEmpID1, strRollID1, intTeamLevel1, strTeamParent1)
        Next
    End Sub
    Private Sub SaveMTs(ByVal empid As String, ByVal rolid As String, ByVal level As Integer, ByVal tparent As String)
        Dim hash As New Hashtable
        Dim col As ColumnName = Nothing
        col = New ColumnName("team", Me.txtTeamName.Text.ToString, "str")
        hash.Add("1", col)
        col = New ColumnName("empID", empid, "str")
        hash.Add("2", col)
        col = New ColumnName("rolID", rolid, "str")
        hash.Add("3", col)
        col = New ColumnName("teamlevel", level, "int")
        hash.Add("4", col)
        col = New ColumnName("teamParent", tparent, "str")
        hash.Add("5", col)
        Dim ad As New DBTaskBO
        ad.InsertDataValues(hash, "boTeamPlayers")
    End Sub
    Private Sub SaveTeam()
        Dim ddat As DateTime = DateTime.Now
        Dim hash As New Hashtable
        Dim col As ColumnName = Nothing
        col = New ColumnName("team", Me.txtTeamName.Text.ToString, "str")
        hash.Add("1", col)
        col = New ColumnName("teamDateTime", ddat, "dat")
        hash.Add("2", col)
        col = New ColumnName("teamDateTimeModified", ddat, "dat")
        hash.Add("3", col)
        If Me.chkEnable.Checked Then
            col = New ColumnName("teamEnable", "1", "str")
            hash.Add("4", col)
        Else
            col = New ColumnName("teamEnable", "0", "str")
            hash.Add("4", col)

        End If

        Dim ad As New DBTaskBO
        Dim i As Integer = ad.InsertDataValues(hash, "boTeam")
        If i > 0 Then
            Me.lblSuccessMessage.Visible = True
            Me.lblSuccessMessage.Text = "Team Successfully Created..."
        Else
            Me.lblSuccessMessage.Text = "Team Not Created Successfully..."
        End If
    End Sub
    Private Sub SaveAllQCs()
        For Each dr As GridViewRow In grdUpper.Rows
            Dim intTID As Integer = intTeamID
            Dim strEmpID As String = dr.Cells(1).Text.ToString
            Dim strRollID As String = "QC"
            Dim intTeamLevel = 2
            Dim strTeamParent = Me.cmbPR.SelectedValue
            SaveQCs(strEmpID, strRollID, intTeamLevel, strTeamParent)
        Next
    End Sub
    Private Sub SaveQCs(ByVal empid As String, ByVal rolid As String, ByVal level As Integer, ByVal tparent As String)
        Dim hash As New Hashtable
        Dim col As ColumnName = Nothing
        col = New ColumnName("team", Me.txtTeamName.Text.ToString, "str")
        hash.Add("1", col)
        col = New ColumnName("empID", empid, "str")
        hash.Add("2", col)
        col = New ColumnName("rolID", rolid, "str")
        hash.Add("3", col)
        col = New ColumnName("teamlevel", level, "int")
        hash.Add("4", col)
        col = New ColumnName("teamParent", tparent, "str")
        hash.Add("5", col)
        Dim ad As New DBTaskBO
        ad.InsertDataValues(hash, "boTeamPlayers")
    End Sub
    Private Sub RemoveValuesQC()

        Try

            For Each row As GridViewRow In grdUpper.Rows

                Session("strRemoveQC") = Session("strRemoveQC") + "'" + row.Cells(1).Text.ToString + "'" + ",".Trim

                strEmployeeRemoveQC = Session("strRemoveQC")

                Dim strTempQC As String = Session("strRemoveQC").ToString

                strEmployeeRemoveQC = strTempQC.Substring(0, strTempQC.Length - 1)

            Next
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub RemoveValuesMT()

        Try
            For Each row As GridViewRow In grdLower.Rows


                Session("strRemoveMT") = Session("strRemoveMT") + "'" + row.Cells(1).Text.ToString + "'" + ",".Trim

                strEmployeeRemoveQC = Session("strRemoveMT")

                Dim strTempMT As String = Session("strRemoveMT").ToString

                strEmployeeRemoveMT = strTempMT.Substring(0, strTempMT.Length - 1)

            Next

        Catch ex As Exception

        End Try
        
    End Sub

    Protected Sub lnkRemoveUpper_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRemoveUpper.Click
        Try
            Dim dt As DataTable = Session("dt")
            Dim i As Int16 = 0
            For Each row As GridViewRow In Me.grdUpper.Rows
                Dim chk As CheckBox = row.FindControl("chkUpper")
                If chk.Checked Then
                    Dim id As String = Convert.ToString(Me.grdUpper.DataKeys(i).Value.ToString)
                    Dim deleteRow() As DataRow = dt.Select("ID=" + id)
                    dt.Rows.Remove(deleteRow(0))

                End If
                i += 1
            Next
            Me.grdUpper.DataSource = dt
            Me.grdUpper.DataBind()
            Session("dt") = dt
            loadQC()
            Session("strRemoveQC") = ""
            RemoveValuesQC()
            loadQCMain()
            Dim dtremove As DataTable = Session("dt")
            If dtremove.Rows.Count = 0 Then

                Me.lnkRemoveUpper.Visible = False
            Else
                Me.lnkRemoveUpper.Visible = True

            End If


        Catch ex As Exception

        End Try
        
    End Sub

    Protected Sub lnkRemoveLower_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRemoveLower.Click

        Try
            Dim dt1 As DataTable = Session("dt1")
            Dim i As Int16 = 0
            For Each row As GridViewRow In Me.grdLower.Rows
                Dim chk As CheckBox = row.FindControl("chkLower")
                If chk.Checked Then
                    Dim id1 As String = Convert.ToString(Me.grdLower.DataKeys(i).Value.ToString)
                    Dim deleteRow() As DataRow = dt1.Select("ID=" + id1)
                    dt1.Rows.Remove(deleteRow(0))

                End If
                i += 1
            Next
            Me.grdLower.DataSource = dt1
            Me.grdLower.DataBind()
            Session("dt1") = dt1
            loadMT()
            Session("strRemoveMT") = ""
            RemoveValuesMT()
            loadMT()
            Dim dtremove1 As DataTable = Session("dt1")
            If dtremove1.Rows.Count = 0 Then

                Me.lnkRemoveLower.Visible = False
            Else
                Me.lnkRemoveLower.Visible = True

            End If


        Catch ex As Exception

        End Try
        
    End Sub

End Class

