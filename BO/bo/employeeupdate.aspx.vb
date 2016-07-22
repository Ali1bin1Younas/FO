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
        Dim str As String = ""
        If Me.txtempID.Text <> "" And Me.txtempFirstName.Text <> "" And Me.txtempLastName.Text <> "" And Me.txtempNIC.Text <> "" And Me.txtempAddress.Text <> "" And Me.txtempCity.Text <> "" And Me.cmbempCountry.Text <> "" And Me.txtempState.Text <> "" And Me.txtempZip.Text <> "" And Me.txtempPhoneNo.Text <> "" And Me.txtempCellNo.Text <> "" And Me.txtempEMail.Text <> "" And Me.txtempNIC.Text <> "" Then

            str = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
                    + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                    + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                    + "<td align=center width=80><img src='../images/error.ico'></td><td align=left width=370><font style='font-size:8pt;'>Please fill all mandatory fields (*).</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr>" _
                    + "<tr><td height=15></td></tr></table>"


            Call SaveRecords()
            Response.Redirect("employeemain.aspx")

        Else
            lblMessage.Text = str
        End If


        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub SaveRecords()

        Dim con As New DBTaskBO
        Dim Query As String = "UPDATE boEmployee SET empLoginID='" & Me.txtempLoginID.Text & "',depID='" & Me.cmbDepartment.SelectedValue & "',comID='" & Me.cmbcom.SelectedValue & "',empFirstName='" & Me.txtempFirstName.Text.ToString & "',empLastName='" & Me.txtempLastName.Text.ToString & "',empGender='" & Me.cmbempGender.Text & "',empPhone='" & Me.txtempPhoneNo.Text.ToString & "',empCell='" & Me.txtempCellNo.Text.ToString & "',empEmail='" & Me.txtempEMail.Text & "',empAddress1='" & Me.txtempAddress.Text.ToString & "',empAddress2='" & Me.txtempAddress2.Text.ToString & "',empPrefix='" & Me.cmbempPrefix.Text.ToString & "',empJoiningDate='" & Format(Me.CPempJoiningDate.SelectedDate, "MM/dd/yyyy") & "',empCity='" & Me.txtempCity.Text.ToString & "',empState='" & Me.txtempState.Text.ToString & "',empCountry='" & Me.cmbempCountry.Text.ToString & "',empZip='" & Me.txtempZip.Text.ToString & "',empNIC='" & Me.txtempNIC.Text.ToString & "',empDOB='" & Format(Me.CPDOB.SelectedDate, "MM/dd/yyyy") & "',empDesignation='" & Me.txtempDesignation.Text.ToString & "',etpID='" & Me.cmbempType.Text.ToString & "' WHERE empID='" & Session("ssempID") & "'"
        con.saveData(Query)
        'Try
        'Dim hash As New Hashtable
        'Dim col As ColumnName = Nothing
        'col = New ColumnName("empLoginID", Me.txtempLoginID.Text, "str")
        'hash.Add("1", col)
        'col = New ColumnName("empFirstName", Me.txtempFirstName.Text.ToString, "str")
        'hash.Add("2", col)
        'col = New ColumnName("empLastName", Me.txtempLastName.Text.ToString, "str")
        'hash.Add("3", col)
        'col = New ColumnName("empGender", Me.cmbempGender.Text, "str")
        'hash.Add("4", col)
        'col = New ColumnName("empPhone", Me.txtempPhoneNo.Text.ToString, "str")
        'hash.Add("5", col)
        'col = New ColumnName("empCell", Me.txtempCellNo.Text.ToString, "str")
        'hash.Add("6", col)
        'col = New ColumnName("empEmail", Me.txtempEMail.Text.ToString, "str")
        'hash.Add("7", col)
        'col = New ColumnName("empAddress1", Me.txtempAddress.Text.ToString, "str")
        'hash.Add("8", col)
        'col = New ColumnName("empJoiningDate", Format(Me.CPempJoiningDate.SelectedDate, "MM/dd/yyyy"), "dat")
        'hash.Add("9", col)

        'col = New ColumnName("empPrefix", Me.cmbempPrefix.Text.ToString, "str")
        'hash.Add("11", col)
        'col = New ColumnName("empAddress2", Me.txtempAddress2.Text.ToString, "str")
        'hash.Add("12", col)
        'col = New ColumnName("empCity", Me.txtempCity.Text.ToString, "str")
        'hash.Add("13", col)
        'col = New ColumnName("empState", Me.txtempState.Text.ToString, "str")
        'hash.Add("14", col)
        'col = New ColumnName("empCountry", Me.cmbempCountry.Text.ToString, "str")
        'hash.Add("15", col)
        'col = New ColumnName("empZip", Me.txtempZip.Text.ToString, "str")
        'hash.Add("16", col)

        'col = New ColumnName("empDateTime", Format(Me.CPDateTime.SelectedDate, "MM/dd/yyyy"), "dat")
        'hash.Add("17", col)

        'If txtempPassword.Text <> "" Then
        '    col = New ColumnName("empPassword", Me.txtempPassword.Text.ToString, "str")
        '    hash.Add("18", col)
        'End If

        'col = New ColumnName("empDOB", Format(Me.CPDOB.SelectedDate, "MM/dd/yyyy"), "dat")
        'hash.Add("19", col)

        'col = New ColumnName("empNIC", Me.txtempNIC.Text.ToString, "str")
        'hash.Add("20", col)

        'Dim col1 As ColumnName
        'col1 = New ColumnName("empID", Session("ssempID".ToString), "str")
        'hash.Add("wheres", col1)
        'Dim ad As New DBTaskBO
        'ad.updateDataValues(hash, "boEmployee")
        'setEmployee()

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
        Response.Redirect("employeemain.aspx")
    End Sub

    Private Sub setEmployee()
        Dim Con As New DBTaskBO

        Dim Query As String = "Select * From boEmployee where empID='" + Session("ssempID") + "'"
        Dim ds As DataSet
        ds = Con.getDataSet(Query)

        If ds.Tables(0).Rows.Count > 0 Then
            Me.txtempID.Text = ds.Tables(0).Rows(0)("empID")
            Me.txtempLoginID.Text = ds.Tables(0).Rows(0)("empLoginID")
            Me.txtempPassword.Text = ds.Tables(0).Rows(0)("empPassword")

            Me.CPempJoiningDate.SelectedDate = ds.Tables(0).Rows(0)("empJoiningDate")
            If Not IsDBNull(ds.Tables(0).Rows(0)("empDesignation")) Then Me.txtempDesignation.Text = ds.Tables(0).Rows(0)("empDesignation")
            Me.cmbDepartment.Text = ds.Tables(0).Rows(0)("depID")
            Me.cmbcom.Text = ds.Tables(0).Rows(0)("comID")
            Me.cmbempType.Text = ds.Tables(0).Rows(0)("etpID")

            If Not IsDBNull(ds.Tables(0).Rows(0)("empPhone")) Then Me.txtempPhoneNo.Text = ds.Tables(0).Rows(0)("empPhone")
            If Not IsDBNull(ds.Tables(0).Rows(0)("empCell")) Then Me.txtempCellNo.Text = ds.Tables(0).Rows(0)("empCell")
            If Not IsDBNull(ds.Tables(0).Rows(0)("empEmail")) Then Me.txtempEMail.Text = ds.Tables(0).Rows(0)("empEmail")
            If Not IsDBNull(ds.Tables(0).Rows(0)("empAddress1")) Then Me.txtempAddress.Text = ds.Tables(0).Rows(0)("empAddress1")
            If Not IsDBNull(ds.Tables(0).Rows(0)("empAddress2")) Then Me.txtempAddress2.Text = ds.Tables(0).Rows(0)("empAddress2")
            If Not IsDBNull(ds.Tables(0).Rows(0)("empCity")) Then Me.txtempCity.Text = ds.Tables(0).Rows(0)("empCity")
            If Not IsDBNull(ds.Tables(0).Rows(0)("empState")) Then Me.txtempState.Text = ds.Tables(0).Rows(0)("empState")
            If Not IsDBNull(ds.Tables(0).Rows(0)("empZip")) Then Me.txtempZip.Text = ds.Tables(0).Rows(0)("empZip")
            If Not IsDBNull(ds.Tables(0).Rows(0)("empCountry")) Then Me.cmbempCountry.Text = ds.Tables(0).Rows(0)("empCountry")

            Me.cmbempPrefix.Text = ds.Tables(0).Rows(0)("empPrefix")
            Me.txtempFirstName.Text = ds.Tables(0).Rows(0)("empFirstName")
            Me.txtempLastName.Text = ds.Tables(0).Rows(0)("empLastName")
            Me.cmbempGender.DataValueField = ds.Tables(0).Rows(0)("empGender")
            Me.CPDOB.SelectedDate = ds.Tables(0).Rows(0)("empDOB")
            If Not IsDBNull(ds.Tables(0).Rows(0)("empNIC")) Then Me.txtempNIC.Text = ds.Tables(0).Rows(0)("empNIC")

        End If
        ds.Dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        Try
            Session("ssempID") = Request.QueryString("empID").ToString
            If Not Page.IsPostBack Then
                Session("ssempID") = Request.QueryString("empID").ToString

                loadCompany() 'loads company dropdown
                loadDepartment() 'loads Department dropdown
                loadEmployeeType() 'loads EmployeeType dropdown

                setEmployee()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadDepartment()

        Dim Con As New DBTaskBO
        Dim Qry As String = "Select * From boDepartment WHERE depEnable=1 ORDER BY depName"
        Dim ds As DataSet
        ds = Con.getDataSet(Qry)
        Dim dt As DataTable = ds.Tables(0)

        Me.cmbDepartment.DataTextField = "depName"
        Me.cmbDepartment.DataValueField = "depID"
        Me.cmbDepartment.DataSource = dt
        Me.cmbDepartment.DataBind()

        Me.cmbDepartment.Items.Insert(0, "--Set Department--")
    End Sub

    Private Sub loadCompany()

        Dim Con As New DBTaskBO
        Dim Qry As String = "Select * From boCompany WHERE comEnable=1 ORDER BY comName"
        Dim ds As DataSet
        ds = Con.getDataSet(Qry)
        Dim dt As DataTable = ds.Tables(0)

        Me.cmbcom.DataTextField = "comName"
        Me.cmbcom.DataValueField = "comID"
        Me.cmbcom.DataSource = dt
        Me.cmbcom.DataBind()

        Me.cmbcom.Items.Insert(0, "--Set Company--")
    End Sub

    Private Sub loadEmployeeType()

        Dim Con As New DBTaskBO
        Dim Qry As String = "Select * From boEmployeeTypes WHERE etpEnable=1 ORDER BY etpName"
        Dim ds As DataSet
        ds = Con.getDataSet(Qry)
        Dim dt As DataTable = ds.Tables(0)

        Me.cmbempType.DataTextField = "etpName"
        Me.cmbempType.DataValueField = "etpID"
        Me.cmbempType.DataSource = dt
        Me.cmbempType.DataBind()

        Me.cmbempType.Items.Insert(0, "--Set Type--")
    End Sub
End Class

