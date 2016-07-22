Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class bologin
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLogin.Click
        If checkUser(Me.txtboID.Text.ToString, Me.txtboPassword.Text, True) Then
            Session("empID") = Me.txtboID.Text.ToString.Trim
            Response.Redirect("BO/dailyworkload.aspx")
        Else
            lblMessage.Text = "Invalid user information."
        End If
    End Sub

    Protected Function checkUser(ByVal vsUser As String, ByVal vsPassword As String, ByVal vbAdmin As Boolean) As Boolean
        Dim Query As String
        'Dim dr As SqlDataReader
        Dim ds As DataSet
        Dim Con As New DBTaskBO

        If vbAdmin Then
            Query = "Select * From boEmployee " _
                    & "INNER JOIN boEmployeeRoles ON boEmployee.empID = boEmployeeRoles.empID " _
                    & "WHERE boEmployee.empID ='" & vsUser & "' " _
                    & "AND empPassword = '" + vsPassword + "' " _
                    & "AND rolID = 'AD' AND boEmployee.empEnable = 1  AND boEmployeeRoles.empEnable = 1"
        Else
            Query = "Select * From boEmployee where empID ='" _
                    & vsUser & "' AND empPassword = '" + vsPassword + "' " _
                    & " AND empEnable = 1"
        End If

        ds = Con.getDataSet(Query)

        If ds.Tables(0).Rows.Count > 0 Then
            checkUser = True
        Else
            checkUser = False
        End If

        ds.Dispose()
        ds = Nothing

        Con = Nothing
    End Function

    Protected Sub btnEmpLogin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEmpLogin.Click
        If checkUser(Me.txtUserID.Text.ToString, Me.txtPassword.Text.ToString, False) Then
            Session("empID") = Me.txtUserID.Text.ToString.Trim
            Response.Redirect("EMP/employeemain.aspx")
        Else
            Me.lblMsgClientLogin.Text = "Invalid user information."
        End If
    End Sub

    Protected Sub txtPassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        If Me.txtPassword.Text = String.Empty Then Exit Sub
        btnEmpLogin_Click(Nothing, Nothing)
        'If Asc(Me.txtPassword.Text.Substring(Me.txtPassword.Text.Length - 1)) = 13 Then
        '    lblMessage.Text = "ok"
        'End If
    End Sub
End Class
