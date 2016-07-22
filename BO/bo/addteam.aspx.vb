Imports MTBMS.DAL
Imports System.Data
Imports System.Data.SqlClient
Partial Class BO_addteam
    Inherits System.Web.UI.Page
    Private dsMt As Data.DataSet
    Private gvMt As GridView
    Protected index As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Call Me.loadPR()
            Call Me.loadFR()
            Call Me.loadQC()
            Call Me.loadMT()
        End If
    End Sub
    Private Sub loadPR()
        Try
            Dim Con As New DBTaskBO
            Dim sqlText As New StringBuilder
            sqlText.Append("SELECT bE.empID, bE.empFirstName + ', ' + empLastName as empName from boEmployeeRoles bER ")
            sqlText.Append("INNER JOIN boEmployee bE on bER.empID = bE.empID ")
            sqlText.Append("WHERE bER.RolID='PR' and bER.empId <> '0' and bER.empEnable=1 AND bE.empEnable=1 ")
            sqlText.Append("AND bER.empID NOt IN(SELECT empID From boTeamPLayers where rolID='PR')")
            Dim ds As DataSet
            ds = Con.getDataSet(sqlText.ToString())
            Me.ddlPr.DataSource = ds.Tables(0)
            Me.ddlPr.DataTextField = "empName"
            Me.ddlPr.DataValueField = "empID"
            Me.ddlPr.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub loadFR()
        Try
            Dim Con As New DBTaskBO
            Dim Qry As String = "select  distinct(a.empID), c.empFirstName + ' ' + c.empLastName as empName from boEmployeeRoles a INNER JOIN boEmployee c on a.empid=c.empID  Where  a.empID <> '0' AND a.RolID='FR' AND a.empEnable=1 AND c.empEnable=1"
            Dim ds As DataSet
            Dim strFR As String = Nothing
            ds = Con.getDataSet(Qry)
            Me.ddlFr.DataSource = ds.Tables(0)
            Me.ddlFr.DataTextField = "empName"
            Me.ddlFr.DataValueField = "empID"
            Me.ddlFr.DataBind()
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub loadQC()
        Try
            Dim Qry As String
            Dim Con As New DBTaskBO
            Qry = "select  distinct(a.empID), c.empFirstName + ' ' + c.empLastName as empName from boEmployeeRoles a INNER JOIN boEmployee c on a.empid=c.empID  where  not a.rolID in(select rolID from boTeamPlayers b where b.empid=a.empid and a.rolID=b.rolID) and a.rolID='QC' and a.empID not in('0') AND (a.empEnable=1 AND c.empEnable=1)"
            Dim ds As DataSet
            Dim strQC As String = Nothing
            ds = Con.getDataSet(Qry)
            Me.ddlQC.DataSource = ds.Tables(0)
            Me.ddlQC.DataTextField = "empName"
            Me.ddlQC.DataValueField = "empID"
            Me.ddlQC.DataBind()
        Catch ex As Exception

        End Try
        
    End Sub


    Private Sub loadTeamQC()
        Dim objload As New loade_New()
        Dim objDb As New MTBMS.DAL.DBTaskBO()
        Dim ds As DataSet = objDb.getDataSet(objload.Query_QC(Me.txtTeam.Text))
        Me.ddlTeamQc.DataSource = ds.Tables(0)
        Me.ddlTeamQc.DataTextField = "empName"
        Me.ddlTeamQc.DataValueField = "empID"
        Me.ddlTeamQc.DataBind()
    End Sub

    Private Sub loadMT()
        Dim Con As New DBTaskBO
        Dim Qry As String
        Qry = "select  distinct(a.empID),c.empFirstName +', '+ c.empLastName as empName from boEmployeeRoles a INNER JOIN boEmployee c on a.empid=c.empID  where  not a.rolID in(select rolID from boTeamPlayers b where b.empid=a.empid and a.rolID=b.rolID) and a.rolID='MT' and a.empID not in('0')"
        Dim ds As DataSet
        Dim strMT As String = Nothing
        ds = Con.getDataSet(Qry)
        Me.ddlMT.DataSource = ds.Tables(0)
        Me.ddlMT.DataTextField = "empName"
        Me.ddlMT.DataValueField = "empID"
        Me.ddlMT.DataBind()
    End Sub


    Private Function AddNewTeam() As Boolean
        Dim cmd As SqlCommand
        Dim con As SqlConnection
        Dim tra As SqlTransaction
        Dim teamParent As String = " "
        Try
            Dim objDb As New DBTaskBO
            con = New SqlConnection(objDb.ConnectionString())
            con.Open()
            tra = con.BeginTransaction
            Dim cmdText As String = "INSERT INTO boTeam(Team,teamDateTime,teamEnable) VALUES ('" & Me.txtTeam.Text & "','" & Now.ToString() & "',1)"
            cmd = New SqlCommand(cmdText, con, tra)
            cmd.ExecuteNonQuery()
            cmdText = "INSERT INTO boTeamPlayers(team,empID,rolID,teamLevel) VALUES('" & Me.txtTeam.Text & "','" & Me.ddlPr.SelectedValue & "','PR',1)"
            cmd = New SqlCommand(cmdText, con, tra)
            cmd.ExecuteNonQuery()
            cmdText = "INSERT INTO boTeamPlayers(team,empID,rolID,teamLevel,teamParent) VALUES('" & Me.txtTeam.Text & "','" & Me.ddlFr.SelectedValue & "','FR',4,'" & Me.ddlPr.SelectedValue & "')"
            cmd = New SqlCommand(cmdText, con, tra)
            cmd.ExecuteNonQuery()
            tra.Commit()
            Return True
        Catch ex As Exception
            tra.Rollback()
            Return False
        Finally
            con.Close()
        End Try
    End Function

    Protected Sub btnAddTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddTeam.Click
        Dim objTeam As New loade_New()
        

        If Me.ddlPr.Enabled Then
            Me.txtTeam.ReadOnly = True
            Me.ddlPr.Enabled = False
            Me.ddlFr.Enabled = False
            If Me.AddNewTeam() Then
                Session("PR") = Me.ddlPr.SelectedValue
                Session("FR") = Me.ddlFr.SelectedValue
                Session("sTeamName") = Me.txtTeam.Text
                objTeam.Insert_QC(Me.ddlFr.SelectedValue, Me.ddlQC.SelectedValue, Me.txtTeam.Text)
            Else
                Me.ddlPr.Enabled = True
                Me.ddlFr.Enabled = True
                Me.txtTeam.ReadOnly = False
                Exit Sub
            End If
        Else
            objTeam.Insert_QC(Me.ddlFr.SelectedValue, Me.ddlQC.SelectedValue, Me.txtTeam.Text)
        End If
        Call Me.loadGrid()
        loadQC()
        Me.loadTeamQC()
    End Sub


    Private Sub loadGrid()
        Me.gvQc.DataSource = Nothing
        Dim objload As New loade_New()
        Dim load_QC As String = objload.Query(Me.txtTeam.Text)
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
                hLink.NavigateUrl = "remove.aspx?rolID=QC&team=" & Me.txtTeam.Text & "&empId=" & Me.gvQc.DataKeys(e.Row.RowIndex).Item("empId").ToString
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
                hLink.NavigateUrl = "remove.aspx?page=addTeam&rolID=MT&team=" & Me.txtTeam.Text & "&empId=" & Me.gvMt.DataKeys(e.Row.RowIndex).Item("empId").ToString
                hLink.Attributes.Add("onClick", "return MT_Remove();")
            Catch ex As Exception

            End Try

        End If
    End Sub



    Protected Sub btnAddMT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddMT.Click
        Dim QC As String = CStr(Me.ddlTeamQc.SelectedValue)
        Dim Mt As String = CStr(Me.ddlMT.SelectedValue)
        Dim objLoad As New loade_New()
        objLoad.Insert_MT(QC, Mt, Me.txtTeam.Text)
        Me.loadGrid()
        loadMT()
    End Sub
End Class


Public Class loade_New

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
