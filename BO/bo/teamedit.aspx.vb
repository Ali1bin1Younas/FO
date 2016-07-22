Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL
Partial Class teamedit
    Inherits System.Web.UI.Page
    Dim intCheckValue As Integer
    Dim strHospitalName As String
    Dim intTeamID As Integer
    Dim strEmployeeRemoveMT As String
    Dim strEmployeeRemoveQC As String
    Private dsMt As Data.DataSet
    Private gvMt As GridView
    Protected index As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        Dim strSTeamName As String = Session("sTeamName")
        If Not Page.IsPostBack Then
            Call Me.loadGrid()
            Dim objDb As New MTBMS.DAL.DBTaskBO()
            Me.chkEnable.Checked = CType(objDb.getScalar("SELECT teamEnable FROM boTeam WHERE team='" & Session("sTeamName") & "'"), Boolean)
            Session("strRemoveQC") = ""
            loadPR()
            loadFR()
            loadQCMain()
            loadMT()
            CreateUpperTable()
            GetQCTalbeUpper(strSTeamName)
            CreateLowerTable()
            GetMTTalbeLower(strSTeamName)
        End If
    End Sub
    Private Sub loadFR()
        Dim Con As New DBTaskBO
        Dim Qry As String = "select  distinct(a.empID), c.empFirstName + ' ' + c.empLastName as empName from boEmployeeRoles a INNER JOIN boEmployee c on a.empid=c.empID  Where  a.empID <> '0' AND a.RolID='FR' AND a.empEnable=1 AND c.empEnable=1"
        Dim ds As DataSet
        Dim strFR As String = Nothing
        ds = Con.getDataSet(Qry)
        cmbFR.DataSource = ds.Tables(0)
        cmbFR.DataTextField = "empName"
        cmbFR.DataValueField = "empID"
        cmbFR.SelectedValue = Session("FR").ToString
        cmbFR.DataBind()
    End Sub

    Private Sub loadPR()
        Dim Con As New DBTaskBO
        Dim sqlText As New StringBuilder
        sqlText.Append("SELECT bE.empID, bE.empFirstName + ', ' + empLastName as empName from boEmployeeRoles bER ")
        sqlText.Append("INNER JOIN boEmployee bE on bER.empID = bE.empID ")
        sqlText.Append("WHERE bER.RolID='PR' and bER.empId <> '0' and bER.empEnable=1 AND bE.empEnable=1 ")
        sqlText.Append("AND bER.empID NOt IN(SELECT empID From boTeamPLayers where rolID='PR' AND Team <> '" & Session("sTeamName") & "')")
        Dim ds As DataSet
        ds = Con.getDataSet(sqlText.ToString())
        cmbPR.DataSource = ds.Tables(0)
        cmbPR.DataTextField = "empName"
        cmbPR.DataValueField = "empID"
        cmbPR.SelectedValue = Session("PR").ToString
        cmbPR.DataBind()
    End Sub
    Private Sub GetQCTalbeUpper(ByVal team As String)
        Dim qry As String = "Select * From viwEditTeam where team='" & team & "' and rolID='QC'"
        Dim Con As New DBTaskBO
        Dim ds As DataSet
        ds = Con.getDataSet(qry)
        Dim dt As DataTable = Session("dt")
        Dim myDataRow As DataRow
        For Each dRow As DataRow In ds.Tables(0).Rows
            myDataRow = dt.NewRow()
            myDataRow("empID") = dRow.Item(0) ' ds.Tables(0).Rows(i)(0)
            myDataRow("empFirstName") = dRow.Item(1) ' ds.Tables(0).Rows(i)(1)
            myDataRow("empLastName") = dRow.Item(2) 'ds.Tables(0).Rows(i)(2)
            myDataRow("dateAdded") = dRow.Item(3) 'ds.Tables(0).Rows(i)(3)
            Session("dt") = dt
            dt.Rows.Add(myDataRow)
        Next
    End Sub

    Private Sub GetMTTalbeLower(ByVal team As String)
        Dim qry As String = "Select * From viwTableMT where team='" & team & "' and rolID='MT'"
        Dim Con As New DBTaskBO
        Dim ds As DataSet
        ds = Con.getDataSet(qry)
        Dim i As Integer = 0
        Dim dt1 As DataTable = Session("dt1")
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Dim myDataRow As DataRow
            myDataRow = dt1.NewRow()
            myDataRow("empID") = ds.Tables(0).Rows(i)(0)
            myDataRow("empFirstName") = ds.Tables(0).Rows(i)(1)
            myDataRow("empLastName") = ds.Tables(0).Rows(i)(2)
            myDataRow("dateAdded") = ds.Tables(0).Rows(i)(3)
            myDataRow("QC") = ds.Tables(0).Rows(i)(6)
            Session("dt1") = dt1
            dt1.Rows.Add(myDataRow)
        Next
        i += 1

        loadQC()
        

    End Sub
    Private Sub GetQCTalbeLower(ByVal team As String)
        Dim qry As String = "Select * From viwTableMT where team='" & team & "' and rolID='MT'"
        Dim Con As New DBTaskBO
        Dim ds As DataSet
        ds = Con.getDataSet(qry)
        Dim ddt1 As DataTable = ds.Tables(0)
        Session("dt1") = ddt1
    End Sub
    Private Sub loadQCMain()
        Dim Qry As String
        Dim Con As New DBTaskBO

        If strEmployeeRemoveQC = "" Then
            Qry = "select  distinct(a.empID), c.empFirstName + ' ' + c.empLastName as empName from boEmployeeRoles a INNER JOIN boEmployee c on a.empid=c.empID  where  not a.rolID in(select rolID from boTeamPlayers b where b.empid=a.empid and a.rolID=b.rolID) and a.rolID='QC' and a.empID not in('0') and a.empID not in ('" & strEmployeeRemoveQC & "') AND (a.empEnable=1 AND c.empEnable=1)"
        Else
            Qry = "select  distinct(a.empID),c.empFirstName + ' ' + c.empLastName as empName from boEmployeeRoles a INNER JOIN boEmployee c on a.empid=c.empID  where  not a.rolID in(select rolID from boTeamPlayers b where b.empid=a.empid and a.rolID=b.rolID) and  a.rolID='FR' and a.empID not in('0') and a.empID not in (" & strEmployeeRemoveQC & ") AND (a.empEnable=1 AND c.empEnable=1)"
        End If
        Dim ds As DataSet
        Dim strQC As String = Nothing
        ds = Con.getDataSet(Qry)
        cmbQCMain.DataSource = ds.Tables(0)
        cmbQCMain.DataTextField = "empName"
        cmbQCMain.DataValueField = "empID"
        cmbQCMain.DataBind()
    End Sub
    Private Sub loadQC()

        Dim objload As New loade()
        Dim objDb As New MTBMS.DAL.DBTaskBO()
        Dim ds As DataSet = objDb.getDataSet(objload.Query_QC(Session("sTeamName").ToString))
        cmbQC.DataSource = ds.Tables(0)
        cmbQC.DataTextField = "empName"
        cmbQC.DataValueField = "empID"
        cmbQC.DataBind()

        ddlChangeQC.DataSource = ds.Tables(0)
        ddlChangeQC.DataTextField = "empName"
        ddlChangeQC.DataValueField = "empID"
        ddlChangeQC.DataBind()

    End Sub
    Private Sub loadMT()
        Dim Con As New DBTaskBO
        Dim Qry As String
        If strEmployeeRemoveMT = "" Then
            Qry = "select  distinct(a.empID),c.empFirstName +', '+ c.empLastName as empName from boEmployeeRoles a INNER JOIN boEmployee c on a.empid=c.empID  where  not a.rolID in(select rolID from boTeamPlayers b where b.empid=a.empid and a.rolID=b.rolID) and a.rolID='MT' and a.empID not in('0') and a.empID not in ('" & strEmployeeRemoveMT & "')"
        Else
            Qry = "select  distinct(a.empID),c.empFirstName +', '+ c.empLastName as empName from boEmployeeRoles a INNER JOIN boEmployee c on a.empid=c.empID  where  not a.rolID in(select rolID from boTeamPlayers b where b.empid=a.empid and a.rolID=b.rolID) and  a.rolID='MT' and a.empID not in('0') and a.empID not in (" & strEmployeeRemoveMT & ")"
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
    

    Private Function GetEmpFirstName(ByVal id As String) As String
        Dim strFirstName As String = Nothing
        Dim Con As New DBTaskBO
        Dim Qry As String = "Select empFirstName from boEmployee where empID='" & id & "'"
        'Dim dr As SqlDataReader
        Dim strMT As String = Nothing
        'dr = Con.getDataReader(Qry)
        Dim ds As DataSet
        ds = Con.getDataSet(Qry)
        'If dr.Read Then
        '    strFirstName = dr("empFirstName").ToString
        'End If
        If ds.tables(0).rows.count > 0 Then
            strFirstName = ds.tables(0).rows(0).item("empFirstName").ToString
        End If
        Return strFirstName
    End Function
    Private Function GetEmpLastName(ByVal id As String) As String
        Dim strLastName As String = Nothing
        Dim Con As New DBTaskBO
        Dim Qry As String = "Select empLastName from boEmployee where empID='" & id & "'"
        'Dim dr As SqlDataReader
        Dim strMT As String = Nothing
        'dr = Con.getDataReader(Qry)
        Dim ds As DataSet
        ds = Con.getDataSet(Qry)
        'If dr.Read Then
        '    strLastName = dr("empLastName")
        'End If
        If ds.tables(0).rows.count > 0 Then
            strLastName = ds.tables(0).rows(0).item("empLastName").ToString
        End If
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

            'formatUpperGridAtLoad()
            'Session("strRemoveQC") = ""
            'RemoveValuesQC()
            Dim objLoad As New loade()
            objLoad.Insert_QC(Session("FR").ToString, cmbQCMain.SelectedValue.ToString, Session("sTeamName"))
            Call Me.loadGrid()
            loadQC()
            loadQCMain()
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

            Dim QC As String = CStr(Me.cmbQC.SelectedValue)
            Dim Mt As String = CStr(Me.cmbMT.SelectedValue)

            Dim objLoad As New loade()
            objLoad.Insert_MT(QC, Mt, Session("sTeamName"))
            Me.loadGrid()
            loadMT()
        End If

    End Sub
    Private Sub DeleteTeamPlayers()
        Dim Con As New DBTaskBO
        Dim Qry As String = "Delete from boTeamPlayers where team='" + Session("sTeamName") + "'"
        Con.deleteDataValues(Qry)
    End Sub

    'Private Sub DeleteTeam()
    '    Dim Con As New DBTaskBO
    '    Dim Qry As String = "Delete from boTeam where team='" + Session("sTeamName") + "'"
    '    Dim ds As DataSet
    '    ds = Con.getDataSet(Qry)

    'End Sub

    Private Sub UpdateTeam()
        Dim dat As DateTime = DateTime.Now
        Dim Con As New DBTaskBO

        Dim Qry As String = "Update boTeam set teamDateTimeModified='" & dat & "'where team='" + Session("sTNam") + "'"

        Con.saveDataValues(Qry)

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
        col = New ColumnName("team", Session("sTeamName"), "str")
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
        col = New ColumnName("team", Session("sTeamName"), "str")
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
    
    Private Sub loadGrid()
        Me.gvQc.DataSource = Nothing
        Dim objload As New loade()
        Dim load_QC As String = objload.Query(Session("sTeamName"))
        Dim objDb As New MTBMS.DAL.DBTaskBO()
        Try
            dsMt = objDb.getDataSet(load_QC)
            dsMt.Tables(0).TableName = "QC"
            dsMt.Tables(1).TableName = "MT"
            Me.gvQc.DataSource = dsMt.Tables(0)
            Me.gvQc.DataMember = "QC"
            Me.gvQc.DataBind()
        Catch ex As Exception
        Finally
            objload = Nothing
            objDb = Nothing
        End Try

    End Sub

    Protected Sub gvQc_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvQc.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            Try
                Dim hLink As HyperLink = e.Row.FindControl("hRemove")
                hLink.NavigateUrl = "remove.aspx?rolID=QC&team=" & Session("sTeamName") & "&empId=" & Me.gvQc.DataKeys(e.Row.RowIndex).Item("empId").ToString
                hLink.Attributes.Add("onClick", "return QC_Remove();")
            Catch ex As Exception

            End Try

        End If
    End Sub

    Protected Sub gvQc_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvQc.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            gvMt = e.Row.FindControl("gvMT")
            Dim dv As New DataView(dsMt.Tables(1))
            dv.RowFilter = "teamParent='" & Me.gvQc.DataKeys(e.Row.RowIndex).Item("empId") & "'"
            gvMt.DataSource = dv
            gvMt.DataMember = "MT"
            gvMt.DataBind()
        End If
        
    End Sub

    Protected Sub gvMT_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            index += 1
        Else
            index = 0
        End If
    End Sub

    Protected Sub gvMT_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Try
                Dim hLink As HyperLink = e.Row.FindControl("hRemove")
                hLink.NavigateUrl = "remove.aspx?rolID=MT&team=" & Session("sTeamName") & "&empId=" & Me.gvMt.DataKeys(e.Row.RowIndex).Item("empId").ToString
                hLink.Attributes.Add("onClick", "return MT_Remove();")
            Catch ex As Exception

            End Try

        End If
    End Sub

    Protected Sub btnChange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChange.Click
        Dim MtList As String = Nothing
        Dim chkMT As CheckBox = Nothing
        For Each gvQCrow As GridViewRow In Me.gvQc.Rows
            Me.gvMt = gvQCrow.FindControl("gvMT")
            For Each gvMTRow As GridViewRow In Me.gvMt.Rows
                chkMT = CType(gvMTRow.FindControl("chkMT"), CheckBox)
                If chkMT.Checked Then
                    If MtList = Nothing Then
                        MtList = "'" & Me.gvMt.DataKeys(gvMTRow.RowIndex).Item("empId") & "'"
                    Else
                        MtList &= ",'" & Me.gvMt.DataKeys(gvMTRow.RowIndex).Item("empId") & "'"
                    End If
                End If
            Next
        Next
        If Not MtList = Nothing Then
            Dim objDb As New MTBMS.DAL.DBTaskBO()
            Dim sql As String = "UPDATE boTeamPlayers set teamParent = '" & Me.ddlChangeQC.SelectedValue & "' WHERE empID In(" & MtList & ") AND team='" & Session("sTeamName") & "'"
            Try
                objDb.update(sql)
                Call Me.loadGrid()
            Catch ex As Exception
            End Try
        End If
    End Sub

   
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim chkEnable As Boolean = CType(Me.chkEnable.Checked, Boolean)

        Dim sql As New StringBuilder

        sql.Append("UPDATE boTeam SET teamEnable=" & chkEnable & ",teamDateTimeModified='" & Now.ToString & "' WHERE team='" & Session("sTeamName") & "'")
        sql.Append("; UPDATE boTeamPlayers SET empID='" & Me.cmbPR.SelectedValue.ToString & "' WHERE team='" & Session("sTeamName") & "' AND rolID='PR'")
        sql.Append("; UPDATE boTeamPlayers SET empID='" & Me.cmbFR.SelectedValue.ToString & "' WHERE team='" & Session("sTeamName") & "' AND rolID='FR'")
        sql = sql.Replace("True", 1)
        sql = sql.Replace("False", 0)
        Dim objDb As New MTBMS.DAL.DBTaskBO()
        objDb.update(sql.ToString)

    End Sub
