Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL

Partial Class employeeupdate
    Inherits System.Web.UI.Page
    Dim intCheckValue As Integer
    Dim strHospitalName As String

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Try
        Dim str As String
        str = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
                + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                + "<td align=center width=80><img src='../images/error.ico'></td><td align=left width=370><font style='font-size:8pt;'>Please fill all mandatory (*) fields.</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr>" _
                + "<tr><td height=15></td></tr></table>"

        If Me.txtempID.Text <> "" And Me.txtempFirstName.Text <> "" And Me.txtempLastName.Text <> "" And Me.txtempNIC.Text <> "" And Me.txtempAddress.Text <> "" And Me.txtempCity.Text <> "" And Me.txtempState.Text <> "" And Me.txtempZip.Text <> "" And Me.cmbempCountry.Text <> "" And Me.txtempPhoneNo.Text <> "" And Me.txtempCellNo.Text <> "" And Me.txtempEMail.Text <> "" Then
            Call SaveRecords()
            Response.Redirect("employeeworkload.aspx")
        Else
            Me.lblMessage.Text = str
        End If
    End Sub

    Private Sub SaveRecords()
        'Try
        Dim hash As New Hashtable
        Dim col As ColumnName = Nothing
        'col = New ColumnName("empID", Me.txtempID.Text.ToString, "str")
        'hash.Add("1", col)
        col = New ColumnName("empFirstName", Me.txtempFirstName.Text.ToString, "str")
        hash.Add("2", col)
        col = New ColumnName("empLastName", Me.txtempLastName.Text.ToString, "str")
        hash.Add("3", col)
        col = New ColumnName("empGender", Me.cmbempGender.Text.ToString, "str")
        hash.Add("4", col)
        col = New ColumnName("empPhone", Me.txtempPhoneNo.Text.ToString, "str")
        hash.Add("5", col)
        col = New ColumnName("empCell", Me.txtempCellNo.Text.ToString, "str")
        hash.Add("6", col)
        col = New ColumnName("empEmail", Me.txtempEMail.Text.ToString, "str")
        hash.Add("7", col)
        col = New ColumnName("empAddress1", Me.txtempAddress.Text.ToString, "str")
        hash.Add("8", col)
        'col = New ColumnName("empJoiningDate", Me.CPempJoiningDate.SelectedDate, "dat")
        'hash.Add("9", col)

        col = New ColumnName("empPrefix", Me.cmbempPrefix.Text.ToString, "str")
        hash.Add("11", col)
        col = New ColumnName("empAddress2", Me.txtempAddress2.Text.ToString, "str")
        hash.Add("12", col)
        col = New ColumnName("empCity", Me.txtempCity.Text.ToString, "str")
        hash.Add("13", col)
        col = New ColumnName("empState", Me.txtempState.Text.ToString, "str")
        hash.Add("14", col)
        col = New ColumnName("empCountry", Me.cmbempCountry.Text.ToString, "str")
        hash.Add("15", col)
        col = New ColumnName("empZip", Me.txtempZip.Text.ToString, "str")
        hash.Add("16", col)

        'col = New ColumnName("empDateTime", Me.CPDateTime.SelectedDate, "dat")
        'hash.Add("17", col)

        'If txtempPassword.Text <> "" Then
        '    col = New ColumnName("empPassword", Me.txtempPassword.Text.ToString, "str")
        '    hash.Add("18", col)
        'End If

        col = New ColumnName("empDOB", Me.CPDOB.SelectedDate, "dat")
        hash.Add("19", col)

        col = New ColumnName("empNIC", Me.txtempNIC.Text.ToString, "str")
        hash.Add("20", col)

        Dim col1 As ColumnName
        col1 = New ColumnName("empID", Session("empID".ToString), "str")
        hash.Add("wheres", col1)

        Dim ad As New DBTaskBO
        ad.updateDataValues(hash, "boEmployee")
        setEmployee()

        'Catch ex As Exception

        'End Try

    End Sub

    Private Function ReturnchkValue(ByVal ctr As Object) As Integer
        If ctr.Checked = True Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("employeeworkload.aspx")
    End Sub

    Private Sub setEmployee()
        'Try
        Dim Con As New DBTaskBO
        Dim Query As String = "Select * From boEmployee where empID='" + Session("empID") + "'"
        'Dim dr As SqlDataReader
        Dim ds As DataSet
        ds = Con.getDataSet(Query)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.txtempID.Text = ds.Tables(0).Rows(0).Item("empID").ToString
            Me.txtempFirstName.Text = ds.Tables(0).Rows(0).Item("empFirstName").ToString
            Me.txtempLastName.Text = ds.Tables(0).Rows(0).Item("empLastName").ToString
            Me.cmbempGender.Text = ds.Tables(0).Rows(0).Item("empGender").ToString
            Me.txtempPhoneNo.Text = ds.Tables(0).Rows(0).Item("empPhone").ToString
            Me.txtempCellNo.Text = ds.Tables(0).Rows(0).Item("empCell").ToString
            Me.txtempEMail.Text = ds.Tables(0).Rows(0).Item("empEmail").ToString
            Me.txtempAddress.Text = ds.Tables(0).Rows(0).Item("empAddress1").ToString
            Me.txtempAddress2.Text = ds.Tables(0).Rows(0).Item("empAddress2").ToString
            Me.txtempCity.Text = ds.Tables(0).Rows(0).Item("empCity").ToString
            Me.txtempState.Text = ds.Tables(0).Rows(0).Item("empState").ToString
            Me.txtempZip.Text = ds.Tables(0).Rows(0).Item("empZip").ToString
            Me.cmbempCountry.Text = ds.Tables(0).Rows(0).Item("empCountry").ToString
            Me.cmbempPrefix.Text = ds.Tables(0).Rows(0).Item("empPrefix").ToString
            Me.txtempNIC.Text = ds.Tables(0).Rows(0).Item("empNIC").ToString
            Me.CPDOB.SelectedDate = CType(ds.Tables(0).Rows(0).Item("empDOB").ToString, Date)
            'Me.CPempJoiningDate.SelectedDate = CType(dr("empJoiningDate").ToString, Date)
            'Me.CPDateTime.SelectedDate = CType(dr("empDateTime").ToString, Date)

        End If

        ds.Dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing
        'Catch ex As Exception

        'End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblCompleteName.Text = Session("CompletePrefix") + "  " + Session("CompleteFirstNAme") + "   " + Session("CompleteLastName")

        Try

            'Session("ssempID") = Request.QueryString("empID").ToString
            If Not Page.IsPostBack Then
                'Session("empID") = Request.QueryString("empID").ToString

                setEmployee()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class

