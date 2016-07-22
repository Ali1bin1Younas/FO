Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL

Partial Class companyupdate
    Inherits System.Web.UI.Page
    Dim intCheckValue As Integer
    Dim strHospitalName As String

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Try
        Dim str As String = ""
        If Me.txtcomID.Text <> "" And Me.txtcomName.Text <> "" And Me.cmbcomEnable.Text <> "" Then

            str = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
                    + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                    + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                    + "<td align=center width=80><img src='../images/error.ico'></td><td align=left width=370><font style='font-size:8pt;'>Please fill all mandatory fields (*).</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr>" _
                    + "<tr><td height=15></td></tr></table>"


            Call SaveRecords()
            Response.Redirect("companymain.aspx")

        Else
            lblMessage.Text = str
        End If


        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub SaveRecords()

        Dim con As New DBTaskBO
        Dim Query As String = "UPDATE boCompany SET comName='" & Me.txtcomName.Text & "',comEnable='" & Me.cmbcomEnable.SelectedValue & "' where comID=' " & Session("ssempID") & " ' "
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
        Response.Redirect("companymain.aspx")
    End Sub

    Private Sub setCompany()
        Dim Con As New DBTaskBO

        Dim Query As String = "Select * From boCompany where comID='" + Session("ssempID") + "'"
        Dim ds As DataSet
        ds = Con.getDataSet(Query)

        If ds.Tables(0).Rows.Count > 0 Then
            Me.txtcomID.Text = ds.Tables(0).Rows(0)("comID")
            Me.txtcomName.Text = ds.Tables(0).Rows(0)("comName")
            Me.cmbcomEnable.Text = ds.Tables(0).Rows(0)("comEnable")

        End If
        ds.Dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        Try
            Session("ssempID") = Request.QueryString("comID").ToString
            If Not Page.IsPostBack Then
                Session("ssempID") = Request.QueryString("comID").ToString

                setCompany()
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class

