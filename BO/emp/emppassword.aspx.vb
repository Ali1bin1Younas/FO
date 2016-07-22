Imports MTBMS.BLL
Imports MTBMS.DAL
Imports System.Data
Imports System.Data.SqlClient

Partial Class frontofficepassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblCompleteName.Text = Session("CompletePrefix") + "  " + Session("CompleteFirstNAme") + "   " + Session("CompleteLastName")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        checkOldPassword()
    End Sub

    Private Sub checkOldPassword()
        Dim str As String
        str = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
                + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; text-align:left; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                + "<td align=center width=80><img src='../images/error.ico'></td><td align=left width=370><font style='font-size:8pt;'>Invalid old password.</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr><tr><td height=15></td></tr></table>"

        'Try

        If Me.txtOldPassword.Text <> "" And Me.txtNewPassword.Text <> "" And Me.txtConfirmPassword.Text <> "" Then
            Dim Con As New DBTaskBO

            Dim Query As String = "Select empPassword From boEmployee where  empID='" + Session("empID").ToString + "' "
            'Dim dr As SqlDataReader
            'dr = Con.getDataReader(Query)
            Dim ds As DataSet
            ds = Con.getDataSet(Query)

            'If dr.Read Then
            If ds.Tables(0).Rows.Count > 0 Then
                If Me.txtOldPassword.Text = ds.Tables(0).Rows(0).Item(0) Then 'dr("empPassword") Then
                    If Me.txtNewPassword.Text = Me.txtConfirmPassword.Text And Me.txtNewPassword.Text <> "" Then

                        Dim strSetPassword As String = "Update boEmployee Set empPassword ='" + txtNewPassword.Text.ToString + "' where empID= '" + Session("empID") + "'"
                        Con.saveData(strSetPassword)
                        Session("confirmationMessage") = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
                                    + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; text-align:left; color:#343434; letter-spacing:0.9px;'><strong>Congratulation &nbsp;</strong></font></legend>" _
                                    + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                                    + "<td align=center width=80><img src='../images/info.ico'></td><td align=left width=370><font style='font-size:8pt;'>The password has been changed.</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr></table>"
                        'Session("confirmationMessage") = "You can use your new password whenever you sign in at site "
                        Response.Redirect("confirmation.aspx")

                    Else
                        lblMessage.Text = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
                + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; text-align:left; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                + "<td align=center width=80><img src='../images/error.ico'></td><td align=left width=370><font style='font-size:8pt;'>Invalid new password.</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr><tr><td height=15></td></tr></table>"
                    End If
                Else
                    lblMessage.Text = str
                End If
            End If

            ds.Dispose()
            ds = Nothing

            Con.objConnection.Close()
            Con = Nothing
        Else
            lblMessage.Text = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
                + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; text-align:left; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                + "<td align=center width=80><img src='../images/error.ico'></td><td align=left width=370><font style='font-size:8pt;'>Fields can not be empty.</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr><tr><td height=15></td></tr></table>"
        End If
        'Catch ex As Exception
        '    lblMessage.Text = str
        'End Try
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("employeeworkload.aspx")
    End Sub
End Class
