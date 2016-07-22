Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL

Partial Class company
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

        'Try

        If Me.txtcomName.Text <> "" And Me.cmbcomEnable.Text <> "" Then

            Call SaveRecords()
            If Session("rdSpecialty") = "specialty.aspx" Then
                Session("PR") = Me.txtcomName.Text
                Session("rdSpecialty") = ""
                Response.Redirect("client.aspx")

            ElseIf Session("rdClientUpdate") = "ClientUpdate" Then
                Session("rdClientUpdate") = ""
                Session("PRU") = Me.txtcomName.Text
                Response.Redirect("clientupdate.aspx")

            Else
                Session("rdSpecialty") = ""
                Response.Redirect("companymain.aspx")

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
        Dim Query As String = "INSERT INTO boCompany(comName,comEnable) Values('" & Me.txtcomName.Text & "','" & Me.cmbcomEnable.SelectedValue & "')"
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
            Response.Redirect("companymain.aspx")
            Session("rdSpecialty") = ""
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)

        If Not Page.IsPostBack Then
        End If

    End Sub
End Class

