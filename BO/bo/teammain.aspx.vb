Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class BO_teammain
    Inherits System.Web.UI.Page
    Dim strSelectLable As String = Nothing
    Function GetTreeViewData() As DataSet
        'Dim con As SqlConnection = New SqlConnection("server=data;database=MTBMS-BO;user=sa")
        'Dim dadCats As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM boTeamPlayers", con)
        'Dim dst As DataSet = New DataSet
        'dadCats.Fill(dst, "Players")


        Dim ds As DataSet
        Dim Con As New DBTaskBO
        Dim Qry As String
        Qry = "SELECT * FROM boTeamPlayers"
        ds = Con.getDataSet(Qry)


        Con.objConnection.Close()
        Con = Nothing
        Return ds
    End Function
    Sub PopulateNodes(ByVal idteam As String)
        Me.tvTeam.Nodes.Clear()
        Dim dst As DataSet = GetTreeViewData()
        Dim TeamNode As TreeNode = Nothing
        Dim PRNode As TreeNode = Nothing
        Dim FRNode As TreeNode = Nothing
        Dim QCNode As TreeNode = Nothing
        Dim MTNode As TreeNode = Nothing
        Dim strEmployeeID As String = Nothing
        Dim strTeamLevel As String = Nothing
        Dim strTeamParent As String = Nothing
        Dim strTeamName As String = Nothing
        For Each masterRow As DataRow In dst.Tables(0).Rows
            strEmployeeID = CType(masterRow("empID"), String)
            strTeamLevel = CType(masterRow("teamLevel"), String)
            If IsDBNull(masterRow("teamParent")) Then
                strTeamParent = ""
            Else
                strTeamParent = CType(masterRow("teamParent"), String)
            End If
            strTeamName = CType(masterRow("team"), String)
            If masterRow("teamLevel") = 1 And strTeamName = idteam Then
                TeamNode = New TreeNode(CType(masterRow("team"), String))
                'TeamNode.SelectAction = TreeNodeSelectAction.Expand
                Session("sTNam") = CType(masterRow("team"), String)
                strSelectLable = CType(masterRow("team"), String)
                tvTeam.Nodes.Add(TeamNode)
                Dim strN As String = CType(masterRow("empID"), String)
                Dim Conn As New DBTaskBO
                'Dim drn As SqlDataReader
                'drn = Conn.getDataReader("SELECT * FROM boTeamPlayers where teamParent='" & strN & "' and teamLevel=4 and team ='" & strTeamName & "' order by team")
                'If drn.Read Then
                '    Dim strNFR As String = getPRName(drn("empID")) + " " + "(FR)"
                '    FRNode = New TreeNode(strNFR)
                '    FRNode.SelectAction = TreeNodeSelectAction.None
                '    TeamNode.ChildNodes.Add(FRNode)
                'End If
                Dim dsn As DataSet
                dsn = Conn.getDataSet("SELECT * FROM boTeamPlayers where teamParent='" & strN & "' and teamLevel=4 and team ='" & strTeamName & "' order by team")
                If dsn.Tables(0).Rows.Count > 0 Then
                    Dim strNFR As String = getPRName(dsn.Tables(0).Rows(0).Item("empID")) + " " + "(FR)"
                    FRNode = New TreeNode(strNFR)
                    FRNode.SelectAction = TreeNodeSelectAction.None
                    TeamNode.ChildNodes.Add(FRNode)
                End If

                Dim strPRNode As String = getPRName(CType(masterRow("empID"), String)) + " " + "(PR)"
                PRNode = New TreeNode(strPRNode)
                PRNode.SelectAction = TreeNodeSelectAction.None
                TeamNode.ChildNodes.Add(PRNode)
                Dim Con As New DBTaskBO
                'Dim dr As SqlDataReader
                'dr = Con.getDataReader("SELECT * FROM boTeamPlayers where teamParent='" & strEmployeeID & "' and teamLevel=2 and team ='" & strTeamName & "' order by team")
                'While dr.Read
                '    Dim strInnerEmployeeID As String = (dr("empID"))
                '    Dim strQC As String = getPRName(dr("empID")) + " " + "(QC)"
                '    QCNode = New TreeNode(strQC)
                '    QCNode.SelectAction = TreeNodeSelectAction.None
                '    PRNode.ChildNodes.Add(QCNode)
                '    Dim ConMT As New DBTaskBO
                '    Dim drMT As SqlDataReader
                '    drMT = ConMT.getDataReader("SELECT * FROM boTeamPlayers where teamParent='" & strInnerEmployeeID & "' and teamLevel=3 and team='" & strTeamName & "' order by team")
                '    While drMT.Read
                '        Dim strMTRoll As String = getPRName(drMT("empID")) + " " + "(MT)"
                '        MTNode = New TreeNode(strMTRoll)
                '        MTNode.SelectAction = TreeNodeSelectAction.None
                '        QCNode.ChildNodes.Add(MTNode)
                '    End While
                'End While

                Dim ds As DataSet
                ds = Con.getDataSet("SELECT * FROM boTeamPlayers where teamParent='" & strEmployeeID & "' and teamLevel=2 and team ='" & strTeamName & "' order by team")
                For Each dr As DataRow In ds.Tables(0).Rows
                    Dim strInnerEmployeeID As String = (dr("empID"))
                    Dim strQC As String = getPRName(dr("empID")) + " " + "(QC)"
                    QCNode = New TreeNode(strQC)
                    QCNode.SelectAction = TreeNodeSelectAction.None
                    PRNode.ChildNodes.Add(QCNode)
                    Dim dsMT As DataSet
                    dsMT = Con.getDataSet("SELECT * FROM boTeamPlayers where teamParent='" & strInnerEmployeeID & "' and teamLevel=3 and team='" & strTeamName & "' order by team")
                    For Each drMT As DataRow In dsMT.Tables(0).Rows
                        Dim strMTRoll As String = getPRName(drMT("empID")) + " " + "(MT)"
                        MTNode = New TreeNode(strMTRoll)
                        MTNode.SelectAction = TreeNodeSelectAction.None
                        QCNode.ChildNodes.Add(MTNode)
                    Next
                Next


            ElseIf masterRow("teamLevel") = 1 And Me.cmbTeam.SelectedValue = "All Teams..." Then
                If masterRow("teamLevel") = 1 Then
                    TeamNode = New TreeNode(CType(masterRow("team"), String))
                    tvTeam.Nodes.Add(TeamNode)
                    Dim strN As String = CType(masterRow("empID"), String)
                    Dim Conn As New DBTaskBO
                    'Dim drn As SqlDataReader
                    'drn = Conn.getDataReader("SELECT * FROM boTeamPlayers where teamParent='" & strN & "' and teamLevel=4 and team ='" & strTeamName & "' order by team")
                    'If drn.Read Then
                    '    Dim strNFR As String = getPRName(drn("empID")) + " " + "(FR)"
                    '    FRNode = New TreeNode(strNFR)
                    '    FRNode.SelectAction = TreeNodeSelectAction.None
                    '    TeamNode.ChildNodes.Add(FRNode)
                    'End If
                    Dim dsn As DataSet
                    dsn = Conn.getDataSet("SELECT * FROM boTeamPlayers where teamParent='" & strN & "' and teamLevel=4 and team ='" & strTeamName & "' order by team")
                    If dsn.Tables(0).Rows.Count > 0 Then
                        Dim strNFR As String = getPRName(dsn.Tables(0).Rows(0).Item("empID")) + " " + "(FR)"
                        FRNode = New TreeNode(strNFR)
                        FRNode.SelectAction = TreeNodeSelectAction.None
                        TeamNode.ChildNodes.Add(FRNode)
                    End If


                    Dim strPRNode As String = getPRName(CType(masterRow("empID"), String)) + " " + "(PR)"
                    PRNode = New TreeNode(strPRNode)
                    PRNode.SelectAction = TreeNodeSelectAction.None
                    TeamNode.ChildNodes.Add(PRNode)
                    Dim Con As New DBTaskBO
                    'Dim dr As SqlDataReader
                    'dr = Con.getDataReader("SELECT * FROM boTeamPlayers where teamParent='" & strEmployeeID & "' and teamLevel=2 and team ='" & strTeamName & "' order by team")
                    'While dr.Read
                    '    Dim strInnerEmployeeID As String = (dr("empID"))
                    '    Dim strQC As String = getPRName(dr("empID")) + " " + "(QC)"
                    '    QCNode = New TreeNode(strQC)
                    '    QCNode.SelectAction = TreeNodeSelectAction.None
                    '    'QCNode = New TreeNode(dr("empID"))
                    '    PRNode.ChildNodes.Add(QCNode)
                    '    Dim ConMT As New DBTaskBO
                    '    Dim drMT As SqlDataReader
                    '    drMT = ConMT.getDataReader("SELECT * FROM boTeamPlayers where teamParent='" & strInnerEmployeeID & "' and teamLevel=3 and team='" & strTeamName & "' order by team")
                    '    While drMT.Read
                    '        Dim strMTRoll As String = getPRName(drMT("empID")) + " " + "(MT)"
                    '        MTNode = New TreeNode(strMTRoll)
                    '        MTNode.SelectAction = TreeNodeSelectAction.None
                    '        QCNode.ChildNodes.Add(MTNode)
                    '    End While
                    'End While


                    Dim ds As DataSet
                    ds = Con.getDataSet("SELECT * FROM boTeamPlayers where teamParent='" & strEmployeeID & "' and teamLevel=2 and team ='" & strTeamName & "' order by team")
                    For Each dr As DataRow In ds.Tables(0).Rows
                        Dim strInnerEmployeeID As String = (dr("empID"))
                        Dim strQC As String = getPRName(dr("empID")) + " " + "(QC)"
                        QCNode = New TreeNode(strQC)
                        QCNode.SelectAction = TreeNodeSelectAction.None
                        'QCNode = New TreeNode(dr("empID"))
                        PRNode.ChildNodes.Add(QCNode)
                        Dim dsMT As DataSet
                        dsMT = Con.getDataSet("SELECT * FROM boTeamPlayers where teamParent='" & strInnerEmployeeID & "' and teamLevel=3 and team='" & strTeamName & "' order by team")
                        For Each drMT As DataRow In dsMT.Tables(0).Rows
                            Dim strMTRoll As String = getPRName(drMT("empID")) + " " + "(MT)"
                            MTNode = New TreeNode(strMTRoll)
                            MTNode.SelectAction = TreeNodeSelectAction.None
                            QCNode.ChildNodes.Add(MTNode)
                        Next
                    Next
                End If
            End If
        Next
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        If Not IsPostBack Then
            LoadTeam()
            Me.cmbTeam.SelectedValue = "All Teams..."
            Dim strTeam1 As String = Nothing
        End If
        PopulateNodes(Me.cmbTeam.SelectedValue.ToString)
        If Session("sTNam") <> "" Then
            PopulateLabels(Session("sTNam").ToString)
            Session("sTNam") = ""
        End If
        CheckTeamExist()
    End Sub
    Private Sub CheckTeamExist()
        Dim Con As New DBTaskBO
        Dim Qry As String = "Select distinct team From boTeamPlayers"
        Dim ds As DataSet
        ds = Con.getDataSet(Qry)
        If ds.Tables(0).Rows.Count = 0 Then
            Me.LinkButton1.Enabled = False
            Me.lnkDeleteTeam.Enabled = False
        Else
            Me.LinkButton1.Enabled = True
            Me.lnkDeleteTeam.Enabled = True

        End If

        If Me.lblTeamNameMain.Text = "" Then
            Me.LinkButton1.Enabled = False
            Me.lnkDeleteTeam.Enabled = False
        Else
            Me.LinkButton1.Enabled = True
            Me.lnkDeleteTeam.Enabled = True
        End If

        'If ds.Tables(0).Rows.Count > 1 Then

        '    Me.LinkButton2.Enabled = True
        'Else
        '    Me.LinkButton2.Enabled = False
        'End If


    End Sub
    Private Sub LoadTeam()

        Dim ConTeam As New DBTaskBO
        Dim Qry As String = "SELECT * From boTeam"
        Dim dsTeam As DataSet
        Dim strTeam As String = Nothing
        dsTeam = ConTeam.getDataSet(Qry)
        cmbTeam.DataSource = dsTeam.Tables(0)
        cmbTeam.DataTextField = "team"
        cmbTeam.DataValueField = "team"
        cmbTeam.DataBind()
        cmbTeam.Items.Add("All Teams...")

    End Sub
    Protected Sub tvTeam_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTeam.SelectedNodeChanged
        Dim strTeam As String = Me.tvTeam.SelectedValue.ToString
        PopulateLabels(strTeam)
        CheckTeamExist()
    End Sub
    Private Sub PopulateLabels(ByVal sTeam As String)
        Try
            Me.lblTeamNameMain.Text = sTeam

            Dim ConPR As New DBTaskBO
            Dim dsPR As DataSet
            dsPR = ConPR.getDataSet("Select empID from boTeamPlayers where team='" & sTeam & "' and rolID='PR' ")
            Session("PR") = dsPR.Tables(0).Rows(0)("empID").ToString
            Session("FR") = CType(ConPR.getScalar("Select empID from boTeamPlayers where team='" & sTeam & "' and rolID='FR' "), String)
            Dim strPRFullName As String = getPRName(dsPR.Tables(0).Rows(0)("empID").ToString)
            Dim ConTC As New DBTaskBO
            Dim dsTC As DataSet
            dsTC = ConPR.getDataSet("Select team from boTeamPlayers where team='" & sTeam & "' and rolID='PR' ")
            Dim strTeam As String = getTeamCreated(dsTC.Tables(0).Rows(0)("team").ToString)
            Me.lblCreated.Text = strTeam
            Me.lblTL.Text = strPRFullName.ToString
            Me.lblQC.Text = ""
            Me.lblMT.Text = ""
            Dim Con As New DBTaskBO
            Dim ds As DataSet
            ds = Con.getDataSet("Select a.team,(Select Count(b.team) from boTeamPlayers b where b.team=a.team and b.rolID='QC' and team='" & sTeam & "') as TotalQC,(Select Count(b.team) from boTeamPlayers b where  b.team=a.team and b.rolID='MT'and team='" & sTeam & "') as TotalMT From boTeamPlayers a  Where team='" & sTeam & "' Group by a.team")
            Me.lblQC.Text = ds.Tables(0).Rows(0)("TotalQC")
            Me.lblMT.Text = ds.Tables(0).Rows(0)("TotalMT")
            Dim ConDate As New DBTaskBO
            Dim dsDate As DataSet
            dsDate = Con.getDataSet("Select * From boTeam Where team='" & sTeam & "'")
            Dim strTeamCreated As String = dsDate.Tables(0).Rows(0)("teamDateTime").ToString
            Me.lblCreated.Text = strTeamCreated
            Dim strTeamModified As String = dsDate.Tables(0).Rows(0)("teamDateTimeModified").ToString
            Me.lblModified.Text = strTeamModified

        Catch ex As Exception
        End Try
    End Sub
    Private Function getTeamCreated(ByVal teamid As String) As String
        Dim ConName As New DBTaskBO
        Dim dsName As DataSet
        dsName = ConName.getDataSet("Select teamDateTime from boTeam where team='" & teamid & "'")
        Dim strDateCreated As DateTime = dsName.Tables(0).Rows(0)("teamDateTime")
        Return strDateCreated.ToLongDateString
    End Function


    Private Function getPRName(ByVal idEmp As String) As String
        Dim ConName As New DBTaskBO
        Dim dsName As DataSet
        dsName = ConName.getDataSet("Select empFirstName +' '+ empLastName as fName from boEmployee where empID='" & idEmp & "'")
        Dim strFullName As String = dsName.Tables(0).Rows(0)("fName")
        Return strFullName
    End Function

    
    Protected Sub btnCreateNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateNew.Click
        Response.Redirect("addteam.aspx")
    End Sub

    Protected Sub lnkDeleteTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDeleteTeam.Click
        DeleteTeamPlayers()
        DeleteTeam()
        Response.Redirect("teammain.aspx")

    End Sub

    Private Sub DeleteTeamPlayers()
        Dim Con As New DBTaskBO
        Dim Qry As String = "Delete from boTeamPlayers where team='" + Me.lblTeamNameMain.Text.Trim + "'"
        Con.deleteDataValues(Qry)
    End Sub

    Private Sub DeleteTeam()
        Dim Con As New DBTaskBO
        Dim Qry As String = "Delete from boTeam where team='" + Me.lblTeamNameMain.Text.Trim + "'"
        Con.deleteDataValues(Qry)
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session("sTeamName") = Me.lblTeamNameMain.Text.Trim
        Response.Redirect("teamedit.aspx")
    End Sub
End Class
