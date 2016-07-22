Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class bologin
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLogin.Click
        If checkUser(Me.txtboID.Text.ToString, Me.txtboPassword.Text, True) Then
            'Response.Redirect("BO/dailyworkload.aspx")
        Else
            lblMessage.Text = "Invalid user information."
        End If
    End Sub

	Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("u") <> Nothing And Request.QueryString("p") <> Nothing Then
            Dim empLoginID As String = Request.QueryString("u")
            Dim empPassword As String = Request.QueryString("p")

            If checkUser(empLoginID, empPassword, True) Then
                'Response.Redirect("BO/dailyworkload.aspx")
            Else
                lblMessage.Text = "Invalid user information."
            End If
        End If
    End Sub

    Protected Function checkUser(ByVal vsUser As String, ByVal vsPassword As String, ByVal vbAdmin As Boolean) As Boolean

        Dim Query As String
        'Dim dr As SqlDataReader
        Dim ds As DataSet
        Dim Con As New DBTaskBO


        Query = "Select * From boEmployee where empLoginID ='" _
                & vsUser & "' AND empPassword COLLATE Latin1_General_BIN = '" + vsPassword + "' " _
                & " AND empEnable = 1"


        ds = Con.getDataSet(Query)

        If ds.Tables(0).Rows.Count > 0 Then
            Session("empID") = ds.Tables(0).Rows(0)("empID")

            Dim page As String = ds.Tables(0).Rows(0)("etpID")
            If page = "ADM" Or page = "SAD" Then
                Response.Redirect("bo/dailyworkload.aspx")
            ElseIf page = "USR" Then
                Response.Redirect("emp/employeeworkload.aspx")
            ElseIf page = "CAD" Then
                Response.Redirect("cmp/cmp-index.html")
            End If
            checkUser = True
        Else
            checkUser = False
        End If

        ds.Dispose()
        ds = Nothing

        Con = Nothing
    End Function

    'Protected Sub btnEmpLogin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEmpLogin.Click
    '    If checkUser(Me.txtUserID.Text.ToString, Me.txtPassword.Text.ToString, False) Then
    '        Session("empID") = Me.txtUserID.Text.ToString.Trim
    '        Response.Redirect("EMP/employeemain.aspx")
    '    Else
    '        Me.lblMsgClientLogin.Text = "Invalid user information."
    '    End If
    'End Sub

    'Protected Sub txtPassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
    '    If Me.txtPassword.Text = String.Empty Then Exit Sub
    '    btnEmpLogin_Click(Nothing, Nothing)
    '    'If Asc(Me.txtPassword.Text.Substring(Me.txtPassword.Text.Length - 1)) = 13 Then
    '    '    lblMessage.Text = "ok"
    '    'End If
    'End Sub
End Class
