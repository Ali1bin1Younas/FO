Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL

Partial Class teamupdate
    Inherits System.Web.UI.Page
    Dim intCheckValue As Integer
    Dim strHospitalName As String
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Call SaveRecords()


    End Sub
    Private Sub SaveRecords()

        'Try
        Dim hash As New Hashtable
        Dim col As ColumnName = Nothing
        col = New ColumnName("teamName", Me.txtTeamName.Text.ToString, "str")
        hash.Add("1", col)


        col = New ColumnName("teamDateTime", Me.CPTeamCreated.SelectedDate, "dat")
        hash.Add("2", col)



        Dim col1 As ColumnName
        col1 = New ColumnName("teamID", Session("ssteamID").ToString, "int")
        hash.Add("wheres", col1)
        Dim ad As New DBTaskBO
        ad.updateDataValues(hash, "boTeam")
        setTeam()

        'Catch ex As Exception

        'End Try

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("teammain.aspx")
    End Sub
    Private Sub setTeam()
        'Try
        Dim Con As New DBTaskBO
        Dim Query As String = "Select * From boTeam where teamID='" + Session("ssteamID") + "'"
        'Dim dr As SqlDataReader
        'dr = Con.getDataReader(Query)
        'If dr.Read Then
        '    Me.txtTeamName.Text = dr("teamName").ToString

        '    Me.CPTeamCreated.SelectedDate = CType(dr("teamDateTime").ToString, Date)

        'End If
        Dim ds As DataSet
        ds = Con.getDataSet(Query)
        If ds.tables(0).rows.count > 0 Then
            Me.txtTeamName.Text = ds.tables(0).rows(0).item("teamName").ToString
            Me.CPTeamCreated.SelectedDate = CType(ds.tables(0).rows(0).item("teamDateTime").ToString, Date)

        End If
        'Catch ex As Exception

        'End Try
        ds.dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        Try

            Session("ssteamID") = Request.QueryString("steamID").ToString
            If Not Page.IsPostBack Then
                setTeam()
            End If
        Catch ex As Exception

        End Try


    End Sub
End Class

