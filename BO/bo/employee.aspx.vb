Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL

Partial Class employee
    Inherits System.Web.UI.Page
    Dim intCheckValue As Integer
    Dim strHospitalName As String

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim str As String
        str = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
                + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                + "<td align=center width=80><img src='../images/error.ico'></td><td align=left width=370><font style='font-size:8pt;'>Please fill all mandatory fields (*).</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr>" _
                + "<tr><td height=10></td></tr></table>"

        Dim str2 As String
        str2 = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
                + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                + "<td align=center width=80><img src='../images/error.ico'></td><td align=left width=370><font style='font-size:8pt;'>Employee ID already exists.</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr>" _
                + "<tr><td height=10></td></tr></table>"

        Dim str3 As String
        str3 = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
                + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                + "<td align=center width=80><img src='../images/error.ico'></td><td align=left width=370><font style='font-size:8pt;'>Login ID already exists.</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr>" _
                + "<tr><td height=10></td></tr></table>"

        'Try

        If Me.htxtempID.Value <> "" And Me.txtempLoginID.Text <> "" And Me.txtempPassword.Text <> "" And Me.txtempRetypePassword.Text <> "" And Me.CPempJoiningDate.Text <> "" And Me.txtempDesignation.Text <> "" And Me.cmbDepartment.Text <> "" And Me.cmbcom.Text <> "" And Me.cmbempType.Text <> "" And Me.txtempFirstName.Text <> "" And Me.txtempLastName.Text <> "" And Me.txtempCity.Text <> "" And Me.cmbempCountry.Text <> "" And Me.txtempPhoneNo.Text <> "" And Me.txtempCellNo.Text <> "" And Me.txtempEMail.Text <> "" And Me.cmbempGender.Text <> "" And Me.cmbempPrefix.Text <> "" Then

            Dim con As New DBTaskBO
            Dim Query As String = "SELECT empID FROM boEmployee WHERE empID='" & htxtempID.Value & "'"
            Dim ds As DataSet = con.getDataSet(Query)

            Dim Query2 As String = "SELECT empLoginID FROM boEmployee WHERE empLoginID='" & txtempLoginID.Text & "'"
            Dim ds2 As DataSet = con.getDataSet(Query2)

            If ds.Tables(0).Rows.Count > 0 Then
                lblMessage.Text = str2
                lblMessage.Visible = True
            ElseIf ds2.Tables(0).Rows.Count > 0 Then
                lblMessage.Text = str3
                lblMessage.Visible = True
                txtempLoginID.Text = ""
            Else
                Call SaveRecords()
                If Session("rdSpecialty") = "specialty.aspx" Then
                    Session("PR") = Me.txtempFirstName.Text
                    Session("rdSpecialty") = ""
                    Response.Redirect("client.aspx")

                ElseIf Session("rdClientUpdate") = "ClientUpdate" Then
                    Session("rdClientUpdate") = ""
                    Session("PRU") = Me.txtempFirstName.Text
                    Response.Redirect("clientupdate.aspx")

                Else
                    Session("rdSpecialty") = ""
                    Response.Redirect("employeemain.aspx")

                End If
            End If

        Else
            lblMessage.Text = str
            lblMessage.Visible = True
            'Catch ex As Exception
            'End Try
        End If
    End Sub

    Private Sub SaveRecords()

        Dim con As New DBTaskBO
        Dim Query As String = "INSERT INTO boEmployee(empID,empLoginID,depID,comID,etpID,empPassword,empFirstName,empLastName,empGender,empPhone,empCell,empEmail,empAddress1,empAddress2,empPrefix,empJoiningDate,empCity,empState,empCountry,empZip,empNIC,empDOB,empDesignation) Values('" & Me.htxtempID.Value.ToString & "', '" & Me.txtempLoginID.Text & "','" & Me.cmbDepartment.SelectedValue & "','" & Me.cmbcom.SelectedValue & "','" & Me.cmbempType.SelectedValue & "','" & Me.txtempPassword.Text.ToString & "','" & Me.txtempFirstName.Text.ToString & "','" & Me.txtempLastName.Text.ToString & "','" & Me.cmbempGender.Text & "', '" & Me.txtempPhoneNo.Text.ToString & "', '" & Me.txtempCellNo.Text.ToString & "', '" & Me.txtempEMail.Text & "', '" & Me.txtempAddress.Text.ToString & "', '" & Me.txtempAddress2.Text.ToString & "', '" & Me.cmbempPrefix.Text.ToString & "', '" & Format(Me.CPempJoiningDate.SelectedDate, "MM/dd/yyyy") & "', '" & Me.txtempCity.Text.ToString & "', '" & Me.txtempState.Text.ToString & "', '" & Me.cmbempCountry.Text.ToString & "', '" & Me.txtempZip.Text.ToString & "', '" & Me.txtempNIC.Text.ToString & "', '" & Format(Me.CPDOB.SelectedDate, "MM/dd/yyyy") & "', '" & Me.txtempDesignation.Text.ToString & "')"
        con.saveData(Query)

    End Sub

    Private Function ReturnchkValue(ByVal ctr As Object) As Integer
        If ctr.Checked = True Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Session("rdSpecialty") = "specialty.aspx" Then
            Session("PR") = ""
            Response.Redirect("client.aspx")
            Session("rdSpecialty") = ""
        ElseIf Session("rdClientUpdate") = "ClientUpdate" Then
            Response.Redirect("clientupdate.aspx")
            Session("rdClientUpdate") = ""
        Else
            Response.Redirect("employeemain.aspx")
            Session("rdSpecialty") = ""
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)

        If Not Page.IsPostBack Then
            loadCompany()
            loadDepartment()
            loadEmployeeType()
        End If

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

        Me.cmbDepartment.Items.Insert(0, "Select Department")
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

        Me.cmbcom.Items.Insert(0, "Select Company")
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

        Me.cmbempType.Items.Insert(0, "Select Emplyee Type")
    End Sub
End Class

