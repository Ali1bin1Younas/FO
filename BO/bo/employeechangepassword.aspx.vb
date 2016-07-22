Imports MTBMS.DAL
Partial Class changepassword
    Inherits System.Web.UI.Page

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Not Request.QueryString("empId") = String.Empty Then
            Dim obj As New DBTaskBO
            obj.update("Update boEmployee Set empPassword= '" & Me.txtNewPassword.Text & "' Where empId='" & Request.QueryString("empId") & "'")
        End If
        Response.Redirect("~/bo/employeemain.aspx")
    End Sub
End Class