End Class

Public Class loade

    Private Text_QC = "SELECT bE.empID, bE.empFirstName + ' ' + bE.empLastName as empName FROM boTeamPlayers  bP INNER JOIN boEmployee bE ON bP.empID = bE.empID WHERE rolID='QC' AND "
    Private Text_MT = "SELECT bE.empID, bE.empFirstName + ' ' + bE.empLastName as empName, teamParent FROM boTeamPlayers  bP INNER JOIN boEmployee bE ON bP.empID = bE.empID WHERE rolID='MT' AND "
    Dim Team_QC As String = "SELECT bE.empID as empID, empFirstName + ' ' + empLastName as empName,teamParent from boEmployee bE INNER JOIN boTeamPlayers bT ON bT.empID = bE.empID where rolID='QC'"
    Public ReadOnly Property Query(ByVal Team As String) As String
        Get
            Return Text_QC + "team='" & Team & "'" + " ; " + Text_MT + "team='" & Team & "'"
        End Get
    End Property
    Public ReadOnly Property Query_QC(ByVal team As String) As String
        Get
            Return Me.Team_QC + " AND team='" + team + "'"
        End Get
    End Property

    Public Function Insert_MT(ByVal Qc As String, ByVal MT As String, ByVal Team As String) As Boolean
        Try
            Dim Query As String = "INSERT INTO boTeamPlayers(Team,empID,rolID,teamLevel,teamParent) Values('" + Team + "','" + MT + "','MT',3,'" + Qc + "')"
            Dim objDb As New MTBMS.DAL.DBTaskBO()
            objDb.saveData(Query)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Insert_QC(ByVal FR As String, ByVal Qc As String, ByVal Team As String) As Boolean
        Try
            Dim Query As String = "INSERT INTO boTeamPlayers(Team,empID,rolID,teamLevel,teamParent) Values('" + Team + "','" + Qc + "','QC',2,'" + FR + "')"
            Dim objDb As New MTBMS.DAL.DBTaskBO()
            objDb.saveData(Query)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class

